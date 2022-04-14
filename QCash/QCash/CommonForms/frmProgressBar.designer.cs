namespace QCash.CommonForms
{
    partial class frmProgressBar
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
            this.lblWaitMessage = new System.Windows.Forms.Label();
            this.pbMyProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblWaitMessage
            // 
            this.lblWaitMessage.BackColor = System.Drawing.Color.White;
            this.lblWaitMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaitMessage.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblWaitMessage.Location = new System.Drawing.Point(3, 3);
            this.lblWaitMessage.Name = "lblWaitMessage";
            this.lblWaitMessage.Size = new System.Drawing.Size(400, 19);
            this.lblWaitMessage.TabIndex = 7;
            this.lblWaitMessage.Text = "Wait..";
            this.lblWaitMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbMyProgressBar
            // 
            this.pbMyProgressBar.BackColor = System.Drawing.SystemColors.Control;
            this.pbMyProgressBar.ForeColor = System.Drawing.Color.SlateGray;
            this.pbMyProgressBar.Location = new System.Drawing.Point(3, 19);
            this.pbMyProgressBar.MarqueeAnimationSpeed = 15;
            this.pbMyProgressBar.Name = "pbMyProgressBar";
            this.pbMyProgressBar.Size = new System.Drawing.Size(403, 21);
            this.pbMyProgressBar.Step = 7;
            this.pbMyProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbMyProgressBar.TabIndex = 6;
            // 
            // frmProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 49);
            this.Controls.Add(this.lblWaitMessage);
            this.Controls.Add(this.pbMyProgressBar);
            this.Name = "frmProgressBar";
            this.Text = "frmProgressBar";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblWaitMessage;
        internal System.Windows.Forms.ProgressBar pbMyProgressBar;

    }
}