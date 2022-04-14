namespace QCash.MasterSetupForms.OpeningBalanceForms
{
    partial class frmOpeningBalance
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
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.AccountHeadLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtCreditAmount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtDebitAmount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cmbAccount = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtEntryDate = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
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
            this.RedToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bsCurrentEntity = new System.Windows.Forms.BindingSource(this.components);
            this.bsAccountHeads = new System.Windows.Forms.BindingSource(this.components);
            this.PanelBodyPart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).BeginInit();
            this.PanelBottomPart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCurrentEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccountHeads)).BeginInit();
            this.SuspendLayout();
            // 
            // MastHead
            // 
            this.MastHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.MastHead.Location = new System.Drawing.Point(0, 0);
            this.MastHead.Name = "MastHead";
            this.MastHead.Size = new System.Drawing.Size(471, 36);
            this.MastHead.TabIndex = 0;
            this.MastHead.Values.Description = "";
            this.MastHead.Values.Heading = "Opening Balance";
            this.MastHead.Values.Image = global::QCash.Properties.Resources.OpeningBalancePng32;
            // 
            // PanelBodyPart
            // 
            this.PanelBodyPart.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PanelBodyPart.Controls.Add(this.kryptonLabel4);
            this.PanelBodyPart.Controls.Add(this.kryptonLabel3);
            this.PanelBodyPart.Controls.Add(this.AccountHeadLabel);
            this.PanelBodyPart.Controls.Add(this.txtCreditAmount);
            this.PanelBodyPart.Controls.Add(this.txtDebitAmount);
            this.PanelBodyPart.Controls.Add(this.cmbAccount);
            this.PanelBodyPart.Controls.Add(this.txtEntryDate);
            this.PanelBodyPart.Controls.Add(this.kryptonLabel1);
            this.PanelBodyPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBodyPart.Location = new System.Drawing.Point(0, 36);
            this.PanelBodyPart.Name = "PanelBodyPart";
            this.PanelBodyPart.Size = new System.Drawing.Size(471, 232);
            this.PanelBodyPart.TabIndex = 1;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(257, 161);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(97, 20);
            this.kryptonLabel4.TabIndex = 13;
            this.kryptonLabel4.Values.Text = "Credit Amount :";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(81, 162);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(94, 20);
            this.kryptonLabel3.TabIndex = 12;
            this.kryptonLabel3.Values.Text = "Debit Amount :";
            // 
            // AccountHeadLabel
            // 
            this.AccountHeadLabel.Location = new System.Drawing.Point(82, 93);
            this.AccountHeadLabel.Name = "AccountHeadLabel";
            this.AccountHeadLabel.Size = new System.Drawing.Size(94, 20);
            this.AccountHeadLabel.TabIndex = 11;
            this.AccountHeadLabel.Values.Text = "Account Head :";
            // 
            // txtCreditAmount
            // 
            this.txtCreditAmount.Location = new System.Drawing.Point(259, 183);
            this.txtCreditAmount.Name = "txtCreditAmount";
            this.txtCreditAmount.Size = new System.Drawing.Size(144, 22);
            this.txtCreditAmount.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtCreditAmount.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtCreditAmount.StateCommon.Border.Rounding = 3;
            this.txtCreditAmount.TabIndex = 10;
            // 
            // txtDebitAmount
            // 
            this.txtDebitAmount.Location = new System.Drawing.Point(83, 183);
            this.txtDebitAmount.Name = "txtDebitAmount";
            this.txtDebitAmount.Size = new System.Drawing.Size(144, 22);
            this.txtDebitAmount.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtDebitAmount.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtDebitAmount.StateCommon.Border.Rounding = 3;
            this.txtDebitAmount.TabIndex = 9;
            // 
            // cmbAccount
            // 
            this.cmbAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAccount.DropDownWidth = 315;
            this.cmbAccount.Location = new System.Drawing.Point(82, 114);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(321, 23);
            this.cmbAccount.StateCommon.ComboBox.Back.Color1 = System.Drawing.Color.White;
            this.cmbAccount.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbAccount.StateCommon.ComboBox.Border.Rounding = 3;
            this.cmbAccount.TabIndex = 8;
            // 
            // txtEntryDate
            // 
            this.txtEntryDate.Location = new System.Drawing.Point(83, 46);
            this.txtEntryDate.Name = "txtEntryDate";
            this.txtEntryDate.Size = new System.Drawing.Size(320, 22);
            this.txtEntryDate.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtEntryDate.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtEntryDate.StateCommon.Border.Rounding = 3;
            this.txtEntryDate.TabIndex = 7;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(82, 24);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(42, 20);
            this.kryptonLabel1.TabIndex = 6;
            this.kryptonLabel1.Values.Text = "Date :";
            // 
            // lblPanelDevider
            // 
            this.lblPanelDevider.BackColor = System.Drawing.Color.SteelBlue;
            this.lblPanelDevider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPanelDevider.Location = new System.Drawing.Point(0, 268);
            this.lblPanelDevider.Name = "lblPanelDevider";
            this.lblPanelDevider.Size = new System.Drawing.Size(471, 1);
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
            this.btnClose.Location = new System.Drawing.Point(374, 7);
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
            this.MyProgressBar.Size = new System.Drawing.Size(99, 23);
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
            this.PanelBottomPart.Location = new System.Drawing.Point(0, 269);
            this.PanelBottomPart.Name = "PanelBottomPart";
            this.PanelBottomPart.Size = new System.Drawing.Size(471, 44);
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
            // frmOpeningBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(471, 313);
            this.Controls.Add(this.PanelBodyPart);
            this.Controls.Add(this.lblPanelDevider);
            this.Controls.Add(this.PanelBottomPart);
            this.Controls.Add(this.MastHead);
            this.Name = "frmOpeningBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opening Balance";
            this.PanelBodyPart.ResumeLayout(false);
            this.PanelBodyPart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).EndInit();
            this.PanelBottomPart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsCurrentEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccountHeads)).EndInit();
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
        private System.Windows.Forms.ToolTip RedToolTip;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNewEntity;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbAccount;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtEntryDate;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCreditAmount;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDebitAmount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel AccountHeadLabel;
        private System.Windows.Forms.BindingSource bsAccountHeads;
    }
}

