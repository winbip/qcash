namespace QCash.MasterSetupForms.ChartOfAccountsForm
{
    partial class frmAddEditSubCatNode
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
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbSubCategoryNode = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtSubCategoryName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
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
            this.contextMenuSetFocusOrder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemAddFocus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemRemoveFocus = new System.Windows.Forms.ToolStripMenuItem();
            this.RedToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bsCurrentEntity = new System.Windows.Forms.BindingSource(this.components);
            this.GreenToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.PanelBodyPart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSubCategoryNode)).BeginInit();
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
            this.MastHead.Size = new System.Drawing.Size(484, 31);
            this.MastHead.TabIndex = 0;
            this.MastHead.Values.Description = "";
            this.MastHead.Values.Heading = "Form Heading";
            this.MastHead.Values.Image = null;
            // 
            // PanelBodyPart
            // 
            this.PanelBodyPart.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PanelBodyPart.Controls.Add(this.kryptonLabel2);
            this.PanelBodyPart.Controls.Add(this.kryptonLabel1);
            this.PanelBodyPart.Controls.Add(this.cmbSubCategoryNode);
            this.PanelBodyPart.Controls.Add(this.txtSubCategoryName);
            this.PanelBodyPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBodyPart.Location = new System.Drawing.Point(0, 31);
            this.PanelBodyPart.Name = "PanelBodyPart";
            this.PanelBodyPart.Size = new System.Drawing.Size(484, 252);
            this.PanelBodyPart.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(67, 54);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(123, 20);
            this.kryptonLabel1.TabIndex = 6;
            this.kryptonLabel1.Values.Text = "Sub Category Name:";
            // 
            // cmbSubCategoryNode
            // 
            this.cmbSubCategoryNode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSubCategoryNode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSubCategoryNode.DropDownWidth = 315;
            this.cmbSubCategoryNode.Location = new System.Drawing.Point(70, 125);
            this.cmbSubCategoryNode.Name = "cmbSubCategoryNode";
            this.cmbSubCategoryNode.Size = new System.Drawing.Size(336, 23);
            this.cmbSubCategoryNode.StateCommon.ComboBox.Back.Color1 = System.Drawing.Color.White;
            this.cmbSubCategoryNode.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbSubCategoryNode.StateCommon.ComboBox.Border.Rounding = 3;
            this.cmbSubCategoryNode.TabIndex = 5;
            // 
            // txtSubCategoryName
            // 
            this.txtSubCategoryName.Location = new System.Drawing.Point(70, 76);
            this.txtSubCategoryName.Name = "txtSubCategoryName";
            this.txtSubCategoryName.Size = new System.Drawing.Size(336, 22);
            this.txtSubCategoryName.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtSubCategoryName.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtSubCategoryName.StateCommon.Border.Rounding = 3;
            this.txtSubCategoryName.TabIndex = 2;
            // 
            // pbEntityFolder
            // 
            this.pbEntityFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbEntityFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbEntityFolder.Location = new System.Drawing.Point(454, 3);
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
            this.lblPanelDevider.Location = new System.Drawing.Point(0, 283);
            this.lblPanelDevider.Name = "lblPanelDevider";
            this.lblPanelDevider.Size = new System.Drawing.Size(484, 1);
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
            this.btnDelete.Location = new System.Drawing.Point(92, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnDelete.Size = new System.Drawing.Size(74, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Values.Text = "&Delete";
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
            this.MyProgressBar.Location = new System.Drawing.Point(187, 10);
            this.MyProgressBar.Name = "MyProgressBar";
            this.MyProgressBar.Size = new System.Drawing.Size(194, 23);
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
            this.PanelBottomPart.Controls.Add(this.btnDelete);
            this.PanelBottomPart.Controls.Add(this.MyProgressBar);
            this.PanelBottomPart.Controls.Add(this.btnSave);
            this.PanelBottomPart.Controls.Add(this.btnClose);
            this.PanelBottomPart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelBottomPart.Location = new System.Drawing.Point(0, 284);
            this.PanelBottomPart.Name = "PanelBottomPart";
            this.PanelBottomPart.Size = new System.Drawing.Size(484, 44);
            this.PanelBottomPart.TabIndex = 7;
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
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(67, 104);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(101, 20);
            this.kryptonLabel2.TabIndex = 7;
            this.kryptonLabel2.Values.Text = "Parent Category:";
            // 
            // frmAddEditSubCatNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(484, 328);
            this.Controls.Add(this.pbEntityFolder);
            this.Controls.Add(this.PanelBodyPart);
            this.Controls.Add(this.lblPanelDevider);
            this.Controls.Add(this.PanelBottomPart);
            this.Controls.Add(this.MastHead);
            this.Name = "frmAddEditSubCatNode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddEditSubCatNode";
            this.PanelBodyPart.ResumeLayout(false);
            this.PanelBodyPart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSubCategoryNode)).EndInit();
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
        private System.Windows.Forms.PictureBox pbEntityFolder;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSubCategoryName;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbSubCategoryNode;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.ToolTip GreenToolTip;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
    }
}

