namespace QCash.ViewMenuForms
{
    partial class frmTrialBalance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MastHead = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.PanelBodyPart = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbMyProgressBar = new System.Windows.Forms.ProgressBar();
            this.lblCrTotal = new System.Windows.Forms.Label();
            this.lbl1stLine = new System.Windows.Forms.Label();
            this.Label22 = new System.Windows.Forms.Label();
            this.lblDrTotal = new System.Windows.Forms.Label();
            this.lbl3rdLine = new System.Windows.Forms.Label();
            this.lbl2ndLine = new System.Windows.Forms.Label();
            this.dgTrialBalance = new System.Windows.Forms.DataGridView();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.lblPanelDevider = new System.Windows.Forms.Label();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.MyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MyProgressBar = new System.Windows.Forms.ProgressBar();
            this.bgwPrimaryWorker = new System.ComponentModel.BackgroundWorker();
            this.PanelBottomPart = new System.Windows.Forms.Panel();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.btnPrint = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnPrepare = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.contextMenuSetFocusOrder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemAddFocus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemRemoveFocus = new System.Windows.Forms.ToolStripMenuItem();
            this.RedToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bsCurrentEntity = new System.Windows.Forms.BindingSource(this.components);
            this.PanelBodyPart.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTrialBalance)).BeginInit();
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
            this.MastHead.Size = new System.Drawing.Size(580, 31);
            this.MastHead.TabIndex = 0;
            this.MastHead.Values.Description = "";
            this.MastHead.Values.Heading = "Trial Balance";
            this.MastHead.Values.Image = global::QCash.Properties.Resources.TrialBalancePng24;
            // 
            // PanelBodyPart
            // 
            this.PanelBodyPart.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PanelBodyPart.Controls.Add(this.panel1);
            this.PanelBodyPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBodyPart.Location = new System.Drawing.Point(0, 31);
            this.PanelBodyPart.Name = "PanelBodyPart";
            this.PanelBodyPart.Size = new System.Drawing.Size(580, 337);
            this.PanelBodyPart.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.pbMyProgressBar);
            this.panel1.Controls.Add(this.lblCrTotal);
            this.panel1.Controls.Add(this.lbl1stLine);
            this.panel1.Controls.Add(this.Label22);
            this.panel1.Controls.Add(this.lblDrTotal);
            this.panel1.Controls.Add(this.lbl3rdLine);
            this.panel1.Controls.Add(this.lbl2ndLine);
            this.panel1.Controls.Add(this.dgTrialBalance);
            this.panel1.Controls.Add(this.Label6);
            this.panel1.Controls.Add(this.Label20);
            this.panel1.Controls.Add(this.Label21);
            this.panel1.Location = new System.Drawing.Point(9, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(563, 323);
            this.panel1.TabIndex = 1;
            // 
            // pbMyProgressBar
            // 
            this.pbMyProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbMyProgressBar.Location = new System.Drawing.Point(4, 303);
            this.pbMyProgressBar.Name = "pbMyProgressBar";
            this.pbMyProgressBar.Size = new System.Drawing.Size(339, 13);
            this.pbMyProgressBar.TabIndex = 113;
            this.pbMyProgressBar.Visible = false;
            // 
            // lblCrTotal
            // 
            this.lblCrTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCrTotal.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblCrTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCrTotal.Location = new System.Drawing.Point(454, 299);
            this.lblCrTotal.Name = "lblCrTotal";
            this.lblCrTotal.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.lblCrTotal.Size = new System.Drawing.Size(104, 18);
            this.lblCrTotal.TabIndex = 112;
            this.lblCrTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl1stLine
            // 
            this.lbl1stLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl1stLine.BackColor = System.Drawing.Color.DimGray;
            this.lbl1stLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1stLine.Location = new System.Drawing.Point(61, 6);
            this.lbl1stLine.Margin = new System.Windows.Forms.Padding(0);
            this.lbl1stLine.Name = "lbl1stLine";
            this.lbl1stLine.Size = new System.Drawing.Size(1, 293);
            this.lbl1stLine.TabIndex = 110;
            // 
            // Label22
            // 
            this.Label22.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label22.ForeColor = System.Drawing.Color.Black;
            this.Label22.Location = new System.Drawing.Point(4, 5);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(58, 32);
            this.Label22.TabIndex = 111;
            this.Label22.Text = "Code";
            this.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDrTotal
            // 
            this.lblDrTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDrTotal.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblDrTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDrTotal.Location = new System.Drawing.Point(351, 299);
            this.lblDrTotal.Name = "lblDrTotal";
            this.lblDrTotal.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.lblDrTotal.Size = new System.Drawing.Size(104, 18);
            this.lblDrTotal.TabIndex = 109;
            this.lblDrTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl3rdLine
            // 
            this.lbl3rdLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl3rdLine.BackColor = System.Drawing.Color.DimGray;
            this.lbl3rdLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3rdLine.Location = new System.Drawing.Point(454, 6);
            this.lbl3rdLine.Margin = new System.Windows.Forms.Padding(0);
            this.lbl3rdLine.Name = "lbl3rdLine";
            this.lbl3rdLine.Size = new System.Drawing.Size(1, 293);
            this.lbl3rdLine.TabIndex = 108;
            // 
            // lbl2ndLine
            // 
            this.lbl2ndLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl2ndLine.BackColor = System.Drawing.Color.DimGray;
            this.lbl2ndLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2ndLine.Location = new System.Drawing.Point(351, 6);
            this.lbl2ndLine.Margin = new System.Windows.Forms.Padding(0);
            this.lbl2ndLine.Name = "lbl2ndLine";
            this.lbl2ndLine.Size = new System.Drawing.Size(1, 293);
            this.lbl2ndLine.TabIndex = 107;
            // 
            // dgTrialBalance
            // 
            this.dgTrialBalance.AllowUserToAddRows = false;
            this.dgTrialBalance.AllowUserToDeleteRows = false;
            this.dgTrialBalance.AllowUserToResizeColumns = false;
            this.dgTrialBalance.AllowUserToResizeRows = false;
            this.dgTrialBalance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgTrialBalance.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgTrialBalance.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgTrialBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTrialBalance.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTrialBalance.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgTrialBalance.Location = new System.Drawing.Point(4, 36);
            this.dgTrialBalance.Name = "dgTrialBalance";
            this.dgTrialBalance.RowHeadersVisible = false;
            dataGridViewCellStyle2.NullValue = null;
            this.dgTrialBalance.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgTrialBalance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgTrialBalance.Size = new System.Drawing.Size(554, 264);
            this.dgTrialBalance.TabIndex = 103;
            this.dgTrialBalance.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTrialBalance_CellDoubleClick);
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(61, 5);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Label6.Size = new System.Drawing.Size(291, 32);
            this.Label6.TabIndex = 104;
            this.Label6.Text = "Account Name";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label20
            // 
            this.Label20.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label20.ForeColor = System.Drawing.Color.Black;
            this.Label20.Location = new System.Drawing.Point(351, 5);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(104, 32);
            this.Label20.TabIndex = 105;
            this.Label20.Text = "Debit";
            this.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label21
            // 
            this.Label21.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label21.ForeColor = System.Drawing.Color.Black;
            this.Label21.Location = new System.Drawing.Point(454, 5);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(104, 32);
            this.Label21.TabIndex = 106;
            this.Label21.Text = "Credit";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPanelDevider
            // 
            this.lblPanelDevider.BackColor = System.Drawing.Color.SteelBlue;
            this.lblPanelDevider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPanelDevider.Location = new System.Drawing.Point(0, 368);
            this.lblPanelDevider.Name = "lblPanelDevider";
            this.lblPanelDevider.Size = new System.Drawing.Size(580, 1);
            this.lblPanelDevider.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(483, 7);
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
            // MyProgressBar
            // 
            this.MyProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyProgressBar.Location = new System.Drawing.Point(269, 10);
            this.MyProgressBar.Name = "MyProgressBar";
            this.MyProgressBar.Size = new System.Drawing.Size(208, 23);
            this.MyProgressBar.TabIndex = 6;
            this.MyProgressBar.Visible = false;
            // 
            // bgwPrimaryWorker
            // 
            this.bgwPrimaryWorker.WorkerReportsProgress = true;
            this.bgwPrimaryWorker.WorkerSupportsCancellation = true;
            // 
            // PanelBottomPart
            // 
            this.PanelBottomPart.Controls.Add(this.txtDate);
            this.PanelBottomPart.Controls.Add(this.btnPrint);
            this.PanelBottomPart.Controls.Add(this.btnPrepare);
            this.PanelBottomPart.Controls.Add(this.MyProgressBar);
            this.PanelBottomPart.Controls.Add(this.btnClose);
            this.PanelBottomPart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelBottomPart.Location = new System.Drawing.Point(0, 369);
            this.PanelBottomPart.Name = "PanelBottomPart";
            this.PanelBottomPart.Size = new System.Drawing.Size(580, 44);
            this.PanelBottomPart.TabIndex = 7;
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDate.Location = new System.Drawing.Point(361, 10);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(67, 20);
            this.txtDate.TabIndex = 9;
            this.txtDate.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Location = new System.Drawing.Point(13, 7);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnPrint.Size = new System.Drawing.Size(74, 30);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Values.Text = "&Print";
            // 
            // btnPrepare
            // 
            this.btnPrepare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrepare.Location = new System.Drawing.Point(187, 7);
            this.btnPrepare.Name = "btnPrepare";
            this.btnPrepare.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnPrepare.Size = new System.Drawing.Size(76, 30);
            this.btnPrepare.TabIndex = 7;
            this.btnPrepare.Values.Text = "&Prepare";
            this.btnPrepare.Visible = false;
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
            // frmTrialBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(580, 413);
            this.Controls.Add(this.PanelBodyPart);
            this.Controls.Add(this.lblPanelDevider);
            this.Controls.Add(this.PanelBottomPart);
            this.Controls.Add(this.MastHead);
            this.Name = "frmTrialBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trial Balance";
            this.PanelBodyPart.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTrialBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).EndInit();
            this.PanelBottomPart.ResumeLayout(false);
            this.PanelBottomPart.PerformLayout();
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
        private System.Windows.Forms.ProgressBar MyProgressBar;
        private System.ComponentModel.BackgroundWorker bgwPrimaryWorker;
        private System.Windows.Forms.Panel PanelBottomPart;
        private System.Windows.Forms.ContextMenuStrip contextMenuSetFocusOrder;
        private System.Windows.Forms.ToolStripMenuItem itemAddFocus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem itemRemoveFocus;
        private System.Windows.Forms.ToolTip RedToolTip;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.ProgressBar pbMyProgressBar;
        internal System.Windows.Forms.Label lblCrTotal;
        internal System.Windows.Forms.Label lbl1stLine;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.Label lblDrTotal;
        internal System.Windows.Forms.Label lbl3rdLine;
        internal System.Windows.Forms.Label lbl2ndLine;
        internal System.Windows.Forms.DataGridView dgTrialBalance;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Label Label21;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPrint;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPrepare;
        private System.Windows.Forms.TextBox txtDate;
    }
}

