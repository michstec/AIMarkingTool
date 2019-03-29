namespace AIMarkingTool
{
    partial class frmLoginScreen
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
            this.btnQuestion = new System.Windows.Forms.Button();
            this.btnResults = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnQuestion
            // 
            this.btnQuestion.Location = new System.Drawing.Point(111, 62);
            this.btnQuestion.Name = "btnQuestion";
            this.btnQuestion.Size = new System.Drawing.Size(194, 69);
            this.btnQuestion.TabIndex = 0;
            this.btnQuestion.Text = "Create New Question";
            this.btnQuestion.UseVisualStyleBackColor = true;
            this.btnQuestion.Click += new System.EventHandler(this.btnQuestion_Click);
            // 
            // btnResults
            // 
            this.btnResults.Location = new System.Drawing.Point(111, 158);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(194, 69);
            this.btnResults.TabIndex = 1;
            this.btnResults.Text = "Display Results";
            this.btnResults.UseVisualStyleBackColor = true;
            this.btnResults.Click += new System.EventHandler(this.btnResults_Click);
            // 
            // frmLoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 296);
            this.Controls.Add(this.btnResults);
            this.Controls.Add(this.btnQuestion);
            this.Name = "frmLoginScreen";
            this.Text = "AI Marking Tool";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQuestion;
        private System.Windows.Forms.Button btnResults;
    }
}

