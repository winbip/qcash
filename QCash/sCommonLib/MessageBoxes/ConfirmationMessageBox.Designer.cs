namespace sCommonLib.MessageBoxes
{
    partial class ConfirmationMessageBox
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
            this.lblUpperLine = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblQuestionDetails = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBottomLine = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeadLine
            // 
            this.lblHeadLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeadLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadLine.ForeColor = System.Drawing.Color.Orange;
            this.lblHeadLine.Location = new System.Drawing.Point(0, 0);
            this.lblHeadLine.Name = "lblHeadLine";
            this.lblHeadLine.Size = new System.Drawing.Size(435, 46);
            this.lblHeadLine.TabIndex = 3;
            this.lblHeadLine.Text = "HeadLine";
            this.lblHeadLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUpperLine
            // 
            this.lblUpperLine.BackColor = System.Drawing.Color.Lavender;
            this.lblUpperLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUpperLine.Location = new System.Drawing.Point(0, 46);
            this.lblUpperLine.Name = "lblUpperLine";
            this.lblUpperLine.Size = new System.Drawing.Size(435, 1);
            this.lblUpperLine.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.Controls.Add(this.lblQuestionDetails);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 146);
            this.panel1.TabIndex = 5;
            // 
            // lblQuestionDetails
            // 
            this.lblQuestionDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuestionDetails.ForeColor = System.Drawing.Color.Lavender;
            this.lblQuestionDetails.Location = new System.Drawing.Point(108, 0);
            this.lblQuestionDetails.Name = "lblQuestionDetails";
            this.lblQuestionDetails.Size = new System.Drawing.Size(327, 146);
            this.lblQuestionDetails.TabIndex = 3;
            this.lblQuestionDetails.Text = "Question Details";
            this.lblQuestionDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Image = global::sCommonLib.Properties.Resources.QuestionSignPng73;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 146);
            this.label2.TabIndex = 2;
            // 
            // lblBottomLine
            // 
            this.lblBottomLine.BackColor = System.Drawing.Color.Lavender;
            this.lblBottomLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBottomLine.Location = new System.Drawing.Point(0, 193);
            this.lblBottomLine.Name = "lblBottomLine";
            this.lblBottomLine.Size = new System.Drawing.Size(435, 1);
            this.lblBottomLine.TabIndex = 6;
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.ForeColor = System.Drawing.Color.White;
            this.btnYes.Image = global::sCommonLib.Properties.Resources.TickSignPng16;
            this.btnYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnYes.Location = new System.Drawing.Point(144, 204);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(60, 27);
            this.btnYes.TabIndex = 10;
            this.btnYes.Text = "&Yes";
            this.btnYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.ForeColor = System.Drawing.Color.White;
            this.btnNo.Image = global::sCommonLib.Properties.Resources.CrossPng16;
            this.btnNo.Location = new System.Drawing.Point(224, 204);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(60, 27);
            this.btnNo.TabIndex = 9;
            this.btnNo.Text = "&No";
            this.btnNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // ConfirmationMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.CancelButton = this.btnNo;
            this.ClientSize = new System.Drawing.Size(435, 243);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.lblBottomLine);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblUpperLine);
            this.Controls.Add(this.lblHeadLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConfirmationMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfirmationMessageBox";
            this.Load += new System.EventHandler(this.ConfirmationMessageBox_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeadLine;
        private System.Windows.Forms.Label lblUpperLine;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblQuestionDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBottomLine;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;

    }
}