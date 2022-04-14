namespace QCash
{
    partial class frmResetDatabase
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
            this.btnResetDatabase = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnResetDatabase
            // 
            this.btnResetDatabase.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnResetDatabase.Location = new System.Drawing.Point(0, 0);
            this.btnResetDatabase.Name = "btnResetDatabase";
            this.btnResetDatabase.Size = new System.Drawing.Size(542, 36);
            this.btnResetDatabase.TabIndex = 0;
            this.btnResetDatabase.Text = "Reset Now";
            this.btnResetDatabase.UseVisualStyleBackColor = true;
            this.btnResetDatabase.Click += new System.EventHandler(this.btnResetDatabase_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.Black;
            this.txtStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStatus.ForeColor = System.Drawing.Color.Lime;
            this.txtStatus.Location = new System.Drawing.Point(0, 36);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(542, 283);
            this.txtStatus.TabIndex = 1;
            // 
            // frmResetDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 319);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnResetDatabase);
            this.Name = "frmResetDatabase";
            this.Text = "Reset Database";
            this.Load += new System.EventHandler(this.frmResetDatabase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnResetDatabase;
        private System.Windows.Forms.TextBox txtStatus;
    }
}