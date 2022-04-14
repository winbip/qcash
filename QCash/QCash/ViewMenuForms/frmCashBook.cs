using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.Reporting.WinForms;

using CustomObjects;
using sCommonLib;
using sCommonLib.Messages;
using sCommonLib.Exceptions;

using System.Collections;

namespace QCash.ViewMenuForms
{
    public partial class frmCashBook : Form
    {

        #region Private Variables
        private DataSet ds;
        public MyDatasets.dsCashBook dscashBook;
        private DataTable dtDefaultCashBookAccount;
        private DataTable dtLedgerData;
        private DataTable dtCashBookDate;
        private DataTable dtCompanyInfo;
        private int CashBookAccountID;
        private string LocalDbName;
        private string LocalConnectionString;
        private string PrintableCashBookDate;

        #endregion

        #region Constructors

        public frmCashBook()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.CashBookIco32;
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
            pbPrint.Click += PrintCashbook;
            btnClose.Click += CloseForm;
            txtDate.KeyDown += DateTextBoxKeyDown;
            cmbCashBookDate.KeyDown += cmbCashbookDateKeyDown;

            dgDrSideCashBook.CellMouseEnter += Datagrid_CellMouseEnter;
            dgDrSideCashBook.CellMouseLeave += Datagrid_CellMouseLeave;
            dgCrSideCashBook.CellMouseEnter += Datagrid_CellMouseEnter;
            dgCrSideCashBook.CellMouseLeave += Datagrid_CellMouseLeave;

            btnPrevDate.Click += SelectPrevCashBookDate;
            btnNextDate.Click += SelectNextCashBookDate;

            this.bgwPrimaryWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PrimaryWork);
            this.bgwPrimaryWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.PrimaryProgress);
            this.bgwPrimaryWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.PrimaryWorkCompleted);    

        }

        #endregion

        #region Event Handlers

        #region FormLoading Event Handler

        private void FormLoadHandler(object sender, EventArgs e)
        {
            /*  
              txtOperatingYear.Text = GlobalVariables.OperatingYear.ToString();
               feesAndChargesRate = FeesAndChargesRate.GetEntity(1, GlobalVariables.ConnectionString);
               AddDataBindings();
               TextBox[] BanglaTextBoxes = new TextBox[] { txtName, txtCareOf, txtAddress, txtContact, txtRemarks, txtBookingType };
               LanguageSettings BanglaLanguage = new LanguageSettings(this, "NonUnicode", 12, "SutonnyMJ");
               BanglaLanguage.SetToTextBoxes(BanglaTextBoxes);
            */

            txtDate.Text = DateTime.Today.Date.ToString("d", GlobalVariables.CurrentCultureInfo);
            LocalDbName = GlobalVariables.OperatingYear;
            LocalConnectionString = GlobalVariables.ConnectionString;
            StartPrimaryWorker();

        }

        #endregion

        #region Button Click Event Handlers


        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region Datagridview Events Handler

        private void Datagrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgData = sender as DataGridView;
            if (e.RowIndex > -1)
            {
                dgData.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.GradientActiveCaption;
                dgData.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void Datagrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgData = sender as DataGridView;
            if (e.RowIndex > -1)
            {
                dgData.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
                dgData.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void dgDrSideCashBook_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String currentColumnName = dgDrSideCashBook.CurrentCell.OwningColumn.Name;

            switch (currentColumnName)
            {
                case "VoucherNo":
                    String strVoucherNo = dgDrSideCashBook.CurrentCell.FormattedValue.ToString();

                    if (!String.IsNullOrEmpty(strVoucherNo))
                    {
                        Int32 intVoucherNo = Int32.Parse(strVoucherNo);
                        VoucherMenuForms.frmVoucher frm = new VoucherMenuForms.frmVoucher(2, intVoucherNo); //since data for this datagrid comes from credit voucher, VoucherTypeId=2.
                        frm.Show(this.Owner);
                    }

                    break;

                case "AccountName":
                    String strAccountId = dgDrSideCashBook.CurrentRow.Cells["Particulars"].Value.ToString();
                    if (!String.IsNullOrEmpty(strAccountId))
                    {

                        Int32 accountId = Int32.Parse(strAccountId);
                        ViewMenuForms.frmGeneralLedger ledger = new frmGeneralLedger(accountId);
                        ledger.Show(this.Owner);
                    }
                    break;

                default:
                    break;
            }
        }

        private void dgCrSideCashBook_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String currentColumnName = dgCrSideCashBook.CurrentCell.OwningColumn.Name;

            switch (currentColumnName)
            {
                case "VoucherNo":
                    String strVoucherNo = dgCrSideCashBook.CurrentCell.FormattedValue.ToString();

                    if (!String.IsNullOrEmpty(strVoucherNo))
                    {
                        Int32 intVoucherNo = Int32.Parse(strVoucherNo);
                        VoucherMenuForms.frmVoucher frm = new VoucherMenuForms.frmVoucher(1, intVoucherNo); //since data for this datagrid comes from credit voucher, VoucherTypeId=2.
                        frm.Show(this.Owner);
                    }

                    break;
                case "AccountName":
                    String strAccountId = dgCrSideCashBook.CurrentRow.Cells["Particulars"].Value.ToString();
                    if (!String.IsNullOrEmpty(strAccountId))
                    {

                        Int32 accountId = Int32.Parse(strAccountId);
                        ViewMenuForms.frmGeneralLedger ledger = new frmGeneralLedger(accountId);
                        ledger.Show(this.Owner);
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region BackGroundWorker Event Handlers

        private void PrimaryWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //object[] Args = (object[])e.Argument;

                using (OleDbConnection Connection = new OleDbConnection(LocalConnectionString))
                {

                    String sqlDefaultCashBookAccount = "SELECT AccountID FROM tblAccountHead WHERE IsCashBookDefault=true";
                    String sqlLedgerData = "SELECT tblLedger.LedgerEntryId, tblLedger.AccountId, tblLedger.VoucherId as VoucherNo, tblLedger.Particulars, tblAccountHead.AccountName, tblAccountHead.AccountCode, tblLedger.DebitAmount, tblLedger.CreditAmount, tblLedger.EntryDate, tblLedger.VoucherTypeId FROM tblAccountHead INNER JOIN tblLedger ON tblAccountHead.AccountId = tblLedger.Particulars";
                    String sqlCompanyInfo = "select CompanyName, AddressLineOne, AddressLineTwo from tblCompanyInfo where CompanyID=1 order by CompanyName asc";

                    OleDbDataAdapter daDefaultCashBookAccount = new OleDbDataAdapter(sqlDefaultCashBookAccount, Connection);
                    OleDbDataAdapter daLedgerData = new OleDbDataAdapter(sqlLedgerData, Connection);
                    OleDbDataAdapter daCompanyInfo = new OleDbDataAdapter(sqlCompanyInfo, Connection);

                    ds = new DataSet();
                    dtDefaultCashBookAccount = new DataTable();
                    dtLedgerData = new DataTable();
                    dtCompanyInfo = new DataTable();


                    daDefaultCashBookAccount.Fill(ds, "DefaultCashBookAccount");
                    daLedgerData.Fill(ds, "LedgerData");
                    daCompanyInfo.Fill(ds, "CompanyInfo");

                    dtDefaultCashBookAccount = ds.Tables["DefaultCashBookAccount"];
                    dtLedgerData = ds.Tables["LedgerData"];
                    dtCompanyInfo = ds.Tables["CompanyInfo"];

                    daDefaultCashBookAccount.Dispose();
                    daLedgerData.Dispose();
                    daCompanyInfo.Dispose();
                }
                //e.Result = new object[] { ArgId,Name,Age};
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
                    if (dtDefaultCashBookAccount.Rows.Count > 0)
                    {
                        CashBookAccountID = (int)dtDefaultCashBookAccount.Rows[0]["AccountID"];
                    }
                    else
                    {
                        throw new Exception("Cashbook account is not configured. Please select an Account as cashbook account.");
                    }


                    string sqlCashBookDate = "SELECT DISTINCT EntryDate AS CashBookDate FROM tblLedger where AccountID=" + CashBookAccountID + " ORDER BY EntryDate asc";

                    OleDbDataAdapter daCashBookDate = new OleDbDataAdapter(sqlCashBookDate, LocalConnectionString);
                    dtCashBookDate = new DataTable();
                    daCashBookDate.Fill(dtCashBookDate);
                    daCashBookDate.Dispose();


                    for (int i = 0; i < dtCashBookDate.Rows.Count; i++)
                    {
                        DateTime dtDate = Convert.ToDateTime(dtCashBookDate.Rows[i][0].ToString());
                        cmbCashBookDate.Items.Add(dtDate.ToString("d", GlobalVariables.CurrentCultureInfo));

                    }

                    txtDate.Text = DateTime.Today.Date.ToString("d", GlobalVariables.CurrentCultureInfo);
                    PreapareCashbook(DateTime.Today.Date);
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

        private void DateTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    DateTime cashbookDate;
                    DateTime.TryParseExact(txtDate.Text.Trim(), GlobalVariables.InputDateFormatsAllowed, GlobalVariables.CurrentCultureInfo, DateTimeStyles.AllowLeadingWhite, out cashbookDate);
                    PrintableCashBookDate = txtDate.Text;
                    PreapareCashbook(cashbookDate);
                }

            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
        }

        private void SelectPrevCashBookDate(object sender, EventArgs e)
        {
            int CurrentIndex = cmbCashBookDate.SelectedIndex;
            int ItemQuantity = cmbCashBookDate.Items.Count - 1;

            if (CurrentIndex > 0)
            {
                int PrevIndex = CurrentIndex - 1;
                cmbCashBookDate.SelectedIndex = PrevIndex;

                try
                {
                    DateTime cashbookDate;
                    DateTime.TryParseExact(cmbCashBookDate.Text.Trim(), GlobalVariables.InputDateFormatsAllowed, GlobalVariables.CurrentCultureInfo, DateTimeStyles.AllowLeadingWhite, out cashbookDate);
                    PrintableCashBookDate = cmbCashBookDate.Text;
                    PreapareCashbook(cashbookDate);
                }
                catch (Exception Ex)
                {
                    CustomMessageBox.ShowSystemException(Ex);
                }
            }



        }

        private void SelectNextCashBookDate(object sender, EventArgs e)
        {
            int CurrentIndex = cmbCashBookDate.SelectedIndex;
            int ItemQuantity = cmbCashBookDate.Items.Count - 1;

            if (CurrentIndex < ItemQuantity)
            {
                int NextIndex = CurrentIndex + 1;
                cmbCashBookDate.SelectedIndex = NextIndex;

                try
                {
                    DateTime cashbookDate;
                    DateTime.TryParseExact(cmbCashBookDate.Text.Trim(), GlobalVariables.InputDateFormatsAllowed, GlobalVariables.CurrentCultureInfo, DateTimeStyles.AllowLeadingWhite, out cashbookDate);
                    PrintableCashBookDate = cmbCashBookDate.Text;
                    PreapareCashbook(cashbookDate);
                }
                catch (Exception Ex)
                {
                    CustomMessageBox.ShowSystemException(Ex);
                }
            }
        }

        private void cmbCashbookDateKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbCashBookDate.SelectedIndex == -1)
                {
                    return;
                }

                try
                {
                    DateTime cashbookDate;
                    DateTime.TryParseExact(cmbCashBookDate.Text.Trim(), GlobalVariables.InputDateFormatsAllowed, GlobalVariables.CurrentCultureInfo, DateTimeStyles.AllowLeadingWhite, out cashbookDate);
                    PrintableCashBookDate = cmbCashBookDate.Text;
                    PreapareCashbook(cashbookDate);
                }
                catch (Exception Ex)
                {
                    CustomMessageBox.ShowSystemException(Ex);
                }
            }
        }

        private void pbLoadCashBook_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime cashbookDate;
                Boolean IsDateValie = DateTime.TryParseExact(cmbCashBookDate.Text.Trim(), GlobalVariables.InputDateFormatsAllowed, GlobalVariables.CurrentCultureInfo, DateTimeStyles.AllowLeadingWhite, out cashbookDate);

                if (IsDateValie)
                {
                    PrintableCashBookDate = cmbCashBookDate.Text;
                    PreapareCashbook(cashbookDate);
                }

            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
        }

        private void pbResetCashbookToCurrentDate_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime cashbookDate = DateTime.Today.Date;
                // DateTime.TryParseExact(txtDate.Text.Trim(), GlobalVariables.InputDateFormatsAllowed, GlobalVariables.CurrentCultureInfo, DateTimeStyles.AllowLeadingWhite, out cashbookDate);
                PrintableCashBookDate = cashbookDate.ToString("d", GlobalVariables.CurrentCultureInfo);
                PreapareCashbook(cashbookDate);

            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
        }
        
        #endregion

        #region Helper Methods

        #region Custom Exception Hander

        /*TODO: Uncomment and editing needed at Custom Exception handler
        private void HandleExceptionWithControl(ExceptionWithControl EWC)
        {
            string strControlName = EWC.ControlName;
            Control control = null;
            switch (strControlName)
            {
                case "TruckNo":
                    control = txtTruckNo;
                    break;
                default:
                    break;
            }
           // CustomMessageBox.ShowGeneralMessage(new GeneralMessage(EWC.TitleBarMessage, EWC.HeadLineMessage, EWC.ErrorDescription));
            RedToolTip.Show(EWC.ErrorDescription, control, 3000);
            //MyErrorProvider.SetError(control, EWC.ErrorDescription); 
            control.Focus();
        }
        */
        #endregion

        #region BackgroundWorker Helper Methods

        private int ProgressValue;
        private void StartPrimaryWorker()
        {
            this.Cursor = Cursors.WaitCursor;
            this.MyProgressBar.Maximum = 10;
            this.MyProgressBar.Value = 0;
            this.MyProgressBar.Visible = true;
            bgwPrimaryWorker.RunWorkerAsync();
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


        #region Create and Format Datagrid

        private void CreateDrDatagrid()
        {
            {
                dgDrSideCashBook.Rows.Clear();
                dgDrSideCashBook.Columns.Clear();

                dgDrSideCashBook.Columns.Add("VoucherNo", "");
                dgDrSideCashBook.Columns.Add("Particulars", "");
                dgDrSideCashBook.Columns.Add("AccountName", "");
                dgDrSideCashBook.Columns.Add("AccountCode", "");
                dgDrSideCashBook.Columns.Add("Amount", "");

                dgDrSideCashBook.Columns["VoucherNo"].Width = 58;
                dgDrSideCashBook.Columns["VoucherNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                dgDrSideCashBook.Columns["Particulars"].Visible = false;

                dgDrSideCashBook.Columns["AccountName"].Width = 252;
                dgDrSideCashBook.Columns["AccountName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgDrSideCashBook.Columns["AccountCode"].Width = 71;
                dgDrSideCashBook.Columns["AccountCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgDrSideCashBook.Columns["Amount"].Width = 80;
                dgDrSideCashBook.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void CreateCrDatagrid()
        {
            {
                dgCrSideCashBook.Rows.Clear();
                dgCrSideCashBook.Columns.Clear();

                dgCrSideCashBook.Columns.Add("VoucherNo", "");
                dgCrSideCashBook.Columns.Add("Particulars", "");
                dgCrSideCashBook.Columns.Add("AccountName", "");
                dgCrSideCashBook.Columns.Add("AccountCode", "");
                dgCrSideCashBook.Columns.Add("Amount", "");

                dgCrSideCashBook.Columns["VoucherNo"].Width = 58;
                dgCrSideCashBook.Columns["VoucherNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgCrSideCashBook.Columns["Particulars"].Visible = false;

                dgCrSideCashBook.Columns["AccountName"].Width = 252;
                dgCrSideCashBook.Columns["AccountName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgCrSideCashBook.Columns["AccountCode"].Width = 71;
                dgCrSideCashBook.Columns["AccountCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgCrSideCashBook.Columns["Amount"].Width = 80;
                dgCrSideCashBook.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            }
        }

        #endregion

        private void PreapareCashbook(DateTime MyDate)
        {
            PrintableCashBookDate = MyDate.ToString("d", GlobalVariables.CurrentCultureInfo);
            MastHead.Text = "Cashbook - " + PrintableCashBookDate;
            CreateDrDatagrid();
            CreateCrDatagrid();
            lblDrDayTotal.Text = "";
            lblDrDayTotal2.Text = "";
            lblCrDayTotal.Text = "";
            lblCashInHand.Text = "";

            decimal BalanceBD = 0;
            decimal DebitAmount = 0;
            decimal CreditAmount = 0;
            decimal DrDayTotal = 0;
            decimal CrDayTotal = 0;

            DataRow[] TodaysRecords = dtLedgerData.Select("AccountID=" + CashBookAccountID + " and EntryDate=#" + MyDate.ToString("dd MMM yyyy") + "#", "LedgerEntryID asc");

            if (TodaysRecords.Length > 0)
            {
                //first, collect Balance BD from previous records
                DataRow[] YesterdayRecords = dtLedgerData.Select("AccountID=" + CashBookAccountID + " and EntryDate<#" + MyDate.ToString("dd MMM yyyy") + "#", "LedgerEntryID asc");
                if (YesterdayRecords.Length > 0)
                {
                    DebitAmount = (decimal)dtLedgerData.Compute("sum(DebitAmount)", "AccountID=" + CashBookAccountID + " and EntryDate<#" + MyDate.ToString("dd MMM yyyy") + "#");
                    CreditAmount = (decimal)dtLedgerData.Compute("sum(CreditAmount)", "AccountID=" + CashBookAccountID + " and EntryDate<#" + MyDate.ToString("dd MMM yyyy") + "#");
                    if (DebitAmount > CreditAmount)
                    {
                        BalanceBD = DebitAmount - CreditAmount;
                    }
                    else if (DebitAmount < CreditAmount)
                    {
                        BalanceBD = CreditAmount - DebitAmount;
                    }
                    else
                    {
                        BalanceBD = 0;
                    }
                    dgDrSideCashBook.Rows.Add("", "", "Balance BD", "", BalanceBD.ToString("N", GlobalVariables.CurrentCultureInfo));
                }

                //second, collect todays Credit vouchers for debit side cash book
                DataView DVDrSide = new DataView(dtLedgerData, "AccountID=" + CashBookAccountID + " and DebitAmount<>0 and CreditAmount=0 and EntryDate=#" + MyDate.ToString("dd MMM yyyy") + "#", "LedgerEntryID asc", DataViewRowState.CurrentRows);
                foreach (DataRowView DRV in DVDrSide)
                {
                    {
                        DrDayTotal += Convert.ToDecimal(DRV["DebitAmount"].ToString());
                        //main code- dgDrSideCashBook.Rows.Add(DRV["VoucherNo"].ToString(), DRV["Particulars"].ToString(), DRV["AccountName"].ToString(), "", DRV["DebitAmount"].ToString());
                        //below is the edited code of above line
                        dgDrSideCashBook.Rows.Add(DRV["VoucherNo"].ToString(), DRV["Particulars"].ToString(), DRV["AccountName"].ToString(), DRV["AccountCode"].ToString(), Convert.ToDecimal(DRV["DebitAmount"].ToString()).ToString("N", GlobalVariables.CurrentCultureInfo));
                    }
                }

                // If TodaysRecords.Length = 0 
            }
            else
            {
                DataRow[] YesterdayRecords = dtLedgerData.Select("AccountID=" + CashBookAccountID + " and EntryDate<#" + MyDate.ToString("dd MMM yyyy") + "#", "LedgerEntryID asc");
                if (YesterdayRecords.Length > 0)
                {
                    DebitAmount = (decimal)dtLedgerData.Compute("sum(DebitAmount)", "AccountID=" + CashBookAccountID + " and EntryDate<#" + MyDate.ToString("dd MMM yyyy") + "#");
                    CreditAmount = (decimal)dtLedgerData.Compute("sum(CreditAmount)", "AccountID=" + CashBookAccountID + " and EntryDate<#" + MyDate.ToString("dd MMM yyyy") + "#");
                    if (DebitAmount > CreditAmount)
                    {
                        BalanceBD = DebitAmount - CreditAmount;
                    }
                    else if (DebitAmount < CreditAmount)
                    {
                        BalanceBD = CreditAmount - DebitAmount;
                    }
                    else
                    {
                        BalanceBD = 0;
                    }
                    dgDrSideCashBook.Rows.Add("", "", "Balance BD", "", BalanceBD.ToString("N", GlobalVariables.CurrentCultureInfo));
                }
            }

            //fill Credit side
            DataView DVCrSide = new DataView(dtLedgerData, "AccountID=" + CashBookAccountID + " and DebitAmount=0 and CreditAmount<>0 and EntryDate=#" + MyDate.ToString("dd MMM yyyy") + "#", "LedgerEntryID asc", DataViewRowState.CurrentRows);
            foreach (DataRowView DRV in DVCrSide)
            {
                {
                    CrDayTotal += Convert.ToDecimal(DRV["CreditAmount"].ToString());
                    //Main code- dgCrSideCashBook.Rows.Add(DRV["VoucherNo"].ToString(), DRV["Particulars"].ToString(), DRV["AccountName"].ToString(), "", DRV["CreditAmount"].ToString()); 
                    //below is the edited code of above line
                    dgCrSideCashBook.Rows.Add(DRV["VoucherNo"].ToString(), DRV["Particulars"].ToString(), DRV["AccountName"].ToString(), DRV["AccountCode"].ToString(), Convert.ToDecimal(DRV["CreditAmount"].ToString()).ToString("N", GlobalVariables.CurrentCultureInfo));
                }
            }

            DrDayTotal = DrDayTotal + BalanceBD;

            lblDrDayTotal.Text = DrDayTotal.ToString("N", GlobalVariables.CurrentCultureInfo);
            lblDrDayTotal2.Text = lblDrDayTotal.Text;
            lblCrDayTotal.Text = CrDayTotal.ToString("N", GlobalVariables.CurrentCultureInfo);
            decimal CashInHand = DrDayTotal - CrDayTotal;
            lblCashInHand.Text = CashInHand.ToString("N", GlobalVariables.CurrentCultureInfo);

            dgDrSideCashBook.ClearSelection(); dgCrSideCashBook.ClearSelection();
        }

        public string strCompanyName = "";
        public string AddressLine1 = "";
        public string AddressLine2 = "";
        public string strCashBookDate = "";
        public string strDrDayTotal = "";
        public string srtCrDayTotal = "";
        public string strCashInHand = "";

        private void PrintCashbook(object sender, EventArgs e)
        {
            try
            {
                 strCashBookDate = PrintableCashBookDate;
              

                if (dtCompanyInfo.Rows.Count == 0)
                {
                    MessageBox.Show("Company Info not found. Please configure it first.");
                    return;
                }
                else
                {
                    strCompanyName = dtCompanyInfo.Rows[0]["CompanyName"].ToString();
                    AddressLine1 = dtCompanyInfo.Rows[0]["AddressLineOne"].ToString();
                    AddressLine2 = dtCompanyInfo.Rows[0]["AddressLineTwo"].ToString();
                }

                int DrSideRowQuantity = dgDrSideCashBook.Rows.Count;
                int CrSideRowQuantity = dgCrSideCashBook.Rows.Count;

                if ((DrSideRowQuantity == 0) && (CrSideRowQuantity == 0))
                {
                    MessageBox.Show("No data to print.");
                    return;
                }

                 pbPrint.Enabled = false;
                Application.DoEvents();

                int CommonQuantity = 0;
                int ExtraQuantity = 0;
                DataGridView ExtraDatagridview = null;
                string EntrySide = "";

                if ((DrSideRowQuantity > 0) && (CrSideRowQuantity > 0))
                {
                    //now check which side is big
                    if (DrSideRowQuantity > CrSideRowQuantity)
                    {
                        CommonQuantity = CrSideRowQuantity;
                        ExtraQuantity = DrSideRowQuantity;
                        //- CrSideRowQuantity
                        ExtraDatagridview = dgDrSideCashBook;
                        EntrySide = "Dr";
                    }
                    else if (CrSideRowQuantity > DrSideRowQuantity)
                    {
                        CommonQuantity = DrSideRowQuantity;
                        ExtraQuantity = CrSideRowQuantity;
                        //- DrSideRowQuantity
                        ExtraDatagridview = dgCrSideCashBook;
                        EntrySide = "Cr";
                    }
                    else if (DrSideRowQuantity == CrSideRowQuantity)
                    {
                        CommonQuantity = DrSideRowQuantity;
                        ExtraQuantity = 0;
                        EntrySide = "";
                    }
                }
                else if ((DrSideRowQuantity == 0) && (CrSideRowQuantity > 0))
                {
                    CommonQuantity = 0;
                    ExtraQuantity = CrSideRowQuantity;
                    ExtraDatagridview = dgCrSideCashBook;
                    EntrySide = "Cr";
                }
                else if ((DrSideRowQuantity > 0) && (CrSideRowQuantity == 0))
                {
                    CommonQuantity = 0;
                    ExtraQuantity = DrSideRowQuantity;
                    ExtraDatagridview = dgDrSideCashBook;
                    EntrySide = "Dr";
                }

                Application.DoEvents();


                dscashBook = new MyDatasets.dsCashBook();
                DataTable tblCashBook = dscashBook.Tables.Add("CashBook");


                tblCashBook.Columns.Add("DrVoucherNo", Type.GetType("System.String"));
                tblCashBook.Columns.Add("DrAccountName", Type.GetType("System.String"));
                tblCashBook.Columns.Add("DrAccountCode", Type.GetType("System.String"));
                //tblCashBook.Columns.Add("DrCash", Type.GetType("System.Int32"));
                tblCashBook.Columns.Add("DrCash", typeof(System.Decimal));
                tblCashBook.Columns.Add("CrVoucherNo", Type.GetType("System.String"));
                tblCashBook.Columns.Add("CrAccountName", Type.GetType("System.String"));
                tblCashBook.Columns.Add("CrAccountCode", Type.GetType("System.String"));
                //tblCashBook.Columns.Add("CrCash", Type.GetType("System.String"));
                tblCashBook.Columns.Add("CrCash", typeof(System.Decimal));

                DataRow DR;
                if (CommonQuantity > 0)
                {
                    for (int i = 0; i <= CommonQuantity - 1; i++)
                    {
                        DR = tblCashBook.NewRow();
                        DR["DrVoucherNo"] = dgDrSideCashBook["VoucherNo", i].FormattedValue.ToString();
                        DR["DrAccountName"] = dgDrSideCashBook["AccountName", i].FormattedValue.ToString();
                        DR["DrAccountCode"] = dgDrSideCashBook["AccountCode", i].FormattedValue.ToString();
                        //DR["DrCash"] = dgDrSideCashBook["Amount", i].FormattedValue.ToString();
                        DR["DrCash"] = Convert.ToDecimal(dgDrSideCashBook["Amount", i].FormattedValue.ToString());
                        DR["CrVoucherNo"] = dgCrSideCashBook["VoucherNo", i].FormattedValue.ToString();
                        DR["CrAccountName"] = dgCrSideCashBook["AccountName", i].FormattedValue.ToString();
                        DR["CrAccountCode"] = dgCrSideCashBook["AccountCode", i].FormattedValue.ToString();
                        //DR["CrCash"] = dgCrSideCashBook["Amount", i].FormattedValue.ToString();
                        DR["CrCash"] = Convert.ToDecimal(dgCrSideCashBook["Amount", i].FormattedValue.ToString());
                        tblCashBook.Rows.Add(DR);
                    }
                }

                if (!(EntrySide == ""))
                {
                    for (int j = CommonQuantity; j <= ExtraQuantity - 1; j++)
                    {
                        if (EntrySide == "Dr")
                        {
                            DR = tblCashBook.NewRow();
                            DR["DrVoucherNo"] = dgDrSideCashBook["VoucherNo", j].FormattedValue.ToString();
                            DR["DrAccountName"] = dgDrSideCashBook["AccountName", j].FormattedValue.ToString();
                            DR["DrAccountCode"] = dgDrSideCashBook["AccountCode", j].FormattedValue.ToString();
                            DR["DrCash"] = dgDrSideCashBook["Amount", j].FormattedValue.ToString();
                            //DR["DrCash") = dgDrSideCashBook["Amount", j).FormattedValue.ToString()
                            DR["CrVoucherNo"] = "";
                            DR["CrAccountName"] = "";
                            DR["CrAccountCode"] = "";
                            DR["CrCash"] = DBNull.Value;  //Changed
                            tblCashBook.Rows.Add(DR);
                        }
                        else if (EntrySide == "Cr")
                        {
                            DR = tblCashBook.NewRow();
                            DR["DrVoucherNo"] = "";
                            DR["DrAccountName"] = "";
                            DR["DrAccountCode"] = "";
                            DR["DrCash"] = DBNull.Value;
                            //""
                            DR["CrVoucherNo"] = dgCrSideCashBook["VoucherNo", j].FormattedValue.ToString();
                            DR["CrAccountName"] = dgCrSideCashBook["AccountName", j].FormattedValue.ToString();
                            DR["CrAccountCode"] = dgCrSideCashBook["AccountCode", j].FormattedValue.ToString();
                            DR["CrCash"] = dgCrSideCashBook["Amount", j].FormattedValue.ToString();
                            tblCashBook.Rows.Add(DR);
                        }
                    }
                }

                Application.DoEvents();

                CommonForms.frmMsReportViewer frm = new CommonForms.frmMsReportViewer();
                frm.MsReportViewer.ProcessingMode = ProcessingMode.Local;

                BindingSource bsCashBookData = new BindingSource();
                bsCashBookData.DataSource = tblCashBook;
                ReportDataSource rdsCashBookData = new ReportDataSource("CashBookDataset", bsCashBookData);
                frm.MsReportViewer.LocalReport.DataSources.Add(rdsCashBookData);


                BindingSource bsCompanyInfomation = new BindingSource();
                bsCompanyInfomation.DataSource = GlobalVariables.currentUser.CompanyInformation;
                ReportDataSource rdsCompanyInfo = new ReportDataSource("CompanyInfoDataset", bsCompanyInfomation);
                frm.MsReportViewer.LocalReport.DataSources.Add(rdsCompanyInfo);


                 ReportParameter[] reportParameters = new ReportParameter[4];
                 reportParameters[0] = new ReportParameter("rpCashBookDate", this.strCashBookDate, true);

                 reportParameters[1] = new ReportParameter("rpDrDayTotal", this.lblDrDayTotal.Text, true);
                 reportParameters[2] = new ReportParameter("rpCrDayTotal", this.lblCrDayTotal.Text, true);
                 reportParameters[3] = new ReportParameter("rpCashInHand", this.lblCashInHand.Text, true);

                frm.MsReportViewer.LocalReport.ReportEmbeddedResource = "QCash.AllReports.CashBook.rdlc";
                frm.MsReportViewer.LocalReport.SetParameters(reportParameters);

                frm.Text = "Cashbook Report";
                frm.Icon = Properties.Resources.PrinterGreenIco64;
                pbPrint.Enabled = true;
                frm.Show(this.Owner);
               

            }
            catch (UserException Uex)
            {
                CustomMessageBox.ShowUserException(Uex);

            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowSystemException(ex);

            }
            finally { pbPrint.Enabled = true; }
        }

        #endregion

    }
}
