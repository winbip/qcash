namespace QCash.ViewMenuForms
{
    partial class frmGeneralLedger
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
            this.MastHead = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.PanelBodyPart = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRecordNotFound = new System.Windows.Forms.Label();
            this.txtDebitAmountGrandTotal = new System.Windows.Forms.TextBox();
            this.txtCreditAmountGrandTotal = new System.Windows.Forms.TextBox();
            this.Label30 = new System.Windows.Forms.Label();
            this.Label31 = new System.Windows.Forms.Label();
            this.VLine3 = new System.Windows.Forms.Label();
            this.VLine4 = new System.Windows.Forms.Label();
            this.VLine1 = new System.Windows.Forms.Label();
            this.Label34 = new System.Windows.Forms.Label();
            this.VLine2 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label33 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label32 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblBalanceDr = new System.Windows.Forms.Label();
            this.lblBalanceCr = new System.Windows.Forms.Label();
            this.dgLedgerRecords = new System.Windows.Forms.DataGridView();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.lblPanelDevider = new System.Windows.Forms.Label();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.MyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MyProgressBar = new System.Windows.Forms.ProgressBar();
            this.bgwPrimaryWorker = new System.ComponentModel.BackgroundWorker();
            this.PanelBottomPart = new System.Windows.Forms.Panel();
            this.btnFilter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cmbAccountList = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnPrint = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnShow = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.contextMenuSetFocusOrder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemAddFocus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemRemoveFocus = new System.Windows.Forms.ToolStripMenuItem();
            this.RedToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bsCurrentEntity = new System.Windows.Forms.BindingSource(this.components);
            this.txtOperatingYear = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.PanelBodyPart.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLedgerRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).BeginInit();
            this.PanelBottomPart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAccountList)).BeginInit();
            this.contextMenuSetFocusOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCurrentEntity)).BeginInit();
            this.SuspendLayout();
            // 
            // MastHead
            // 
            this.MastHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.MastHead.Location = new System.Drawing.Point(0, 0);
            this.MastHead.Name = "MastHead";
            this.MastHead.Size = new System.Drawing.Size(1036, 36);
            this.MastHead.TabIndex = 0;
            this.MastHead.Values.Description = "";
            this.MastHead.Values.Heading = "General Ledger";
            this.MastHead.Values.Image = global::QCash.Properties.Resources.LedgerBookPng32;
            // 
            // PanelBodyPart
            // 
            this.PanelBodyPart.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PanelBodyPart.Controls.Add(this.panel1);
            this.PanelBodyPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBodyPart.Location = new System.Drawing.Point(0, 36);
            this.PanelBodyPart.Name = "PanelBodyPart";
            this.PanelBodyPart.Size = new System.Drawing.Size(1036, 316);
            this.PanelBodyPart.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.lblRecordNotFound);
            this.panel1.Controls.Add(this.txtDebitAmountGrandTotal);
            this.panel1.Controls.Add(this.txtCreditAmountGrandTotal);
            this.panel1.Controls.Add(this.Label30);
            this.panel1.Controls.Add(this.Label31);
            this.panel1.Controls.Add(this.VLine3);
            this.panel1.Controls.Add(this.VLine4);
            this.panel1.Controls.Add(this.VLine1);
            this.panel1.Controls.Add(this.Label34);
            this.panel1.Controls.Add(this.VLine2);
            this.panel1.Controls.Add(this.Label10);
            this.panel1.Controls.Add(this.Label33);
            this.panel1.Controls.Add(this.Label9);
            this.panel1.Controls.Add(this.Label5);
            this.panel1.Controls.Add(this.Label32);
            this.panel1.Controls.Add(this.Label3);
            this.panel1.Controls.Add(this.Label8);
            this.panel1.Controls.Add(this.Label7);
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.lblBalanceDr);
            this.panel1.Controls.Add(this.lblBalanceCr);
            this.panel1.Controls.Add(this.dgLedgerRecords);
            this.panel1.Controls.Add(this.Label6);
            this.panel1.Controls.Add(this.Label20);
            this.panel1.Location = new System.Drawing.Point(8, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1017, 298);
            this.panel1.TabIndex = 1;
            // 
            // lblRecordNotFound
            // 
            this.lblRecordNotFound.AutoSize = true;
            this.lblRecordNotFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordNotFound.Location = new System.Drawing.Point(368, 138);
            this.lblRecordNotFound.Name = "lblRecordNotFound";
            this.lblRecordNotFound.Size = new System.Drawing.Size(193, 25);
            this.lblRecordNotFound.TabIndex = 149;
            this.lblRecordNotFound.Text = "Record not found";
            this.lblRecordNotFound.Visible = false;
            // 
            // txtDebitAmountGrandTotal
            // 
            this.txtDebitAmountGrandTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDebitAmountGrandTotal.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtDebitAmountGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDebitAmountGrandTotal.Location = new System.Drawing.Point(524, 272);
            this.txtDebitAmountGrandTotal.Name = "txtDebitAmountGrandTotal";
            this.txtDebitAmountGrandTotal.ReadOnly = true;
            this.txtDebitAmountGrandTotal.Size = new System.Drawing.Size(110, 20);
            this.txtDebitAmountGrandTotal.TabIndex = 7;
            this.txtDebitAmountGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCreditAmountGrandTotal
            // 
            this.txtCreditAmountGrandTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCreditAmountGrandTotal.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtCreditAmountGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCreditAmountGrandTotal.Location = new System.Drawing.Point(633, 272);
            this.txtCreditAmountGrandTotal.Name = "txtCreditAmountGrandTotal";
            this.txtCreditAmountGrandTotal.ReadOnly = true;
            this.txtCreditAmountGrandTotal.Size = new System.Drawing.Size(110, 20);
            this.txtCreditAmountGrandTotal.TabIndex = 8;
            this.txtCreditAmountGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label30
            // 
            this.Label30.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Label30.BackColor = System.Drawing.Color.Black;
            this.Label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label30.Location = new System.Drawing.Point(633, 7);
            this.Label30.Margin = new System.Windows.Forms.Padding(0);
            this.Label30.Name = "Label30";
            this.Label30.Size = new System.Drawing.Size(1, 266);
            this.Label30.TabIndex = 143;
            // 
            // Label31
            // 
            this.Label31.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Label31.BackColor = System.Drawing.Color.Black;
            this.Label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label31.Location = new System.Drawing.Point(524, 6);
            this.Label31.Margin = new System.Windows.Forms.Padding(0);
            this.Label31.Name = "Label31";
            this.Label31.Size = new System.Drawing.Size(1, 266);
            this.Label31.TabIndex = 142;
            // 
            // VLine3
            // 
            this.VLine3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.VLine3.BackColor = System.Drawing.Color.Black;
            this.VLine3.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VLine3.Location = new System.Drawing.Point(190, 7);
            this.VLine3.Margin = new System.Windows.Forms.Padding(0);
            this.VLine3.Name = "VLine3";
            this.VLine3.Size = new System.Drawing.Size(1, 266);
            this.VLine3.TabIndex = 129;
            // 
            // VLine4
            // 
            this.VLine4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.VLine4.BackColor = System.Drawing.Color.Black;
            this.VLine4.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VLine4.Location = new System.Drawing.Point(472, 7);
            this.VLine4.Margin = new System.Windows.Forms.Padding(0);
            this.VLine4.Name = "VLine4";
            this.VLine4.Size = new System.Drawing.Size(1, 266);
            this.VLine4.TabIndex = 141;
            // 
            // VLine1
            // 
            this.VLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.VLine1.BackColor = System.Drawing.Color.Black;
            this.VLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VLine1.Location = new System.Drawing.Point(64, 7);
            this.VLine1.Margin = new System.Windows.Forms.Padding(0);
            this.VLine1.Name = "VLine1";
            this.VLine1.Size = new System.Drawing.Size(1, 266);
            this.VLine1.TabIndex = 140;
            // 
            // Label34
            // 
            this.Label34.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Label34.BackColor = System.Drawing.Color.Black;
            this.Label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label34.Location = new System.Drawing.Point(960, 6);
            this.Label34.Margin = new System.Windows.Forms.Padding(0);
            this.Label34.Name = "Label34";
            this.Label34.Size = new System.Drawing.Size(1, 266);
            this.Label34.TabIndex = 146;
            // 
            // VLine2
            // 
            this.VLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.VLine2.BackColor = System.Drawing.Color.Black;
            this.VLine2.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VLine2.Location = new System.Drawing.Point(141, 7);
            this.VLine2.Margin = new System.Windows.Forms.Padding(0);
            this.VLine2.Name = "VLine2";
            this.VLine2.Size = new System.Drawing.Size(1, 266);
            this.VLine2.TabIndex = 130;
            // 
            // Label10
            // 
            this.Label10.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label10.ForeColor = System.Drawing.Color.Black;
            this.Label10.Location = new System.Drawing.Point(961, 6);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(47, 36);
            this.Label10.TabIndex = 139;
            this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label33
            // 
            this.Label33.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Label33.BackColor = System.Drawing.Color.Black;
            this.Label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label33.Location = new System.Drawing.Point(851, 26);
            this.Label33.Margin = new System.Windows.Forms.Padding(0);
            this.Label33.Name = "Label33";
            this.Label33.Size = new System.Drawing.Size(1, 246);
            this.Label33.TabIndex = 145;
            // 
            // Label9
            // 
            this.Label9.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(4, 6);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(61, 36);
            this.Label9.TabIndex = 138;
            this.Label9.Text = "Serial";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(64, 6);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(78, 36);
            this.Label5.TabIndex = 137;
            this.Label5.Text = "Date";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label32
            // 
            this.Label32.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Label32.BackColor = System.Drawing.Color.Black;
            this.Label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label32.Location = new System.Drawing.Point(742, 7);
            this.Label32.Margin = new System.Windows.Forms.Padding(0);
            this.Label32.Name = "Label32";
            this.Label32.Size = new System.Drawing.Size(1, 266);
            this.Label32.TabIndex = 144;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(141, 6);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(50, 36);
            this.Label3.TabIndex = 136;
            this.Label3.Text = "V. No";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label8
            // 
            this.Label8.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(472, 6);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(53, 36);
            this.Label8.TabIndex = 135;
            this.Label8.Text = "Code";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(524, 6);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(110, 36);
            this.Label7.TabIndex = 134;
            this.Label7.Text = "Debit Amount";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(742, 6);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(219, 20);
            this.Label1.TabIndex = 131;
            this.Label1.Text = "Balance";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBalanceDr
            // 
            this.lblBalanceDr.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBalanceDr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBalanceDr.ForeColor = System.Drawing.Color.Black;
            this.lblBalanceDr.Location = new System.Drawing.Point(742, 25);
            this.lblBalanceDr.Name = "lblBalanceDr";
            this.lblBalanceDr.Size = new System.Drawing.Size(110, 17);
            this.lblBalanceDr.TabIndex = 133;
            this.lblBalanceDr.Text = "Debit";
            this.lblBalanceDr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBalanceCr
            // 
            this.lblBalanceCr.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBalanceCr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBalanceCr.ForeColor = System.Drawing.Color.Black;
            this.lblBalanceCr.Location = new System.Drawing.Point(851, 25);
            this.lblBalanceCr.Name = "lblBalanceCr";
            this.lblBalanceCr.Size = new System.Drawing.Size(110, 17);
            this.lblBalanceCr.TabIndex = 132;
            this.lblBalanceCr.Text = "Credit";
            this.lblBalanceCr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgLedgerRecords
            // 
            this.dgLedgerRecords.AllowUserToAddRows = false;
            this.dgLedgerRecords.AllowUserToDeleteRows = false;
            this.dgLedgerRecords.AllowUserToResizeColumns = false;
            this.dgLedgerRecords.AllowUserToResizeRows = false;
            this.dgLedgerRecords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgLedgerRecords.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgLedgerRecords.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgLedgerRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLedgerRecords.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgLedgerRecords.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgLedgerRecords.Location = new System.Drawing.Point(4, 41);
            this.dgLedgerRecords.MultiSelect = false;
            this.dgLedgerRecords.Name = "dgLedgerRecords";
            this.dgLedgerRecords.ReadOnly = true;
            this.dgLedgerRecords.RowHeadersVisible = false;
            this.dgLedgerRecords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgLedgerRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLedgerRecords.Size = new System.Drawing.Size(1004, 232);
            this.dgLedgerRecords.TabIndex = 126;
            this.dgLedgerRecords.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLedgerRecords_CellDoubleClick);
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(190, 6);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(283, 36);
            this.Label6.TabIndex = 127;
            this.Label6.Text = "Particulars";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label20
            // 
            this.Label20.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label20.ForeColor = System.Drawing.Color.Black;
            this.Label20.Location = new System.Drawing.Point(633, 6);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(110, 36);
            this.Label20.TabIndex = 128;
            this.Label20.Text = "Credit Amount";
            this.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPanelDevider
            // 
            this.lblPanelDevider.BackColor = System.Drawing.Color.SteelBlue;
            this.lblPanelDevider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPanelDevider.Location = new System.Drawing.Point(0, 352);
            this.lblPanelDevider.Name = "lblPanelDevider";
            this.lblPanelDevider.Size = new System.Drawing.Size(1036, 1);
            this.lblPanelDevider.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(939, 7);
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
            this.MyProgressBar.Location = new System.Drawing.Point(570, 10);
            this.MyProgressBar.Name = "MyProgressBar";
            this.MyProgressBar.Size = new System.Drawing.Size(363, 23);
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
            this.PanelBottomPart.Controls.Add(this.btnFilter);
            this.PanelBottomPart.Controls.Add(this.cmbAccountList);
            this.PanelBottomPart.Controls.Add(this.btnPrint);
            this.PanelBottomPart.Controls.Add(this.btnShow);
            this.PanelBottomPart.Controls.Add(this.MyProgressBar);
            this.PanelBottomPart.Controls.Add(this.btnClose);
            this.PanelBottomPart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelBottomPart.Location = new System.Drawing.Point(0, 353);
            this.PanelBottomPart.Name = "PanelBottomPart";
            this.PanelBottomPart.Size = new System.Drawing.Size(1036, 44);
            this.PanelBottomPart.TabIndex = 7;
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilter.Location = new System.Drawing.Point(349, 8);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnFilter.Size = new System.Drawing.Size(76, 24);
            this.btnFilter.TabIndex = 15;
            this.btnFilter.Values.Text = "Filter";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cmbAccountList
            // 
            this.cmbAccountList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbAccountList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAccountList.DropDownWidth = 170;
            this.cmbAccountList.Location = new System.Drawing.Point(8, 9);
            this.cmbAccountList.Name = "cmbAccountList";
            this.cmbAccountList.Size = new System.Drawing.Size(172, 23);
            this.cmbAccountList.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbAccountList.StateCommon.ComboBox.Border.Rounding = 3;
            this.cmbAccountList.StateCommon.ComboBox.Content.Padding = new System.Windows.Forms.Padding(2);
            this.cmbAccountList.TabIndex = 14;
            this.cmbAccountList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbAccountList_KeyDown);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Location = new System.Drawing.Point(267, 9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnPrint.Size = new System.Drawing.Size(76, 24);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Values.Text = "Print";
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShow.Location = new System.Drawing.Point(187, 9);
            this.btnShow.Name = "btnShow";
            this.btnShow.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnShow.Size = new System.Drawing.Size(76, 24);
            this.btnShow.TabIndex = 11;
            this.btnShow.Values.Text = "Show";
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
            this.txtOperatingYear.Location = new System.Drawing.Point(948, 8);
            this.txtOperatingYear.Name = "txtOperatingYear";
            this.txtOperatingYear.Size = new System.Drawing.Size(70, 22);
            this.txtOperatingYear.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtOperatingYear.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtOperatingYear.StateCommon.Border.Rounding = 3;
            this.txtOperatingYear.TabIndex = 12;
            this.txtOperatingYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmGeneralLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1036, 397);
            this.Controls.Add(this.txtOperatingYear);
            this.Controls.Add(this.PanelBodyPart);
            this.Controls.Add(this.lblPanelDevider);
            this.Controls.Add(this.PanelBottomPart);
            this.Controls.Add(this.MastHead);
            this.Name = "frmGeneralLedger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "General Ledger";
            this.PanelBodyPart.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLedgerRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).EndInit();
            this.PanelBottomPart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbAccountList)).EndInit();
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
        private System.Windows.Forms.Label lblRecordNotFound;
        private System.Windows.Forms.TextBox txtDebitAmountGrandTotal;
        private System.Windows.Forms.TextBox txtCreditAmountGrandTotal;
        internal System.Windows.Forms.Label Label30;
        internal System.Windows.Forms.Label Label31;
        internal System.Windows.Forms.Label VLine4;
        internal System.Windows.Forms.Label VLine1;
        internal System.Windows.Forms.Label Label34;
        internal System.Windows.Forms.Label VLine2;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label33;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label32;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lblBalanceDr;
        internal System.Windows.Forms.Label lblBalanceCr;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label20;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbAccountList;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPrint;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnShow;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFilter;
        public System.Windows.Forms.DataGridView dgLedgerRecords;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtOperatingYear;
        internal System.Windows.Forms.Label VLine3;
    }
}

