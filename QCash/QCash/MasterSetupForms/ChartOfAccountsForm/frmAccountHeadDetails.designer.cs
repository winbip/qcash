namespace QCash.MasterSetupForms.ChartOfAccountsForm
{
    partial class frmAccountHeadDetails
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
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.chkCashBookDefault = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.kryptonGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.btnSelectC = new System.Windows.Forms.Button();
            this.btnSelectB = new System.Windows.Forms.Button();
            this.btnSelectA = new System.Windows.Forms.Button();
            this.txtPathC = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtPathB = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtPathA = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.radioOptionC = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.radioOptionB = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.radioOptionA = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.txtAccountName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtAccountCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
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
            this.PanelBodyPart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).BeginInit();
            this.kryptonGroup1.Panel.SuspendLayout();
            this.kryptonGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).BeginInit();
            this.PanelBottomPart.SuspendLayout();
            this.SuspendLayout();
            // 
            // MastHead
            // 
            this.MastHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.MastHead.Location = new System.Drawing.Point(0, 0);
            this.MastHead.Name = "MastHead";
            this.MastHead.Size = new System.Drawing.Size(583, 36);
            this.MastHead.TabIndex = 0;
            this.MastHead.Values.Description = "";
            this.MastHead.Values.Heading = "Account Head";
            this.MastHead.Values.Image = global::QCash.Properties.Resources.AccountHeadPng32;
            // 
            // PanelBodyPart
            // 
            this.PanelBodyPart.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PanelBodyPart.Controls.Add(this.kryptonGroupBox1);
            this.PanelBodyPart.Controls.Add(this.kryptonGroup1);
            this.PanelBodyPart.Controls.Add(this.txtAccountName);
            this.PanelBodyPart.Controls.Add(this.kryptonLabel3);
            this.PanelBodyPart.Controls.Add(this.kryptonLabel2);
            this.PanelBodyPart.Controls.Add(this.txtAccountCode);
            this.PanelBodyPart.Controls.Add(this.kryptonLabel1);
            this.PanelBodyPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBodyPart.Location = new System.Drawing.Point(0, 36);
            this.PanelBodyPart.Name = "PanelBodyPart";
            this.PanelBodyPart.Size = new System.Drawing.Size(583, 320);
            this.PanelBodyPart.TabIndex = 1;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonGroupBox1.Location = new System.Drawing.Point(361, 30);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.chkCashBookDefault);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(208, 54);
            this.kryptonGroupBox1.TabIndex = 16;
            this.kryptonGroupBox1.Values.Heading = "";
            // 
            // chkCashBookDefault
            // 
            this.chkCashBookDefault.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.chkCashBookDefault.Location = new System.Drawing.Point(13, 16);
            this.chkCashBookDefault.Name = "chkCashBookDefault";
            this.chkCashBookDefault.Size = new System.Drawing.Size(190, 20);
            this.chkCashBookDefault.TabIndex = 15;
            this.chkCashBookDefault.Text = "Default Account for Cashbook.";
            this.chkCashBookDefault.Values.Text = "Default Account for Cashbook.";
            // 
            // kryptonGroup1
            // 
            this.kryptonGroup1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonGroup1.Location = new System.Drawing.Point(113, 107);
            this.kryptonGroup1.Name = "kryptonGroup1";
            // 
            // kryptonGroup1.Panel
            // 
            this.kryptonGroup1.Panel.Controls.Add(this.btnSelectC);
            this.kryptonGroup1.Panel.Controls.Add(this.btnSelectB);
            this.kryptonGroup1.Panel.Controls.Add(this.btnSelectA);
            this.kryptonGroup1.Panel.Controls.Add(this.txtPathC);
            this.kryptonGroup1.Panel.Controls.Add(this.txtPathB);
            this.kryptonGroup1.Panel.Controls.Add(this.txtPathA);
            this.kryptonGroup1.Panel.Controls.Add(this.radioOptionC);
            this.kryptonGroup1.Panel.Controls.Add(this.radioOptionB);
            this.kryptonGroup1.Panel.Controls.Add(this.radioOptionA);
            this.kryptonGroup1.Size = new System.Drawing.Size(458, 195);
            this.kryptonGroup1.TabIndex = 14;
            // 
            // btnSelectC
            // 
            this.btnSelectC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectC.Location = new System.Drawing.Point(403, 160);
            this.btnSelectC.Name = "btnSelectC";
            this.btnSelectC.Size = new System.Drawing.Size(37, 21);
            this.btnSelectC.TabIndex = 21;
            this.btnSelectC.Text = "...";
            this.btnSelectC.UseVisualStyleBackColor = true;
            this.btnSelectC.Visible = false;
            this.btnSelectC.Click += new System.EventHandler(this.btnSelectC_Click);
            // 
            // btnSelectB
            // 
            this.btnSelectB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectB.Location = new System.Drawing.Point(403, 100);
            this.btnSelectB.Name = "btnSelectB";
            this.btnSelectB.Size = new System.Drawing.Size(37, 21);
            this.btnSelectB.TabIndex = 20;
            this.btnSelectB.Text = "...";
            this.btnSelectB.UseVisualStyleBackColor = true;
            this.btnSelectB.Visible = false;
            this.btnSelectB.Click += new System.EventHandler(this.btnSelectB_Click);
            // 
            // btnSelectA
            // 
            this.btnSelectA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectA.Location = new System.Drawing.Point(403, 36);
            this.btnSelectA.Name = "btnSelectA";
            this.btnSelectA.Size = new System.Drawing.Size(37, 21);
            this.btnSelectA.TabIndex = 19;
            this.btnSelectA.Text = "...";
            this.btnSelectA.UseVisualStyleBackColor = true;
            this.btnSelectA.Visible = false;
            this.btnSelectA.Click += new System.EventHandler(this.btnSelectA_Click);
            // 
            // txtPathC
            // 
            this.txtPathC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathC.Location = new System.Drawing.Point(33, 160);
            this.txtPathC.Name = "txtPathC";
            this.txtPathC.ReadOnly = true;
            this.txtPathC.Size = new System.Drawing.Size(364, 22);
            this.txtPathC.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtPathC.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtPathC.StateCommon.Border.Rounding = 3;
            this.txtPathC.TabIndex = 18;
            this.txtPathC.Text = "None";
            this.txtPathC.Visible = false;
            // 
            // txtPathB
            // 
            this.txtPathB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathB.Location = new System.Drawing.Point(33, 99);
            this.txtPathB.Name = "txtPathB";
            this.txtPathB.ReadOnly = true;
            this.txtPathB.Size = new System.Drawing.Size(364, 22);
            this.txtPathB.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtPathB.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtPathB.StateCommon.Border.Rounding = 3;
            this.txtPathB.TabIndex = 17;
            this.txtPathB.Text = "None";
            this.txtPathB.Visible = false;
            // 
            // txtPathA
            // 
            this.txtPathA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathA.Location = new System.Drawing.Point(33, 36);
            this.txtPathA.Name = "txtPathA";
            this.txtPathA.ReadOnly = true;
            this.txtPathA.Size = new System.Drawing.Size(364, 22);
            this.txtPathA.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtPathA.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtPathA.StateCommon.Border.Rounding = 3;
            this.txtPathA.TabIndex = 16;
            this.txtPathA.Text = "None";
            this.txtPathA.Visible = false;
            // 
            // radioOptionC
            // 
            this.radioOptionC.Location = new System.Drawing.Point(16, 134);
            this.radioOptionC.Name = "radioOptionC";
            this.radioOptionC.Size = new System.Drawing.Size(98, 20);
            this.radioOptionC.TabIndex = 2;
            this.radioOptionC.Values.Text = "Balance Sheet";
            // 
            // radioOptionB
            // 
            this.radioOptionB.Location = new System.Drawing.Point(16, 73);
            this.radioOptionB.Name = "radioOptionB";
            this.radioOptionB.Size = new System.Drawing.Size(186, 20);
            this.radioOptionB.TabIndex = 1;
            this.radioOptionB.Values.Text = "Profit and Loss/Administrative";
            // 
            // radioOptionA
            // 
            this.radioOptionA.Location = new System.Drawing.Point(16, 16);
            this.radioOptionA.Name = "radioOptionA";
            this.radioOptionA.Size = new System.Drawing.Size(149, 20);
            this.radioOptionA.TabIndex = 0;
            this.radioOptionA.Values.Text = "Trading/Manufacturing";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountName.Location = new System.Drawing.Point(111, 62);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(220, 22);
            this.txtAccountName.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtAccountName.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtAccountName.StateCommon.Border.Rounding = 3;
            this.txtAccountName.TabIndex = 13;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(11, 103);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(91, 20);
            this.kryptonLabel3.TabIndex = 9;
            this.kryptonLabel3.Values.Text = "Account Type :";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(11, 62);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(97, 20);
            this.kryptonLabel2.TabIndex = 8;
            this.kryptonLabel2.Values.Text = "Account Name :";
            // 
            // txtAccountCode
            // 
            this.txtAccountCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountCode.Location = new System.Drawing.Point(111, 32);
            this.txtAccountCode.Name = "txtAccountCode";
            this.txtAccountCode.Size = new System.Drawing.Size(220, 22);
            this.txtAccountCode.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtAccountCode.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtAccountCode.StateCommon.Border.Rounding = 3;
            this.txtAccountCode.TabIndex = 7;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(11, 32);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(93, 20);
            this.kryptonLabel1.TabIndex = 6;
            this.kryptonLabel1.Values.Text = "Account Code :";
            // 
            // lblPanelDevider
            // 
            this.lblPanelDevider.BackColor = System.Drawing.Color.SteelBlue;
            this.lblPanelDevider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPanelDevider.Location = new System.Drawing.Point(0, 356);
            this.lblPanelDevider.Name = "lblPanelDevider";
            this.lblPanelDevider.Size = new System.Drawing.Size(583, 1);
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
            this.btnClose.Location = new System.Drawing.Point(486, 7);
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
            this.MyProgressBar.Size = new System.Drawing.Size(211, 23);
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
            this.PanelBottomPart.Location = new System.Drawing.Point(0, 357);
            this.PanelBottomPart.Name = "PanelBottomPart";
            this.PanelBottomPart.Size = new System.Drawing.Size(583, 44);
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
            // frmAccountHeadDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(583, 401);
            this.Controls.Add(this.PanelBodyPart);
            this.Controls.Add(this.lblPanelDevider);
            this.Controls.Add(this.PanelBottomPart);
            this.Controls.Add(this.MastHead);
            this.Name = "frmAccountHeadDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Head";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAccountHeadDetails_FormClosing);
            this.PanelBodyPart.ResumeLayout(false);
            this.PanelBodyPart.PerformLayout();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.kryptonGroup1.Panel.ResumeLayout(false);
            this.kryptonGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).EndInit();
            this.kryptonGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).EndInit();
            this.PanelBottomPart.ResumeLayout(false);
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
        private System.Windows.Forms.ProgressBar MyProgressBar;
        private System.ComponentModel.BackgroundWorker bgwPrimaryWorker;
        private System.Windows.Forms.Panel PanelBottomPart;
        private System.Windows.Forms.ToolTip RedToolTip;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNewEntity;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAccountCode;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAccountName;
        private ComponentFactory.Krypton.Toolkit.KryptonGroup kryptonGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radioOptionC;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radioOptionB;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radioOptionA;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkCashBookDefault;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPathC;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPathB;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPathA;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private System.Windows.Forms.Button btnSelectA;
        private System.Windows.Forms.Button btnSelectC;
        private System.Windows.Forms.Button btnSelectB;
    }
}

