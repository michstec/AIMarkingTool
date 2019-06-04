using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AIMarkingTool
{
    public partial class frmResultsViewer : Form
    {
        //Stores the sentence-criteria matches produced by the backend for reference
        List<Sentence> sentences;
        Examination examinationData { get; set; }

        public frmResultsViewer()
        {
            InitializeComponent();

            //building the Data Grid View for the Criteria display
            dgvCriteriaResults.Columns.Add("colName", "Criteria");
            dgvCriteriaResults.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCriteriaResults.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvCriteriaResults.RowHeadersWidth = 50;

            dgvCriteriaResults.Columns.Add("colMarksAvailable", "Marks");
            dgvCriteriaResults.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            DataGridViewColumn column = dgvCriteriaResults.Columns[1];
            column.Width = 50;
        }

        //Adds the selected Question json file deserializes it and passes to a function which populates the relevant data (populateQuestionData)
        private void btnAddQuestionFile_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = @"C:\Desktop";
            openFileDialog.Filter = "Json files (*.json) | *.json;";
            openFileDialog.Title = "Choose a question file.";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                txtQuestionFile.Text = fileName;

                using (StreamReader r = new StreamReader(fileName))
                {
                    string json = r.ReadToEnd();
                    examinationData = JsonConvert.DeserializeObject<Examination>(json);
                    populateQuestionData(examinationData);
                }
            }
        }

        //Populates the Question related field (question, criteria, marks available) from the deserialized JSON
        private void populateQuestionData(Examination ex)
        {
            txtQuestion.Text = ex.question;
            trbMarks.Maximum = ex.overallMarksAvailable;
            lblMaxGrades.Text = ex.overallMarksAvailable.ToString();

            dgvCriteriaResults.Rows.Clear();
            dgvCriteriaResults.Refresh();

            foreach (Criteria cr in ex.criteria)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvCriteriaResults);
                row.Cells[0].Value = cr.fact;
                row.Cells[1].Value = cr.marksAvailable;
                dgvCriteriaResults.Rows.Add(row);
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }

        }

        //Adds the selected answer files into the list of available answers to mark
        private void btnAddAnswerFiles_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = @"C:\Desktop";
            openFileDialog.Filter = "Text files (*.txt) | *.txt;";
            openFileDialog.Title = "Choose answer files.";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    lstAnswerFiles.Items.Add(fileName);
                }
            }
        }

        //Removes the selected answer file from the list of answers
        private void btnRemoveAnswerFile_Click(object sender, EventArgs e)
        {
            if (lstAnswerFiles.SelectedItem != null)//makes sure that an item was selected
            {
                lstAnswerFiles.Items.RemoveAt(lstAnswerFiles.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Select list entry first.");
            }
        }

        //Executes the python script that uses NLP to find semantic similarity between sentences and returns the results
        //This funtcion has an internal call to another function which populates the Answer from the results provided by the script
        private void btnMarkSelected_Click(object sender, EventArgs e)
        {
            this.sentences = new List<Sentence>();
            if (String.IsNullOrEmpty(txtQuestionFile.Text) || lstAnswerFiles.SelectedIndex == -1)
            {
                MessageBox.Show("Please upload a Question File and/or upload and select an Answer File.");
            }
            else
            {
                btnMarkSelected.Enabled = false;
                List<string> results = runSemanticSimilarityScriptAndReturnResults();

                if (results != null && results.Any())
                {
                    parseResultsAndPopulateSentenceList(results);
                    displayAnswerResults();

                    btnMarkSelected.Enabled = true;
                }
            }
        }

        //Runs the backend python script that determines the similarity between the answer and the criteria, returns tokenized sentences and the matches that were found
        private List<string> runSemanticSimilarityScriptAndReturnResults()
        {
            //Getting the PATH Variable for Python Compiler
            string keyName = @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment\";
            string existingPathVariable = (string)Registry.LocalMachine.OpenSubKey(keyName).GetValue("PATH", "", RegistryValueOptions.DoNotExpandEnvironmentNames);
            if (existingPathVariable[0].Equals(';')) existingPathVariable = existingPathVariable.Remove(0, 1); //clears the first semicolon in case there is more than one item in the PATH

            string[] paths = existingPathVariable.Split(';'); 
            int indexOfSemiColon = existingPathVariable.IndexOf(';');
            if (indexOfSemiColon != -1) existingPathVariable = existingPathVariable.Substring(0, indexOfSemiColon);
            existingPathVariable += @"\python.exe";

            //Creating new Process Info to run the script
            var psi = new ProcessStartInfo();
            psi.FileName = existingPathVariable;

            //Getting the Backend Script file path from the project folder
            var script = @"Backend\MarkingTool.py";

            //Getting the Examination and Answer Files from the GUI components
            var examinationFile = txtQuestionFile.Text;
            int index = lstAnswerFiles.SelectedIndex;
            var answerFile = lstAnswerFiles.Items[index].ToString();

            //Passing the script name and file paths as arguments for the process to execute the Backend Script
            psi.Arguments = $"\"{script}\" \"{examinationFile}\" \"{answerFile}\"";

            //Process configuration
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            //Executing process and get output
            string errors = "";
            List<string> results = new List<string>();

            using (var process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                do results.Add(process.StandardOutput.ReadLine());
                while (!process.StandardOutput.EndOfStream);
            }

            //If there were any errors in the execution, they are printed to the user
            if (errors != "") MessageBox.Show("Errors: " + errors);
            return results;
        }

        //Parses the result provided by the backend script and populates the Answer with approperiate sentnces as well as decodes the sentence-criteria similarity matrix
        private void parseResultsAndPopulateSentenceList(List<string> results)
        {
            //used to decode the results, marks the start and end of the "sentence" part
            string sentenceBeginMarker = "<s>";
            string sentenceEndMarker = "<!s>";

            //used to decode the results, marks the start and end of the "similariy matrix" part
            string matrixBeginMarker = "<m>";
            string matrixEndMarker = "<!m>";

            int i = 0;

            //parsing the sentences that were returned by the backend and passing to a function which populate the form dispialyign the sentences
            if (results[i].Equals(sentenceBeginMarker))
            {
                i++; //skips the <s> element
                while (!results[i].Equals(sentenceEndMarker) && i < results.Count)
                {
                    //for each sentence found in the results creates a new object of type Sentence, assignes its text value and adds to the list
                    Sentence s = new Sentence();
                    s.text = results[i];
                    this.sentences.Add(s);
                    i++;
                }
                i++; //moves on from the sentence closing statement <!s> for the next check
            }

            //parsing the sentence-criteria matches that were returned by the backend and passing to a function which populate the form dispialyign the sentences
            if (results[i].Equals(matrixBeginMarker))
            {
                i++; //skips the <m> element
                while (!results[i].Equals(matrixEndMarker) && i < results.Count)
                {
                    //for each match found in the match matrix accesses the matched sentence object by the indedx and assigns its match value to the criteria index that was matched with
                    string[] matchAsString = results[i].Split(',');
                    int matchedSentenceIndex;
                    int matchedCriteriaIndex;

                    int.TryParse(matchAsString[0], out matchedSentenceIndex);
                    int.TryParse(matchAsString[1], out matchedCriteriaIndex);

                    this.sentences[matchedSentenceIndex].matched = true;
                    this.sentences[matchedSentenceIndex].matchedCriteriaIndex.Add(matchedCriteriaIndex);
                    
                    i++;
                }
            }
        }

        //Goes through the current Sentence List values and displays their text, and highlights matched sentences, calculates the current grade based on the matches
        private void displayAnswerResults()
        {
            clearFlowLayoutForRepopulation();
            int currentGrade = 0;
            List<int> criteriaIncludedInMark = new List<int>();
            foreach (Sentence sent in this.sentences)
            {
                //displays the sentences in the Answer box as clickable labels
                LinkLabel newLabel = new LinkLabel();
                newLabel.Text = sent.text;
                setLabelSettings(newLabel);

                if (sent.matched)
                {
                    newLabel.BackColor = Color.FromArgb(173, 255, 47);
                    string toolTipMatchesOutput = "Matched with criteria number: ";

                    foreach (int index in sent.matchedCriteriaIndex)
                    {
                        toolTipMatchesOutput += (index + 1) + ". ";

                        if (!criteriaIncludedInMark.Contains(index))  //checks if the current criteria that was match is already included in the current grade
                        {
                            currentGrade += this.examinationData.criteria[index].marksAvailable; //if not adds the mark available of that criteria to the current grade
                            criteriaIncludedInMark.Add(index); //and pushes the current index to the set
                        }
                    }
                    ttMatches.SetToolTip(newLabel, toolTipMatchesOutput);
                }
                else
                {
                    ttMatches.SetToolTip(newLabel, "No matches");
                    newLabel.BackColor = Color.White;
                }

                flpSentncesBox.Controls.Add(newLabel);
                trbMarks.Value = currentGrade;
                lblCurrentGrade.Text = currentGrade.ToString() + " out of " + examinationData.overallMarksAvailable;
            }
        }

        //Clear Flow Layout Pattern containing the sentences before populating it with new set
        public void clearFlowLayoutForRepopulation()
        {
            List<Control> listControls = flpSentncesBox.Controls.Cast<Control>().ToList();
            foreach (Control control in listControls)
            {
                flpSentncesBox.Controls.Remove(control);
                flpSentncesBox.Controls.Clear();
                control.Dispose();
            }
        }

        //Sets the settings of the dynamically created labels that represent sentces from the answer
        public void setLabelSettings(LinkLabel ll)
        {
            ll.LinkColor = Color.FromArgb(0, 0, 0);
            ll.Font = new Font("Arial", 12, FontStyle.Regular);
            ll.Margin = new Padding(1);
            ll.AutoSize = true;
            ll.DoubleClick += new EventHandler(sentenceLabel_DoubleClick);
            ll.Click += new EventHandler(sentenceLabel_Click);
            ll.LinkBehavior = LinkBehavior.NeverUnderline;
        }

        //Opens a new form that allows to manipulate the clicked sentence's text and criteria it has matched
        public void sentenceLabel_DoubleClick(object sender, EventArgs e)
        {
            int clickedSentenceIndex = flpSentncesBox.Controls.GetChildIndex((sender as LinkLabel));
            frmSentenceControl sc = new frmSentenceControl(this.sentences[clickedSentenceIndex], this.examinationData.criteria);
            sc.ShowDialog();
            displayAnswerResults();
        }

        //Highlights the criteria that was matched with the clicked sentence
        private void sentenceLabel_Click(object sender, EventArgs e)
        {
            int clickedSentenceIndex = flpSentncesBox.Controls.GetChildIndex((sender as LinkLabel));

            for (int i = 0; i < dgvCriteriaResults.Rows.Count; i++)
            {
                dgvCriteriaResults.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }

            foreach (int match in this.sentences[clickedSentenceIndex].matchedCriteriaIndex)
                dgvCriteriaResults.Rows[match].DefaultCellStyle.BackColor = Color.FromArgb(173, 255, 47);
        }

        //Goes to the previous form (Login)
        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to go back without saving?", "Go back", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();
                frmLoginScreen login = new frmLoginScreen();
                login.ShowDialog();
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
        }
    }
}
