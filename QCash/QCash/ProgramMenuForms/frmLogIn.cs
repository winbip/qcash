using System;
using System.Windows.Forms;

using CustomObjects;
using sCommonLib;
using sCommonLib.Exceptions;
using sCommonLib.Messages;
using System.IO;

namespace QCash.ProgramMenuForms
{
    public partial class frmLogIn : Form
    {
        frmMain MainForm;
        public frmLogIn(frmMain mainForm)
        {
            InitializeComponent();
            this.Load += FormIsLoading;
            MainForm = mainForm;
            pbUserIcon.Image = Properties.Resources.UserIconLoginBig;
        }

        private void FormIsLoading(object sender, EventArgs e)
        {
            try
            {
                if (GlobalVariables.isRegistered)
                {
                    string SavedUserNameFilePath = Path.Combine(GlobalVariables.AppDataDirectoryPath, "CurrentUserName.inf");
                    if (File.Exists(SavedUserNameFilePath))
                    {
                        using (StreamReader reader = new StreamReader(SavedUserNameFilePath))
                        {
                            txtLoginName.Text = reader.ReadLine();
                        }
                    }
                    else
                    {
                        FileStream file = File.Create(SavedUserNameFilePath);
                        file.Close();
                    }
                }
                else //if not not registered
                {
                    txtLoginName.Text = "Unregistered copy";
                    txtLoginName.Enabled = false;
                    txtPassword.Enabled = false;
                    btnLogin.Enabled = false;
                }

            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
        }

        private void txtLoginName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnLogin_Click(this, new System.EventArgs());
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UserLogIn newlogin = new UserLogIn(GlobalVariables.ConnectionString);
                GlobalVariables.currentUser = newlogin.PerformLogIn(txtLoginName.Text, txtPassword.Text, 1);
                if (GlobalVariables.currentUser == null)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Login Failed.", "Invalid Login Name and/or Password. Please try again."));
                }
                else
                {
                    string FilePath = Path.Combine(GlobalVariables.AppDataDirectoryPath, "CurrentUserName.inf");
                    using (StreamWriter writer = new StreamWriter(FilePath, false))
                    {
                        writer.Write(txtLoginName.Text.Trim());
                    }

                    MainForm.ProcessLogIn();
                    this.DialogResult = DialogResult.OK;
                }
            }

            catch (UserException UEx)
            {
                CustomMessageBox.ShowUserException(UEx);
            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
        }


    }
}
