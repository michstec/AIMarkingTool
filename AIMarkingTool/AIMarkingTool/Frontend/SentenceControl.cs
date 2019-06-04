using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIMarkingTool
{
    public partial class frmSentenceControl : Form
    {
        private Sentence sentence;
        private List<Criteria> criteria = new List<Criteria>();

        //Populates the data using 
        public frmSentenceControl(Sentence sent, List<Criteria> cr)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;

            txtSentence.Text = sent.text;

            DataGridViewTextBoxColumn tb = new DataGridViewTextBoxColumn();
            DataGridViewCheckBoxColumn cb = new DataGridViewCheckBoxColumn();
            tb.ReadOnly = true;
            dgvCriteriaAvailable.RowHeadersVisible = false;

            dgvCriteriaAvailable.Columns.Add(tb);
            dgvCriteriaAvailable.Columns[0].HeaderText = "Criteria";
            dgvCriteriaAvailable.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvCriteriaAvailable.Columns.Add(cb);
            dgvCriteriaAvailable.Columns[1].HeaderText = "Matched";
            dgvCriteriaAvailable.Columns[1].Width = 58;

            foreach (Criteria fact in cr)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvCriteriaAvailable);
                row.Cells[0].Value = fact.fact;
                row.Cells[1].Value = false;
                dgvCriteriaAvailable.Rows.Add(row);
            }

            if (sent.matched)
            {
                foreach (int criteriaIndex in sent.matchedCriteriaIndex)
                    dgvCriteriaAvailable.Rows[criteriaIndex].Cells[1].Value = true;
            }

            this.sentence = sent;
            this.criteria = cr;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSentence.Text))
                MessageBox.Show("The sentence cannot be empty.");
            else
            {
                this.sentence.text = txtSentence.Text;
                this.sentence.matchedCriteriaIndex.Clear();
                for (int i = 0; i < dgvCriteriaAvailable.RowCount; i++)
                {
                    bool isChecked = Convert.ToBoolean(dgvCriteriaAvailable.Rows[i].Cells[1].Value);
                    if (isChecked)
                        this.sentence.matchedCriteriaIndex.Add(i);
                }
                if (!this.sentence.matchedCriteriaIndex.Any())
                    this.sentence.matched = false;
                else this.sentence.matched = true;
                this.Hide();
                this.Close();
            }
        }

        //Closes the current form
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
