namespace QCash.ViewMenuForms
{
    partial class frmGeneralLedgerFilter
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
            this.MastHead = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.PanelBodyPart = new System.Windows.Forms.Panel();
            this.btnApplyFilter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.gbSerialFilter = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonTextBox3 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonTextBox4 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.chkFilterBySerial = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.chkDateFilter = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.gbDateFilter = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonTextBox2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblPanelDevider = new System.Windows.Forms.Label();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.MyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bgwPrimaryWorker = new System.ComponentModel.BackgroundWorker();
            this.PanelBottomPart = new System.Windows.Forms.Panel();
            this.contextMenuSetFocusOrder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemAddFocus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemRemoveFocus = new System.Windows.Forms.ToolStripMenuItem();
            this.RedToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bsCurrentEntity = new System.Windows.Forms.BindingSource(this.components);
            this.PanelBodyPart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbSerialFilter)).BeginInit();
            this.gbSerialFilter.Panel.SuspendLayout();
            this.gbSerialFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbDateFilter)).BeginInit();
            this.gbDateFilter.Panel.SuspendLayout();
            this.gbDateFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).BeginInit();
            this.PanelBottomPart.SuspendLayout();
            this.contextMenuSetFocusOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCurrentEntity)).BeginInit();
            this.SuspendLayout();
            // 
            // MastHead
            // 
            this.MastHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.MastHead.Location = new System.Drawing.Point(0, 0);
            this.MastHead.Name = "MastHead";
            this.MastHead.Size = new System.Drawing.Size(485, 31);
            this.MastHead.TabIndex = 0;
            this.MastHead.Values.Description = "";
            this.MastHead.Values.Heading = "General Ledger Filter";
            this.MastHead.Values.Image = null;
            // 
            // PanelBodyPart
            // 
            this.PanelBodyPart.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PanelBodyPart.Controls.Add(this.btnApplyFilter);
            this.PanelBodyPart.Controls.Add(this.gbSerialFilter);
            this.PanelBodyPart.Controls.Add(this.chkFilterBySerial);
            this.PanelBodyPart.Controls.Add(this.chkDateFilter);
            this.PanelBodyPart.Controls.Add(this.gbDateFilter);
            this.PanelBodyPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBodyPart.Location = new System.Drawing.Point(0, 31);
            this.PanelBodyPart.Name = "PanelBodyPart";
            this.PanelBodyPart.Size = new System.Drawing.Size(485, 202);
            this.PanelBodyPart.TabIndex = 1;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(136, 149);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnApplyFilter.Size = new System.Drawing.Size(76, 30);
            this.btnApplyFilter.TabIndex = 12;
            this.btnApplyFilter.Values.Text = "&Apply";
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // gbSerialFilter
            // 
            this.gbSerialFilter.Location = new System.Drawing.Point(136, 88);
            this.gbSerialFilter.Name = "gbSerialFilter";
            // 
            // gbSerialFilter.Panel
            // 
            this.gbSerialFilter.Panel.Controls.Add(this.kryptonTextBox3);
            this.gbSerialFilter.Panel.Controls.Add(this.kryptonTextBox4);
            this.gbSerialFilter.Panel.Controls.Add(this.kryptonLabel4);
            this.gbSerialFilter.Panel.Controls.Add(this.kryptonLabel5);
            this.gbSerialFilter.Size = new System.Drawing.Size(315, 35);
            this.gbSerialFilter.StateCommon.Back.Color1 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbSerialFilter.TabIndex = 11;
            this.gbSerialFilter.Values.Heading = "";
            // 
            // kryptonTextBox3
            // 
            this.kryptonTextBox3.Location = new System.Drawing.Point(43, 4);
            this.kryptonTextBox3.Name = "kryptonTextBox3";
            this.kryptonTextBox3.Size = new System.Drawing.Size(107, 22);
            this.kryptonTextBox3.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonTextBox3.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonTextBox3.StateCommon.Border.Rounding = 3;
            this.kryptonTextBox3.TabIndex = 3;
            // 
            // kryptonTextBox4
            // 
            this.kryptonTextBox4.Location = new System.Drawing.Point(190, 4);
            this.kryptonTextBox4.Name = "kryptonTextBox4";
            this.kryptonTextBox4.Size = new System.Drawing.Size(107, 22);
            this.kryptonTextBox4.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonTextBox4.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonTextBox4.StateCommon.Border.Rounding = 3;
            this.kryptonTextBox4.TabIndex = 11;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(157, 6);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(30, 20);
            this.kryptonLabel4.TabIndex = 12;
            this.kryptonLabel4.Values.Text = "To :";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(2, 5);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(45, 20);
            this.kryptonLabel5.TabIndex = 11;
            this.kryptonLabel5.Values.Text = "From :";
            // 
            // chkFilterBySerial
            // 
            this.chkFilterBySerial.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.chkFilterBySerial.Location = new System.Drawing.Point(32, 98);
            this.chkFilterBySerial.Name = "chkFilterBySerial";
            this.chkFilterBySerial.Size = new System.Drawing.Size(92, 20);
            this.chkFilterBySerial.TabIndex = 10;
            this.chkFilterBySerial.Text = "By Serial No.";
            this.chkFilterBySerial.Values.Text = "By Serial No.";
            // 
            // chkDateFilter
            // 
            this.chkDateFilter.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.chkDateFilter.Location = new System.Drawing.Point(32, 38);
            this.chkDateFilter.Name = "chkDateFilter";
            this.chkDateFilter.Size = new System.Drawing.Size(72, 20);
            this.chkDateFilter.TabIndex = 8;
            this.chkDateFilter.Text = "By Date :";
            this.chkDateFilter.Values.Text = "By Date :";
            // 
            // gbDateFilter
            // 
            this.gbDateFilter.Location = new System.Drawing.Point(136, 30);
            this.gbDateFilter.Name = "gbDateFilter";
            // 
            // gbDateFilter.Panel
            // 
            this.gbDateFilter.Panel.Controls.Add(this.kryptonTextBox1);
            this.gbDateFilter.Panel.Controls.Add(this.kryptonTextBox2);
            this.gbDateFilter.Panel.Controls.Add(this.kryptonLabel3);
            this.gbDateFilter.Panel.Controls.Add(this.kryptonLabel2);
            this.gbDateFilter.Size = new System.Drawing.Size(315, 35);
            this.gbDateFilter.StateCommon.Back.Color1 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbDateFilter.TabIndex = 7;
            this.gbDateFilter.Values.Heading = "";
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(43, 4);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(107, 22);
            this.kryptonTextBox1.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonTextBox1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonTextBox1.StateCommon.Border.Rounding = 3;
            this.kryptonTextBox1.TabIndex = 3;
            // 
            // kryptonTextBox2
            // 
            this.kryptonTextBox2.Location = new System.Drawing.Point(190, 4);
            this.kryptonTextBox2.Name = "kryptonTextBox2";
            this.kryptonTextBox2.Size = new System.Drawing.Size(107, 22);
            this.kryptonTextBox2.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonTextBox2.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonTextBox2.StateCommon.Border.Rounding = 3;
            this.kryptonTextBox2.TabIndex = 11;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(157, 6);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(30, 20);
            this.kryptonLabel3.TabIndex = 12;
            this.kryptonLabel3.Values.Text = "To :";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(2, 5);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(45, 20);
            this.kryptonLabel2.TabIndex = 11;
            this.kryptonLabel2.Values.Text = "From :";
            // 
            // lblPanelDevider
            // 
            this.lblPanelDevider.BackColor = System.Drawing.Color.SteelBlue;
            this.lblPanelDevider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPanelDevider.Location = new System.Drawing.Point(0, 233);
            this.lblPanelDevider.Name = "lblPanelDevider";
            this.lblPanelDevider.Size = new System.Drawing.Size(485, 1);
            this.lblPanelDevider.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(388, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnClose.Size = new System.Drawing.Size(86, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Values.Text = "&Close";
            // 
            // MyErrorProvider
            // 
            this.MyErrorProvider.ContainerControl = this;
            // 
            // bgwPrimaryWorker
            // 
            this.bgwPrimaryWorker.WorkerReportsProgress = true;
            this.bgwPrimaryWorker.WorkerSupportsCancellation = true;
            // 
            // PanelBottomPart
            // 
            this.PanelBottomPart.Controls.Add(this.btnClose);
            this.PanelBottomPart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelBottomPart.Location = new System.Drawing.Point(0, 234);
            this.PanelBottomPart.Name = "PanelBottomPart";
            this.PanelBottomPart.Size = new System.Drawing.Size(485, 44);
            this.PanelBottomPart.TabIndex = 7;
            // 
            // contextMenuSetFocusOrder
            // 
            this.contextMenuSetFocusOrder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuSetFocusOrder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemAddFocus,
            this.toolStripSeparator1,
            this.itemRemoveFocus});
            this.contextMenuSetFocusOrder.Name = "contextMenuSetFocusOrder";
            this.contextMenuSetFocusOrder.Size = new System.Drawing.Size(170, 54);
            // 
            // itemAddFocus
            // 
            this.itemAddFocus.Name = "itemAddFocus";
            this.itemAddFocus.Size = new System.Drawing.Size(169, 22);
            this.itemAddFocus.Text = "Add Into List";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // itemRemoveFocus
            // 
            this.itemRemoveFocus.Name = "itemRemoveFocus";
            this.itemRemoveFocus.Size = new System.Drawing.Size(169, 22);
            this.itemRemoveFocus.Text = "Remove From List";
            // 
            // frmGeneralLedgerFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(485, 278);
            this.Controls.Add(this.PanelBodyPart);
            this.Controls.Add(this.lblPanelDevider);
            this.Controls.Add(this.PanelBottomPart);
            this.Controls.Add(this.MastHead);
            this.Name = "frmGeneralLedgerFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGeneralLedgerFilter";
            this.PanelBodyPart.ResumeLayout(false);
            this.PanelBodyPart.PerformLayout();
            this.gbSerialFilter.Panel.ResumeLayout(false);
            this.gbSerialFilter.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbSerialFilter)).EndInit();
            this.gbSerialFilter.ResumeLayout(false);
            this.gbDateFilter.Panel.ResumeLayout(false);
            this.gbDateFilter.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbDateFilter)).EndInit();
            this.gbDateFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).EndInit();
            this.PanelBottomPart.ResumeLayout(false);
            this.contextMenuSetFocusOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsCurrentEntity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeader MastHead;
        private System.Windows.Forms.Panel PanelBodyPart;
        private System.Windows.Forms.Label lblPanelDevider;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private System.Windows.Forms.ErrorProvider MyErrorProvider;
        private System.Windows.Forms.ToolTip MyToolTip;
        private System.Windows.Forms.BindingSource bsCurrentEntity;
        private System.ComponentModel.BackgroundWorker bgwPrimaryWorker;
        private System.Windows.Forms.Panel PanelBottomPart;
        private System.Windows.Forms.ContextMenuStrip contextMenuSetFocusOrder;
        private System.Windows.Forms.ToolStripMenuItem itemAddFocus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem itemRemoveFocus;
        private System.Windows.Forms.ToolTip RedToolTip;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbDateFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkFilterBySerial;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkDateFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbSerialFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnApplyFilter;
    }
}

