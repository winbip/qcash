namespace QCash.MasterSetupForms
{
    partial class frmPermissions
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
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ProgressBarSave = new System.Windows.Forms.ProgressBar();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.chkSelectAllNone = new System.Windows.Forms.CheckBox();
            this.dgPermissions = new System.Windows.Forms.DataGridView();
            this.Label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.MyProgressBar = new System.Windows.Forms.ProgressBar();
            this.bgwStartupDataLoader = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPermissions)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(280, 398);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(54, 28);
            this.btnReset.TabIndex = 912;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.ProgressBarSave);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.chkSelectAllNone);
            this.groupBox1.Controls.Add(this.dgPermissions);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 288);
            this.groupBox1.TabIndex = 911;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Permission List";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.SlateGray;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(317, 258);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(54, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Visible = false;
            // 
            // ProgressBarSave
            // 
            this.ProgressBarSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBarSave.Location = new System.Drawing.Point(120, 19);
            this.ProgressBarSave.Name = "ProgressBarSave";
            this.ProgressBarSave.Size = new System.Drawing.Size(251, 15);
            this.ProgressBarSave.TabIndex = 8;
            this.ProgressBarSave.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(11, 258);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 20);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TabStop = false;
            this.txtSearch.Visible = false;
            // 
            // chkSelectAllNone
            // 
            this.chkSelectAllNone.AutoSize = true;
            this.chkSelectAllNone.Location = new System.Drawing.Point(10, 20);
            this.chkSelectAllNone.Name = "chkSelectAllNone";
            this.chkSelectAllNone.Size = new System.Drawing.Size(15, 14);
            this.chkSelectAllNone.TabIndex = 10;
            this.chkSelectAllNone.UseVisualStyleBackColor = true;
            this.chkSelectAllNone.CheckedChanged += new System.EventHandler(this.chkSelectAllNone_CheckedChanged);
            // 
            // dgPermissions
            // 
            this.dgPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPermissions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPermissions.BackgroundColor = System.Drawing.Color.White;
            this.dgPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPermissions.Location = new System.Drawing.Point(11, 44);
            this.dgPermissions.Name = "dgPermissions";
            this.dgPermissions.Size = new System.Drawing.Size(360, 209);
            this.dgPermissions.TabIndex = 9;
            this.dgPermissions.TabStop = false;
            this.dgPermissions.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgPermissions_CurrentCellDirtyStateChanged);
            this.dgPermissions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPermissions_CellContentClick);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(25, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(77, 13);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "select all/none";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbUsers);
            this.groupBox2.Location = new System.Drawing.Point(15, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 60);
            this.groupBox2.TabIndex = 910;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select User";
            // 
            // cmbUsers
            // 
            this.cmbUsers.BackColor = System.Drawing.Color.White;
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(10, 24);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(158, 21);
            this.cmbUsers.TabIndex = 0;
            this.cmbUsers.SelectedIndexChanged += new System.EventHandler(this.cmbUsers_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(340, 398);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 28);
            this.btnExit.TabIndex = 908;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(212, 398);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(62, 28);
            this.btnSave.TabIndex = 907;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MyProgressBar
            // 
            this.MyProgressBar.Location = new System.Drawing.Point(15, 398);
            this.MyProgressBar.Name = "MyProgressBar";
            this.MyProgressBar.Size = new System.Drawing.Size(190, 20);
            this.MyProgressBar.TabIndex = 909;
            this.MyProgressBar.Visible = false;
            // 
            // bgwStartupDataLoader
            // 
            this.bgwStartupDataLoader.WorkerReportsProgress = true;
            this.bgwStartupDataLoader.WorkerSupportsCancellation = true;
            this.bgwStartupDataLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwStartupDataLoader_DoWork);
            this.bgwStartupDataLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwStartupDataLoader_RunWorkerCompleted);
            this.bgwStartupDataLoader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwStartupDataLoader_ProgressChanged);
            // 
            // frmPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 450);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.MyProgressBar);
            this.Name = "frmPermissions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permissions";
            this.Load += new System.EventHandler(this.frmPermissions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPermissions)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btnSearch;
        internal System.Windows.Forms.ProgressBar ProgressBarSave;
        internal System.Windows.Forms.TextBox txtSearch;
        internal System.Windows.Forms.CheckBox chkSelectAllNone;
        internal System.Windows.Forms.DataGridView dgPermissions;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.ComboBox cmbUsers;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.ProgressBar MyProgressBar;
        internal System.ComponentModel.BackgroundWorker bgwStartupDataLoader;
    }
}