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
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        //Opens the question generation form
        private void btnQuestion_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQuestionCreator creator = new frmQuestionCreator();
            creator.ShowDialog();
            this.Close();
        }

        //Opens the results viewer form
        private void btnResults_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmResultsViewer results = new frmResultsViewer();
            results.ShowDialog();
            this.Close();
        }
    }
}
