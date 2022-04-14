namespace QCash.MasterSetupForms
{
    partial class frmCompanyInfo
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
            System.Windows.Forms.Label addressLineOneLabel;
            System.Windows.Forms.Label addressLineTwoLabel;
            System.Windows.Forms.Label companyNameLabel;
            this.FormHeader = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAddressLineOne = new System.Windows.Forms.TextBox();
            this.txtAddressLineTwo = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDelete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.bsCurrentEntity = new System.Windows.Forms.BindingSource(this.components);
            addressLineOneLabel = new System.Windows.Forms.Label();
            addressLineTwoLabel = new System.Windows.Forms.Label();
            companyNameLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCurrentEntity)).BeginInit();
            this.SuspendLayout();
            // 
            // addressLineOneLabel
            // 
            addressLineOneLabel.AutoSize = true;
            addressLineOneLabel.Location = new System.Drawing.Point(39, 106);
            addressLineOneLabel.Name = "addressLineOneLabel";
            addressLineOneLabel.Size = new System.Drawing.Size(94, 13);
            addressLineOneLabel.TabIndex = 0;
            addressLineOneLabel.Text = "Address Line One:";
            // 
            // addressLineTwoLabel
            // 
            addressLineTwoLabel.AutoSize = true;
            addressLineTwoLabel.Location = new System.Drawing.Point(39, 158);
            addressLineTwoLabel.Name = "addressLineTwoLabel";
            addressLineTwoLabel.Size = new System.Drawing.Size(95, 13);
            addressLineTwoLabel.TabIndex = 2;
            addressLineTwoLabel.Text = "Address Line Two:";
            // 
            // companyNameLabel
            // 
            companyNameLabel.AutoSize = true;
            companyNameLabel.Location = new System.Drawing.Point(38, 49);
            companyNameLabel.Name = "companyNameLabel";
            companyNameLabel.Size = new System.Drawing.Size(85, 13);
            companyNameLabel.TabIndex = 6;
            companyNameLabel.Text = "Company Name:";
            // 
            // FormHeader
            // 
            this.FormHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.FormHeader.Location = new System.Drawing.Point(0, 0);
            this.FormHeader.Name = "FormHeader";
            this.FormHeader.Size = new System.Drawing.Size(514, 31);
            this.FormHeader.TabIndex = 0;
            this.FormHeader.Values.Description = "";
            this.FormHeader.Values.Heading = "Company Information";
            this.FormHeader.Values.Image = global::QCash.Properties.Resources.OfficeTree16;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(41, 296);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 41);
            this.btnSave.TabIndex = 1;
            this.btnSave.Values.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(addressLineOneLabel);
            this.panel1.Controls.Add(this.txtAddressLineOne);
            this.panel1.Controls.Add(addressLineTwoLabel);
            this.panel1.Controls.Add(this.txtAddressLineTwo);
            this.panel1.Controls.Add(companyNameLabel);
            this.panel1.Controls.Add(this.txtCompanyName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 254);
            this.panel1.TabIndex = 0;
            // 
            // txtAddressLineOne
            // 
            this.txtAddressLineOne.Location = new System.Drawing.Point(41, 122);
            this.txtAddressLineOne.Name = "txtAddressLineOne";
            this.txtAddressLineOne.Size = new System.Drawing.Size(437, 20);
            this.txtAddressLineOne.TabIndex = 1;
            // 
            // txtAddressLineTwo
            // 
            this.txtAddressLineTwo.Location = new System.Drawing.Point(41, 174);
            this.txtAddressLineTwo.Name = "txtAddressLineTwo";
            this.txtAddressLineTwo.Size = new System.Drawing.Size(437, 20);
            this.txtAddressLineTwo.TabIndex = 2;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(41, 65);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(437, 20);
            this.txtCompanyName.TabIndex = 0;
            this.txtCompanyName.Validating += new System.ComponentModel.CancelEventHandler(this.txtCompanyName_Validating);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(514, 1);
            this.label1.TabIndex = 3;
            // 
            // MyErrorProvider
            // 
            this.MyErrorProvider.ContainerControl = this;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(166, 296);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(108, 41);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Values.Text = "&Delete";
            this.btnDelete.Visible = false;
            // 
            // frmCompanyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(514, 345);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.FormHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmCompanyInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Info";
            this.Load += new System.EventHandler(this.frmCompanyInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCurrentEntity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeader FormHeader;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddressLineOne;
        private System.Windows.Forms.TextBox txtAddressLineTwo;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.ErrorProvider MyErrorProvider;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDelete;
        private System.Windows.Forms.BindingSource bsCurrentEntity;
    }
}