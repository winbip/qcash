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
using System.Diagnostics;
using System.IO;

namespace QCash
{
    public partial class frmMain : Form
    {
        #region Private Variables
        private StartupError pStartupError;
        #endregion

        #region Public Properties
        public StartupError StartupErrorInfo
        {
            get { return pStartupError; }
            set { pStartupError = value; }
        }
        #endregion

        #region Constructor
        public frmMain()
        {
            InitializeComponent();
            this.Resize += FormIsResizing;
            btnDebitVoucher.Click += submenuDrVoucher_Click;
            btnCreditVoucher.Click += submenuCrVoucher_Click;
            btnJournalVoucher.Click += submenuJournalVoucher_Click;
            btnCashBook.Click += submenuCashBook_Click;
            btnLedgerBook.Click += submenuGeneralLedger_Click;
            btnTrialBalance.Click += submenuTrialBalance_Click;
            this.Icon = Properties.Resources.GreenUSDollarIco64;
            pStartupError = new StartupError();
        }
        #endregion



        private void FormIsResizing(object sender, EventArgs e)
        {
            //int FormWidth = this.Width + 173;
            //lblAppName.Top = (this.Height - lblAppName.Height) / 2;
            //lblAppName.Left = (FormWidth - lblAppName.Width) / 2;

            int FormWidth = this.Width + 173;
            pnlMenu.Top = (this.Height - pnlMenu.Height) / 2;
            pnlMenu.Left = (FormWidth - (pnlMenu.Width + 170)) / 2;
        }

        public void StartSplashForm()
        {
            frmSplash SplashForm = new frmSplash(this);
            DialogResult SplashResult = SplashForm.ShowDialog();

            switch (SplashResult)
            {
                case DialogResult.Abort:
                    break;

                case DialogResult.OK:
                    this.pnlMenu.Visible = true;
                    ProgramMenuForms.frmLogIn LogInForm = new ProgramMenuForms.frmLogIn(this);
                    LogInForm.ShowDialog();
                    break;

                case DialogResult.Retry:
                    MessageBox.Show(this.pStartupError.ErrorDetails.ToString());
                    switch (this.pStartupError.StartupErrorId)
                    {
                        case 101: //Database Configuration not found.
                            MasterSetupForms.frmDatabaseConfiguration frm = new MasterSetupForms.frmDatabaseConfiguration(this);
                            frm.Show(this);
                            frm.BringToFront();
                            break;

                        case 102:
                            break;

                        case 103: //Font installed completed.
                            Application.Restart();
                            break;

                        case 104: // Font not found in application directory.
                            Application.Exit();
                            break;

                        default:
                            break;
                    }

                    break;
                default:
                    break;
            }
        }

        private Boolean IsLoggedIn()
        {
            if (GlobalVariables.currentUser == null)
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are currently not logged in. Please login first."));
                return false;
            }
            else
            {
                return true;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                //Multiple Instance of this application is turned-off. See Program.cs for details.
                ProcessLogOut();
                StatusLabelDate.Text = DateTime.Today.Date.ToString("dd MMM yyyy");
                StartSplashForm();
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

        #region Process Login Logout
        public void ProcessLogIn() //this has been called from frmLogIn.
        {
            this.submenuLogIn.Enabled = false;
            this.submenuLogOut.Enabled = true;
            this.submenuChangePassword.Enabled = true;

            this.StatusLabelLoginStatus.Image = Properties.Resources.LoggedIn;
            this.StatusLabelLoginStatus.ForeColor = Color.Green;
            this.StatusLabelLoginStatus.Text = "User: " + GlobalVariables.currentUser.UserInformation.LogInName;
        }


        private void ProcessLogOut()
        {
            GlobalVariables.currentUser = null;

            submenuLogIn.Enabled = true;
            submenuLogOut.Enabled = false;
            submenuChangePassword.Enabled = false;

            StatusLabelLoginStatus.Image = Properties.Resources.LoggedOut;
            StatusLabelLoginStatus.ForeColor = Color.Red;
            StatusLabelLoginStatus.Text = "User: None";

        }

        #endregion

        #region Program Menu Links

        private void submenuLogIn_Click(object sender, EventArgs e)
        {
            ProgramMenuForms.frmLogIn LogInForm = new ProgramMenuForms.frmLogIn(this);
            LogInForm.ShowDialog();
        }

        private void submenuLogOut_Click(object sender, EventArgs e)
        {
            ProcessLogOut();
            ProgramMenuForms.frmLogIn LogInForm = new ProgramMenuForms.frmLogIn(this);
            LogInForm.ShowDialog();
        }


        private void submenuChangePassword_Click(object sender, EventArgs e)
        {
            ProgramMenuForms.frmChangePassword frm =
                new ProgramMenuForms.frmChangePassword();
            frm.Show(this);
        }

        private void submenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion


        #region Master Setup Forms

        private void submenuCompanyInfo_Click(object sender, EventArgs e)
        {
            if (GlobalVariables.currentUser == null)
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are currently not logged in. Please login first."));
                return;
            }
            else
            {
                if (!GlobalVariables.currentUser.FindPermission("9")) //TODO: Change here
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are not permitted to do this task. Contact your admin."));
                    return;
                }
            }

            MasterSetupForms.frmCompanyInfo frm = new MasterSetupForms.frmCompanyInfo();
            frm.Show();
        }

 

        private void submenuPermissions_Click(object sender, EventArgs e)
        {
            if (GlobalVariables.currentUser == null)
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are currently not logged in. Please login first."));
                return;
            }
            else
            {
                if (!GlobalVariables.currentUser.FindPermission("10"))
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are not permitted to do this task. Contact your admin."));
                    return;
                }
            }

            MasterSetupForms.frmPermissions frm = new MasterSetupForms.frmPermissions();
            frm.Show(this);
        }
        #endregion

        #region Utility Menu Forms

        private void submenuErrorLogs_Click(object sender, EventArgs e)
        {
            string ErrorLogPath = Path.Combine(GlobalVariables.AppDataDirectoryPath, "ErrorLog.log");
            Process.Start(ErrorLogPath);
        }

        #endregion

        private void submenuResetDatabase_Click(object sender, EventArgs e)
        {
            InputDialogBox.InputDialogResult result = InputDialogBox.InputDialog.Show(InputDialogBox.InputType.String, "Enter Password");
            if (result.OK)
            {
                if (result.Value.ToString().Equals("somehowiknow"))
                {
                    frmResetDatabase frm = new frmResetDatabase();
                    frm.Show(this);
                }
                else
                {
                    MessageBox.Show("Wrong Password");
                }
            }

        }

        private void submenuEventMaker_Click(object sender, EventArgs e)
        {
            frmEventMaker frm = new frmEventMaker();
            frm.Show();
        }

        private void submenuDatabaseConfiguration_Click(object sender, EventArgs e)
        {
            MasterSetupForms.frmDatabaseConfiguration frm = new MasterSetupForms.frmDatabaseConfiguration(this);
            frm.Show(this);
        }

        private void subCategoryListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsLoggedIn())
            {
            MasterSetupForms.SubCategoryForms.frmSubCategoryList frm =
                new MasterSetupForms.SubCategoryForms.frmSubCategoryList();
            frm.Show(this);
            }

        }

        private void addEditSubCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsLoggedIn())
            {
            MasterSetupForms.SubCategoryForms.frmSubCategoryDetails frm =
               new MasterSetupForms.SubCategoryForms.frmSubCategoryDetails();
            frm.Show(this);
            }

        }



        private void chartOfAccountHeadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsLoggedIn())
            {
                MasterSetupForms.ChartOfAccountsForm.frmChartOfAccount frm =
                    new MasterSetupForms.ChartOfAccountsForm.frmChartOfAccount();
                frm.Show(this);
            }
        }

        private void submenuDrVoucher_Click(object sender, EventArgs e)
        {
            if (IsLoggedIn())
            {
            VoucherMenuForms.frmVoucher frm = new VoucherMenuForms.frmVoucher(1, null);
            frm.Show(this);
            }

        }

        private void submenuCrVoucher_Click(object sender, EventArgs e)
        {
            if (IsLoggedIn())
            {
            VoucherMenuForms.frmVoucher frm = new VoucherMenuForms.frmVoucher(2, null);
            frm.Show(this);
            }

        }

        private void submenuJournalVoucher_Click(object sender, EventArgs e)
        {
            if (IsLoggedIn())
            {
            VoucherMenuForms.frmVoucher frm = new VoucherMenuForms.frmVoucher(3, null);
            frm.Show(this);
            }

        }

        private void submenuCashBook_Click(object sender, EventArgs e)
        {
            if (IsLoggedIn())
            {
            ViewMenuForms.frmCashBook frm = new ViewMenuForms.frmCashBook();
            frm.Show(this);
            }

        }

        private void submenuGeneralLedger_Click(object sender, EventArgs e)
        {
            if (IsLoggedIn())
            {
            ViewMenuForms.frmGeneralLedger frm = new ViewMenuForms.frmGeneralLedger(null);
            frm.Show(this);
            }

        }

        private void submenuTrialBalance_Click(object sender, EventArgs e)
        {
            if (IsLoggedIn())
            {
                ViewMenuForms.frmTrialBalance frm = new ViewMenuForms.frmTrialBalance();
                frm.Show(this);
            }
        }

        private void submenuVoucherHistory_Click(object sender, EventArgs e)
        {
            if (IsLoggedIn())
            {
            VoucherMenuForms.frmVoucherHistory frm = new VoucherMenuForms.frmVoucherHistory();
            frm.Show(this);
            }

        }

        private void submenuAddOpeningBalance_Click(object sender, EventArgs e)
        {
            if (IsLoggedIn())
            {
                MasterSetupForms.OpeningBalanceForms.frmOpeningBalance frm =
                    new MasterSetupForms.OpeningBalanceForms.frmOpeningBalance();
                frm.Show(this);
            }
        }

        private void submenuOpeningBalanceHistory_Click(object sender, EventArgs e)
        {
            if (IsLoggedIn())
            {
                MasterSetupForms.OpeningBalanceForms.frmOpeningBalanceHistory frm =
                    new MasterSetupForms.OpeningBalanceForms.frmOpeningBalanceHistory();
                frm.Show(this);
            }
        }

        private void submenuAddEditUser_Click(object sender, EventArgs e)
        {
            if (IsLoggedIn())
            {
                MasterSetupForms.UserMenuForms.frmAppUser frm =
                    new MasterSetupForms.UserMenuForms.frmAppUser();
                frm.Show(this);
            }
        }

        private void submenuUserList_Click(object sender, EventArgs e)
        {
            if (IsLoggedIn())
            {
                MasterSetupForms.UserMenuForms.frmAppUserList frm =
                    new MasterSetupForms.UserMenuForms.frmAppUserList();
                frm.Show(this);
            }
        }

        private void submenuAboutUs_Click(object sender, EventArgs e)
        {
            AboutUsForms.frmAboutUs frm = new AboutUsForms.frmAboutUs();
            frm.Show(this);
        }

        private void submenuRegister_Click(object sender, EventArgs e)
        {
            AboutUsForms.frmRegister frm = new AboutUsForms.frmRegister();
            frm.Show(this);
        }

        private void submenuExportData_Click(object sender, EventArgs e)
        {
            if (IsLoggedIn())
            {
                UtilityMenuForms.frmExportData frm = new UtilityMenuForms.frmExportData();
                frm.Show(this);
            }
        }



    }
}
