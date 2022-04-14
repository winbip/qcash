using System.Windows.Forms;
using System.IO;
using System;


namespace QCash.AboutUsForms
{
    public partial class frmRegister : Form
    {

        #region Constructors

        public frmRegister()
        {
            InitializeComponent();
        }

        #endregion

        private void frmRegister_Load(object sender, System.EventArgs e)
        {
            txtProductKey.Text = GlobalVariables.productKey;
            txtLicenseKey.Text = GlobalVariables.licenseKey;

            if (!GlobalVariables.isRegistered)
            {
                this.Text = "Unregistered Product";
            }
            else
            {
                this.Text = "Registered Product";
                btnRegister.Enabled = false;
            }
        }

        private void btnRegister_Click(object sender, System.EventArgs e)
        {
            try
            {
                string licensekey = txtLicenseKey.Text.Trim();
                if (string.IsNullOrEmpty(licensekey))
                {
                    MessageBox.Show("Enter License Key."); return;
                }

                string licenseKeyFile = Path.Combine(GlobalVariables.AppDataDirectoryPath, "License.lcx");
                if (!File.Exists(licenseKeyFile))
                {
                    FileStream file = File.Create(licenseKeyFile);
                    file.Close();
                }

                using (StreamWriter writer = new StreamWriter(licenseKeyFile, false))
                {
                    writer.Write(licensekey);
                }

                MessageBox.Show("License Key entered successfully. It wiil be verified at the next Login." + Environment.NewLine + "Please restart the application.");
                Application.Restart();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        


    }
}
