namespace QCash.MasterSetupForms.ChartOfAccountsForm
{
    partial class frmSelectSubCategoryNode
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
            this.btnSelect = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.MyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MyProgressBar = new System.Windows.Forms.ProgressBar();
            this.bgwPrimaryWorker = new System.ComponentModel.BackgroundWorker();
            this.PanelBottomPart = new System.Windows.Forms.Panel();
            this.RedToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.TreeViewIconList = new System.Windows.Forms.ImageList(this.components);
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
            this.MastHead.Size = new System.Drawing.Size(484, 31);
            this.MastHead.TabIndex = 0;
            this.MastHead.Values.Description = "";
            this.MastHead.Values.Heading = "Form Heading";
            this.MastHead.Values.Image = null;
            // 
            // PanelBodyPart
            // 
            this.PanelBodyPart.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PanelBodyPart.Controls.Add(this.trvChartOfAccount);
            this.PanelBodyPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBodyPart.Location = new System.Drawing.Point(0, 31);
            this.PanelBodyPart.Name = "PanelBodyPart";
            this.PanelBodyPart.Size = new System.Drawing.Size(484, 252);
            this.PanelBodyPart.TabIndex = 1;
            // 
            // trvChartOfAccount
            // 
            this.trvChartOfAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvChartOfAccount.Location = new System.Drawing.Point(0, 0);
            this.trvChartOfAccount.Name = "trvChartOfAccount";
            this.trvChartOfAccount.Size = new System.Drawing.Size(484, 252);
            this.trvChartOfAccount.TabIndex = 8;
            // 
            // lblPanelDevider
            // 
            this.lblPanelDevider.BackColor = System.Drawing.Color.SteelBlue;
            this.lblPanelDevider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPanelDevider.Location = new System.Drawing.Point(0, 283);
            this.lblPanelDevider.Name = "lblPanelDevider";
            this.lblPanelDevider.Size = new System.Drawing.Size(484, 1);
            this.lblPanelDevider.TabIndex = 2;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelect.Location = new System.Drawing.Point(11, 7);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnSelect.Size = new System.Drawing.Size(76, 30);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Values.Text = "&Select";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(387, 7);
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
            this.MyProgressBar.Size = new System.Drawing.Size(112, 23);
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
            this.PanelBottomPart.Controls.Add(this.MyProgressBar);
            this.PanelBottomPart.Controls.Add(this.btnSelect);
            this.PanelBottomPart.Controls.Add(this.btnClose);
            this.PanelBottomPart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelBottomPart.Location = new System.Drawing.Point(0, 284);
            this.PanelBottomPart.Name = "PanelBottomPart";
            this.PanelBottomPart.Size = new System.Drawing.Size(484, 44);
            this.PanelBottomPart.TabIndex = 7;
            // 
            // TreeViewIconList
            // 
            this.TreeViewIconList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.TreeViewIconList.ImageSize = new System.Drawing.Size(16, 16);
            this.TreeViewIconList.TransparentColor = System.Drawing.Color.White;
            // 
            // frmSelectSubCategoryNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(484, 328);
            this.Controls.Add(this.PanelBodyPart);
            this.Controls.Add(this.lblPanelDevider);
            this.Controls.Add(this.PanelBottomPart);
            this.Controls.Add(this.MastHead);
            this.Name = "frmSelectSubCategoryNode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSelectSubCategoryNode";
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
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSelect;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private System.Windows.Forms.ErrorProvider MyErrorProvider;
        private System.Windows.Forms.ToolTip MyToolTip;
        private System.Windows.Forms.ProgressBar MyProgressBar;
        private System.ComponentModel.BackgroundWorker bgwPrimaryWorker;
        private System.Windows.Forms.Panel PanelBottomPart;
        private System.Windows.Forms.ToolTip RedToolTip;
        public System.Windows.Forms.TreeView trvChartOfAccount;
        private System.Windows.Forms.ImageList TreeViewIconList;
    }
}

