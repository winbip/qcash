namespace QCash.VoucherMenuForms
{
    partial class frmVoucher
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
            this.lblCreditAccountBalance = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblDebitAccountBalance = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtEntryDate = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.mcDate = new System.Windows.Forms.MonthCalendar();
            this.pbAddCreditAccount = new System.Windows.Forms.PictureBox();
            this.pbAddDebitAccount = new System.Windows.Forms.PictureBox();
            this.pbPrint = new System.Windows.Forms.PictureBox();
            this.pbLastRecord = new System.Windows.Forms.PictureBox();
            this.pbNextRecord = new System.Windows.Forms.PictureBox();
            this.pbPreviousRecord = new System.Windows.Forms.PictureBox();
            this.pbFirstRecord = new System.Windows.Forms.PictureBox();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.txtNarration = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtAmountInWords = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.AmountLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtAmount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cmbCreditAccount = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbDebitAccount = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.VoucherLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtVoucherId = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.pbEntityFolder = new System.Windows.Forms.PictureBox();
            this.lblPanelDevider = new System.Windows.Forms.Label();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnDelete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.MyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MyProgressBar = new System.Windows.Forms.ProgressBar();
            this.bgwPrimaryWorker = new System.ComponentModel.BackgroundWorker();
            this.PanelBottomPart = new System.Windows.Forms.Panel();
            this.btnNewEntity = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.contextMenuSetFocusOrder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemAddFocus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemRemoveFocus = new System.Windows.Forms.ToolStripMenuItem();
            this.RedToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bsCurrentEntity = new System.Windows.Forms.BindingSource(this.components);
            this.txtOperatingYear = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.PanelBodyPart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddCreditAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddDebitAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLastRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNextRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviousRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirstRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCreditAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDebitAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEntityFolder)).BeginInit();
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
            this.MastHead.Size = new System.Drawing.Size(713, 31);
            this.MastHead.TabIndex = 0;
            this.MastHead.Values.Description = "";
            this.MastHead.Values.Heading = "Form Heading";
            this.MastHead.Values.Image = null;
            // 
            // PanelBodyPart
            // 
            this.PanelBodyPart.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PanelBodyPart.Controls.Add(this.lblCreditAccountBalance);
            this.PanelBodyPart.Controls.Add(this.lblDebitAccountBalance);
            this.PanelBodyPart.Controls.Add(this.txtEntryDate);
            this.PanelBodyPart.Controls.Add(this.mcDate);
            this.PanelBodyPart.Controls.Add(this.pbAddCreditAccount);
            this.PanelBodyPart.Controls.Add(this.pbAddDebitAccount);
            this.PanelBodyPart.Controls.Add(this.pbPrint);
            this.PanelBodyPart.Controls.Add(this.pbLastRecord);
            this.PanelBodyPart.Controls.Add(this.pbNextRecord);
            this.PanelBodyPart.Controls.Add(this.pbPreviousRecord);
            this.PanelBodyPart.Controls.Add(this.pbFirstRecord);
            this.PanelBodyPart.Controls.Add(this.pbSearch);
            this.PanelBodyPart.Controls.Add(this.txtNarration);
            this.PanelBodyPart.Controls.Add(this.kryptonLabel7);
            this.PanelBodyPart.Controls.Add(this.txtAmountInWords);
            this.PanelBodyPart.Controls.Add(this.kryptonLabel6);
            this.PanelBodyPart.Controls.Add(this.AmountLabel);
            this.PanelBodyPart.Controls.Add(this.txtAmount);
            this.PanelBodyPart.Controls.Add(this.cmbCreditAccount);
            this.PanelBodyPart.Controls.Add(this.kryptonLabel4);
            this.PanelBodyPart.Controls.Add(this.cmbDebitAccount);
            this.PanelBodyPart.Controls.Add(this.kryptonLabel3);
            this.PanelBodyPart.Controls.Add(this.kryptonLabel2);
            this.PanelBodyPart.Controls.Add(this.VoucherLabel);
            this.PanelBodyPart.Controls.Add(this.txtVoucherId);
            this.PanelBodyPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBodyPart.Location = new System.Drawing.Point(0, 31);
            this.PanelBodyPart.Name = "PanelBodyPart";
            this.PanelBodyPart.Size = new System.Drawing.Size(713, 313);
            this.PanelBodyPart.TabIndex = 1;
            // 
            // lblCreditAccountBalance
            // 
            this.lblCreditAccountBalance.Location = new System.Drawing.Point(363, 136);
            this.lblCreditAccountBalance.Name = "lblCreditAccountBalance";
            this.lblCreditAccountBalance.Size = new System.Drawing.Size(15, 20);
            this.lblCreditAccountBalance.TabIndex = 34909;
            this.lblCreditAccountBalance.Values.Text = "-";
            // 
            // lblDebitAccountBalance
            // 
            this.lblDebitAccountBalance.Location = new System.Drawing.Point(23, 136);
            this.lblDebitAccountBalance.Name = "lblDebitAccountBalance";
            this.lblDebitAccountBalance.Size = new System.Drawing.Size(15, 20);
            this.lblDebitAccountBalance.TabIndex = 34908;
            this.lblDebitAccountBalance.Values.Text = "-";
            // 
            // txtEntryDate
            // 
            this.txtEntryDate.CausesValidation = false;
            this.txtEntryDate.Location = new System.Drawing.Point(461, 39);
            this.txtEntryDate.MaxLength = 10;
            this.txtEntryDate.Name = "txtEntryDate";
            this.txtEntryDate.Size = new System.Drawing.Size(226, 39);
            this.txtEntryDate.StateCommon.Back.Color1 = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtEntryDate.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtEntryDate.StateCommon.Border.Rounding = 2;
            this.txtEntryDate.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntryDate.TabIndex = 1;
            // 
            // mcDate
            // 
            this.mcDate.Location = new System.Drawing.Point(460, 78);
            this.mcDate.Name = "mcDate";
            this.mcDate.TabIndex = 34898;
            this.mcDate.Visible = false;
            // 
            // pbAddCreditAccount
            // 
            this.pbAddCreditAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAddCreditAccount.Image = global::QCash.Properties.Resources.FocusAdd;
            this.pbAddCreditAccount.Location = new System.Drawing.Point(447, 89);
            this.pbAddCreditAccount.Name = "pbAddCreditAccount";
            this.pbAddCreditAccount.Size = new System.Drawing.Size(16, 16);
            this.pbAddCreditAccount.TabIndex = 34907;
            this.pbAddCreditAccount.TabStop = false;
            this.pbAddCreditAccount.Visible = false;
            // 
            // pbAddDebitAccount
            // 
            this.pbAddDebitAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAddDebitAccount.Image = global::QCash.Properties.Resources.FocusAdd;
            this.pbAddDebitAccount.Location = new System.Drawing.Point(106, 89);
            this.pbAddDebitAccount.Name = "pbAddDebitAccount";
            this.pbAddDebitAccount.Size = new System.Drawing.Size(16, 16);
            this.pbAddDebitAccount.TabIndex = 34906;
            this.pbAddDebitAccount.TabStop = false;
            this.pbAddDebitAccount.Visible = false;
            // 
            // pbPrint
            // 
            this.pbPrint.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pbPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPrint.Image = global::QCash.Properties.Resources.PrinterGreen16;
            this.pbPrint.Location = new System.Drawing.Point(421, 43);
            this.pbPrint.Name = "pbPrint";
            this.pbPrint.Size = new System.Drawing.Size(32, 32);
            this.pbPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPrint.TabIndex = 34904;
            this.pbPrint.TabStop = false;
            this.pbPrint.Visible = false;
            // 
            // pbLastRecord
            // 
            this.pbLastRecord.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pbLastRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLastRecord.Image = global::QCash.Properties.Resources.WhiteArrowLast16;
            this.pbLastRecord.Location = new System.Drawing.Point(388, 43);
            this.pbLastRecord.Name = "pbLastRecord";
            this.pbLastRecord.Size = new System.Drawing.Size(32, 32);
            this.pbLastRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbLastRecord.TabIndex = 34903;
            this.pbLastRecord.TabStop = false;
            this.pbLastRecord.Visible = false;
            // 
            // pbNextRecord
            // 
            this.pbNextRecord.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pbNextRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbNextRecord.Image = global::QCash.Properties.Resources.WhiteArrowNext16;
            this.pbNextRecord.Location = new System.Drawing.Point(355, 43);
            this.pbNextRecord.Name = "pbNextRecord";
            this.pbNextRecord.Size = new System.Drawing.Size(32, 32);
            this.pbNextRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbNextRecord.TabIndex = 34902;
            this.pbNextRecord.TabStop = false;
            this.pbNextRecord.Visible = false;
            // 
            // pbPreviousRecord
            // 
            this.pbPreviousRecord.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pbPreviousRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPreviousRecord.Image = global::QCash.Properties.Resources.WhiteArrowPrev16;
            this.pbPreviousRecord.Location = new System.Drawing.Point(322, 43);
            this.pbPreviousRecord.Name = "pbPreviousRecord";
            this.pbPreviousRecord.Size = new System.Drawing.Size(32, 32);
            this.pbPreviousRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPreviousRecord.TabIndex = 34901;
            this.pbPreviousRecord.TabStop = false;
            this.pbPreviousRecord.Visible = false;
            // 
            // pbFirstRecord
            // 
            this.pbFirstRecord.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pbFirstRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbFirstRecord.Image = global::QCash.Properties.Resources.WhiteArrowFirst16;
            this.pbFirstRecord.Location = new System.Drawing.Point(289, 43);
            this.pbFirstRecord.Name = "pbFirstRecord";
            this.pbFirstRecord.Size = new System.Drawing.Size(32, 32);
            this.pbFirstRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbFirstRecord.TabIndex = 34900;
            this.pbFirstRecord.TabStop = false;
            this.pbFirstRecord.Visible = false;
            // 
            // pbSearch
            // 
            this.pbSearch.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pbSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSearch.Image = global::QCash.Properties.Resources.SearchGreenHandle16;
            this.pbSearch.Location = new System.Drawing.Point(421, 43);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(32, 32);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSearch.TabIndex = 34899;
            this.pbSearch.TabStop = false;
            this.pbSearch.Visible = false;
            // 
            // txtNarration
            // 
            this.txtNarration.Location = new System.Drawing.Point(23, 257);
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(664, 36);
            this.txtNarration.StateCommon.Back.Color1 = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtNarration.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtNarration.StateCommon.Border.Rounding = 2;
            this.txtNarration.TabIndex = 5;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(285, 162);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(104, 20);
            this.kryptonLabel7.TabIndex = 29;
            this.kryptonLabel7.Values.Text = "Amount in words";
            // 
            // txtAmountInWords
            // 
            this.txtAmountInWords.Location = new System.Drawing.Point(290, 184);
            this.txtAmountInWords.Multiline = true;
            this.txtAmountInWords.Name = "txtAmountInWords";
            this.txtAmountInWords.ReadOnly = true;
            this.txtAmountInWords.Size = new System.Drawing.Size(398, 37);
            this.txtAmountInWords.StateCommon.Back.Color1 = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtAmountInWords.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtAmountInWords.StateCommon.Border.Rounding = 2;
            this.txtAmountInWords.TabIndex = 28;
            this.txtAmountInWords.TabStop = false;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(18, 236);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(62, 20);
            this.kryptonLabel6.TabIndex = 27;
            this.kryptonLabel6.Values.Text = "Narration";
            // 
            // AmountLabel
            // 
            this.AmountLabel.Location = new System.Drawing.Point(20, 162);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(55, 20);
            this.AmountLabel.TabIndex = 26;
            this.AmountLabel.Values.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(23, 184);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(260, 37);
            this.txtAmount.StateCommon.Back.Color1 = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtAmount.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtAmount.StateCommon.Border.Rounding = 2;
            this.txtAmount.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.TabIndex = 4;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbCreditAccount
            // 
            this.cmbCreditAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCreditAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCreditAccount.DropDownWidth = 152;
            this.cmbCreditAccount.Location = new System.Drawing.Point(359, 110);
            this.cmbCreditAccount.Name = "cmbCreditAccount";
            this.cmbCreditAccount.Size = new System.Drawing.Size(330, 23);
            this.cmbCreditAccount.StateCommon.ComboBox.Back.Color1 = System.Drawing.SystemColors.GradientActiveCaption;
            this.cmbCreditAccount.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbCreditAccount.StateCommon.ComboBox.Border.Rounding = 2;
            this.cmbCreditAccount.TabIndex = 3;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(355, 87);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(92, 20);
            this.kryptonLabel4.TabIndex = 23;
            this.kryptonLabel4.Values.Text = "Credit Account";
            // 
            // cmbDebitAccount
            // 
            this.cmbDebitAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbDebitAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDebitAccount.DropDownWidth = 152;
            this.cmbDebitAccount.Location = new System.Drawing.Point(23, 110);
            this.cmbDebitAccount.Name = "cmbDebitAccount";
            this.cmbDebitAccount.Size = new System.Drawing.Size(330, 23);
            this.cmbDebitAccount.StateCommon.ComboBox.Back.Color1 = System.Drawing.SystemColors.GradientActiveCaption;
            this.cmbDebitAccount.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbDebitAccount.StateCommon.ComboBox.Border.Rounding = 2;
            this.cmbDebitAccount.TabIndex = 2;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(19, 87);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(88, 20);
            this.kryptonLabel3.TabIndex = 21;
            this.kryptonLabel3.Values.Text = "Debit Account";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(459, 17);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel2.TabIndex = 20;
            this.kryptonLabel2.Values.Text = "Date";
            // 
            // VoucherLabel
            // 
            this.VoucherLabel.Location = new System.Drawing.Point(20, 16);
            this.VoucherLabel.Name = "VoucherLabel";
            this.VoucherLabel.Size = new System.Drawing.Size(78, 20);
            this.VoucherLabel.TabIndex = 19;
            this.VoucherLabel.Values.Text = "Voucher No.";
            // 
            // txtVoucherId
            // 
            this.txtVoucherId.Location = new System.Drawing.Point(23, 39);
            this.txtVoucherId.MaxLength = 12;
            this.txtVoucherId.Name = "txtVoucherId";
            this.txtVoucherId.Size = new System.Drawing.Size(432, 39);
            this.txtVoucherId.StateCommon.Back.Color1 = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtVoucherId.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtVoucherId.StateCommon.Border.Rounding = 2;
            this.txtVoucherId.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucherId.TabIndex = 0;
            // 
            // pbEntityFolder
            // 
            this.pbEntityFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbEntityFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbEntityFolder.Location = new System.Drawing.Point(683, 3);
            this.pbEntityFolder.Name = "pbEntityFolder";
            this.pbEntityFolder.Size = new System.Drawing.Size(24, 24);
            this.pbEntityFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbEntityFolder.TabIndex = 1;
            this.pbEntityFolder.TabStop = false;
            this.MyToolTip.SetToolTip(this.pbEntityFolder, "Select Existing Record");
            // 
            // lblPanelDevider
            // 
            this.lblPanelDevider.BackColor = System.Drawing.Color.SteelBlue;
            this.lblPanelDevider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPanelDevider.Location = new System.Drawing.Point(0, 344);
            this.lblPanelDevider.Name = "lblPanelDevider";
            this.lblPanelDevider.Size = new System.Drawing.Size(713, 1);
            this.lblPanelDevider.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(11, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnSave.Size = new System.Drawing.Size(76, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Values.Text = "&Save";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(172, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnDelete.Size = new System.Drawing.Size(74, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Values.Text = "&Delete";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(616, 7);
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
            this.MyProgressBar.Size = new System.Drawing.Size(341, 23);
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
            this.PanelBottomPart.Controls.Add(this.btnNewEntity);
            this.PanelBottomPart.Controls.Add(this.btnDelete);
            this.PanelBottomPart.Controls.Add(this.MyProgressBar);
            this.PanelBottomPart.Controls.Add(this.btnSave);
            this.PanelBottomPart.Controls.Add(this.btnClose);
            this.PanelBottomPart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelBottomPart.Location = new System.Drawing.Point(0, 345);
            this.PanelBottomPart.Name = "PanelBottomPart";
            this.PanelBottomPart.Size = new System.Drawing.Size(713, 44);
            this.PanelBottomPart.TabIndex = 7;
            // 
            // btnNewEntity
            // 
            this.btnNewEntity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewEntity.Location = new System.Drawing.Point(93, 7);
            this.btnNewEntity.Name = "btnNewEntity";
            this.btnNewEntity.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnNewEntity.Size = new System.Drawing.Size(74, 30);
            this.btnNewEntity.TabIndex = 1;
            this.btnNewEntity.Values.Text = "&New";
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
            // txtOperatingYear
            // 
            this.txtOperatingYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOperatingYear.Location = new System.Drawing.Point(604, 4);
            this.txtOperatingYear.Name = "txtOperatingYear";
            this.txtOperatingYear.Size = new System.Drawing.Size(69, 22);
            this.txtOperatingYear.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtOperatingYear.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtOperatingYear.StateCommon.Border.Rounding = 2;
            this.txtOperatingYear.TabIndex = 17;
            this.txtOperatingYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(713, 389);
            this.Controls.Add(this.txtOperatingYear);
            this.Controls.Add(this.pbEntityFolder);
            this.Controls.Add(this.PanelBodyPart);
            this.Controls.Add(this.lblPanelDevider);
            this.Controls.Add(this.PanelBottomPart);
            this.Controls.Add(this.MastHead);
            this.Name = "frmVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voucher";
            this.PanelBodyPart.ResumeLayout(false);
            this.PanelBodyPart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddCreditAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddDebitAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLastRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNextRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviousRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirstRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCreditAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDebitAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEntityFolder)).EndInit();
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
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDelete;
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
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNewEntity;
        private System.Windows.Forms.PictureBox pbEntityFolder;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNarration;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAmountInWords;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel AmountLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAmount;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbCreditAccount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbDebitAccount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel VoucherLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtEntryDate;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtVoucherId;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtOperatingYear;
        private System.Windows.Forms.MonthCalendar mcDate;
        private System.Windows.Forms.PictureBox pbPrint;
        private System.Windows.Forms.PictureBox pbLastRecord;
        private System.Windows.Forms.PictureBox pbNextRecord;
        private System.Windows.Forms.PictureBox pbPreviousRecord;
        private System.Windows.Forms.PictureBox pbFirstRecord;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.PictureBox pbAddDebitAccount;
        private System.Windows.Forms.PictureBox pbAddCreditAccount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblCreditAccountBalance;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblDebitAccountBalance;
    }
}

