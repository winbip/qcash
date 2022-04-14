using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.Reporting.WinForms;

using CustomObjects;
using sCommonLib;
using sCommonLib.Messages;
using sCommonLib.Exceptions;

using System.Collections;

namespace QCash.ViewMenuForms
{
    public partial class frmTrialBalance : Form
    {

        #region Private Variables
        private DataSet ds;
        private DataTable dtDefaultCashBookAccount;
        private DataTable dtLedgerAccount;
        private DataTable dtLedgerData;

        private DataTable dtCompanyInfo;
        public MyDatasets.dsTrialBalance dsTrialbalance;
        public string strTrialBalanceDate = "";
        public string strCompanyName = "";
        public string AddressLine1 = "";
        public string AddressLine2 = "";
        public string strDebitTotal = "";
        public string strCreditTotal = "";
        #endregion

        #region Constructors

        public frmTrialBalance()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.TrialBalanceIco48;
            RedToolTip.OwnerDraw = true;
            RedToolTip.BackColor = System.Drawing.Color.Red;
            RedToolTip.ForeColor = System.Drawing.Color.White; //if option-A is used.
            AddEventHandlers();
        }

        #endregion

        #region Add Event Handlers
        private void AddEventHandlers()
        {

            this.Load += FormLoadHandler;
            btnPrint.Click += PrintReport;
            btnClose.Click += CloseForm;

            RedToolTip.Draw += new DrawToolTipEventHandler(RedToolTipDraw);

            dgTrialBalance.CellMouseEnter += CellMouseEnter;
            dgTrialBalance.CellMouseLeave += CellMouseLeave;
            // dgTrialBalance.CellDoubleClick += CellDoubleClick;

            this.bgwPrimaryWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PrimaryWork);
            this.bgwPrimaryWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.PrimaryProgress);
            this.bgwPrimaryWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.PrimaryWorkCompleted);
        }
        #endregion

        #region Event Handlers

        #region FormLoading Event Handler

        private void FormLoadHandler(object sender, EventArgs e)
        {
            StartPrimaryWorker(null);
        }

        #endregion

        #region Button Click Event Handlers

        private void PrintReport(object sender, EventArgs e)
        {
            try
            {
                if (dgTrialBalance.Rows.Count == 0)
                {
                    MessageBox.Show("No data found to print.");
                    return;
                }

                btnPrint.Text = "wait..";
                btnPrint.Enabled = false;

                Application.DoEvents();

                strTrialBalanceDate = txtDate.Text;
                strDebitTotal = lblDrTotal.Text;
                strCreditTotal = lblCrTotal.Text;

                MyDatasets.dsTrialBalance dsTrialbalance = new MyDatasets.dsTrialBalance();
                DataTable tblTrialBalance = dsTrialbalance.Tables["tblTrialBalance"];

                DataRow DR;
                foreach (DataGridViewRow iRow in dgTrialBalance.Rows)
                {
                    DR = tblTrialBalance.NewRow();
                    DR["AccountCode"] = iRow.Cells["AccountCode"].FormattedValue.ToString();
                    DR["AccountName"] = iRow.Cells["AccountName"].FormattedValue.ToString();
                    DR["DebitBalance"] = iRow.Cells["DebitBalance"].FormattedValue.ToString();
                    DR["CreditBalance"] = iRow.Cells["CreditBalance"].FormattedValue.ToString();
                    tblTrialBalance.Rows.Add(DR);
                }

                Application.DoEvents();

             
                CommonForms.frmMsReportViewer frm = new CommonForms.frmMsReportViewer();
                frm.MsReportViewer.ProcessingMode = ProcessingMode.Local;

                BindingSource bsTrialBalance = new BindingSource();
                bsTrialBalance.DataSource = tblTrialBalance;
                ReportDataSource rds = new ReportDataSource("TrialBalanceDataset", bsTrialBalance);
                frm.MsReportViewer.LocalReport.DataSources.Add(rds);

                BindingSource bsCompanyInfomation = new BindingSource();
                bsCompanyInfomation.DataSource = GlobalVariables.currentUser.CompanyInformation;
                ReportDataSource rdsCompanyInfo = new ReportDataSource("CompanyInfoDataset", bsCompanyInfomation);
                frm.MsReportViewer.LocalReport.DataSources.Add(rdsCompanyInfo);


                 ReportParameter[] reportParameters = new ReportParameter[3];
                 reportParameters[0] = new ReportParameter("pTrialBalanceDate", strTrialBalanceDate, true);
                 reportParameters[1] = new ReportParameter("pDebitTotal", strDebitTotal, true);
                 reportParameters[2] = new ReportParameter("pCreditTotal", strCreditTotal, true);

                frm.MsReportViewer.LocalReport.ReportEmbeddedResource = "QCash.AllReports.TrialBalance.rdlc";
                frm.MsReportViewer.LocalReport.SetParameters(reportParameters);

                frm.Text = "Trial Balance Report";
                frm.Icon = Properties.Resources.PrinterGreenIco64;
                frm.Show(this.Owner);
                btnPrint.Enabled = true;
                btnPrint.Text = "&Print";

            }
            catch (UserException Uex)
            {
                CustomMessageBox.ShowUserException(Uex);
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowSystemException(ex);
            }
        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region RedToolTip Draw Event Handlers
        private void RedToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            //Option A (should be the first choice)
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();

            /* Option B
            Font f = new Font("Arial", 10.0f);
            toolTip1.BackColor = System.Drawing.Color.Blue;
           
            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawString(e.ToolTipText, f, Brushes.White, new PointF(2, 2));
            */
        }
        #endregion

        #region Datagridview CellMouseEnter,CellMouseLeave, CellDoubleClick Events Handler

        private void CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgTrialBalance.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.InactiveCaption;
                dgTrialBalance.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgTrialBalance.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
                dgTrialBalance.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        #endregion

        #region BackGroundWorker Event Handlers
         
        private void PrimaryWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                LoadStartupData();
            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
        }
         
        private void PrimaryProgress(object sender, ProgressChangedEventArgs e)
        {
            MyProgressBar.Value = e.ProgressPercentage;
        }
         
        private void PrimaryWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Cancelled", "Tasks Cancelled", "Tasks have been cancelled. Please try again."));
                }
                else if (e.Error != null)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Error", "Error", e.Error.Message));
                }
                else
                {
                   DateTime todaysDate=DateTime.Today.Date;
                   txtDate.Text = todaysDate.ToString("d", GlobalVariables.CurrentCultureInfo);
                   PrepareTrialBalance(todaysDate);
                }

            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
            finally
            {
                this.Cursor = Cursors.Default; MyProgressBar.Visible = false;
            }
        } 

        #endregion

        #endregion


        #region Helper Methods

        #region BackgroundWorker Helper Methods
        private int ProgressValue;
        private void StartPrimaryWorker(object[] Args) 
        {
            this.Cursor = Cursors.WaitCursor;
            this.MyProgressBar.Maximum = 10;
            this.MyProgressBar.Value = 0;
            this.MyProgressBar.Visible = true;
            bgwPrimaryWorker.RunWorkerAsync(Args);
        }

        private void ReportPrimaryProgress()
        {
            ProgressValue += 1;
            bgwPrimaryWorker.ReportProgress(ProgressValue);
            System.Threading.Thread.Sleep(100);
        }

        private void ReportPostProgress()
        {
            Application.DoEvents();
            //ProgressValue += 1;
            MyProgressBar.Value += 1;
            System.Threading.Thread.Sleep(100);
        }

        #endregion

        private void LoadStartupData()
        {
            OleDbConnection MyConnection = new OleDbConnection(GlobalVariables.ConnectionString);
            string sqlDefaultCashBookAccount = "SELECT AccountID FROM tblAccountHead WHERE IsCashBookDefault=true";
            string sqlLedgerAccount = "SELECT DISTINCT tblLedger.AccountId, tblAccountHead.AccountCode, tblAccountHead.AccountName FROM tblLedger INNER JOIN tblAccountHead ON tblLedger.AccountId = tblAccountHead.AccountId ORDER BY tblAccountHead.AccountName asc";
            string sqlLedgerData = "SELECT AccountId, DebitAmount, CreditAmount, EntryDate FROM tblLedger ORDER BY AccountId, LedgerEntryId";
            string sqlCompanyInfo = "select CompanyName, AddressLineOne, AddressLineTwo from tblCompanyInfo where CompanyID=1 order by CompanyName asc";

            OleDbDataAdapter daDefaultCashBookAccount = new OleDbDataAdapter(sqlDefaultCashBookAccount, MyConnection);
            OleDbDataAdapter daLedgerAccount = new OleDbDataAdapter(sqlLedgerAccount, MyConnection);
            OleDbDataAdapter daLedgerData = new OleDbDataAdapter(sqlLedgerData, MyConnection);
            OleDbDataAdapter daCompanyInfo = new OleDbDataAdapter(sqlCompanyInfo, MyConnection);

            ds = new DataSet();
            dtDefaultCashBookAccount = new DataTable();
            dtLedgerAccount = new DataTable();
            dtLedgerData = new DataTable();
            dtCompanyInfo = new DataTable();


            if (MyConnection.State == ConnectionState.Open)
            {
                MyConnection.Close();
            }
            MyConnection.Open();

            daDefaultCashBookAccount.Fill(ds, "DefaultCashBookAccount");
            daLedgerAccount.Fill(ds, "LedgerAccount");
            daLedgerData.Fill(ds, "LedgerData");
            daCompanyInfo.Fill(ds, "CompanyInfo");

            MyConnection.Close();
            MyConnection.Dispose();

            dtDefaultCashBookAccount = ds.Tables["DefaultCashBookAccount"];
            dtLedgerAccount = ds.Tables["LedgerAccount"];
            dtLedgerData = ds.Tables["LedgerData"];
            dtCompanyInfo = ds.Tables["CompanyInfo"];

            daDefaultCashBookAccount.Dispose();
            daLedgerAccount.Dispose();
            daLedgerData.Dispose();
            daCompanyInfo.Dispose();
        }

        private void CreateDatagrid()
        {
            dgTrialBalance.Columns.Clear();
            dgTrialBalance.Rows.Clear();

            dgTrialBalance.Columns.Add("AccountID", "");
            dgTrialBalance.Columns.Add("AccountCode", "");
            dgTrialBalance.Columns.Add("AccountName", "");
            dgTrialBalance.Columns.Add("DebitBalance", "");
            dgTrialBalance.Columns.Add("CreditBalance", "");
            dgTrialBalance.Columns.Add("EmptyColumn", "");

            dgTrialBalance.Columns["AccountID"].Visible = false;
            dgTrialBalance.Columns["AccountCode"].Width = 58;
            dgTrialBalance.Columns["AccountName"].Width = 291;
            dgTrialBalance.Columns["DebitBalance"].Width = 100;
            dgTrialBalance.Columns["CreditBalance"].Width = 90;
            dgTrialBalance.Columns["EmptyColumn"].Width = 15;

            dgTrialBalance.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgTrialBalance.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgTrialBalance.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgTrialBalance.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgTrialBalance.ReadOnly = true;
            /// dgTrialBalance.BackgroundColor = Color.SlateGray;
            // dgTrialBalance.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.InactiveCaption;
            // dgTrialBalance.DefaultCellStyle.BackColor = Color.SlateGray;
            // dgTrialBalance.DefaultCellStyle.SelectionBackColor = Color.Silver;
            // dgTrialBalance.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgTrialBalance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // dgTrialBalance.DefaultCellStyle.ForeColor = Color.White;

        }

        private void PrepareTrialBalance(DateTime TrialBalanceDate)
        {
            try
            {
                this.Text = "Trial Balance as of " + TrialBalanceDate.ToString("d", GlobalVariables.CurrentCultureInfo);
                MastHead.Text = this.Text;


                int DefaultCashAccountID;
                if (dtDefaultCashBookAccount.Rows.Count > 0)
                {
                    DefaultCashAccountID = (int)dtDefaultCashBookAccount.Rows[0][0];
                }
                else
                {
                    MessageBox.Show("Default cash account not found.");
                    return;
                }

                //all account data of ledger book without default cash book account
                DataView dvLedgerAccountExcludingCashAccount;
                dvLedgerAccountExcludingCashAccount = new DataView(dtLedgerAccount, "AccountID<>" + DefaultCashAccountID + "", "AccountName asc", DataViewRowState.CurrentRows);

                //only cash account data of ledger book
                DataView dvCashAccountOnly;
                dvCashAccountOnly = new DataView(dtLedgerAccount, "AccountID=" + DefaultCashAccountID + "", "AccountID asc", DataViewRowState.CurrentRows);

                int? AccountID = null;
                string AccountCode = "";
                string AccountName = "";
                decimal DebitAmount;
                decimal CreditAmount;
                decimal DebitBalance;
                decimal CreditBalance;
                decimal DebitBalanceTotal = 0;
                decimal CreditBalanceTotal = 0;

                CreateDatagrid();
                lblDrTotal.Text = "";
                lblCrTotal.Text = "";
                Application.DoEvents();

                pbMyProgressBar.Minimum = 0;
                pbMyProgressBar.Maximum = dvLedgerAccountExcludingCashAccount.Count + 1;
                pbMyProgressBar.Visible = true;
                pbMyProgressBar.Value = 0;

                Application.DoEvents();

                foreach (DataRowView DRV in dvLedgerAccountExcludingCashAccount)
                {
                    AccountID = (int)DRV["AccountID"];
                    AccountCode = DRV["AccountCode"].ToString();
                    AccountName = DRV["AccountName"].ToString();

                    DataRow[] LedgerRows = dtLedgerData.Select("AccountID=" + AccountID + " and EntryDate<=#" + TrialBalanceDate.ToString("dd MMM yyyy") + "#");
                    if (LedgerRows.Length > 0)
                    {

                        DebitAmount = (decimal)dtLedgerData.Compute("sum(DebitAmount)", "AccountID=" + AccountID + " and EntryDate<=#" + TrialBalanceDate.ToString("dd MMM yyyy") + "#");
                        CreditAmount = (decimal)dtLedgerData.Compute("sum(CreditAmount)", "AccountID=" + AccountID + " and EntryDate<=#" + TrialBalanceDate.ToString("dd MMM yyyy") + "#");

                        if (DebitAmount > CreditAmount)
                        {
                            DebitBalance = DebitAmount - CreditAmount;
                            CreditBalance = 0;
                            DebitBalanceTotal += DebitBalance;
                            CreditBalanceTotal += CreditBalance;
                            dgTrialBalance.Rows.Add(AccountID, AccountCode, AccountName, DebitBalance.ToString("N", GlobalVariables.CurrentCultureInfo), "", "");
                            lblDrTotal.Text = DebitBalanceTotal.ToString("N", GlobalVariables.CurrentCultureInfo);
                            lblCrTotal.Text = CreditBalanceTotal.ToString("N", GlobalVariables.CurrentCultureInfo);
                        }
                        else if (CreditAmount > DebitAmount)
                        {
                            DebitBalance = 0;
                            CreditBalance = CreditAmount - DebitAmount;
                            DebitBalanceTotal += DebitBalance;
                            CreditBalanceTotal += CreditBalance;
                            dgTrialBalance.Rows.Add(AccountID, AccountCode, AccountName, "", CreditBalance.ToString("N", GlobalVariables.CurrentCultureInfo), "");
                            lblDrTotal.Text = DebitBalanceTotal.ToString("N", GlobalVariables.CurrentCultureInfo);
                            lblCrTotal.Text = CreditBalanceTotal.ToString("N", GlobalVariables.CurrentCultureInfo);
                        }
                        else if (DebitAmount == CreditAmount)
                        {
                            //do nothing
                        }
                        Application.DoEvents();
                        pbMyProgressBar.Value += 1;
                        Application.DoEvents();
                    }
                }


                foreach (DataRowView DRV in dvCashAccountOnly)
                {
                    AccountID = (int)DRV["AccountID"];
                    AccountCode = DRV["AccountCode"].ToString();
                    AccountName = DRV["AccountName"].ToString();

                    DataRow[] LedgerRows = dtLedgerData.Select("AccountID=" + AccountID + " and EntryDate<=#" + TrialBalanceDate.ToString("dd MMM yyyy") + "#");
                    if (LedgerRows.Length > 0)
                    {
                        DebitAmount = (decimal)dtLedgerData.Compute("sum(DebitAmount)", "AccountID=" + AccountID + " and EntryDate<=#" + TrialBalanceDate.ToString("dd MMM yyyy") + "#");
                        CreditAmount = (decimal)dtLedgerData.Compute("sum(CreditAmount)", "AccountID=" + AccountID + " and EntryDate<=#" + TrialBalanceDate.ToString("dd MMM yyyy") + "#");

                        if (DebitAmount > CreditAmount)
                        {
                            DebitBalance = DebitAmount - CreditAmount;
                            CreditBalance = 0;
                            DebitBalanceTotal += DebitBalance;
                            CreditBalanceTotal += CreditBalance;
                            dgTrialBalance.Rows.Add(AccountID, AccountCode, AccountName, DebitBalance.ToString("N", GlobalVariables.CurrentCultureInfo), "", "");
                            lblDrTotal.Text = DebitBalanceTotal.ToString("N", GlobalVariables.CurrentCultureInfo);
                            lblCrTotal.Text = CreditBalanceTotal.ToString("N", GlobalVariables.CurrentCultureInfo);
                        }
                        else if (CreditAmount > DebitAmount)
                        {
                            DebitBalance = 0;
                            CreditBalance = CreditAmount - DebitAmount;
                            DebitBalanceTotal += DebitBalance;
                            CreditBalanceTotal += CreditBalance;
                            dgTrialBalance.Rows.Add(AccountID, AccountCode, AccountName, "", CreditBalance.ToString("N", GlobalVariables.CurrentCultureInfo), "");
                            lblDrTotal.Text = DebitBalanceTotal.ToString("N", GlobalVariables.CurrentCultureInfo);
                            lblCrTotal.Text = CreditBalanceTotal.ToString("N", GlobalVariables.CurrentCultureInfo);
                        }
                        else if (DebitAmount == CreditAmount)
                        {
                            //do nothing
                        }
                        Application.DoEvents();
                        pbMyProgressBar.Value += 1;
                        Application.DoEvents();
                    }
                }

                dgTrialBalance.ClearSelection();
                //For Each iCell As DataGridViewCell In dgTrialBalance.SelectedCells
                //    iCell.Selected = False
                //Next

                pbMyProgressBar.Visible = false;

            }
            catch (UserException Uex)
            {
                pbMyProgressBar.Visible = false;
                CustomMessageBox.ShowUserException(Uex);
            }
            catch (Exception ex)
            {
                pbMyProgressBar.Visible = false;
                CustomMessageBox.ShowSystemException(ex);
            }
        }

        #endregion

        private void dgTrialBalance_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 currentAccountId =Convert.ToInt32( dgTrialBalance.CurrentRow.Cells[0].Value);
            frmGeneralLedger frm = new frmGeneralLedger(currentAccountId);
            frm.Show(this.Owner);
        }

    }
}
