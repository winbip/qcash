namespace sCommonLib.MessageBoxes
{
    partial class SystemExceptionMessageBox
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
            this.lblHeadLine = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMessageBody = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblViewDetails = new System.Windows.Forms.Label();
            this.lblDetailIcon = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblDetailIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeadLine
            // 
            this.lblHeadLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeadLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadLine.ForeColor = System.Drawing.Color.Red;
            this.lblHeadLine.Location = new System.Drawing.Point(0, 0);
            this.lblHeadLine.Name = "lblHeadLine";
            this.lblHeadLine.Size = new System.Drawing.Size(425, 35);
            this.lblHeadLine.TabIndex = 1;
            this.lblHeadLine.Text = "Error !!";
            this.lblHeadLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Lavender;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(425, 1);
            this.label1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.Controls.Add(this.lblMessageBody);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 160);
            this.panel1.TabIndex = 3;
            // 
            // lblMessageBody
            // 
            this.lblMessageBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessageBody.ForeColor = System.Drawing.Color.Lavender;
            this.lblMessageBody.Location = new System.Drawing.Point(108, 0);
            this.lblMessageBody.Name = "lblMessageBody";
            this.lblMessageBody.Size = new System.Drawing.Size(317, 160);
            this.lblMessageBody.TabIndex = 2;
            this.lblMessageBody.Text = "Message Body";
            this.lblMessageBody.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Lavender;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(425, 1);
            this.label2.TabIndex = 4;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(337, 208);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(68, 31);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "&Close";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblViewDetails
            // 
            this.lblViewDetails.AutoSize = true;
            this.lblViewDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblViewDetails.ForeColor = System.Drawing.Color.White;
            this.lblViewDetails.Location = new System.Drawing.Point(31, 215);
            this.lblViewDetails.Name = "lblViewDetails";
            this.lblViewDetails.Size = new System.Drawing.Size(89, 13);
            this.lblViewDetails.TabIndex = 7;
            this.lblViewDetails.Text = "Technical Details";
            this.lblViewDetails.Click += new System.EventHandler(this.lblViewDetails_Click);
            // 
            // lblDetailIcon
            // 
            this.lblDetailIcon.BackColor = System.Drawing.Color.Transparent;
            this.lblDetailIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDetailIcon.Image = global::sCommonLib.Properties.Resources.NextArrowWhitePng16;
            this.lblDetailIcon.Location = new System.Drawing.Point(13, 214);
            this.lblDetailIcon.Name = "lblDetailIcon";
            this.lblDetailIcon.Size = new System.Drawing.Size(16, 16);
            this.lblDetailIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.lblDetailIcon.TabIndex = 6;
            this.lblDetailIcon.TabStop = false;
            this.lblDetailIcon.Click += new System.EventHandler(this.lblDetailIcon_Click);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Image = global::sCommonLib.Properties.Resources.MSGBoxError;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 160);
            this.label3.TabIndex = 1;
            // 
            // SystemExceptionMessageBox
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(425, 249);
            this.ControlBox = false;
            this.Controls.Add(this.lblViewDetails);
            this.Controls.Add(this.lblDetailIcon);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHeadLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemExceptionMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            this.Load += new System.EventHandler(this.SystemExceptionMessageBox_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblDetailIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeadLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMessageBody;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.PictureBox lblDetailIcon;
        private System.Windows.Forms.Label lblViewDetails;
    }
}