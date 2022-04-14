namespace QCash.ViewMenuForms
{
    partial class frmCashBook
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
            this.panelCreditSide = new System.Windows.Forms.Panel();
            this.lblCreditSideIcon = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label29 = new System.Windows.Forms.Label();
            this.lblCashInHand = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.lblCrDayTotal = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.dgCrSideCashBook = new System.Windows.Forms.DataGridView();
            this.Label18 = new System.Windows.Forms.Label();
            this.Label27 = new System.Windows.Forms.Label();
            this.Label28 = new System.Windows.Forms.Label();
            this.lblDrDayTotal2 = new System.Windows.Forms.Label();
            this.panelDebitSide = new System.Windows.Forms.Panel();
            this.lblDebitSideIcon = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.lblDrLine1 = new System.Windows.Forms.Label();
            this.Label22 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.lblDrDayTotal = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.dgDrSideCashBook = new System.Windows.Forms.DataGridView();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.lblPanelDevider = new System.Windows.Forms.Label();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.MyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pbResetCashbookToCurrentDate = new System.Windows.Forms.PictureBox();
            this.pbLoadCashBook = new System.Windows.Forms.PictureBox();
            this.pbPrint = new System.Windows.Forms.PictureBox();
            this.MyProgressBar = new System.Windows.Forms.ProgressBar();
            this.bgwPrimaryWorker = new System.ComponentModel.BackgroundWorker();
            this.PanelBottomPart = new System.Windows.Forms.Panel();
            this.cmbCashBookDate = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnPrevDate = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnNextDate = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtDate = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.contextMenuSetFocusOrder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemAddFocus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemRemoveFocus = new System.Windows.Forms.ToolStripMenuItem();
            this.RedToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bsCurrentEntity = new System.Windows.Forms.BindingSource(this.components);
            this.PanelBodyPart.SuspendLayout();
            this.panelCreditSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCrSideCashBook)).BeginInit();
            this.panelDebitSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDrSideCashBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbResetCashbookToCurrentDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadCashBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).BeginInit();
            this.PanelBottomPart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCashBookDate)).BeginInit();
            this.contextMenuSetFocusOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCurrentEntity)).BeginInit();
            this.SuspendLayout();
            // 
            // MastHead
            // 
            this.MastHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.MastHead.Location = new System.Drawing.Point(0, 0);
            this.MastHead.Name = "MastHead";
            this.MastHead.Size = new System.Drawing.Size(999, 36);
            this.MastHead.TabIndex = 0;
            this.MastHead.Values.Description = "";
            this.MastHead.Values.Heading = "Cashbook";
            this.MastHead.Values.Image = global::QCash.Properties.Resources.CashBook32;
            // 
            // PanelBodyPart
            // 
            this.PanelBodyPart.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PanelBodyPart.Controls.Add(this.panelCreditSide);
            this.PanelBodyPart.Controls.Add(this.panelDebitSide);
            this.PanelBodyPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBodyPart.Location = new System.Drawing.Point(0, 36);
            this.PanelBodyPart.Name = "PanelBodyPart";
            this.PanelBodyPart.Size = new System.Drawing.Size(999, 382);
            this.PanelBodyPart.TabIndex = 1;
            // 
            // panelCreditSide
            // 
            this.panelCreditSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCreditSide.Controls.Add(this.lblCreditSideIcon);
            this.panelCreditSide.Controls.Add(this.Label11);
            this.panelCreditSide.Controls.Add(this.Label14);
            this.panelCreditSide.Controls.Add(this.Label29);
            this.panelCreditSide.Controls.Add(this.lblCashInHand);
            this.panelCreditSide.Controls.Add(this.Label7);
            this.panelCreditSide.Controls.Add(this.lblCrDayTotal);
            this.panelCreditSide.Controls.Add(this.Label12);
            this.panelCreditSide.Controls.Add(this.Label3);
            this.panelCreditSide.Controls.Add(this.Label5);
            this.panelCreditSide.Controls.Add(this.Label13);
            this.panelCreditSide.Controls.Add(this.Label17);
            this.panelCreditSide.Controls.Add(this.dgCrSideCashBook);
            this.panelCreditSide.Controls.Add(this.Label18);
            this.panelCreditSide.Controls.Add(this.Label27);
            this.panelCreditSide.Controls.Add(this.Label28);
            this.panelCreditSide.Controls.Add(this.lblDrDayTotal2);
            this.panelCreditSide.Location = new System.Drawing.Point(496, 4);
            this.panelCreditSide.Name = "panelCreditSide";
            this.panelCreditSide.Size = new System.Drawing.Size(499, 379);
            this.panelCreditSide.TabIndex = 3;
            // 
            // lblCreditSideIcon
            // 
            this.lblCreditSideIcon.ForeColor = System.Drawing.Color.White;
            this.lblCreditSideIcon.Image = global::QCash.Properties.Resources.CashPayment16;
            this.lblCreditSideIcon.Location = new System.Drawing.Point(10, 353);
            this.lblCreditSideIcon.Name = "lblCreditSideIcon";
            this.lblCreditSideIcon.Size = new System.Drawing.Size(16, 16);
            this.lblCreditSideIcon.TabIndex = 132;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(102, 353);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(125, 13);
            this.Label11.TabIndex = 131;
            this.Label11.Text = "(Comes from Dr Voucher)";
            this.Label11.Visible = false;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.ForeColor = System.Drawing.Color.Black;
            this.Label14.Location = new System.Drawing.Point(32, 352);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(58, 13);
            this.Label14.TabIndex = 130;
            this.Label14.Text = "Credit Side";
            // 
            // Label29
            // 
            this.Label29.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label29.Location = new System.Drawing.Point(228, 331);
            this.Label29.Name = "Label29";
            this.Label29.Size = new System.Drawing.Size(158, 18);
            this.Label29.TabIndex = 129;
            this.Label29.Text = "Cash-In-Hand";
            this.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCashInHand
            // 
            this.lblCashInHand.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblCashInHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCashInHand.Location = new System.Drawing.Point(385, 331);
            this.lblCashInHand.Name = "lblCashInHand";
            this.lblCashInHand.Padding = new System.Windows.Forms.Padding(0, 0, 23, 0);
            this.lblCashInHand.Size = new System.Drawing.Size(103, 18);
            this.lblCashInHand.TabIndex = 128;
            this.lblCashInHand.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label7.Location = new System.Drawing.Point(228, 314);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(158, 18);
            this.Label7.TabIndex = 123;
            this.Label7.Text = "Day Total";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCrDayTotal
            // 
            this.lblCrDayTotal.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblCrDayTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCrDayTotal.Location = new System.Drawing.Point(385, 314);
            this.lblCrDayTotal.Name = "lblCrDayTotal";
            this.lblCrDayTotal.Padding = new System.Windows.Forms.Padding(0, 0, 23, 0);
            this.lblCrDayTotal.Size = new System.Drawing.Size(103, 18);
            this.lblCrDayTotal.TabIndex = 122;
            this.lblCrDayTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label12
            // 
            this.Label12.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label12.Location = new System.Drawing.Point(6, 314);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(482, 35);
            this.Label12.TabIndex = 127;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(63, 7);
            this.Label3.Margin = new System.Windows.Forms.Padding(0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(1, 310);
            this.Label3.TabIndex = 125;
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label5.Location = new System.Drawing.Point(6, 6);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(58, 32);
            this.Label5.TabIndex = 126;
            this.Label5.Text = "V. No";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label13
            // 
            this.Label13.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.Location = new System.Drawing.Point(384, 7);
            this.Label13.Margin = new System.Windows.Forms.Padding(0);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(1, 310);
            this.Label13.TabIndex = 121;
            // 
            // Label17
            // 
            this.Label17.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label17.Location = new System.Drawing.Point(314, 7);
            this.Label17.Margin = new System.Windows.Forms.Padding(0);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(1, 310);
            this.Label17.TabIndex = 120;
            // 
            // dgCrSideCashBook
            // 
            this.dgCrSideCashBook.AllowUserToAddRows = false;
            this.dgCrSideCashBook.AllowUserToDeleteRows = false;
            this.dgCrSideCashBook.AllowUserToResizeColumns = false;
            this.dgCrSideCashBook.AllowUserToResizeRows = false;
            this.dgCrSideCashBook.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgCrSideCashBook.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgCrSideCashBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCrSideCashBook.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCrSideCashBook.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgCrSideCashBook.Location = new System.Drawing.Point(6, 37);
            this.dgCrSideCashBook.MultiSelect = false;
            this.dgCrSideCashBook.Name = "dgCrSideCashBook";
            this.dgCrSideCashBook.ReadOnly = true;
            this.dgCrSideCashBook.RowHeadersVisible = false;
            this.dgCrSideCashBook.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgCrSideCashBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCrSideCashBook.Size = new System.Drawing.Size(482, 278);
            this.dgCrSideCashBook.TabIndex = 116;
            this.dgCrSideCashBook.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCrSideCashBook_CellDoubleClick);
            // 
            // Label18
            // 
            this.Label18.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label18.Location = new System.Drawing.Point(63, 6);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(252, 32);
            this.Label18.TabIndex = 117;
            this.Label18.Text = "Particulars";
            this.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label27
            // 
            this.Label27.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label27.Location = new System.Drawing.Point(314, 6);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(71, 32);
            this.Label27.TabIndex = 118;
            this.Label27.Text = "A/C Code";
            this.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label28
            // 
            this.Label28.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label28.Location = new System.Drawing.Point(384, 6);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(104, 32);
            this.Label28.TabIndex = 119;
            this.Label28.Text = "Cash";
            this.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDrDayTotal2
            // 
            this.lblDrDayTotal2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDrDayTotal2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDrDayTotal2.Location = new System.Drawing.Point(385, 348);
            this.lblDrDayTotal2.Name = "lblDrDayTotal2";
            this.lblDrDayTotal2.Padding = new System.Windows.Forms.Padding(0, 0, 23, 0);
            this.lblDrDayTotal2.Size = new System.Drawing.Size(103, 18);
            this.lblDrDayTotal2.TabIndex = 124;
            this.lblDrDayTotal2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelDebitSide
            // 
            this.panelDebitSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDebitSide.Controls.Add(this.lblDebitSideIcon);
            this.panelDebitSide.Controls.Add(this.Label9);
            this.panelDebitSide.Controls.Add(this.Label10);
            this.panelDebitSide.Controls.Add(this.lblDrLine1);
            this.panelDebitSide.Controls.Add(this.Label22);
            this.panelDebitSide.Controls.Add(this.Label15);
            this.panelDebitSide.Controls.Add(this.lblDrDayTotal);
            this.panelDebitSide.Controls.Add(this.Label2);
            this.panelDebitSide.Controls.Add(this.Label4);
            this.panelDebitSide.Controls.Add(this.dgDrSideCashBook);
            this.panelDebitSide.Controls.Add(this.Label6);
            this.panelDebitSide.Controls.Add(this.Label20);
            this.panelDebitSide.Controls.Add(this.Label21);
            this.panelDebitSide.Location = new System.Drawing.Point(4, 4);
            this.panelDebitSide.Name = "panelDebitSide";
            this.panelDebitSide.Size = new System.Drawing.Size(493, 379);
            this.panelDebitSide.TabIndex = 2;
            // 
            // lblDebitSideIcon
            // 
            this.lblDebitSideIcon.ForeColor = System.Drawing.Color.White;
            this.lblDebitSideIcon.Image = global::QCash.Properties.Resources.CashReceive16;
            this.lblDebitSideIcon.Location = new System.Drawing.Point(7, 353);
            this.lblDebitSideIcon.Name = "lblDebitSideIcon";
            this.lblDebitSideIcon.Size = new System.Drawing.Size(16, 16);
            this.lblDebitSideIcon.TabIndex = 127;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(91, 353);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(124, 13);
            this.Label9.TabIndex = 126;
            this.Label9.Text = "(Comes from Cr Voucher)";
            this.Label9.Visible = false;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.ForeColor = System.Drawing.Color.Black;
            this.Label10.Location = new System.Drawing.Point(29, 353);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(56, 13);
            this.Label10.TabIndex = 125;
            this.Label10.Text = "Debit Side";
            // 
            // lblDrLine1
            // 
            this.lblDrLine1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDrLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrLine1.Location = new System.Drawing.Point(61, 7);
            this.lblDrLine1.Margin = new System.Windows.Forms.Padding(0);
            this.lblDrLine1.Name = "lblDrLine1";
            this.lblDrLine1.Size = new System.Drawing.Size(1, 342);
            this.lblDrLine1.TabIndex = 123;
            // 
            // Label22
            // 
            this.Label22.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label22.Location = new System.Drawing.Point(4, 6);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(58, 32);
            this.Label22.TabIndex = 124;
            this.Label22.Text = "V. No";
            this.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label15
            // 
            this.Label15.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label15.Location = new System.Drawing.Point(312, 348);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(72, 18);
            this.Label15.TabIndex = 122;
            this.Label15.Text = "Day Total";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDrDayTotal
            // 
            this.lblDrDayTotal.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblDrDayTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDrDayTotal.Location = new System.Drawing.Point(383, 348);
            this.lblDrDayTotal.Name = "lblDrDayTotal";
            this.lblDrDayTotal.Padding = new System.Windows.Forms.Padding(0, 0, 23, 0);
            this.lblDrDayTotal.Size = new System.Drawing.Size(103, 18);
            this.lblDrDayTotal.TabIndex = 121;
            this.lblDrDayTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(382, 7);
            this.Label2.Margin = new System.Windows.Forms.Padding(0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(1, 342);
            this.Label2.TabIndex = 120;
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(312, 7);
            this.Label4.Margin = new System.Windows.Forms.Padding(0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(1, 342);
            this.Label4.TabIndex = 119;
            // 
            // dgDrSideCashBook
            // 
            this.dgDrSideCashBook.AllowUserToAddRows = false;
            this.dgDrSideCashBook.AllowUserToDeleteRows = false;
            this.dgDrSideCashBook.AllowUserToResizeColumns = false;
            this.dgDrSideCashBook.AllowUserToResizeRows = false;
            this.dgDrSideCashBook.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgDrSideCashBook.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgDrSideCashBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDrSideCashBook.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgDrSideCashBook.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgDrSideCashBook.Location = new System.Drawing.Point(4, 37);
            this.dgDrSideCashBook.MultiSelect = false;
            this.dgDrSideCashBook.Name = "dgDrSideCashBook";
            this.dgDrSideCashBook.ReadOnly = true;
            this.dgDrSideCashBook.RowHeadersVisible = false;
            this.dgDrSideCashBook.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgDrSideCashBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDrSideCashBook.Size = new System.Drawing.Size(482, 312);
            this.dgDrSideCashBook.TabIndex = 115;
            this.dgDrSideCashBook.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDrSideCashBook_CellDoubleClick);
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label6.Location = new System.Drawing.Point(61, 6);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(252, 32);
            this.Label6.TabIndex = 116;
            this.Label6.Text = "Particulars";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label20
            // 
            this.Label20.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label20.Location = new System.Drawing.Point(312, 6);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(71, 32);
            this.Label20.TabIndex = 117;
            this.Label20.Text = "A/C Code";
            this.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label21
            // 
            this.Label21.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label21.Location = new System.Drawing.Point(382, 6);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(104, 32);
            this.Label21.TabIndex = 118;
            this.Label21.Text = "Cash";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPanelDevider
            // 
            this.lblPanelDevider.BackColor = System.Drawing.Color.SteelBlue;
            this.lblPanelDevider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPanelDevider.Location = new System.Drawing.Point(0, 418);
            this.lblPanelDevider.Name = "lblPanelDevider";
            this.lblPanelDevider.Size = new System.Drawing.Size(999, 1);
            this.lblPanelDevider.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(902, 7);
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
            // pbResetCashbookToCurrentDate
            // 
            this.pbResetCashbookToCurrentDate.BackColor = System.Drawing.Color.White;
            this.pbResetCashbookToCurrentDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbResetCashbookToCurrentDate.Image = global::QCash.Properties.Resources.ResetCashBook16;
            this.pbResetCashbookToCurrentDate.Location = new System.Drawing.Point(194, 10);
            this.pbResetCashbookToCurrentDate.Name = "pbResetCashbookToCurrentDate";
            this.pbResetCashbookToCurrentDate.Size = new System.Drawing.Size(32, 21);
            this.pbResetCashbookToCurrentDate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbResetCashbookToCurrentDate.TabIndex = 145;
            this.pbResetCashbookToCurrentDate.TabStop = false;
            this.MyToolTip.SetToolTip(this.pbResetCashbookToCurrentDate, "Reload Todays Cashbook.");
            this.pbResetCashbookToCurrentDate.Click += new System.EventHandler(this.pbResetCashbookToCurrentDate_Click);
            // 
            // pbLoadCashBook
            // 
            this.pbLoadCashBook.BackColor = System.Drawing.Color.White;
            this.pbLoadCashBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLoadCashBook.Image = global::QCash.Properties.Resources.WhiteArrowNext16;
            this.pbLoadCashBook.Location = new System.Drawing.Point(160, 10);
            this.pbLoadCashBook.Name = "pbLoadCashBook";
            this.pbLoadCashBook.Size = new System.Drawing.Size(32, 21);
            this.pbLoadCashBook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbLoadCashBook.TabIndex = 143;
            this.pbLoadCashBook.TabStop = false;
            this.MyToolTip.SetToolTip(this.pbLoadCashBook, "Load Cashbook for the selected date.");
            this.pbLoadCashBook.Click += new System.EventHandler(this.pbLoadCashBook_Click);
            // 
            // pbPrint
            // 
            this.pbPrint.BackColor = System.Drawing.Color.White;
            this.pbPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPrint.Image = global::QCash.Properties.Resources.PrinterGreen16;
            this.pbPrint.Location = new System.Drawing.Point(228, 10);
            this.pbPrint.Name = "pbPrint";
            this.pbPrint.Size = new System.Drawing.Size(32, 21);
            this.pbPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPrint.TabIndex = 146;
            this.pbPrint.TabStop = false;
            this.MyToolTip.SetToolTip(this.pbPrint, "Cashbook Print Preview.");
            // 
            // MyProgressBar
            // 
            this.MyProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyProgressBar.Location = new System.Drawing.Point(644, 10);
            this.MyProgressBar.Name = "MyProgressBar";
            this.MyProgressBar.Size = new System.Drawing.Size(252, 23);
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
            this.PanelBottomPart.Controls.Add(this.pbPrint);
            this.PanelBottomPart.Controls.Add(this.pbResetCashbookToCurrentDate);
            this.PanelBottomPart.Controls.Add(this.pbLoadCashBook);
            this.PanelBottomPart.Controls.Add(this.cmbCashBookDate);
            this.PanelBottomPart.Controls.Add(this.kryptonTextBox1);
            this.PanelBottomPart.Controls.Add(this.kryptonLabel2);
            this.PanelBottomPart.Controls.Add(this.txtDate);
            this.PanelBottomPart.Controls.Add(this.MyProgressBar);
            this.PanelBottomPart.Controls.Add(this.btnClose);
            this.PanelBottomPart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelBottomPart.Location = new System.Drawing.Point(0, 419);
            this.PanelBottomPart.Name = "PanelBottomPart";
            this.PanelBottomPart.Size = new System.Drawing.Size(999, 44);
            this.PanelBottomPart.TabIndex = 7;
            // 
            // cmbCashBookDate
            // 
            this.cmbCashBookDate.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnPrevDate,
            this.btnNextDate});
            this.cmbCashBookDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCashBookDate.DropDownWidth = 122;
            this.cmbCashBookDate.Location = new System.Drawing.Point(6, 9);
            this.cmbCashBookDate.Name = "cmbCashBookDate";
            this.cmbCashBookDate.Size = new System.Drawing.Size(159, 23);
            this.cmbCashBookDate.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbCashBookDate.StateCommon.ComboBox.Border.Rounding = 3;
            this.cmbCashBookDate.StateCommon.ComboBox.Content.Padding = new System.Windows.Forms.Padding(2);
            this.cmbCashBookDate.TabIndex = 139;
            // 
            // btnPrevDate
            // 
            this.btnPrevDate.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.ArrowLeft;
            this.btnPrevDate.UniqueName = "8DF5406CF30B49403A86A3A3C8126E0B";
            // 
            // btnNextDate
            // 
            this.btnNextDate.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.ArrowRight;
            this.btnNextDate.UniqueName = "B5BF415AFCC3437B8FB56F9DCEDDED5A";
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(160, 9);
            this.kryptonTextBox1.Multiline = true;
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(108, 23);
            this.kryptonTextBox1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonTextBox1.StateCommon.Border.Rounding = 3;
            this.kryptonTextBox1.StateCommon.Content.Padding = new System.Windows.Forms.Padding(2);
            this.kryptonTextBox1.TabIndex = 144;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(338, 12);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(46, 20);
            this.kryptonLabel2.TabIndex = 141;
            this.kryptonLabel2.Values.Text = "Today:";
            this.kryptonLabel2.Visible = false;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(387, 10);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(79, 24);
            this.txtDate.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtDate.StateCommon.Border.Rounding = 3;
            this.txtDate.StateCommon.Content.Padding = new System.Windows.Forms.Padding(2);
            this.txtDate.TabIndex = 138;
            this.txtDate.Visible = false;
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
            // frmCashBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(999, 463);
            this.Controls.Add(this.PanelBodyPart);
            this.Controls.Add(this.lblPanelDevider);
            this.Controls.Add(this.PanelBottomPart);
            this.Controls.Add(this.MastHead);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1015, 501);
            this.MinimumSize = new System.Drawing.Size(1015, 501);
            this.Name = "frmCashBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cashbook";
            this.PanelBodyPart.ResumeLayout(false);
            this.panelCreditSide.ResumeLayout(false);
            this.panelCreditSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCrSideCashBook)).EndInit();
            this.panelDebitSide.ResumeLayout(false);
            this.panelDebitSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDrSideCashBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbResetCashbookToCurrentDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadCashBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).EndInit();
            this.PanelBottomPart.ResumeLayout(false);
            this.PanelBottomPart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCashBookDate)).EndInit();
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
        private System.Windows.Forms.Panel panelCreditSide;
        internal System.Windows.Forms.Label lblCreditSideIcon;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label29;
        internal System.Windows.Forms.Label lblCashInHand;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label lblCrDayTotal;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.DataGridView dgCrSideCashBook;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.Label Label27;
        internal System.Windows.Forms.Label Label28;
        internal System.Windows.Forms.Label lblDrDayTotal2;
        private System.Windows.Forms.Panel panelDebitSide;
        internal System.Windows.Forms.Label lblDebitSideIcon;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label lblDrLine1;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label lblDrDayTotal;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.DataGridView dgDrSideCashBook;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Label Label21;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbCashBookDate;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnPrevDate;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnNextDate;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDate;
        private System.Windows.Forms.PictureBox pbLoadCashBook;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private System.Windows.Forms.PictureBox pbResetCashbookToCurrentDate;
        private System.Windows.Forms.PictureBox pbPrint;
    }
}

