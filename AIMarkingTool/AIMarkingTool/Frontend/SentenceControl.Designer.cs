namespace AIMarkingTool
{
    partial class frmSentenceControl
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
            this.btnBack = new System.Windows.Forms.Button();
            this.txtSentence = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.dgvCriteriaAvailable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriteriaAvailable)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnBack.Location = new System.Drawing.Point(12, 232);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(127, 32);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtSentence
            // 
            this.txtSentence.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtSentence.Location = new System.Drawing.Point(13, 13);
            this.txtSentence.Name = "txtSentence";
            this.txtSentence.Size = new System.Drawing.Size(546, 54);
            this.txtSentence.TabIndex = 11;
            this.txtSentence.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnSave.Location = new System.Drawing.Point(432, 232);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 32);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save and Close";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblHint.Location = new System.Drawing.Point(12, 70);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(541, 16);
            this.lblHint.TabIndex = 13;
            this.lblHint.Text = "The system found that this sentence was matched by the criteria below. Change if " +
    "incorrect.";
            // 
            // dgvCriteriaAvailable
            // 
            this.dgvCriteriaAvailable.AllowUserToAddRows = false;
            this.dgvCriteriaAvailable.AllowUserToDeleteRows = false;
            this.dgvCriteriaAvailable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCriteriaAvailable.Location = new System.Drawing.Point(15, 90);
            this.dgvCriteriaAvailable.Name = "dgvCriteriaAvailable";
            this.dgvCriteriaAvailable.Size = new System.Drawing.Size(544, 136);
            this.dgvCriteriaAvailable.TabIndex = 14;
            // 
            // frmSentenceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 271);
            this.Controls.Add(this.dgvCriteriaAvailable);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSentence);
            this.Controls.Add(this.btnBack);
            this.Name = "frmSentenceControl";
            this.Text = "Sentence Controls";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriteriaAvailable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.RichTextBox txtSentence;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.DataGridView dgvCriteriaAvailable;
    }
}