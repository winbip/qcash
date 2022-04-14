using System;
using System.Windows.Forms;

using System.Data.OleDb;

using sCommonLib;
using sCommonLib.Messages;
using sCommonLib.Exceptions;

namespace QCash.ProgramMenuForms
{
    public partial class frmChangePassword : Form
    {


        #region Constructors

        public frmChangePassword()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.KeyNiceIco16;
            AddEventHandlers();
        }


        private void AddEventHandlers()
        {
            btnSave.Click += SaveEntity;
            btnClose.Click += CloseForm;
        }
        #endregion


        #region Button Click Events

        private void SaveEntity(object sender, EventArgs e)
        {
            try
            {
                if (GlobalVariables.currentUser == null)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Unauthorized Access", "You are currently not logged in. Please login first."));
                    return;
                }

                string NewPassword = txtNewPassword.Text.Trim();

                if (txtOldPassword.Text.Trim() != GlobalVariables.currentUser.UserInformation.LogInPassword)
                {
                    throw new UserException("Password Change", "Incorrent Password", "Old password is not correct. Try again.");
                }

                if (NewPassword.Length == 0)
                {
                    throw new UserException("Password Change", "Invalid Data", "Enter a password.");
                }
                else if (NewPassword.Length > 10)
                {
                    throw new UserException("Password Change", "Invalid Data", "Maximum 10 characters allowed");
                }

                btnSave.Enabled = false;
                string sqlUpdate = "update tblUserDetails set LogInPassword='" + NewPassword + "' where UserID=" + GlobalVariables.currentUser.UserInformation.UserId + "";
                using (OleDbConnection Connection = new OleDbConnection(GlobalVariables.ConnectionString))
                {
                    Connection.Open();
                    OleDbCommand cmdUpdatePassword = new OleDbCommand(sqlUpdate, Connection);
                    cmdUpdatePassword.ExecuteNonQuery();
                    Connection.Close();
                }
                CustomMessageBox.ShowSuccessMessage(new SuccessMessage("Change Password", "Success", "Password changed successfully."));
            }

            catch (UserException UEx)
            {
                CustomMessageBox.ShowUserException(UEx);
            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        private void chkShowText_CheckedChanged(object sender, EventArgs e)
        {
            string password = txtNewPassword.Text.Trim();
            if (chkShowText.Checked)
            {
                txtNewPassword.PasswordChar = '\0';
                txtNewPassword.Text = string.Empty;
                txtNewPassword.Text = password;
            }
            else
            {
                txtNewPassword.PasswordChar = '*';
                txtNewPassword.Text = string.Empty;
                txtNewPassword.Text = password;
            }
        }



    }
}
