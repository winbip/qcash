using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Reporting.WinForms;

using CustomObjects;
using sCommonLib;
using sCommonLib.Messages;
using sCommonLib.Exceptions;

using System.Collections;

namespace QCash.ViewMenuForms
{
    public partial class frmGeneralLedger : Form
    {

        #region Private Variables

        private Int32? pAccountIdToLoad;
        private List<AccountHeadComboItem> AccountHeadList;

        private DataTable dtLedgerData;
        private DataTable dtCompanyInfo;
        //private string LocalDbName;
        private string LocalConnectionString;
        private String LocalOperatingYear;
        private int ProgressValue;
        public MyDatasets.dsGeneralLedger dsLedgerBookObject;
        public string strAccountDetails;
        public string strCompanyName;
        public string AddressLine1;
        public string AddressLine2;
        #endregion

        #region Public Properties
        /// <summary>
        /// Returns Client that just have created.
        /// </summary>
        /*TODO: Uncomment needed
        public MyType NewlyCreatedEntity
        {
            get { return CurrentEntity; }
        }
        */
        #endregion

        #region Constructors

        public frmGeneralLedger(Int32? AccountIdToLoad)
        {
            InitializeComponent();
            pAccountIdToLoad = AccountIdToLoad;
            this.Icon = Properties.Resources.LedgerBookIco32;
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
            btnShow.Click += ShowLedger;
            btnPrint.Click += PrintReport;
          
            btnClose.Click += CloseForm;

            RedToolTip.Draw += new DrawToolTipEventHandler(RedToolTipDraw);
            txtOperatingYear.KeyDown += OperatingYearKeyDownHandler;

            dgLedgerRecords.CellMouseEnter += Datagrid_CellMouseEnter;
            dgLedgerRecords.CellMouseLeave += Datagrid_CellMouseLeave;

            this.bgwPrimaryWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PrimaryWork);
            this.bgwPrimaryWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.PrimaryProgress);
            this.bgwPrimaryWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.PrimaryWorkCompleted);
        }

        #endregion

        #region Event Handlers

        #region FormLoading Event Handler

        private void FormLoadHandler(object sender, EventArgs e)
        {
            txtOperatingYear.Text = GlobalVariables.OperatingYear.ToString();
            LocalOperatingYear = GlobalVariables.OperatingYear;
            LocalConnectionString = GlobalVariables.ConnectionString;
            StartPrimaryWorker(null);
        }

        #endregion

        #region Button Click Event Handlers

        private void ShowLedger(object sender, EventArgs e)
        {

            try
            {
                if (GlobalVariables.currentUser == null)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Unauthorized Access", "You are currently not logged in. Please login first."));
                    return;
                }
                else
                {
                    //if (!GlobalVariables.currentUser.FindPermission("1"))
                    //{
                    //    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Unauthorized Access", "You are authorized. Contact your admin."));
                    //    return;
                    //}
                }


                ViewLedger();

            }
            catch (UserException UEx)
            {
                CustomMessageBox.ShowUserException(UEx);

            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
            finally { btnShow.Enabled = true; }

        }

        private void PrintReport(object sender, EventArgs e)
        {
            try
            {

                if (dgLedgerRecords.Rows.Count == 0)
                {
                    MessageBox.Show("No data");
                    return;
                }

                Application.DoEvents();
                // frmProgressBar.lblWaitMessage.Text = "Loading data...... Please wait.";
                // frmProgressBar.Show();
                Application.DoEvents();

                btnPrint.Text = "Wait..";
                btnPrint.Enabled = false;
                strAccountDetails = cmbAccountList.Text;

                dsLedgerBookObject = new MyDatasets.dsGeneralLedger();
                DataTable dtLedgerBook = dsLedgerBookObject.Tables[0];

                DataRow DR;

                foreach (DataGridViewRow row in dgLedgerRecords.Rows)
                {
                    DR = dtLedgerBook.NewRow();
                    DR["SerialNo"] = row.Cells["SerialNo"].FormattedValue.ToString();
                    DR["EntryDate"] = row.Cells["EntryDate"].FormattedValue.ToString();
                    DR["VoucherNo"] = row.Cells["VoucherNo"].FormattedValue.ToString();
                    DR["Particulars"] = row.Cells["AccountName"].FormattedValue.ToString();
                    DR["AccountCode"] = row.Cells["AccountCode"].FormattedValue.ToString();
                    DR["DebitAmount"] = row.Cells["DebitAmount"].FormattedValue.ToString();
                    DR["CreditAmount"] = row.Cells["CreditAmount"].FormattedValue.ToString();
                    DR["DebitBalance"] = row.Cells["DebitBalance"].FormattedValue.ToString();
                    DR["CreditBalance"] = row.Cells["CreditBalance"].FormattedValue.ToString();
                    dtLedgerBook.Rows.Add(DR);
                }


                Application.DoEvents();

                btnPrint.Enabled = false;
                CommonForms.frmMsReportViewer frm = new CommonForms.frmMsReportViewer();
                frm.MsReportViewer.ProcessingMode = ProcessingMode.Local;

                BindingSource bsInvoice = new BindingSource();
                bsInvoice.DataSource = dtLedgerBook;
                ReportDataSource rds = new ReportDataSource("GeneralLedgerDataset", bsInvoice);
                frm.MsReportViewer.LocalReport.DataSources.Add(rds);

                BindingSource bsCompanyInfomation = new BindingSource();
                bsCompanyInfomation.DataSource = GlobalVariables.currentUser.CompanyInformation;
                ReportDataSource rdsCompanyInfo = new ReportDataSource("CompanyInfoDataset", bsCompanyInfomation);
                frm.MsReportViewer.LocalReport.DataSources.Add(rdsCompanyInfo);


                ReportParameter[] reportParameters = new ReportParameter[4];
                reportParameters[0] = new ReportParameter("pOperatingYear", LocalOperatingYear, true);
                reportParameters[1] = new ReportParameter("rpAccountName", cmbAccountList.Text, true);
                reportParameters[2] = new ReportParameter("rpDebitTotal", txtDebitAmountGrandTotal.Text, true);
                reportParameters[3] = new ReportParameter("rpCreditTotal", txtCreditAmountGrandTotal.Text, true);

                frm.MsReportViewer.LocalReport.ReportEmbeddedResource = "QCash.AllReports.GeneralLedger.rdlc";
                frm.MsReportViewer.LocalReport.SetParameters(reportParameters);

                frm.Text = "General Ledger- " + cmbAccountList.Text;
                frm.Icon = Properties.Resources.PrinterGreenIco64;
                frm.Show(this.Owner);
                btnPrint.Enabled = true;

            }
            catch (UserException UEx)
            {
                CustomMessageBox.ShowUserException(UEx);
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowSystemException(ex);
            }
            finally { btnPrint.Text = "Print"; btnPrint.Enabled = true; }
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

        private void dgLedgerRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String currentCellName = dgLedgerRecords.CurrentCell.OwningColumn.Name;

            switch (currentCellName)
            {
                case "AccountName":
                    Int32 selectedAccountId = Convert.ToInt32(dgLedgerRecords.CurrentRow.Cells["Particulars"].Value);
                    cmbAccountList.SelectedValue = selectedAccountId;
                    ViewLedger();
                    break;
                case "VoucherNo":
                    String CurrentCellValue = dgLedgerRecords.CurrentCell.FormattedValue.ToString();
                    String voucherPrefix = CurrentCellValue.Substring(0, 1);
                    Int32 voucherTypeId = 0;
                    Int32 voucherId = 0;

                    if (voucherPrefix == "D")
                    {
                        voucherTypeId = 1;
                        voucherId = Convert.ToInt32(CurrentCellValue.Replace("D- ", ""));
                    }
                    else if (voucherPrefix == "C")
                    {
                        voucherTypeId = 2;
                        voucherId = Convert.ToInt32(CurrentCellValue.Replace("C- ", ""));
                    }
                    else if (voucherPrefix == "J")
                    {
                        voucherTypeId = 3;
                        voucherId = Convert.ToInt32(CurrentCellValue.Replace("J- ", ""));
                    }

                    if (voucherTypeId > 0)
                    {
                        VoucherMenuForms.frmVoucher frm = new VoucherMenuForms.frmVoucher(voucherTypeId, voucherId);
                        frm.Show(this.Owner);
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

                AccountHeadList = AccountHeadComboItem.GetComboList(LocalConnectionString);
                e.Result = e.Argument;
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
                    cmbAccountList.DataSource = null;
                    cmbAccountList.Items.Clear();
                    cmbAccountList.DataSource = AccountHeadList;
                    cmbAccountList.ValueMember = "AccountId";
                    cmbAccountList.DisplayMember = "AccountNameWithCode";
                   
                    if (pAccountIdToLoad != null)
                    {
                        cmbAccountList.SelectedValue = (Int32) pAccountIdToLoad;
                        ViewLedger();
                    }

                    cmbAccountList.Focus();
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

        //     private int ProgressValue;
        public void StartPrimaryWorker(Int32? arg)
        {
            this.Cursor = Cursors.WaitCursor;
            this.MyProgressBar.Maximum = 10;
            this.MyProgressBar.Value = 0;
            this.MyProgressBar.Visible = true;
            bgwPrimaryWorker.RunWorkerAsync(arg);
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

        private void CreateDatagrid()
        {

            dgLedgerRecords.Rows.Clear();

            dgLedgerRecords.Columns.Clear();
            dgLedgerRecords.Columns.Add("SerialNo", "");
            dgLedgerRecords.Columns.Add("EntryDate", "");
            dgLedgerRecords.Columns.Add("VoucherNo", "");
            dgLedgerRecords.Columns.Add("Particulars", "");
            dgLedgerRecords.Columns.Add("AccountName", "");
            dgLedgerRecords.Columns.Add("AccountCode", "");
            dgLedgerRecords.Columns.Add("DebitAmount", "");
            dgLedgerRecords.Columns.Add("CreditAmount", "");
            dgLedgerRecords.Columns.Add("DebitBalance", "");
            dgLedgerRecords.Columns.Add("CreditBalance", "");

            dgLedgerRecords.Columns["Particulars"].Visible = false;
            // Particuluars Account ID [invisible]

            dgLedgerRecords.Columns["SerialNo"].Width = 61;
            dgLedgerRecords.Columns["SerialNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //  0- serial

            dgLedgerRecords.Columns["EntryDate"].Width = 78;
            dgLedgerRecords.Columns["EntryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // 1- date
            dgLedgerRecords.Columns["EntryDate"].DefaultCellStyle.Format = "dd MMM yyyy";

            dgLedgerRecords.Columns["VoucherNo"].Width = 50;
            dgLedgerRecords.Columns["VoucherNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            // 2- voucher No

            dgLedgerRecords.Columns["AccountName"].Width = 280;
            dgLedgerRecords.Columns["AccountName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //  3- Particuluars Account Name

            dgLedgerRecords.Columns["AccountCode"].Width = 51;
            dgLedgerRecords.Columns["AccountCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // 4- Particulars Account code

            dgLedgerRecords.Columns["DebitAmount"].Width = 108;
            dgLedgerRecords.Columns["DebitAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgLedgerRecords.Columns["CreditAmount"].Width = 108;
            dgLedgerRecords.Columns["CreditAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgLedgerRecords.Columns["DebitBalance"].Width = 108;
            dgLedgerRecords.Columns["DebitBalance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgLedgerRecords.Columns["CreditBalance"].Width = 108;
            dgLedgerRecords.Columns["CreditBalance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // dgLedgerRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSlateGray;
            dgLedgerRecords.AllowUserToAddRows = false;
            dgLedgerRecords.ReadOnly = true;

        }

        public void ViewLedger()
        {

            int AccountID = (int)cmbAccountList.SelectedValue;

            if (AccountID==-5000)
            {
                return;
            }

            MastHead.Text =cmbAccountList.Text;
            this.Text = "General Ledger- " + cmbAccountList.Text;

            string sqlLedgerData = "";
            sqlLedgerData = sqlLedgerData + "SELECT tblVoucherType.VoucherPrefix+'-'+Str(tblLedger.VoucherId) AS VoucherNo, tblLedger.Particulars,tblLedger.EntryDate, tblAccountHead.AccountName, tblAccountHead.AccountCode, tblLedger.DebitAmount, tblLedger.CreditAmount, tblLedger.Narration ";
            sqlLedgerData = sqlLedgerData + " FROM tblAccountHead INNER JOIN (tblLedger INNER JOIN tblVoucherType ON tblLedger.VoucherTypeId = tblVoucherType.VoucherTypeId) ON tblAccountHead.AccountId = tblLedger.Particulars ";
            sqlLedgerData = sqlLedgerData + " WHERE tblLedger.AccountId = " + AccountID + "";
            sqlLedgerData = sqlLedgerData + " ORDER BY tblLedger.EntryDate asc, tblLedger.LedgerEntryId asc";

            OleDbDataAdapter daLedgerData = new OleDbDataAdapter(sqlLedgerData, LocalConnectionString);
            dtLedgerData = new DataTable();
            daLedgerData.Fill(dtLedgerData);

            decimal DebitAmountGrandTotal = 0;
            decimal CreditAmountGrandTotal = 0;

            if (dtLedgerData.Rows.Count > 0)
            {
                CreateDatagrid();
                lblRecordNotFound.Visible = false;
                string SerialNo;
                string VoucherNo;
                string AccountName;
                string AccountCode;
                string Narration;
                DateTime EntryDate;
                int Particulars;
                decimal DebitAmount;
                decimal CreditAmount;
                decimal DebitBalance;
                decimal CreditBalance;
                string strDebitAmount;
                string strCreditAmount;
                string strDebitBalance;
                string strCreditBalance;
                strDebitAmount = "";
                strCreditAmount = "";
                strDebitBalance = "";
                strCreditBalance = "";

                DebitBalance = 0;
                CreditBalance = 0;

                Application.DoEvents();

                MyProgressBar.Minimum = 0;
                MyProgressBar.Maximum = dtLedgerData.Rows.Count;
                MyProgressBar.Value = 0;
                MyProgressBar.Visible = true;

                Application.DoEvents();



                for (int i = 0; i <= dtLedgerData.Rows.Count - 1; i++)
                {
                    SerialNo = (i + 1).ToString();
                    // .Rows(i)("SerialNo")
                    EntryDate = (DateTime)dtLedgerData.Rows[i]["EntryDate"];
                    //.ToString()[MyDateStyle]
                    VoucherNo = dtLedgerData.Rows[i]["VoucherNo"].ToString();
                    Particulars = (int)dtLedgerData.Rows[i]["Particulars"];
                    AccountName = dtLedgerData.Rows[i]["AccountName"].ToString();
                    AccountCode = dtLedgerData.Rows[i]["AccountCode"].ToString();
                    DebitAmount = (decimal)(dtLedgerData.Rows[i]["DebitAmount"]);
                    CreditAmount = (decimal)(dtLedgerData.Rows[i]["CreditAmount"]);
                    Narration = dtLedgerData.Rows[i]["Narration"].ToString();

                    DebitAmountGrandTotal += DebitAmount;
                    CreditAmountGrandTotal += CreditAmount;

                    //    Step A
                    if ((DebitAmount != 0) && (CreditAmount == 0))
                    {
                        strDebitAmount = DebitAmount.ToString("N", GlobalVariables.CurrentCultureInfo);
                        strCreditAmount = "";
                        //Step A.1
                        if ((DebitBalance == 0) && (CreditBalance == 0))
                        {
                            DebitBalance = DebitAmount;
                            strDebitBalance = DebitBalance.ToString("N", GlobalVariables.CurrentCultureInfo);
                            CreditBalance = 0;
                            strCreditBalance = "";
                            //Step A.2
                        }
                        else if ((DebitBalance != 0) && (CreditBalance == 0))
                        {
                            DebitBalance = DebitBalance + DebitAmount;
                            strDebitBalance = DebitBalance.ToString("N", GlobalVariables.CurrentCultureInfo);
                            CreditBalance = 0;
                            strCreditBalance = "";
                            //Step A.3
                        }
                        else if ((DebitBalance == 0) && (CreditBalance != 0))
                        {
                            //Step A.3.a
                            if (CreditBalance > DebitAmount)
                            {
                                strDebitBalance = "";
                                CreditBalance = CreditBalance - DebitAmount;
                                strCreditBalance = CreditBalance.ToString("N", GlobalVariables.CurrentCultureInfo);
                                //Step A.3.b
                            }
                            else if (CreditBalance < DebitAmount)
                            {
                                DebitBalance = DebitAmount - CreditBalance;
                                strDebitBalance = DebitBalance.ToString("N", GlobalVariables.CurrentCultureInfo);
                                CreditBalance = 0;
                                strCreditBalance = "";

                                //Step A.3.c
                            }
                            else if (CreditBalance == DebitAmount)
                            {
                                DebitBalance = 0;
                                strDebitBalance = "0";
                                CreditBalance = 0;
                                strCreditBalance = "0";
                            }
                        }
                        //Step B
                    }
                    else if ((DebitAmount == 0) && (CreditAmount != 0))
                    {
                        strDebitAmount = "";
                        strCreditAmount = CreditAmount.ToString("N", GlobalVariables.CurrentCultureInfo);
                        //Step B.1
                        if ((DebitBalance == 0) && (CreditBalance == 0))
                        {

                            strDebitBalance = "";
                            CreditBalance = CreditAmount;
                            strCreditBalance = CreditBalance.ToString("N", GlobalVariables.CurrentCultureInfo);
                            //Step B.2
                        }
                        else if ((DebitBalance != 0) && (CreditBalance == 0))
                        {
                            //Step B.2.a
                            if (DebitBalance == CreditAmount)
                            {
                                DebitBalance = 0;
                                strDebitBalance = "0";
                                CreditBalance = 0;
                                strCreditBalance = "0";
                                //Step B.2.b
                            }
                            else if (DebitBalance > CreditAmount)
                            {
                                DebitBalance = DebitBalance - CreditAmount;
                                strDebitBalance = DebitBalance.ToString("N", GlobalVariables.CurrentCultureInfo);
                                CreditBalance = 0;
                                strCreditBalance = "";
                                //Step B.2.c
                            }
                            else if (DebitBalance < CreditAmount)
                            {
                                CreditBalance = CreditAmount - DebitBalance;
                                strCreditBalance = CreditBalance.ToString("N", GlobalVariables.CurrentCultureInfo);
                                DebitBalance = 0;
                                strDebitBalance = "";
                            }
                            //Step B.3
                        }
                        else if ((DebitBalance == 0) && (CreditBalance != 0))
                        {
                            strDebitBalance = "";
                            CreditBalance = CreditBalance + CreditAmount;
                            strCreditBalance = CreditBalance.ToString("N", GlobalVariables.CurrentCultureInfo);
                        }
                        //Step C
                    }
                    else if ((DebitAmount == 0) && (CreditAmount == 0))
                    {
                    }


                    int AccountNameLength = AccountName.Length;
                    int RemainingLength = 55 - AccountNameLength;


                    switch (Narration.Length)
                    {
                        case 0:
                            Narration = string.Empty;
                            break;
                        //TODO: correct this
                        // case  // ERROR: Case labels with binary operators are unsupported : GreaterThanOrEqual         RemainingLength:
                        //    Narration = " (" + Narration.Substring(0, RemainingLength - 5) + "..)";
                        //   break;
                        default:
                            Narration = " (" + Narration + ")";
                            break;
                    }

                    dgLedgerRecords.Rows.Add(SerialNo, EntryDate.ToString("d", GlobalVariables.CurrentCultureInfo), VoucherNo, Particulars, AccountName + Narration, AccountCode, strDebitAmount, strCreditAmount, strDebitBalance, strCreditBalance);
                    Application.DoEvents();
                    MyProgressBar.Value += 1;
                    Application.DoEvents();
                }

                MyProgressBar.Visible = false;


            }
            else
            {
                dgLedgerRecords.Rows.Clear();
                lblRecordNotFound.Visible = true;
            }

            txtDebitAmountGrandTotal.Text = DebitAmountGrandTotal.ToString("N", GlobalVariables.CurrentCultureInfo);
            txtCreditAmountGrandTotal.Text = CreditAmountGrandTotal.ToString("N", GlobalVariables.CurrentCultureInfo);

            dgLedgerRecords.ClearSelection();
            cmbAccountList.Focus();
        }

        #endregion

        private void cmbAccountList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ViewLedger();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            frmGeneralLedgerFilter frm = new frmGeneralLedgerFilter(this);
            if (frm.ShowDialog()==DialogResult.OK)
            {

            }
        }

        private void ChangeOperatingYearDatabase()
        {
            string NewOperatingYear = txtOperatingYear.Text.Trim();

            if (LocalOperatingYear==NewOperatingYear)
            {
                return;
            }

            if (NewOperatingYear.Length != 4)
            {
                RedToolTip.Show("Invalid Operating Year", txtOperatingYear);
                return;
            }

            int ChangingOperatingYear; bool IsNumeric = false;
            IsNumeric = int.TryParse(NewOperatingYear, out ChangingOperatingYear);
            if (!IsNumeric)
            {
                RedToolTip.Show("Invalid Operating Year", txtOperatingYear);
                return;
            }

            if (!File.Exists(GlobalVariables.DatabaseDirectory + "\\" + ConnectionStringGenerator.DatabasePrefix + NewOperatingYear + ".mdb"))
            {
                RedToolTip.Show("Operating Year not found.", txtOperatingYear,4000);
                return;
            }

            LocalConnectionString = ConnectionStringGenerator.GenerateForAccess2003(GlobalVariables.DatabaseDirectory, NewOperatingYear);

            this.Cursor = Cursors.WaitCursor;
            using (OleDbConnection Connection = new OleDbConnection(LocalConnectionString))
            {
                Connection.Open();
                LocalOperatingYear = NewOperatingYear;
                Connection.Close();

            }

            StartPrimaryWorker(null);
        }

        private void OperatingYearKeyDownHandler(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    ChangeOperatingYearDatabase();
                }

            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);

            }
        }

    }
}
