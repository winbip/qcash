namespace QCash
{
    partial class frmEventMaker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEventMaker));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtEnterEvents = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtLeaveEvents = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtKeyDownEvents = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtFocusOrder = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonCopyAll = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(728, 378);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtEnterEvents);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(720, 352);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Enter";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtEnterEvents
            // 
            this.txtEnterEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnterEvents.Location = new System.Drawing.Point(8, 8);
            this.txtEnterEvents.Multiline = true;
            this.txtEnterEvents.Name = "txtEnterEvents";
            this.txtEnterEvents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEnterEvents.Size = new System.Drawing.Size(704, 330);
            this.txtEnterEvents.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtLeaveEvents);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(720, 377);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Leave";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtLeaveEvents
            // 
            this.txtLeaveEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLeaveEvents.Location = new System.Drawing.Point(8, 8);
            this.txtLeaveEvents.Multiline = true;
            this.txtLeaveEvents.Name = "txtLeaveEvents";
            this.txtLeaveEvents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLeaveEvents.Size = new System.Drawing.Size(704, 355);
            this.txtLeaveEvents.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtKeyDownEvents);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(720, 377);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "KeyDown";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtKeyDownEvents
            // 
            this.txtKeyDownEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyDownEvents.Location = new System.Drawing.Point(8, 8);
            this.txtKeyDownEvents.Multiline = true;
            this.txtKeyDownEvents.Name = "txtKeyDownEvents";
            this.txtKeyDownEvents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtKeyDownEvents.Size = new System.Drawing.Size(704, 355);
            this.txtKeyDownEvents.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtFocusOrder);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(720, 377);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Focus Order";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtFocusOrder
            // 
            this.txtFocusOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFocusOrder.Location = new System.Drawing.Point(8, 8);
            this.txtFocusOrder.Multiline = true;
            this.txtFocusOrder.Name = "txtFocusOrder";
            this.txtFocusOrder.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFocusOrder.Size = new System.Drawing.Size(704, 355);
            this.txtFocusOrder.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCopyAll});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(728, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonCopyAll
            // 
            this.toolStripButtonCopyAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonCopyAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCopyAll.Image")));
            this.toolStripButtonCopyAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopyAll.Name = "toolStripButtonCopyAll";
            this.toolStripButtonCopyAll.Size = new System.Drawing.Size(56, 22);
            this.toolStripButtonCopyAll.Text = "Copy All";
            this.toolStripButtonCopyAll.Click += new System.EventHandler(this.toolStripButtonCopyAll_Click);
            // 
            // frmEventMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 403);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmEventMaker";
            this.Text = "frmEventMaker";
            this.Load += new System.EventHandler(this.frmEventMaker_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtEnterEvents;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtLeaveEvents;
        private System.Windows.Forms.TextBox txtKeyDownEvents;
        private System.Windows.Forms.TextBox txtFocusOrder;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopyAll;
    }
}