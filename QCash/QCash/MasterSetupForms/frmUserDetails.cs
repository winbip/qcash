using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CustomObjects;
using sCommonLib;
using sCommonLib.Messages;
using sCommonLib.Exceptions;
using System.Collections;



namespace QCash.MasterSetupForms
{
    public partial class frmUserDetails : Form
    {

        #region Private Variables

        DataTable dtUsers;
        string EntryMode;
        int ProgressValue;
        #endregion

        #region Constructors

        public frmUserDetails()
        {
            InitializeComponent();
            btnDelete.Visible = false;

        }

        #endregion

        #region Functions

        private void StartBackgroundWorker()
        {
            this.Cursor = Cursors.WaitCursor;
            MyProgressBar.Value = 0;
            MyProgressBar.Maximum = 10;
            MyProgressBar.Visible = true;
            // bgwStartupDataLoader = new System.ComponentModel.BackgroundWorker();

            bgwStartupDataLoader.WorkerReportsProgress = true;
            bgwStartupDataLoader.WorkerSupportsCancellation = true;
            bgwStartupDataLoader.RunWorkerAsync();

        }

        private void ReportProgress()
        {
            ProgressValue += 1;
            bgwStartupDataLoader.ReportProgress(ProgressValue);
            System.Threading.Thread.Sleep(10);
        }

        private void ReportPostProgress()
        {
            Application.DoEvents();
            MyProgressBar.Value += 1;
            System.Threading.Thread.Sleep(10);
        }

        private void FormatDataGrid()
        {
            dgUsers.RowHeadersVisible = false;
            dgUsers.AllowUserToAddRows = false;
            dgUsers.AllowUserToDeleteRows = false;
            dgUsers.AllowUserToResizeRows = false;

            dgUsers.ColumnHeadersVisible = true;
            dgUsers.AllowUserToOrderColumns = false;
            dgUsers.AllowUserToResizeColumns = false;

            dgUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgUsers.ScrollBars = ScrollBars.Vertical;
            dgUsers.ReadOnly = true;
            dgUsers.MultiSelect = false;

            dgUsers.EnableHeadersVisualStyles = false;
            dgUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            dgUsers.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.Wheat;
            dgUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgUsers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //.ColumnHeadersDefaultCellStyle.Font = New Font(MyFontName, MyFontSize, FontStyle.Regular)

            dgUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            //\\SingleHorizontal is required to set custom gridcolor
            dgUsers.GridColor = Color.LightSteelBlue;
            dgUsers.BorderStyle = BorderStyle.None;
            dgUsers.BackgroundColor = Color.White;

            //.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            //.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            dgUsers.DefaultCellStyle.BackColor = Color.Blue;
            dgUsers.DefaultCellStyle.ForeColor = Color.Yellow;

            dgUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.SlateGray;
            dgUsers.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            dgUsers.DefaultCellStyle.SelectionBackColor = Color.Red;
            //Color.White '
            dgUsers.DefaultCellStyle.SelectionForeColor = Color.White;
            //Color.Black '

            dgUsers.Columns[0].Visible = false;
            dgUsers.Columns[1].Visible = true;
            dgUsers.Columns[1].Width = 100;
            dgUsers.Columns[1].HeaderText = "User Name";
            dgUsers.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgUsers.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgUsers.Columns[1].HeaderCell.Style.BackColor = Color.Lavender;
            dgUsers.Columns[1].HeaderCell.Style.ForeColor = Color.SlateGray;
            dgUsers.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgUsers.Columns[2].Visible = false;

            dgUsers.Columns[3].Visible = true;
            dgUsers.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //.Width = 100
            //.ReadOnly = True
            dgUsers.Columns[3].HeaderText = "Full Name";
            dgUsers.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgUsers.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgUsers.Columns[3].HeaderCell.Style.BackColor = Color.Lavender;
            dgUsers.Columns[3].HeaderCell.Style.ForeColor = Color.SlateGray;
            dgUsers.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgUsers.Columns[4].Visible = true;
            dgUsers.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //.Width = 100
            //.ReadOnly = True
            dgUsers.Columns[4].HeaderText = "Designation";
            dgUsers.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgUsers.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgUsers.Columns[4].HeaderCell.Style.BackColor = Color.Lavender;
            dgUsers.Columns[4].HeaderCell.Style.ForeColor = Color.SlateGray;
            dgUsers.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dgUsers.ClearSelection();

        }


        private void ClearTextbox()
        {
            txtUserName.Clear(); txtUserPassword.Clear(); txtFullName.Clear(); txtDesignation.Clear();
        }

        private void ClearComboBox(ComboBox[] ComboBoxes)
        {
            for (int i = 0; i <= ComboBoxes.Length - 1; i++)
            {
                ComboBoxes[i].Text = "";
            }
        }

        private void AddNewMode()
        {
            EntryMode = "Add";
            txtUserName.ReadOnly = false;
            //lblFormHeading.Text = " Add New User";
            btnSave.Text = EntryMode;
            // btnSave.Image = My.Resources.UserAddBlue16;
            btnDelete.Enabled = false;

            ClearTextbox();

            MyErrorProvider.Clear();
            //MyOkProvider.Clear()
            dgUsers.ClearSelection();
        }

        private void UpdateMode()
        {
            EntryMode = "Update";
            txtUserName.ReadOnly = true;
            btnDelete.Enabled = true;
            // btnSave.Image = My.Resources.UserUpdate16;
            btnSave.Text = EntryMode;
            // lblFormHeading.Text = " Update User Info";
            MyErrorProvider.Clear();
            //MyOkProvider.Clear()
        }

        private bool IsUserExists(string UserName)
        {
            using (OleDbConnection Connection = new OleDbConnection(GlobalVariables.ConnectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand("select LogInName from tblUserDetails where LogInName='" + UserName + "'", Connection))
                {
                    Connection.Open();
                    object result = cmd.ExecuteScalar();
                    Connection.Close();
                    if (result != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        #endregion

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            StartBackgroundWorker();
        }

        private void bgwStartupDataLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                ProgressValue = 0;

                using (OleDbConnection Connection = new OleDbConnection(GlobalVariables.ConnectionString))
                {

                    OleDbDataAdapter daUsers = new OleDbDataAdapter("select UserID,LogInName,LogInPassword,FullName, UserDesignation from tblUserDetails where UserID>1 order by LogInName asc", Connection);

                    dtUsers = new DataTable();

                    ReportProgress();
                    //---------------------------------------------------------progress 1

                    Connection.Open();
                    ReportProgress();
                    //---------------------------------------------------------progress 2

                    daUsers.Fill(dtUsers);
                    ReportProgress();
                    //---------------------------------------------------------progress 3

                    daUsers.Dispose();
                    ReportProgress();
                    //---------------------------------------------------------progress 4

                    ReportProgress();
                    //---------------------------------------------------------progress 5

                }

            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
        }

        private void bgwStartupDataLoader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MyProgressBar.Value = e.ProgressPercentage;
        }

        private void bgwStartupDataLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled == true)
                {
                    MessageBox.Show("Task Cancelled.");
                }
                else if (e.Error != null)
                {
                    MessageBox.Show("Error: " + e.Error.Message);
                }
                else
                {
                    ReportPostProgress();
                    //--------------------------------Progress 1

                    ReportPostProgress();
                    //--------------------------------Progress 2


                    dgUsers.DataSource = null;
                    dgUsers.Rows.Clear();
                    dgUsers.DataSource = dtUsers;


                    FormatDataGrid();

                    //  End If

                    ReportPostProgress();
                    //--------------------------------Progress 3

                    ReportPostProgress();
                    //--------------------------------Progress 4

                    AddNewMode();

                    ReportPostProgress();
                    //--------------------------------Progress 5
                }

            }
            catch (Exception ex)
            {
                MyProgressBar.Visible = false;
                this.Cursor = Cursors.Default;
                CustomMessageBox.ShowSystemException(ex);
            }
            finally
            {
                MyProgressBar.Visible = false;
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if (GlobalVariables.currentUser.UserInformation.UserId != 1)
                //{
                //    MessageBox.Show("You are not allowed to create new user.");
                //    return;
                //}

                string UserPassword = "";
                {
                    if (txtUserPassword.Text.Trim() == "")
                    {
                        throw new UserException("User", "Error", "Enter Password");
                    }
                    else if (txtUserPassword.Text.Trim().Length > 10)
                    {
                        throw new UserException("", "Error", "Maximum 10 characters allowed.");
                    }
                    else
                    {
                        UserPassword = txtUserPassword.Text.Trim();

                    }
                }

                string FullName = "";
                {
                    if (txtFullName.Text.Trim().Length > 25)
                    {
                        throw new UserException("", "", "Maximum 25 characters allowed.");
                    }
                    else
                    {
                        FullName = txtFullName.Text.Trim();

                    }
                }

                string Designation;
                {
                    Designation = txtDesignation.Text.Trim();
                    if (Designation.Length > 25)
                    {
                        throw new UserException("", "", "Maximum 25 characters allowed.", this.txtDesignation);
                    }

                }

                switch (EntryMode)
                {
                    case "Add":


                        string UserName = "";
                        {
                            if (txtUserName.Text.Trim() == "")
                            {
                                throw new UserException("", "", "Please enter user name.", this.txtUserName);
                            }
                            else if (txtUserName.Text.Trim().Length > 10)
                            {
                                throw new UserException("", "", "User name can not be more than 10 chars.", this.txtUserName);
                                //ElseIf SQLServerFunctions.FindRecords("select UserName from tblUser where UserName='" & txtUserName.Text.Trim & "'", CreateConnectionString(DatabaseName)) = True Then

                            }
                            else if (IsUserExists(txtUserName.Text.Trim()))
                            {
                                throw new UserException("", "", "User name already exists.", this.txtUserName);
                            }
                            else
                            {
                                UserName = txtUserName.Text.Trim();
                            }
                        }

                        using (OleDbConnection Connection = new OleDbConnection(GlobalVariables.ConnectionString))
                        {
                            string sqlLastId = "select Max(UserId) as LastId from tblUserDetails";
                            OleDbCommand cmd = new OleDbCommand(sqlLastId, Connection);
                            Connection.Open();
                            object objLastId = cmd.ExecuteScalar();
                            int UserId = (int)objLastId + 1;
                            string sqlInsertUserInfo = "insert into tblUserDetails(UserId,LogInName,LogInPassword,FullName,UserDesignation,CompanyId) values(" + UserId + ",'" + UserName + "','" + UserPassword + "','" + FullName + "','" + Designation + "',1)";
                            OleDbCommand cmdInsert = new OleDbCommand(sqlInsertUserInfo, Connection);
                            cmdInsert.ExecuteNonQuery();
                            Connection.Close();
                            StartBackgroundWorker();
                            CustomMessageBox.ShowSuccessMessage(new SuccessMessage("User", "Success", "New user added successfully."));
                        }

                        break;

                    case "Update":

                        int UserID;
                        if (dgUsers.SelectedRows.Count != 1)
                        {
                            MessageBox.Show("Select a User.");
                            return;
                        }
                        else
                        {
                            UserID = (int)dgUsers.CurrentRow.Cells["UserID"].FormattedValue;
                        }


                        string sqlUpateInfo;
                        sqlUpateInfo = "update tblUserDetails set UserPassword='" + UserPassword + "', FullName='" + FullName + "', UserDesignation='" + Designation + "' where UserID=" + UserID + "";
                        using (OleDbConnection Connection = new OleDbConnection(GlobalVariables.ConnectionString))
                        {
                            Connection.Open();
                            using (OleDbCommand cmd = new OleDbCommand(sqlUpateInfo, Connection))
                            {
                                cmd.ExecuteNonQuery();
                            }
                            Connection.Close();
                        }

                        StartBackgroundWorker(); MessageBox.Show("User information updated successfully.");
                        break;
                }

            }
            catch (UserException ex)
            {

                CustomMessageBox.ShowUserException(ex);
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowSystemException(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ushort UserID;
            //    if (dgUsers.SelectedRows.Count != 1)
            //    {
            //        CustomMsgBox.ShowErrorMessage("", "Select a User.", this);
            //        return;
            //    }
            //    else
            //    {
            //        UserID = dgUsers.CurrentRow.Cells("UserID").FormattedValue;
            //    }

            //    //prevent user to delete himself
            //    if (UserID == GlobalUserID)
            //    {
            //        CustomMsgBox.DenyUser();
            //        return;
            //    }

            //    if (GlobalUserID != 1)
            //    {
            //        if (FindPermission("DeleteUser") == false)
            //        {
            //            CustomMsgBox.DenyUser();
            //            return;
            //        }
            //    }

            //    if (CustomMsgBox.AskQuestion("", "Are you sure to delete?", this) == Windows.Forms.DialogResult.No)
            //    {
            //        return;
            //    }

            //    AccessFunctions.UpdateRecord("delete  from tblUser where UserID=" + UserID + "", CreateAccessConnString(DatabaseName));
            //    StartBackgroundWorker();
            //    CustomMsgBox.ShowSuccessMessage("", "User deleted successfully.", this);

            //}
            //catch (Exception ex)
            //{
            //    CustomMsgBox.ShowException("", ex.Message, this, ErrorLogPath);
            //}
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddNewMode();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                UpdateMode();
                txtUserName.ReadOnly = true;

                // lblUserID.Text = .Cells[0].Value
                txtUserName.Text = dgUsers.CurrentRow.Cells[1].FormattedValue.ToString();
                txtUserPassword.Text = dgUsers.CurrentRow.Cells[2].FormattedValue.ToString();
                txtFullName.Text = dgUsers.CurrentRow.Cells[3].FormattedValue.ToString();
                txtDesignation.Text = dgUsers.CurrentRow.Cells[4].FormattedValue.ToString();

            }
            catch (Exception ex)
            {
                // CustomMsgBox.ShowException("", ex.Message, this, ErrorLogPath);
            }
        }


    }
}
