namespace AIMarkingTool
{
    partial class frmResultsViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.flpSentncesBox = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtQuestionFile = new System.Windows.Forms.TextBox();
            this.btnAddQuestionFile = new System.Windows.Forms.Button();
            this.btnAddQuestionFiles = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.lstAnswerFiles = new System.Windows.Forms.ListBox();
            this.btnRemoveAnswerFile = new System.Windows.Forms.Button();
            this.grbQuestionControls = new System.Windows.Forms.GroupBox();
            this.grbAnswerControls = new System.Windows.Forms.GroupBox();
            this.btnMarkSelected = new System.Windows.Forms.Button();
            this.trbMarks = new System.Windows.Forms.TrackBar();
            this.lblZero = new System.Windows.Forms.Label();
            this.lblMaxGrades = new System.Windows.Forms.Label();
            this.dgvCriteriaResults = new System.Windows.Forms.DataGridView();
            this.lblCriteria = new System.Windows.Forms.Label();
            this.lblGrade = new System.Windows.Forms.Label();
            this.lblCurrentGrade = new System.Windows.Forms.Label();
            this.ttMatches = new System.Windows.Forms.ToolTip(this.components);
            this.grbQuestionControls.SuspendLayout();
            this.grbAnswerControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbMarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriteriaResults)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQuestion
            // 
            this.txtQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtQuestion.Location = new System.Drawing.Point(12, 28);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.ReadOnly = true;
            this.txtQuestion.Size = new System.Drawing.Size(746, 138);
            this.txtQuestion.TabIndex = 1;
            // 
            // flpSentncesBox
            // 
            this.flpSentncesBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flpSentncesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpSentncesBox.Location = new System.Drawing.Point(12, 188);
            this.flpSentncesBox.Name = "flpSentncesBox";
            this.flpSentncesBox.Size = new System.Drawing.Size(745, 333);
            this.flpSentncesBox.TabIndex = 2;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnBack.Location = new System.Drawing.Point(764, 527);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(132, 61);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtQuestionFile
            // 
            this.txtQuestionFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtQuestionFile.Location = new System.Drawing.Point(139, 16);
            this.txtQuestionFile.Multiline = true;
            this.txtQuestionFile.Name = "txtQuestionFile";
            this.txtQuestionFile.ReadOnly = true;
            this.txtQuestionFile.Size = new System.Drawing.Size(482, 32);
            this.txtQuestionFile.TabIndex = 7;
            // 
            // btnAddQuestionFile
            // 
            this.btnAddQuestionFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnAddQuestionFile.Location = new System.Drawing.Point(5, 16);
            this.btnAddQuestionFile.Name = "btnAddQuestionFile";
            this.btnAddQuestionFile.Size = new System.Drawing.Size(127, 32);
            this.btnAddQuestionFile.TabIndex = 8;
            this.btnAddQuestionFile.Text = "Select Question";
            this.btnAddQuestionFile.UseVisualStyleBackColor = true;
            this.btnAddQuestionFile.Click += new System.EventHandler(this.btnAddQuestionFile_Click);
            // 
            // btnAddQuestionFiles
            // 
            this.btnAddQuestionFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnAddQuestionFiles.Location = new System.Drawing.Point(6, 16);
            this.btnAddQuestionFiles.Name = "btnAddQuestionFiles";
            this.btnAddQuestionFiles.Size = new System.Drawing.Size(127, 32);
            this.btnAddQuestionFiles.TabIndex = 9;
            this.btnAddQuestionFiles.Text = "Add Answer";
            this.btnAddQuestionFiles.UseVisualStyleBackColor = true;
            this.btnAddQuestionFiles.Click += new System.EventHandler(this.btnAddAnswerFiles_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "txt";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Choose the question file";
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblQuestion.Location = new System.Drawing.Point(12, 9);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(64, 16);
            this.lblQuestion.TabIndex = 10;
            this.lblQuestion.Text = "Question:";
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblAnswer.Location = new System.Drawing.Point(11, 169);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(55, 16);
            this.lblAnswer.TabIndex = 11;
            this.lblAnswer.Text = "Answer:";
            // 
            // lstAnswerFiles
            // 
            this.lstAnswerFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lstAnswerFiles.FormattingEnabled = true;
            this.lstAnswerFiles.ItemHeight = 15;
            this.lstAnswerFiles.Location = new System.Drawing.Point(137, 16);
            this.lstAnswerFiles.Name = "lstAnswerFiles";
            this.lstAnswerFiles.Size = new System.Drawing.Size(406, 64);
            this.lstAnswerFiles.TabIndex = 12;
            // 
            // btnRemoveAnswerFile
            // 
            this.btnRemoveAnswerFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnRemoveAnswerFile.Location = new System.Drawing.Point(6, 53);
            this.btnRemoveAnswerFile.Name = "btnRemoveAnswerFile";
            this.btnRemoveAnswerFile.Size = new System.Drawing.Size(127, 32);
            this.btnRemoveAnswerFile.TabIndex = 13;
            this.btnRemoveAnswerFile.Text = "Remove Selected";
            this.btnRemoveAnswerFile.UseVisualStyleBackColor = true;
            this.btnRemoveAnswerFile.Click += new System.EventHandler(this.btnRemoveAnswerFile_Click);
            // 
            // grbQuestionControls
            // 
            this.grbQuestionControls.Controls.Add(this.txtQuestionFile);
            this.grbQuestionControls.Controls.Add(this.btnAddQuestionFile);
            this.grbQuestionControls.Location = new System.Drawing.Point(764, 12);
            this.grbQuestionControls.Name = "grbQuestionControls";
            this.grbQuestionControls.Size = new System.Drawing.Size(628, 57);
            this.grbQuestionControls.TabIndex = 15;
            this.grbQuestionControls.TabStop = false;
            this.grbQuestionControls.Text = "Question Controls";
            // 
            // grbAnswerControls
            // 
            this.grbAnswerControls.Controls.Add(this.btnMarkSelected);
            this.grbAnswerControls.Controls.Add(this.lstAnswerFiles);
            this.grbAnswerControls.Controls.Add(this.btnRemoveAnswerFile);
            this.grbAnswerControls.Controls.Add(this.btnAddQuestionFiles);
            this.grbAnswerControls.Location = new System.Drawing.Point(765, 75);
            this.grbAnswerControls.Name = "grbAnswerControls";
            this.grbAnswerControls.Size = new System.Drawing.Size(627, 91);
            this.grbAnswerControls.TabIndex = 16;
            this.grbAnswerControls.TabStop = false;
            this.grbAnswerControls.Text = "Answer Controls";
            // 
            // btnMarkSelected
            // 
            this.btnMarkSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnMarkSelected.Location = new System.Drawing.Point(549, 16);
            this.btnMarkSelected.Name = "btnMarkSelected";
            this.btnMarkSelected.Size = new System.Drawing.Size(72, 69);
            this.btnMarkSelected.TabIndex = 20;
            this.btnMarkSelected.Text = "Mark Selected";
            this.btnMarkSelected.UseVisualStyleBackColor = true;
            this.btnMarkSelected.Click += new System.EventHandler(this.btnMarkSelected_Click);
            // 
            // trbMarks
            // 
            this.trbMarks.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trbMarks.Enabled = false;
            this.trbMarks.Location = new System.Drawing.Point(12, 543);
            this.trbMarks.Name = "trbMarks";
            this.trbMarks.Size = new System.Drawing.Size(746, 45);
            this.trbMarks.TabIndex = 20;
            // 
            // lblZero
            // 
            this.lblZero.AutoSize = true;
            this.lblZero.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblZero.Location = new System.Drawing.Point(18, 564);
            this.lblZero.Name = "lblZero";
            this.lblZero.Size = new System.Drawing.Size(15, 16);
            this.lblZero.TabIndex = 21;
            this.lblZero.Text = "0";
            // 
            // lblMaxGrades
            // 
            this.lblMaxGrades.AutoSize = true;
            this.lblMaxGrades.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblMaxGrades.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblMaxGrades.Location = new System.Drawing.Point(735, 564);
            this.lblMaxGrades.Name = "lblMaxGrades";
            this.lblMaxGrades.Size = new System.Drawing.Size(22, 16);
            this.lblMaxGrades.TabIndex = 22;
            this.lblMaxGrades.Text = "10";
            // 
            // dgvCriteriaResults
            // 
            this.dgvCriteriaResults.AllowUserToAddRows = false;
            this.dgvCriteriaResults.AllowUserToDeleteRows = false;
            this.dgvCriteriaResults.AllowUserToResizeColumns = false;
            this.dgvCriteriaResults.AllowUserToResizeRows = false;
            this.dgvCriteriaResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCriteriaResults.Location = new System.Drawing.Point(765, 188);
            this.dgvCriteriaResults.Name = "dgvCriteriaResults";
            this.dgvCriteriaResults.ReadOnly = true;
            this.dgvCriteriaResults.Size = new System.Drawing.Size(627, 333);
            this.dgvCriteriaResults.TabIndex = 9;
            // 
            // lblCriteria
            // 
            this.lblCriteria.AutoSize = true;
            this.lblCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblCriteria.Location = new System.Drawing.Point(763, 169);
            this.lblCriteria.Name = "lblCriteria";
            this.lblCriteria.Size = new System.Drawing.Size(53, 16);
            this.lblCriteria.TabIndex = 23;
            this.lblCriteria.Text = "Criteria:";
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblGrade.Location = new System.Drawing.Point(9, 524);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(52, 16);
            this.lblGrade.TabIndex = 24;
            this.lblGrade.Text = "Grade: ";
            // 
            // lblCurrentGrade
            // 
            this.lblCurrentGrade.AutoSize = true;
            this.lblCurrentGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblCurrentGrade.Location = new System.Drawing.Point(54, 524);
            this.lblCurrentGrade.Name = "lblCurrentGrade";
            this.lblCurrentGrade.Size = new System.Drawing.Size(15, 16);
            this.lblCurrentGrade.TabIndex = 25;
            this.lblCurrentGrade.Text = "0";
            // 
            // frmResultsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 632);
            this.Controls.Add(this.lblCurrentGrade);
            this.Controls.Add(this.lblGrade);
            this.Controls.Add(this.lblCriteria);
            this.Controls.Add(this.dgvCriteriaResults);
            this.Controls.Add(this.lblMaxGrades);
            this.Controls.Add(this.lblZero);
            this.Controls.Add(this.trbMarks);
            this.Controls.Add(this.grbAnswerControls);
            this.Controls.Add(this.grbQuestionControls);
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.flpSentncesBox);
            this.Controls.Add(this.txtQuestion);
            this.Name = "frmResultsViewer";
            this.Text = "Results";
            this.grbQuestionControls.ResumeLayout(false);
            this.grbQuestionControls.PerformLayout();
            this.grbAnswerControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trbMarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriteriaResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.FlowLayoutPanel flpSentncesBox;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtQuestionFile;
        private System.Windows.Forms.Button btnAddQuestionFile;
        private System.Windows.Forms.Button btnAddQuestionFiles;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.ListBox lstAnswerFiles;
        private System.Windows.Forms.Button btnRemoveAnswerFile;
        private System.Windows.Forms.GroupBox grbQuestionControls;
        private System.Windows.Forms.GroupBox grbAnswerControls;
        private System.Windows.Forms.Button btnMarkSelected;
        private System.Windows.Forms.TrackBar trbMarks;
        private System.Windows.Forms.Label lblZero;
        private System.Windows.Forms.Label lblMaxGrades;
        private System.Windows.Forms.DataGridView dgvCriteriaResults;
        private System.Windows.Forms.Label lblCriteria;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Label lblCurrentGrade;
        private System.Windows.Forms.ToolTip ttMatches;
    }
}