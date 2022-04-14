using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using sCommonLib;
using sCommonLib.Exceptions;
using sCommonLib.MessageBoxes;

namespace QCash.MasterSetupForms
{
    public partial class frmPermissions : Form
    {
        public frmPermissions()
        {
            InitializeComponent();
        }

        DataSet ds;
        DataTable dtUsersDetails;
        DataTable dtPermissionDetails;
        DataTable dtUserWisePermission;
        int ProgressValue;

        private void StartBackgroundWorker()
        {
            this.Cursor = Cursors.WaitCursor;
            cmbUsers.Enabled = false;
            btnSave.Enabled = false;

            MyProgressBar.Value = 0;
            MyProgressBar.Maximum = 10;
            MyProgressBar.Visible = true;

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

        private void frmPermissions_Load(object sender, EventArgs e)
        {
            StartBackgroundWorker();
        }

        private void bgwStartupDataLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (bgwStartupDataLoader.CancellationPending == true)
                {
                    e.Cancel = true;
                }

                ProgressValue = 0;



                using (OleDbConnection Connection = new OleDbConnection(GlobalVariables.ConnectionString))
                {
                    OleDbDataAdapter daUserDetails = new OleDbDataAdapter("select UserID, LogInName, LogInPassword, FullName, UserDesignation from tblUserDetails where UserID>1 order by LogInName asc", Connection);
                    OleDbDataAdapter daPermissionDetails = new OleDbDataAdapter("select PermissionID, PermissionName from tblPermission order by SerialNo asc", Connection);
                    OleDbDataAdapter daUserWisePermission = new OleDbDataAdapter("select UserID, PermissionID from tblUserPermission order by UserID asc,PermissionID asc", Connection);
                    ReportProgress();
                    //---------------------------------------------------------progress 1

                    ds = new DataSet("AllNecessaryData");
                    dtUsersDetails = new DataTable();
                    dtPermissionDetails = new DataTable();
                    dtUserWisePermission = new DataTable();
                    ReportProgress();
                    //---------------------------------------------------------progress 2

                    Connection.Open();

                    daUserDetails.Fill(ds, "UserDetails");
                    daPermissionDetails.Fill(ds, "PermissionDetails");
                    daUserWisePermission.Fill(ds, "UserWisePermission");
                    ReportProgress();
                    //------------------------------------------------------progress 3
                    Connection.Close();

                    dtUsersDetails = ds.Tables["UserDetails"];
                    dtPermissionDetails = ds.Tables["PermissionDetails"];
                    dtUserWisePermission = ds.Tables["UserWisePermission"];
                    ReportProgress();
                    //------------------------------------------------------progress 4

                    daUserDetails.Dispose();
                    daPermissionDetails.Dispose();
                    daUserWisePermission.Dispose();
                }

                ReportProgress();
                //------------------------------------------------------progress 5

            }
            catch (Exception ex)
            {

                CustomMessageBox.ShowSystemException(ex);
            }
        }

        private void bgwStartupDataLoader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.MyProgressBar.Value = e.ProgressPercentage;
        }

        private void bgwStartupDataLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled == true)
                {

                    MessageBox.Show("Task Cancelled");
                }
                else if (e.Error != null)
                {

                    MessageBox.Show("Error: " + e.Error.Message);
                }
                else
                {
                    this.cmbUsers.SelectedIndexChanged -= this.cmbUsers_SelectedIndexChanged;
                    {
                        cmbUsers.DataSource = null;
                        if (dtUsersDetails.Rows.Count > 0)
                        {
                            cmbUsers.DataSource = dtUsersDetails;
                            cmbUsers.ValueMember = "UserID";
                            cmbUsers.DisplayMember = "LogInName";
                            cmbUsers.SelectedIndex = -1;
                        }
                    }
                    this.cmbUsers.SelectedIndexChanged += this.cmbUsers_SelectedIndexChanged;

                    FillDatagridview();

                    cmbUsers.Enabled = true;
                    btnSave.Enabled = false;


                    chkSelectAllNone.Checked = false;

                    cmbUsers.Focus();

                    ReportPostProgress();
                    //--------------------------------Progress 1

                    ReportPostProgress();
                    //--------------------------------Progress 2

                    ReportPostProgress();
                    //--------------------------------Progress 3

                    ReportPostProgress();
                    //--------------------------------Progress 4

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


        private void DisplayUserDetails(int ThisUserID)
        {
            DataRow[] FoundDataRow;
            // array of datarow
            FoundDataRow = dtUsersDetails.Select("UserID = " + ThisUserID);
            //single quote for string type variable

            //if (FoundDataRow.Length == 1)
            //{
            //    txtFullName.Text = FoundDataRow(0)("FullName");
            //    txtDesignation.Text = FoundDataRow(0)("Designation");
            //}

        }


        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbUsers.SelectedIndex == -1)
                {
                    return;
                }
                else
                {
                    int ThisUserID = (int)cmbUsers.SelectedValue;

                    DisplayUserDetails(ThisUserID);

                    if (dgPermissions.Rows.Count > 0)
                    {
                        dgPermissions.ClearSelection();

                        btnSave.Enabled = true;
                        int PermissionID;
                        DataRow[] UserPermissionRow;

                        {
                            for (int i = 0; i <= dgPermissions.Rows.Count - 1; i++)
                            {
                                PermissionID = int.Parse(dgPermissions.Rows[i].Cells[0].FormattedValue.ToString()); //dgPermissions.Item(0, i).Value;
                                UserPermissionRow = dtUserWisePermission.Select("UserID= " + ThisUserID + " And PermissionID=" + PermissionID);
                                if (UserPermissionRow.Length == 1)
                                {
                                    dgPermissions.Rows[i].Cells[1].Value = true;
                                    dgPermissions.Rows[i].Cells[1].Style.BackColor = Color.SeaGreen;
                                    dgPermissions.Rows[i].Cells[1].Style.ForeColor = Color.White;
                                    dgPermissions.Rows[i].Cells[2].Style.BackColor = Color.SeaGreen;
                                    dgPermissions.Rows[i].Cells[2].Style.ForeColor = Color.White;

                                }
                                else if (UserPermissionRow.Length == 0)
                                {
                                    dgPermissions.Rows[i].Cells[1].Value = false;
                                    dgPermissions.Rows[i].Cells[1].Style.BackColor = Color.Lavender;
                                    dgPermissions.Rows[i].Cells[1].Style.ForeColor = Color.Black;
                                    dgPermissions.Rows[i].Cells[2].Style.BackColor = Color.Lavender;
                                    dgPermissions.Rows[i].Cells[2].Style.ForeColor = Color.Black;
                                }
                            }
                        }

                    }

                    cmbUsers.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowSystemException(ex);

            }
        }

        private void CreateDatagirdview()
        {
            {
                dgPermissions.Columns.Clear();
                dgPermissions.Rows.Clear();

                dgPermissions.Columns.Add("PermissionID", "");

                DataGridViewCheckBoxColumn chkcol = new DataGridViewCheckBoxColumn();
                chkcol.Name = "chkcol";
                chkcol.HeaderText = "";

                dgPermissions.Columns.Add(chkcol);
                dgPermissions.Columns.Add("PermissionName", "");
            }
        }

        private void FillDatagridview()
        {
            if (dtPermissionDetails.Rows.Count > 0)
            {
                CreateDatagirdview();
                int PermissionID;
                string PermissionName;
                for (int i = 0; i < dtPermissionDetails.Rows.Count; i++)
                {
                    PermissionID = int.Parse(dtPermissionDetails.Rows[i][0].ToString());
                    PermissionName = dtPermissionDetails.Rows[i][1].ToString();
                    dgPermissions.Rows.Add(PermissionID, false, PermissionName);
                }
                FormatDataGrid();
            }
        }

        private void FormatDataGrid()
        {
            {
                dgPermissions.AllowUserToAddRows = false;
                dgPermissions.AllowUserToDeleteRows = false;
                dgPermissions.AllowUserToResizeRows = false;
                dgPermissions.AllowUserToResizeColumns = false;
                dgPermissions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgPermissions.RowHeadersVisible = false;
                dgPermissions.ColumnHeadersVisible = false;

                dgPermissions.CellBorderStyle = DataGridViewCellBorderStyle.None;

                dgPermissions.DefaultCellStyle.SelectionBackColor = Color.Silver;
                dgPermissions.DefaultCellStyle.SelectionForeColor = Color.Black;

                dgPermissions.DefaultCellStyle.BackColor = Color.White;
                dgPermissions.DefaultCellStyle.ForeColor = Color.Black;


                dgPermissions.Columns["PermissionID"].Visible = false;
                dgPermissions.Columns["chkcol"].Width = 58;
                // dgPermissions.Columns["PermissionName"].Width = 280;

                dgPermissions.Columns["PermissionID"].ReadOnly = true;
                dgPermissions.Columns["chkcol"].ReadOnly = false;
                dgPermissions.Columns["PermissionName"].ReadOnly = true;
            }
        }

        private bool DisplayPermission(int ThisUserID, int PermissionID)
        {
            try
            {
                //bool result = false;
                DataRow[] Permissions;

                Permissions = dtUserWisePermission.Select("UserID = " + ThisUserID + " AND PermissionID= " + PermissionID);

                if (Permissions.Length == 1)
                {
                    return true;
                }
                else //if (Permissions.Length == 0)
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowSystemException(ex);
                return false;
            }
        }

        private void AddPermission(int ThisUserID, int PermissionID)
        {
            try
            {
                DataRow[] Permissions;
                Permissions = dtUserWisePermission.Select("UserID = " + ThisUserID + " AND PermissionID= " + PermissionID);

                if (Permissions.Length == 0)
                {
                    //AccessFunctions.InsertRecord("insert into tblUserPermission(UserID, PermissionID) values(" + ThisUserID + "," + PermissionID + ")", ConnectionString);
                    using (OleDbConnection Connection = new OleDbConnection(GlobalVariables.ConnectionString))
                    {
                        string sqlInsert = "insert into tblUserPermission(UserID, PermissionID) values(" + ThisUserID + "," + PermissionID + ")";
                        using (OleDbCommand cmd = new OleDbCommand(sqlInsert, Connection))
                        {
                            Connection.Open();
                            cmd.ExecuteNonQuery();
                            Connection.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                CustomMessageBox.ShowSystemException(ex);
            }

        }

        private void DeletePermission(int ThisUserID, int PermissionID)
        {
            try
            {
                DataRow[] Permissions;
                Permissions = dtUserWisePermission.Select("UserID = " + ThisUserID + " AND PermissionID= " + PermissionID);

                if (Permissions.Length == 1)
                {
                    // AccessFunctions.DeleteRecord("delete from tblUserPermission where UserID=" + ThisUserID + " and PermissionID=" + PermissionID + "", ConnectionString);

                    using (OleDbConnection Connection = new OleDbConnection(GlobalVariables.ConnectionString))
                    {
                        string sqlDelete = "delete from tblUserPermission where UserID=" + ThisUserID + " and PermissionID=" + PermissionID + "";
                        using (OleDbCommand cmd = new OleDbCommand(sqlDelete, Connection))
                        {
                            Connection.Open();
                            cmd.ExecuteNonQuery();
                            Connection.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                CustomMessageBox.ShowSystemException(ex);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if (GlobalVariables.currentUser.UserInformation.UserId != 1)
                //{
                //    MessageBox.Show("You are not permitted to do this task."); return;
                //}

                int ThisUserID;
                if (cmbUsers.SelectedIndex == -1)
                {
                    return;
                }
                else
                {
                    ThisUserID = (int)cmbUsers.SelectedValue;
                }

                int PermissionID;


                if (dgPermissions.Rows.Count > 0)
                {
                    ProgressBarSave.Visible = true;
                    ProgressBarSave.Value = 0;
                    ProgressBarSave.Maximum = dgPermissions.Rows.Count * 2;

                    for (short i = 0; i <= dgPermissions.Rows.Count - 1; i++)
                    {
                        PermissionID = int.Parse(dgPermissions.Rows[i].Cells["PermissionID"].FormattedValue.ToString());
                        ProgressBarSave.Value = ProgressBarSave.Value + 1;
                        if ((bool)dgPermissions.Rows[i].Cells["chkcol"].Value == true)
                        {
                            AddPermission(ThisUserID, PermissionID);
                        }
                        else if ((bool)dgPermissions.Rows[i].Cells["chkcol"].Value == false)
                        {
                            DeletePermission(ThisUserID, PermissionID);
                        }
                        ProgressBarSave.Value = ProgressBarSave.Value + 1;
                    }
                }

                cmbUsers.Enabled = false;
                btnSave.Enabled = false;


                MessageBox.Show("Permissions updated successfully.");
                ProgressBarSave.Visible = false;

                StartBackgroundWorker();

            }
            catch (Exception ex)
            {

                CustomMessageBox.ShowSystemException(ex);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkSelectAllNone_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgPermissions.Rows.Count > 0)
                {
                    if (chkSelectAllNone.Checked == true)
                    {
                        for (short i = 0; i <= dgPermissions.Rows.Count - 1; i++)
                        {
                            dgPermissions.Rows[i].Cells["chkcol"].Value = true;
                        }
                    }
                    else if (chkSelectAllNone.Checked == false)
                    {
                        for (short i = 0; i <= dgPermissions.Rows.Count - 1; i++)
                        {
                            dgPermissions.Rows[i].Cells["chkcol"].Value = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                CustomMessageBox.ShowSystemException(ex);
            }
        }

        private void dgPermissions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dgPermissions.CurrentCell.OwningColumn.Name == "chkcol")
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dgPermissions.Rows[e.RowIndex].Cells["chkcol"];

                    if (Convert.ToBoolean(checkCell.Value) == true)
                    {
                        dgPermissions.CurrentRow.Selected = false;
                        dgPermissions.CurrentRow.Cells[1].Style.BackColor = Color.SeaGreen;
                        dgPermissions.CurrentRow.Cells[1].Style.ForeColor = Color.White;
                        dgPermissions.CurrentRow.Cells[2].Style.BackColor = Color.SeaGreen;
                        dgPermissions.CurrentRow.Cells[2].Style.ForeColor = Color.White;
                        dgPermissions.Invalidate();


                    }
                    else if (Convert.ToBoolean(checkCell.Value) == false)
                    {
                        dgPermissions.CurrentRow.Cells[1].Style.BackColor = Color.Lavender;
                        dgPermissions.CurrentRow.Cells[1].Style.ForeColor = Color.Black;
                        dgPermissions.CurrentRow.Cells[2].Style.BackColor = Color.Lavender;
                        dgPermissions.CurrentRow.Cells[2].Style.ForeColor = Color.Black;
                        dgPermissions.Invalidate();
                        dgPermissions.CurrentRow.Selected = true;
                    }

                }
            }
            catch (Exception ex)
            {

                CustomMessageBox.ShowSystemException(ex);
            }
        }

        private void dgPermissions_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgPermissions.IsCurrentCellDirty)
            {
                dgPermissions.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbUsers.Enabled = true;
            cmbUsers.SelectedIndex = -1;
            btnSave.Enabled = false;


            {
                for (short i = 0; i <= dgPermissions.Rows.Count - 1; i++)
                {
                    dgPermissions.Rows[i].Cells["chkcol"].Value = false;
                    dgPermissions.Rows[i].Cells[1].Style.BackColor = Color.Lavender;
                    dgPermissions.Rows[i].Cells[1].Style.ForeColor = Color.Black;
                    dgPermissions.Rows[i].Cells[2].Style.BackColor = Color.Lavender;
                    dgPermissions.Rows[i].Cells[2].Style.ForeColor = Color.Black;
                }
            }

            dgPermissions.ClearSelection();

            //txtFullName.Text = "";
            //txtDesignation.Text = "";
            chkSelectAllNone.Checked = false;

            cmbUsers.Focus();
        }



    }
}
