namespace QCash.CommonForms
{
    partial class frmMsReportViewer
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
            this.MsReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // MsReportViewer
            // 
            this.MsReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MsReportViewer.Location = new System.Drawing.Point(0, 0);
            this.MsReportViewer.Name = "MsReportViewer";
            this.MsReportViewer.Size = new System.Drawing.Size(896, 451);
            this.MsReportViewer.TabIndex = 0;
            // 
            // frmMsReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 451);
            this.Controls.Add(this.MsReportViewer);
            this.Name = "frmMsReportViewer";
            this.Text = "frmMsReportViewer";
            this.Load += new System.EventHandler(this.frmMsReportViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer MsReportViewer;




    }
}