namespace AIMarkingTool
{
    partial class frmQuestionCreator
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
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblCriteria = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dgvCriteria = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriteria)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQuestion
            // 
            this.txtQuestion.AcceptsTab = true;
            this.txtQuestion.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtQuestion.Location = new System.Drawing.Point(12, 40);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(762, 66);
            this.txtQuestion.TabIndex = 0;
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(9, 24);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(137, 13);
            this.lblQuestion.TabIndex = 1;
            this.lblQuestion.Text = "Step 1. Type your question.";
            // 
            // lblCriteria
            // 
            this.lblCriteria.AutoSize = true;
            this.lblCriteria.Location = new System.Drawing.Point(9, 146);
            this.lblCriteria.Name = "lblCriteria";
            this.lblCriteria.Size = new System.Drawing.Size(171, 13);
            this.lblCriteria.TabIndex = 2;
            this.lblCriteria.Text = "Step 2. Specify criteria for marking.";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(635, 511);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(139, 44);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.onSubmitClick);
            // 
            // dgvCriteria
            // 
            this.dgvCriteria.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCriteria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCriteria.GridColor = System.Drawing.Color.Black;
            this.dgvCriteria.Location = new System.Drawing.Point(13, 163);
            this.dgvCriteria.Name = "dgvCriteria";
            this.dgvCriteria.Size = new System.Drawing.Size(761, 262);
            this.dgvCriteria.TabIndex = 4;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 516);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(139, 44);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.CheckPathExists = false;
            this.saveFileDialog.CreatePrompt = true;
            this.saveFileDialog.DefaultExt = "json";
            this.saveFileDialog.FilterIndex = 2;
            this.saveFileDialog.Title = "Save as a Json File";
            // 
            // frmQuestionCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 572);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvCriteria);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblCriteria);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.txtQuestion);
            this.Name = "frmQuestionCreator";
            this.Text = "Create Question";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriteria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label lblCriteria;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView dgvCriteria;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}