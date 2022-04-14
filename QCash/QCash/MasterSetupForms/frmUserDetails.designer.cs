namespace QCash.MasterSetupForms
{
    partial class frmUserDetails
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
            this.kryptonHeader1 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgUsers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.MyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.MyProgressBar = new System.Windows.Forms.ProgressBar();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.bgwStartupDataLoader = new System.ComponentModel.BackgroundWorker();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.logInNameLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.logInPasswordLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.fullNameLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.userDesignationLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtUserName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtUserPassword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtFullName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtDesignation = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonGroupBox3 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).BeginInit();
            this.kryptonGroupBox3.Panel.SuspendLayout();
            this.kryptonGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeader1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.Size = new System.Drawing.Size(636, 31);
            this.kryptonHeader1.TabIndex = 0;
            this.kryptonHeader1.Values.Description = "";
            this.kryptonHeader1.Values.Heading = "Form Heading";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.kryptonGroupBox3);
            this.panel1.Controls.Add(this.kryptonGroupBox2);
            this.panel1.Controls.Add(this.kryptonGroupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 324);
            this.panel1.TabIndex = 1;
            // 
            // dgUsers
            // 
            this.dgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgUsers.Location = new System.Drawing.Point(0, 0);
            this.dgUsers.Name = "dgUsers";
            this.dgUsers.Size = new System.Drawing.Size(579, 188);
            this.dgUsers.TabIndex = 17;
            this.dgUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUsers_CellClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(636, 1);
            this.label1.TabIndex = 2;
            // 
            // MyErrorProvider
            // 
            this.MyErrorProvider.ContainerControl = this;
            // 
            // MyProgressBar
            // 
            this.MyProgressBar.Location = new System.Drawing.Point(148, 367);
            this.MyProgressBar.Name = "MyProgressBar";
            this.MyProgressBar.Size = new System.Drawing.Size(100, 22);
            this.MyProgressBar.TabIndex = 906;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(473, 363);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(70, 27);
            this.btnNew.TabIndex = 905;
            this.btnNew.Text = "&New";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(388, 363);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 27);
            this.btnDelete.TabIndex = 904;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(548, 363);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 27);
            this.btnExit.TabIndex = 903;
            this.btnExit.Text = "&Exit";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(303, 363);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 27);
            this.btnSave.TabIndex = 902;
            this.btnSave.Text = "&Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // bgwStartupDataLoader
            // 
            this.bgwStartupDataLoader.WorkerReportsProgress = true;
            this.bgwStartupDataLoader.WorkerSupportsCancellation = true;
            this.bgwStartupDataLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwStartupDataLoader_DoWork);
            this.bgwStartupDataLoader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwStartupDataLoader_ProgressChanged);
            this.bgwStartupDataLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwStartupDataLoader_RunWorkerCompleted);
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(24, 13);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.logInPasswordLabel);
            this.kryptonGroupBox1.Panel.Controls.Add(this.logInNameLabel);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtUserPassword);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtUserName);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(223, 90);
            this.kryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.kryptonGroupBox1.TabIndex = 18;
            this.kryptonGroupBox1.Text = "Login Details";
            this.kryptonGroupBox1.Values.Heading = "Login Details";
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Location = new System.Drawing.Point(264, 13);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.txtDesignation);
            this.kryptonGroupBox2.Panel.Controls.Add(this.userDesignationLabel);
            this.kryptonGroupBox2.Panel.Controls.Add(this.txtFullName);
            this.kryptonGroupBox2.Panel.Controls.Add(this.fullNameLabel);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(341, 90);
            this.kryptonGroupBox2.StateCommon.Back.Color1 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.kryptonGroupBox2.TabIndex = 19;
            this.kryptonGroupBox2.Text = "User Details";
            this.kryptonGroupBox2.Values.Heading = "User Details";
            // 
            // logInNameLabel
            // 
            this.logInNameLabel.Location = new System.Drawing.Point(4, 6);
            this.logInNameLabel.Name = "logInNameLabel";
            this.logInNameLabel.Size = new System.Drawing.Size(80, 20);
            this.logInNameLabel.TabIndex = 15;
            this.logInNameLabel.Values.Text = "Login Name:";
            // 
            // logInPasswordLabel
            // 
            this.logInPasswordLabel.Location = new System.Drawing.Point(4, 33);
            this.logInPasswordLabel.Name = "logInPasswordLabel";
            this.logInPasswordLabel.Size = new System.Drawing.Size(98, 20);
            this.logInPasswordLabel.TabIndex = 16;
            this.logInPasswordLabel.Values.Text = "Login Password:";
            // 
            // fullNameLabel
            // 
            this.fullNameLabel.Location = new System.Drawing.Point(3, 8);
            this.fullNameLabel.Name = "fullNameLabel";
            this.fullNameLabel.Size = new System.Drawing.Size(68, 20);
            this.fullNameLabel.TabIndex = 17;
            this.fullNameLabel.Values.Text = "Full Name:";
            // 
            // userDesignationLabel
            // 
            this.userDesignationLabel.Location = new System.Drawing.Point(3, 33);
            this.userDesignationLabel.Name = "userDesignationLabel";
            this.userDesignationLabel.Size = new System.Drawing.Size(79, 20);
            this.userDesignationLabel.TabIndex = 18;
            this.userDesignationLabel.Values.Text = "Designation:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(107, 5);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(97, 22);
            this.txtUserName.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtUserName.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtUserName.StateCommon.Border.Rounding = 3;
            this.txtUserName.TabIndex = 20;
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(107, 33);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Size = new System.Drawing.Size(97, 22);
            this.txtUserPassword.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtUserPassword.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtUserPassword.StateCommon.Border.Rounding = 3;
            this.txtUserPassword.TabIndex = 21;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(78, 6);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(252, 22);
            this.txtFullName.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtFullName.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtFullName.StateCommon.Border.Rounding = 3;
            this.txtFullName.TabIndex = 22;
            // 
            // txtDesignation
            // 
            this.txtDesignation.Location = new System.Drawing.Point(78, 33);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.Size = new System.Drawing.Size(252, 22);
            this.txtDesignation.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtDesignation.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtDesignation.StateCommon.Border.Rounding = 3;
            this.txtDesignation.TabIndex = 23;
            // 
            // kryptonGroupBox3
            // 
            this.kryptonGroupBox3.Location = new System.Drawing.Point(22, 106);
            this.kryptonGroupBox3.Name = "kryptonGroupBox3";
            // 
            // kryptonGroupBox3.Panel
            // 
            this.kryptonGroupBox3.Panel.Controls.Add(this.dgUsers);
            this.kryptonGroupBox3.Size = new System.Drawing.Size(583, 212);
            this.kryptonGroupBox3.StateCommon.Back.Color1 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.kryptonGroupBox3.TabIndex = 20;
            this.kryptonGroupBox3.Text = "User Details";
            this.kryptonGroupBox3.Values.Heading = "User Details";
            // 
            // frmUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(636, 402);
            this.Controls.Add(this.MyProgressBar);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonHeader1);
            this.Name = "frmUserDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUserDetails";
            this.Load += new System.EventHandler(this.frmUserDetails_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            this.kryptonGroupBox3.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).EndInit();
            this.kryptonGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider MyErrorProvider;
        private System.Windows.Forms.DataGridView dgUsers;
        private System.Windows.Forms.ProgressBar MyProgressBar;
        internal System.Windows.Forms.Button btnNew;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.Button btnSave;
        private System.ComponentModel.BackgroundWorker bgwStartupDataLoader;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel userDesignationLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel fullNameLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel logInPasswordLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel logInNameLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDesignation;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtFullName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUserPassword;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUserName;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox3;
    }
}

