namespace QCash.MasterSetupForms.OpeningBalanceForms
{
    partial class frmOpeningBalanceHistory
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
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPanelDevider = new System.Windows.Forms.Label();
            this.MyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bsCurrentEntity = new System.Windows.Forms.BindingSource(this.components);
            this.MyProgressBar = new System.Windows.Forms.ProgressBar();
            this.bgwPrimaryWorker = new System.ComponentModel.BackgroundWorker();
            this.PanelBottomPart = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCreditTotal = new System.Windows.Forms.TextBox();
            this.txtDebitTotal = new System.Windows.Forms.TextBox();
            this.btnPrint = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.PanelBodyPart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyNavBar)).BeginInit();
            this.MyNavBar.SuspendLayout();
            this.naviBand1.ClientArea.SuspendLayout();
            this.naviBand1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.naviGroup1)).BeginInit();
            this.naviGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCurrentEntity)).BeginInit();
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
            this.MastHead.Values.Heading = "Opening Balance History";
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
            this.PanelBodyPart.Size = new System.Drawing.Size(753, 284);
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
            this.dgData.Size = new System.Drawing.Size(563, 284);
            this.dgData.TabIndex = 0;
            // 
            // MyNavBar
            // 
            this.MyNavBar.ActiveBand = this.naviBand1;
            this.MyNavBar.Controls.Add(this.naviBand1);
            this.MyNavBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.MyNavBar.Location = new System.Drawing.Point(0, 0);
            this.MyNavBar.Name = "MyNavBar";
            this.MyNavBar.Size = new System.Drawing.Size(190, 284);
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
            this.naviBand1.ClientArea.Size = new System.Drawing.Size(188, 217);
            this.naviBand1.ClientArea.TabIndex = 0;
            this.naviBand1.Location = new System.Drawing.Point(1, 27);
            this.naviBand1.Name = "naviBand1";
            this.naviBand1.Size = new System.Drawing.Size(188, 217);
            this.naviBand1.TabIndex = 3;
            this.naviBand1.Text = "Filter Options";
            // 
            // naviGroup1
            // 
            this.naviGroup1.Caption = null;
            this.naviGroup1.Controls.Add(this.txtAccountName);
            this.naviGroup1.Controls.Add(this.label1);
            this.naviGroup1.Dock = System.Windows.Forms.DockStyle.Top;
            this.naviGroup1.ExpandedHeight = 262;
            this.naviGroup1.HeaderContextMenuStrip = null;
            this.naviGroup1.Location = new System.Drawing.Point(0, 0);
            this.naviGroup1.Name = "naviGroup1";
            this.naviGroup1.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
            this.naviGroup1.Size = new System.Drawing.Size(188, 262);
            this.naviGroup1.TabIndex = 0;
            this.naviGroup1.Text = "naviGroup1";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(27, 56);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(138, 20);
            this.txtAccountName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter by Account Name:";
            // 
            // lblPanelDevider
            // 
            this.lblPanelDevider.BackColor = System.Drawing.Color.SteelBlue;
            this.lblPanelDevider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPanelDevider.Location = new System.Drawing.Point(0, 315);
            this.lblPanelDevider.Name = "lblPanelDevider";
            this.lblPanelDevider.Size = new System.Drawing.Size(753, 1);
            this.lblPanelDevider.TabIndex = 2;
            // 
            // MyErrorProvider
            // 
            this.MyErrorProvider.ContainerControl = this;
            // 
            // MyProgressBar
            // 
            this.MyProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyProgressBar.Location = new System.Drawing.Point(95, 17);
            this.MyProgressBar.Name = "MyProgressBar";
            this.MyProgressBar.Size = new System.Drawing.Size(276, 23);
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
            this.PanelBottomPart.Controls.Add(this.label3);
            this.PanelBottomPart.Controls.Add(this.label2);
            this.PanelBottomPart.Controls.Add(this.txtCreditTotal);
            this.PanelBottomPart.Controls.Add(this.txtDebitTotal);
            this.PanelBottomPart.Controls.Add(this.btnPrint);
            this.PanelBottomPart.Controls.Add(this.MyProgressBar);
            this.PanelBottomPart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelBottomPart.Location = new System.Drawing.Point(0, 316);
            this.PanelBottomPart.Name = "PanelBottomPart";
            this.PanelBottomPart.Size = new System.Drawing.Size(753, 52);
            this.PanelBottomPart.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(534, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Credit Total :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(534, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Debit Total :";
            // 
            // txtCreditTotal
            // 
            this.txtCreditTotal.Location = new System.Drawing.Point(602, 25);
            this.txtCreditTotal.Name = "txtCreditTotal";
            this.txtCreditTotal.Size = new System.Drawing.Size(148, 20);
            this.txtCreditTotal.TabIndex = 10;
            // 
            // txtDebitTotal
            // 
            this.txtDebitTotal.Location = new System.Drawing.Point(602, 5);
            this.txtDebitTotal.Name = "txtDebitTotal";
            this.txtDebitTotal.Size = new System.Drawing.Size(148, 20);
            this.txtDebitTotal.TabIndex = 9;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Location = new System.Drawing.Point(3, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnPrint.Size = new System.Drawing.Size(86, 30);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Values.Text = "&Print";
            // 
            // frmOpeningBalanceHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(753, 368);
            this.Controls.Add(this.PanelBodyPart);
            this.Controls.Add(this.lblPanelDevider);
            this.Controls.Add(this.PanelBottomPart);
            this.Controls.Add(this.MastHead);
            this.Name = "frmOpeningBalanceHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opening Balance History";
            this.PanelBodyPart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyNavBar)).EndInit();
            this.MyNavBar.ResumeLayout(false);
            this.naviBand1.ClientArea.ResumeLayout(false);
            this.naviBand1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.naviGroup1)).EndInit();
            this.naviGroup1.ResumeLayout(false);
            this.naviGroup1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCurrentEntity)).EndInit();
            this.PanelBottomPart.ResumeLayout(false);
            this.PanelBottomPart.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeader MastHead;
        private System.Windows.Forms.Panel PanelBodyPart;
        private System.Windows.Forms.Label lblPanelDevider;
        private System.Windows.Forms.ErrorProvider MyErrorProvider;
        private System.Windows.Forms.ToolTip MyToolTip;
        private System.Windows.Forms.BindingSource bsCurrentEntity;
        private System.Windows.Forms.ProgressBar MyProgressBar;
        private System.Windows.Forms.DataGridView dgData;
        private System.ComponentModel.BackgroundWorker bgwPrimaryWorker;
        private Guifreaks.NavigationBar.NaviBar MyNavBar;
        private Guifreaks.NavigationBar.NaviBand naviBand1;
        private Guifreaks.NavigationBar.NaviGroup naviGroup1;
        private System.Windows.Forms.Panel PanelBottomPart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccountName;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPrint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCreditTotal;
        private System.Windows.Forms.TextBox txtDebitTotal;
    }
}

