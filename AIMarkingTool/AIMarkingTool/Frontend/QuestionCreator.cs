using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace AIMarkingTool
{
    public partial class frmQuestionCreator : Form
    {
        public frmQuestionCreator()
        {
            InitializeComponent();

            //building the Data Grid View for the Criteria Generation
            dgvCriteria.Columns.Add("colName", "Criteria");
            dgvCriteria.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvCriteria.AllowUserToDeleteRows = true;

            dgvCriteria.Columns.Add("colMarksAvailable", "Marks");
            DataGridViewColumn column = dgvCriteria.Columns[1];
            column.Width = 60;
        }

        //Checks if all relevant inputs have been filled out properly by the user. This function is called before saving the JSON file
        private bool checkIfAllInputsAreValid()
        {
            bool allInputsAreValid = true;

            if (string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                MessageBox.Show("Please make sure that a Question is provided.");
                allInputsAreValid = false;
            }
            else
            {
                if (dgvCriteria.RowCount < 2)
                {
                    allInputsAreValid = false;
                    MessageBox.Show("Cannot submit a file without any criteria assigned!");
                }
                else
                {
                    for (int i = 0; i < dgvCriteria.RowCount - 1; i++)
                    {
                        DataGridViewRow row = dgvCriteria.Rows[i];
                        int n;

                        if (row.Cells[0].Value == null)
                        {
                            allInputsAreValid = false;
                            MessageBox.Show("Please make sure that the criteria at row: " + row.Index + " is not empty (or remove excess marks).");
                            break;
                        }
                        if (row.Cells[1].Value == null)
                        {
                            allInputsAreValid = false;
                            MessageBox.Show("Please make sure that the criteria at row: " + row.Index + " has a mark assigned.");
                            break;
                        }
                        else if (!int.TryParse(row.Cells[1].Value.ToString(), out n))
                        {
                            allInputsAreValid = false;
                            MessageBox.Show("Please make sure that the mark at row: " + row.Index + " is a positive integer");
                            break;
                        }
                    }
                }
            }
            return allInputsAreValid;
        }

        //Generates a JSON file based on the user input (which are validated previously) and saves it to a JSON file through a File Dialog
        private void onSubmitClick(object sender, EventArgs e)
        {
            if (checkIfAllInputsAreValid())
            {
                //create a Json object
                Examination examination = new Examination();
                int overallMarksAvailable = 0;
                //loop through all the available rows in the data grid view
                for (int i = 0; i < dgvCriteria.RowCount - 1; i++)
                {
                    //initiate a new criteria object and add to the list in the examination object
                    examination.criteria.Add(new Criteria());

                    //access the value from the given row and assing as a fact in criteria
                    examination.criteria[i].fact = dgvCriteria.Rows[i].Cells[0].Value.ToString();

                    //access the value from the given row and assing as a mark available
                    int mark;
                    if (int.TryParse(dgvCriteria.Rows[i].Cells[1].Value.ToString(), out mark))
                    {
                        examination.criteria[i].marksAvailable = mark;
                        overallMarksAvailable += mark;
                    }
                }

                examination.overallMarksAvailable = overallMarksAvailable;

                //reads in the quesiton and pass it to Json object
                examination.question = txtQuestion.Text;

                saveFileDialog.InitialDirectory = @"C:\Desktop";
                saveFileDialog.Filter = "Json files (*.json) | *.json;";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //writes the content to the file
                    File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(examination));
                    goBack();
                }
            }
        }

        //Prompts the user to confirm leaving the current form. Calls the goBack() method which closes the current form and opens the home screen.
        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to go back without saving?", "Go back", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                goBack();
            }
        }

        //Closes the current Form and open the home screen.
        private void goBack()
        {
            this.Hide();
            frmLoginScreen login = new frmLoginScreen();
            login.ShowDialog();
            this.Close();
        }
    }
}
