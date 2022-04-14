namespace QCash.MasterSetupForms.ChartOfAccountsForm
{
    partial class frmChartOfAccount
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
            this.trvChartOfAccount = new System.Windows.Forms.TreeView();
            this.lblPanelDevider = new System.Windows.Forms.Label();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.MyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MyProgressBar = new System.Windows.Forms.ProgressBar();
            this.bgwPrimaryWorker = new System.ComponentModel.BackgroundWorker();
            this.PanelBottomPart = new System.Windows.Forms.Panel();
            this.btnEditAccount = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnNewAccount = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnEditSubCategory = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnNewSubCategory = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.RedToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.TreeViewIconList = new System.Windows.Forms.ImageList(this.components);
            this.btnPrint = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.PanelBodyPart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).BeginInit();
            this.PanelBottomPart.SuspendLayout();
            this.SuspendLayout();
            // 
            // MastHead
            // 
            this.MastHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.MastHead.Location = new System.Drawing.Point(0, 0);
            this.MastHead.Name = "MastHead";
            this.MastHead.Size = new System.Drawing.Size(649, 36);
            this.MastHead.TabIndex = 0;
            this.MastHead.Values.Description = "";
            this.MastHead.Values.Heading = "Chart of Account Heads";
            this.MastHead.Values.Image = global::QCash.Properties.Resources.ChartOfAccountsPng32;
            // 
            // PanelBodyPart
            // 
            this.PanelBodyPart.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PanelBodyPart.Controls.Add(this.trvChartOfAccount);
            this.PanelBodyPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBodyPart.Location = new System.Drawing.Point(0, 36);
            this.PanelBodyPart.Name = "PanelBodyPart";
            this.PanelBodyPart.Size = new System.Drawing.Size(649, 333);
            this.PanelBodyPart.TabIndex = 1;
            // 
            // trvChartOfAccount
            // 
            this.trvChartOfAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvChartOfAccount.Location = new System.Drawing.Point(0, 0);
            this.trvChartOfAccount.Name = "trvChartOfAccount";
            this.trvChartOfAccount.Size = new System.Drawing.Size(649, 333);
            this.trvChartOfAccount.TabIndex = 7;
            // 
            // lblPanelDevider
            // 
            this.lblPanelDevider.BackColor = System.Drawing.Color.SteelBlue;
            this.lblPanelDevider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPanelDevider.Location = new System.Drawing.Point(0, 369);
            this.lblPanelDevider.Name = "lblPanelDevider";
            this.lblPanelDevider.Size = new System.Drawing.Size(649, 1);
            this.lblPanelDevider.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(552, 7);
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
            this.MyProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MyProgressBar.Location = new System.Drawing.Point(461, 10);
            this.MyProgressBar.Name = "MyProgressBar";
            this.MyProgressBar.Size = new System.Drawing.Size(85, 23);
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
            this.PanelBottomPart.Controls.Add(this.MyProgressBar);
            this.PanelBottomPart.Controls.Add(this.btnEditAccount);
            this.PanelBottomPart.Controls.Add(this.btnClose);
            this.PanelBottomPart.Controls.Add(this.btnNewAccount);
            this.PanelBottomPart.Controls.Add(this.btnEditSubCategory);
            this.PanelBottomPart.Controls.Add(this.btnNewSubCategory);
            this.PanelBottomPart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelBottomPart.Location = new System.Drawing.Point(0, 370);
            this.PanelBottomPart.Name = "PanelBottomPart";
            this.PanelBottomPart.Size = new System.Drawing.Size(649, 44);
            this.PanelBottomPart.TabIndex = 7;
            // 
            // btnEditAccount
            // 
            this.btnEditAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditAccount.Location = new System.Drawing.Point(356, 7);
            this.btnEditAccount.Name = "btnEditAccount";
            this.btnEditAccount.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnEditAccount.Size = new System.Drawing.Size(87, 30);
            this.btnEditAccount.TabIndex = 12;
            this.btnEditAccount.Values.Text = "Edit Account";
            this.btnEditAccount.Visible = false;
            // 
            // btnNewAccount
            // 
            this.btnNewAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewAccount.Location = new System.Drawing.Point(254, 7);
            this.btnNewAccount.Name = "btnNewAccount";
            this.btnNewAccount.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnNewAccount.Size = new System.Drawing.Size(96, 30);
            this.btnNewAccount.TabIndex = 10;
            this.btnNewAccount.Values.Text = "New Account";
            this.btnNewAccount.Visible = false;
            // 
            // btnEditSubCategory
            // 
            this.btnEditSubCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditSubCategory.Location = new System.Drawing.Point(135, 7);
            this.btnEditSubCategory.Name = "btnEditSubCategory";
            this.btnEditSubCategory.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnEditSubCategory.Size = new System.Drawing.Size(110, 30);
            this.btnEditSubCategory.TabIndex = 9;
            this.btnEditSubCategory.Values.Text = "Edit Sub-Category";
            this.btnEditSubCategory.Visible = false;
            // 
            // btnNewSubCategory
            // 
            this.btnNewSubCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewSubCategory.Location = new System.Drawing.Point(12, 7);
            this.btnNewSubCategory.Name = "btnNewSubCategory";
            this.btnNewSubCategory.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnNewSubCategory.Size = new System.Drawing.Size(117, 30);
            this.btnNewSubCategory.TabIndex = 7;
            this.btnNewSubCategory.Values.Text = "New Sub-Category";
            this.btnNewSubCategory.Visible = false;
            // 
            // TreeViewIconList
            // 
            this.TreeViewIconList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.TreeViewIconList.ImageSize = new System.Drawing.Size(16, 16);
            this.TreeViewIconList.TransparentColor = System.Drawing.Color.White;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Location = new System.Drawing.Point(461, 7);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnPrint.Size = new System.Drawing.Size(87, 30);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Values.Text = "Print";
            // 
            // frmChartOfAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(649, 414);
            this.Controls.Add(this.PanelBodyPart);
            this.Controls.Add(this.lblPanelDevider);
            this.Controls.Add(this.PanelBottomPart);
            this.Controls.Add(this.MastHead);
            this.Name = "frmChartOfAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chart of Account Heads";
            this.PanelBodyPart.ResumeLayout(false);
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
        private System.ComponentModel.BackgroundWorker bgwPrimaryWorker;
        private System.Windows.Forms.Panel PanelBottomPart;
        private System.Windows.Forms.ToolTip RedToolTip;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNewSubCategory;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEditSubCategory;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEditAccount;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNewAccount;
        public System.Windows.Forms.TreeView trvChartOfAccount;
        private System.Windows.Forms.ImageList TreeViewIconList;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPrint;
    }
}

