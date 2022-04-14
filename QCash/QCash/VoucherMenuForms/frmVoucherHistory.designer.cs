namespace QCash.VoucherMenuForms
{
    partial class frmVoucherHistory
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
            this.dgData = new System.Windows.Forms.DataGridView();
            this.MyNavBar = new Guifreaks.NavigationBar.NaviBar(this.components);
            this.naviBand1 = new Guifreaks.NavigationBar.NaviBand(this.components);
            this.naviGroup1 = new Guifreaks.NavigationBar.NaviGroup(this.components);
            this.btnRemoveFilter = new System.Windows.Forms.Button();
            this.chkFilterByVoucherNo = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtToVoucherNo = new System.Windows.Forms.TextBox();
            this.txtFromVoucherNo = new System.Windows.Forms.TextBox();
            this.chkFilterByVoucherType = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkJournalVoucher = new System.Windows.Forms.CheckBox();
            this.chkCreditVoucher = new System.Windows.Forms.CheckBox();
            this.chkDebitVoucher = new System.Windows.Forms.CheckBox();
            this.chkFilterByDate = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToDate = new System.Windows.Forms.TextBox();
            this.txtFromDate = new System.Windows.Forms.TextBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.lblPanelDevider = new System.Windows.Forms.Label();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.MyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MyProgressBar = new System.Windows.Forms.ProgressBar();
            this.bgwPrimaryWorker = new System.ComponentModel.BackgroundWorker();
            this.PanelBottomPart = new System.Windows.Forms.Panel();
            this.btnExport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.RedToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnPrint = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.PanelBodyPart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyNavBar)).BeginInit();
            this.MyNavBar.SuspendLayout();
            this.naviBand1.ClientArea.SuspendLayout();
            this.naviBand1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.naviGroup1)).BeginInit();
            this.naviGroup1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).BeginInit();
            this.PanelBottomPart.SuspendLayout();
            this.SuspendLayout();
            // 
            // MastHead
            // 
            this.MastHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.MastHead.Location = new System.Drawing.Point(0, 0);
            this.MastHead.Name = "MastHead";
            this.MastHead.Size = new System.Drawing.Size(753, 31);
            this.MastHead.TabIndex = 0;
            this.MastHead.Values.Description = "";
            this.MastHead.Values.Heading = "Voucher History";
            this.MastHead.Values.Image = null;
            // 
            // PanelBodyPart
            // 
            this.PanelBodyPart.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PanelBodyPart.Controls.Add(this.dgData);
            this.PanelBodyPart.Controls.Add(this.MyNavBar);
            this.PanelBodyPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBodyPart.Location = new System.Drawing.Point(0, 31);
            this.PanelBodyPart.Name = "PanelBodyPart";
            this.PanelBodyPart.Size = new System.Drawing.Size(753, 410);
            this.PanelBodyPart.TabIndex = 1;
            // 
            // dgData
            // 
            this.dgData.BackgroundColor = System.Drawing.Color.White;
            this.dgData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgData.Location = new System.Drawing.Point(190, 0);
            this.dgData.Name = "dgData";
            this.dgData.Size = new System.Drawing.Size(563, 410);
            this.dgData.TabIndex = 0;
            // 
            // MyNavBar
            // 
            this.MyNavBar.ActiveBand = this.naviBand1;
            this.MyNavBar.Controls.Add(this.naviBand1);
            this.MyNavBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.MyNavBar.Location = new System.Drawing.Point(0, 0);
            this.MyNavBar.Name = "MyNavBar";
            this.MyNavBar.Size = new System.Drawing.Size(190, 410);
            this.MyNavBar.TabIndex = 1;
            this.MyNavBar.Text = "naviBar1";
            // 
            // naviBand1
            // 
            // 
            // naviBand1.ClientArea
            // 
            this.naviBand1.ClientArea.Controls.Add(this.naviGroup1);
            this.naviBand1.ClientArea.Location = new System.Drawing.Point(0, 0);
            this.naviBand1.ClientArea.Name = "ClientArea";
            this.naviBand1.ClientArea.Size = new System.Drawing.Size(188, 343);
            this.naviBand1.ClientArea.TabIndex = 0;
            this.naviBand1.Location = new System.Drawing.Point(1, 27);
            this.naviBand1.Name = "naviBand1";
            this.naviBand1.Size = new System.Drawing.Size(188, 343);
            this.naviBand1.TabIndex = 3;
            this.naviBand1.Text = "Filter Options";
            // 
            // naviGroup1
            // 
            this.naviGroup1.Caption = null;
            this.naviGroup1.Controls.Add(this.btnRemoveFilter);
            this.naviGroup1.Controls.Add(this.chkFilterByVoucherNo);
            this.naviGroup1.Controls.Add(this.groupBox3);
            this.naviGroup1.Controls.Add(this.chkFilterByVoucherType);
            this.naviGroup1.Controls.Add(this.groupBox2);
            this.naviGroup1.Controls.Add(this.chkFilterByDate);
            this.naviGroup1.Controls.Add(this.groupBox1);
            this.naviGroup1.Controls.Add(this.btnApplyFilter);
            this.naviGroup1.Dock = System.Windows.Forms.DockStyle.Top;
            this.naviGroup1.ExpandedHeight = 340;
            this.naviGroup1.HeaderContextMenuStrip = null;
            this.naviGroup1.Location = new System.Drawing.Point(0, 0);
            this.naviGroup1.Name = "naviGroup1";
            this.naviGroup1.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
            this.naviGroup1.Size = new System.Drawing.Size(188, 340);
            this.naviGroup1.TabIndex = 0;
            this.naviGroup1.Text = "naviGroup1";
            // 
            // btnRemoveFilter
            // 
            this.btnRemoveFilter.Location = new System.Drawing.Point(81, 308);
            this.btnRemoveFilter.Name = "btnRemoveFilter";
            this.btnRemoveFilter.Size = new System.Drawing.Size(62, 21);
            this.btnRemoveFilter.TabIndex = 12;
            this.btnRemoveFilter.Text = "Remove";
            this.btnRemoveFilter.UseVisualStyleBackColor = true;
            this.btnRemoveFilter.Click += new System.EventHandler(this.btnRemoveFilter_Click);
            // 
            // chkFilterByVoucherNo
            // 
            this.chkFilterByVoucherNo.AutoSize = true;
            this.chkFilterByVoucherNo.BackColor = System.Drawing.Color.White;
            this.chkFilterByVoucherNo.Location = new System.Drawing.Point(31, 220);
            this.chkFilterByVoucherNo.Name = "chkFilterByVoucherNo";
            this.chkFilterByVoucherNo.Size = new System.Drawing.Size(15, 14);
            this.chkFilterByVoucherNo.TabIndex = 11;
            this.chkFilterByVoucherNo.UseVisualStyleBackColor = false;
            this.chkFilterByVoucherNo.CheckedChanged += new System.EventHandler(this.chkFilterByVoucherNo_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtToVoucherNo);
            this.groupBox3.Controls.Add(this.txtFromVoucherNo);
            this.groupBox3.Location = new System.Drawing.Point(21, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(156, 79);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "      Filter by Voucher No.:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "To:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(11, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "From:";
            // 
            // txtToVoucherNo
            // 
            this.txtToVoucherNo.Enabled = false;
            this.txtToVoucherNo.Location = new System.Drawing.Point(48, 50);
            this.txtToVoucherNo.Name = "txtToVoucherNo";
            this.txtToVoucherNo.Size = new System.Drawing.Size(86, 20);
            this.txtToVoucherNo.TabIndex = 1;
            // 
            // txtFromVoucherNo
            // 
            this.txtFromVoucherNo.Enabled = false;
            this.txtFromVoucherNo.Location = new System.Drawing.Point(48, 27);
            this.txtFromVoucherNo.Name = "txtFromVoucherNo";
            this.txtFromVoucherNo.Size = new System.Drawing.Size(86, 20);
            this.txtFromVoucherNo.TabIndex = 0;
            // 
            // chkFilterByVoucherType
            // 
            this.chkFilterByVoucherType.AutoSize = true;
            this.chkFilterByVoucherType.BackColor = System.Drawing.Color.White;
            this.chkFilterByVoucherType.Location = new System.Drawing.Point(31, 37);
            this.chkFilterByVoucherType.Name = "chkFilterByVoucherType";
            this.chkFilterByVoucherType.Size = new System.Drawing.Size(15, 14);
            this.chkFilterByVoucherType.TabIndex = 9;
            this.chkFilterByVoucherType.UseVisualStyleBackColor = false;
            this.chkFilterByVoucherType.CheckedChanged += new System.EventHandler(this.chkFilterByVoucherType_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.chkJournalVoucher);
            this.groupBox2.Controls.Add(this.chkCreditVoucher);
            this.groupBox2.Controls.Add(this.chkDebitVoucher);
            this.groupBox2.Location = new System.Drawing.Point(21, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 90);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "      Filter by Voucher Type:";
            // 
            // chkJournalVoucher
            // 
            this.chkJournalVoucher.AutoSize = true;
            this.chkJournalVoucher.BackColor = System.Drawing.Color.White;
            this.chkJournalVoucher.Enabled = false;
            this.chkJournalVoucher.Location = new System.Drawing.Point(28, 67);
            this.chkJournalVoucher.Name = "chkJournalVoucher";
            this.chkJournalVoucher.Size = new System.Drawing.Size(103, 17);
            this.chkJournalVoucher.TabIndex = 12;
            this.chkJournalVoucher.Text = "Journal Voucher";
            this.chkJournalVoucher.UseVisualStyleBackColor = false;
            // 
            // chkCreditVoucher
            // 
            this.chkCreditVoucher.AutoSize = true;
            this.chkCreditVoucher.BackColor = System.Drawing.Color.White;
            this.chkCreditVoucher.Enabled = false;
            this.chkCreditVoucher.Location = new System.Drawing.Point(28, 44);
            this.chkCreditVoucher.Name = "chkCreditVoucher";
            this.chkCreditVoucher.Size = new System.Drawing.Size(96, 17);
            this.chkCreditVoucher.TabIndex = 11;
            this.chkCreditVoucher.Text = "Credit Voucher";
            this.chkCreditVoucher.UseVisualStyleBackColor = false;
            // 
            // chkDebitVoucher
            // 
            this.chkDebitVoucher.AutoSize = true;
            this.chkDebitVoucher.BackColor = System.Drawing.Color.White;
            this.chkDebitVoucher.Enabled = false;
            this.chkDebitVoucher.Location = new System.Drawing.Point(28, 21);
            this.chkDebitVoucher.Name = "chkDebitVoucher";
            this.chkDebitVoucher.Size = new System.Drawing.Size(94, 17);
            this.chkDebitVoucher.TabIndex = 10;
            this.chkDebitVoucher.Text = "Debit Voucher";
            this.chkDebitVoucher.UseVisualStyleBackColor = false;
            // 
            // chkFilterByDate
            // 
            this.chkFilterByDate.AutoSize = true;
            this.chkFilterByDate.BackColor = System.Drawing.Color.White;
            this.chkFilterByDate.Location = new System.Drawing.Point(31, 135);
            this.chkFilterByDate.Name = "chkFilterByDate";
            this.chkFilterByDate.Size = new System.Drawing.Size(15, 14);
            this.chkFilterByDate.TabIndex = 7;
            this.chkFilterByDate.UseVisualStyleBackColor = false;
            this.chkFilterByDate.CheckedChanged += new System.EventHandler(this.chkFilterByDate_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtToDate);
            this.groupBox1.Controls.Add(this.txtFromDate);
            this.groupBox1.Location = new System.Drawing.Point(21, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 79);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "      Filter by Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(11, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "To:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "From:";
            // 
            // txtToDate
            // 
            this.txtToDate.Enabled = false;
            this.txtToDate.Location = new System.Drawing.Point(48, 50);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Size = new System.Drawing.Size(86, 20);
            this.txtToDate.TabIndex = 1;
            // 
            // txtFromDate
            // 
            this.txtFromDate.Enabled = false;
            this.txtFromDate.Location = new System.Drawing.Point(48, 27);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(86, 20);
            this.txtFromDate.TabIndex = 0;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(22, 308);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(53, 21);
            this.btnApplyFilter.TabIndex = 2;
            this.btnApplyFilter.Text = "Apply";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // lblPanelDevider
            // 
            this.lblPanelDevider.BackColor = System.Drawing.Color.SteelBlue;
            this.lblPanelDevider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPanelDevider.Location = new System.Drawing.Point(0, 441);
            this.lblPanelDevider.Name = "lblPanelDevider";
            this.lblPanelDevider.Size = new System.Drawing.Size(753, 1);
            this.lblPanelDevider.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(655, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnClose.Size = new System.Drawing.Size(86, 30);
            this.btnClose.TabIndex = 5;
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
            this.MyProgressBar.Location = new System.Drawing.Point(225, 14);
            this.MyProgressBar.Name = "MyProgressBar";
            this.MyProgressBar.Size = new System.Drawing.Size(420, 23);
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
            this.PanelBottomPart.Controls.Add(this.btnPrint);
            this.PanelBottomPart.Controls.Add(this.btnExport);
            this.PanelBottomPart.Controls.Add(this.MyProgressBar);
            this.PanelBottomPart.Controls.Add(this.btnClose);
            this.PanelBottomPart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelBottomPart.Location = new System.Drawing.Point(0, 442);
            this.PanelBottomPart.Name = "PanelBottomPart";
            this.PanelBottomPart.Size = new System.Drawing.Size(753, 52);
            this.PanelBottomPart.TabIndex = 3;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.Location = new System.Drawing.Point(104, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnExport.Size = new System.Drawing.Size(86, 30);
            this.btnExport.TabIndex = 7;
            this.btnExport.Values.Text = "&Export";
            this.btnExport.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Location = new System.Drawing.Point(12, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnPrint.Size = new System.Drawing.Size(86, 30);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Values.Text = "&Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmVoucherHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(753, 494);
            this.Controls.Add(this.PanelBodyPart);
            this.Controls.Add(this.lblPanelDevider);
            this.Controls.Add(this.PanelBottomPart);
            this.Controls.Add(this.MastHead);
            this.Name = "frmVoucherHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voucher History";
            this.PanelBodyPart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyNavBar)).EndInit();
            this.MyNavBar.ResumeLayout(false);
            this.naviBand1.ClientArea.ResumeLayout(false);
            this.naviBand1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.naviGroup1)).EndInit();
            this.naviGroup1.ResumeLayout(false);
            this.naviGroup1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).EndInit();
            this.PanelBottomPart.ResumeLayout(false);
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
        private System.Windows.Forms.ProgressBar MyProgressBar;
        private System.Windows.Forms.DataGridView dgData;
        private System.ComponentModel.BackgroundWorker bgwPrimaryWorker;
        private Guifreaks.NavigationBar.NaviBar MyNavBar;
        private Guifreaks.NavigationBar.NaviBand naviBand1;
        private Guifreaks.NavigationBar.NaviGroup naviGroup1;
        private System.Windows.Forms.Panel PanelBottomPart;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.TextBox txtToDate;
        private System.Windows.Forms.TextBox txtFromDate;
        private System.Windows.Forms.CheckBox chkFilterByDate;
        private System.Windows.Forms.CheckBox chkFilterByVoucherType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkJournalVoucher;
        private System.Windows.Forms.CheckBox chkCreditVoucher;
        private System.Windows.Forms.CheckBox chkDebitVoucher;
        private System.Windows.Forms.CheckBox chkFilterByVoucherNo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtToVoucherNo;
        private System.Windows.Forms.TextBox txtFromVoucherNo;
        private System.Windows.Forms.Button btnRemoveFilter;
        private System.Windows.Forms.ToolTip RedToolTip;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPrint;
    }
}

