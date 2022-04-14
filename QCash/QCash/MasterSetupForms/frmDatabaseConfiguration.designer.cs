namespace QCash.MasterSetupForms
{
    partial class frmDatabaseConfiguration
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
            this.kryptonHeaderOperatingYear = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelectDatabaseDirectory = new System.Windows.Forms.Button();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.chkCreateNewDatabase = new System.Windows.Forms.CheckBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtDatabaseDirectory = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtOperatingYear = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonHeaderOperatingYear
            // 
            this.kryptonHeaderOperatingYear.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeaderOperatingYear.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderOperatingYear.Name = "kryptonHeaderOperatingYear";
            this.kryptonHeaderOperatingYear.Size = new System.Drawing.Size(473, 36);
            this.kryptonHeaderOperatingYear.TabIndex = 0;
            this.kryptonHeaderOperatingYear.Values.Description = "";
            this.kryptonHeaderOperatingYear.Values.Heading = "Database Configuration";
            this.kryptonHeaderOperatingYear.Values.Image = global::QCash.Properties.Resources.ServerPng32;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.kryptonLabel3);
            this.panel1.Controls.Add(this.txtOperatingYear);
            this.panel1.Controls.Add(this.txtDatabaseDirectory);
            this.panel1.Controls.Add(this.btnSelectDatabaseDirectory);
            this.panel1.Controls.Add(this.kryptonLabel2);
            this.panel1.Controls.Add(this.chkCreateNewDatabase);
            this.panel1.Controls.Add(this.kryptonLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 201);
            this.panel1.TabIndex = 1;
            // 
            // btnSelectDatabaseDirectory
            // 
            this.btnSelectDatabaseDirectory.Location = new System.Drawing.Point(421, 60);
            this.btnSelectDatabaseDirectory.Name = "btnSelectDatabaseDirectory";
            this.btnSelectDatabaseDirectory.Size = new System.Drawing.Size(31, 21);
            this.btnSelectDatabaseDirectory.TabIndex = 8;
            this.btnSelectDatabaseDirectory.Text = "...";
            this.btnSelectDatabaseDirectory.UseVisualStyleBackColor = true;
            this.btnSelectDatabaseDirectory.Click += new System.EventHandler(this.btnSelectDatabaseDirectory_Click);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(19, 35);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(114, 20);
            this.kryptonLabel2.TabIndex = 7;
            this.kryptonLabel2.Values.Text = "Database Directory";
            // 
            // chkCreateNewDatabase
            // 
            this.chkCreateNewDatabase.AutoSize = true;
            this.chkCreateNewDatabase.ForeColor = System.Drawing.Color.Black;
            this.chkCreateNewDatabase.Location = new System.Drawing.Point(26, 148);
            this.chkCreateNewDatabase.Name = "chkCreateNewDatabase";
            this.chkCreateNewDatabase.Size = new System.Drawing.Size(15, 14);
            this.chkCreateNewDatabase.TabIndex = 5;
            this.chkCreateNewDatabase.UseVisualStyleBackColor = true;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(20, 89);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(93, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Operating Year";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(473, 1);
            this.label1.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(389, 246);
            this.btnSave.Name = "btnSave";
            this.btnSave.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnSave.Size = new System.Drawing.Size(74, 28);
            this.btnSave.TabIndex = 3;
            this.btnSave.Values.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDatabaseDirectory
            // 
            this.txtDatabaseDirectory.Location = new System.Drawing.Point(23, 60);
            this.txtDatabaseDirectory.Name = "txtDatabaseDirectory";
            this.txtDatabaseDirectory.Size = new System.Drawing.Size(392, 22);
            this.txtDatabaseDirectory.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtDatabaseDirectory.StateCommon.Border.Rounding = 3;
            this.txtDatabaseDirectory.TabIndex = 9;
            // 
            // txtOperatingYear
            // 
            this.txtOperatingYear.Location = new System.Drawing.Point(23, 111);
            this.txtOperatingYear.Name = "txtOperatingYear";
            this.txtOperatingYear.Size = new System.Drawing.Size(392, 22);
            this.txtOperatingYear.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtOperatingYear.StateCommon.Border.Rounding = 3;
            this.txtOperatingYear.TabIndex = 10;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(40, 145);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(128, 20);
            this.kryptonLabel3.TabIndex = 11;
            this.kryptonLabel3.Values.Text = "Create New Database";
            // 
            // frmDatabaseConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(473, 283);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonHeaderOperatingYear);
            this.MaximizeBox = false;
            this.Name = "frmDatabaseConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Configuration";
            this.Load += new System.EventHandler(this.frmOperatingYearSetup_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeaderOperatingYear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.CheckBox chkCreateNewDatabase;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private System.Windows.Forms.Button btnSelectDatabaseDirectory;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtOperatingYear;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDatabaseDirectory;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
    }
}