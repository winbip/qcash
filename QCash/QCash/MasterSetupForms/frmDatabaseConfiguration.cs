using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CustomObjects;
using sCommonLib;
using sCommonLib.Messages;
using sCommonLib.Exceptions;
using System.IO;

namespace QCash.MasterSetupForms
{
    public partial class frmDatabaseConfiguration : Form
    {
        private frmMain MainForm;

        public frmDatabaseConfiguration()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ServerIco16;
        }

        public frmDatabaseConfiguration(frmMain PrevForm)
        {

            InitializeComponent();
            this.Icon = Properties.Resources.ServerIco16;
            MainForm = PrevForm;
        }

        private void frmOperatingYearSetup_Load(object sender, EventArgs e)
        {
            txtDatabaseDirectory.Text = GlobalVariables.DatabaseDirectory;
            txtOperatingYear.Text = GlobalVariables.OperatingYear;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                string databaseDirectory = txtDatabaseDirectory.Text;
                if (string.IsNullOrEmpty(databaseDirectory))
                {
                    throw new UserException("Database Configuration", "Invalid input", "Database Configuration is not valid.", txtDatabaseDirectory);
                }

                int OperatingYear;
                if (!int.TryParse(txtOperatingYear.Text.Trim(), out OperatingYear))
                {
                    throw new UserException("Operating Year", "Invalid input", "Operating year is not valid.", txtOperatingYear);
                }

                if (OperatingYear.ToString().Length != 4)
                {
                    throw new UserException("Operating Year", "Invalid input", "Operating year is not valid.", txtOperatingYear);
                }

                //-->Create Database 
                if (chkCreateNewDatabase.Checked)
                {

                    string sourceFileName = Application.StartupPath + "\\MainDatabase.mdb";
                    string destFileName = databaseDirectory + "\\" + ConnectionStringGenerator.DatabasePrefix + OperatingYear.ToString() + ".mdb";

                    if (!File.Exists(sourceFileName))
                    {
                        MessageBox.Show("Source file not found."); return;
                    }

                    if (File.Exists(destFileName))
                    {
                        MessageBox.Show("Destination file already exists."); return;
                    }


                    File.Copy(sourceFileName, destFileName);


                }
                //<--Create Database 

                string DatabaseConfigFilePath = Path.Combine(GlobalVariables.AppDataDirectoryPath, "Database.Config");
                using (StreamWriter writer = new StreamWriter(DatabaseConfigFilePath, false))
                {
                    writer.Write(databaseDirectory + "*" + OperatingYear.ToString());
                }


                this.Close(); MainForm.StartSplashForm();
            }
            catch (UserException UEX)
            {
                CustomMessageBox.ShowUserException(UEX);
            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
        }

        private void btnSelectDatabaseDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog SelectDatabaseDirectory = new FolderBrowserDialog();

            DialogResult result = SelectDatabaseDirectory.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtDatabaseDirectory.Text = SelectDatabaseDirectory.SelectedPath.ToString();
            }
        }
    }
}
