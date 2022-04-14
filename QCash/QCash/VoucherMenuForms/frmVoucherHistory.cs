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

using Guifreaks;
using Guifreaks.Common;
using Guifreaks.NavigationBar;

using System.Collections;

namespace QCash.VoucherMenuForms
{
    public partial class frmVoucherHistory : Form
    {

        #region Private Variables
        private DataTable dtData;
        private Int32 pSelectedEntityId;

        private string LocalOperatingYear;
        private string LocalConnectionString;

        #endregion

        #region Public Properties

        public int SelectedEntityId
        {
            get { return pSelectedEntityId; }
        }

        #endregion

        #region Constructors

        public frmVoucherHistory()//frmMain MainForm
        {
            InitializeComponent();
           // this.Icon = Properties.Resources.AllVouchersIco32;
            RedToolTip.OwnerDraw = true;
            RedToolTip.BackColor = System.Drawing.Color.Red;
            RedToolTip.ForeColor = System.Drawing.Color.White; //if option-A is used.
            AddEventHandlers();
        }

        #endregion

        #region Assigning Event Handlers

        private void AddEventHandlers()
        {

            this.Load += FormLoadHandler;
            btnClose.Click += CloseForm;
            btnExport.Click += ExportDataToExcel;
            btnApplyFilter.Click += FilterByDate;

            RedToolTip.Draw += new DrawToolTipEventHandler(RedToolTipDraw);

            dgData.CellMouseEnter += dgData_CellMouseEnter;
            dgData.CellMouseLeave += dgData_CellMouseLeave;
            dgData.CellDoubleClick += dgData_CellDoubleClick;
            this.bgwPrimaryWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PrimaryWork);
            this.bgwPrimaryWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.PrimaryProgress);
            this.bgwPrimaryWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.PrimaryWorkCompleted);
        }
        #endregion

        #region FormatDatagrid


        private void FormatdgData()
        {
            dgData.DefaultCellStyle.FormatProvider = GlobalVariables.CurrentCultureInfo;
            dgData.RowHeadersVisible = false;
            dgData.AllowUserToAddRows = false;
            dgData.AllowUserToDeleteRows = false;
            dgData.AllowUserToResizeRows = true;

            dgData.ColumnHeadersVisible = true;
            dgData.AllowUserToOrderColumns = false;
            dgData.AllowUserToResizeColumns = true;

            dgData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgData.ScrollBars = ScrollBars.Vertical;
            dgData.ReadOnly = true;
            dgData.MultiSelect = false;

            dgData.EnableHeadersVisualStyles = false;
            dgData.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            dgData.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgData.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgData.ColumnHeadersDefaultCellStyle.Font = new Font(MyFontName, MyFontSize, FontStyle.Regular);

            dgData.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            //SingleHorizontal is required to set custom gridcolor

            dgData.GridColor = Color.LightSteelBlue;
            //dgData.BorderStyle = BorderStyle.None;
            //dgData.BackgroundColor = ControlFunctions.FormBackColor;

            dgData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgData.DefaultCellStyle.BackColor = Color.White;
            dgData.DefaultCellStyle.ForeColor = Color.Black;

            dgData.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgData.DefaultCellStyle.SelectionForeColor = Color.White;

            dgData.Columns["LedgerEntryId"].Visible = false;
            dgData.Columns["VoucherId"].Visible = false;
            dgData.Columns["VoucherTypeId"].Visible = false;
            dgData.Columns["VoucherType"].Visible = false;

            dgData.Columns["DrAccountId"].Visible = false;
            dgData.Columns["CrAccountId"].Visible = false;

            //dgData.Columns[1].Visible = true;
            //dgData.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgData.Columns[1].Width = 100;
            //dgData.Columns[1].ReadOnly = true;
            //dgData.Columns[1].HeaderText = "Session";
            //dgData.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dgData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgData.Columns[1].HeaderCell.Style.BackColor = Color.Lavender;
            //dgData.Columns[1].HeaderCell.Style.ForeColor = Color.SlateGray;
            //dgData.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgData.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;


            dgData.ClearSelection();

        }

        #endregion

        #region FormEventHandlers

        private void FormLoadHandler(object sender, EventArgs e)
        {
            MyNavBar.Collapsed = true;
            LocalOperatingYear = GlobalVariables.OperatingYear;
            LocalConnectionString = GlobalVariables.ConnectionString;
            StartPrimaryWorker();
        }

        #endregion

        #region BackgroundWorker Helper Methods

        private int ProgressValue;
        private void StartPrimaryWorker() //private void StartPrimaryWorker(object[] Args) 
        {
            this.Cursor = Cursors.WaitCursor;
            this.MyProgressBar.Maximum = 10;
            this.MyProgressBar.Value = 0;
            this.MyProgressBar.Visible = true;
            bgwPrimaryWorker.RunWorkerAsync(); // bgwPrimaryWorker.RunWorkerAsync(Args);
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

        //private void ReportSpinningProgress()
        //{
        //    Application.DoEvents();
        //    MyProgressDisk.Value++;
        //    System.Threading.Thread.Sleep(50);
        //} 


        #endregion

        #region BackGroundWorker Event Handlers

        private void PrimaryWork(object sender, DoWorkEventArgs e)
        {
            
             try
             {
                 string sqlSelectData = "select * from qryVoucherHistory";

                 using (OleDbDataAdapter da = new OleDbDataAdapter(sqlSelectData, GlobalVariables.ConnectionString))
                 {
                     dtData = new DataTable();
                     da.Fill(dtData);
                 }
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
                    DataView dv=new DataView(dtData,"","",DataViewRowState.CurrentRows);
                    dgData.DataSource=dv;FormatdgData();
                }

            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;MyProgressBar.Visible = false;
            }
        }

        #endregion

        #region Button Click Events

        private void ExportDataToExcel(object sender, EventArgs e)
        {
            /*
             try
              {
                  btnExport.Text = "Wait..";
                  btnExport.Enabled = false;
               
                  DataExporter.ExportToExcel.Export(dgData, MastHead.Text);
                  btnExport.Text = "&Export"; btnExport.Enabled = true;
              }
              catch (Exception Ex)
              {
                  MessageBox.Show(Ex.Message);
                  btnExport.Text = "&Export"; btnExport.Enabled = true;               
              }
             */
        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region Datagridview CellMouseEnter,CellMouseLeave, CellDoubleClick Events Handler


        private void dgData_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgData.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void dgData_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dgData.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void dgData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pSelectedEntityId = Convert.ToInt32(dgData.CurrentRow.Cells[0].Value);
            this.DialogResult = DialogResult.OK;
            //frmRawMaterialDetails frm = new frmRawMaterialDetails(entityId);
            //this.Close();
            //frm.Show(mainForm);

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

        #region Filter DataGridView

        private void FilterDataGridView(object sender, EventArgs e)
        {

            Control control = (Control)sender;

            string ColumnName = control.Name.ToString().Replace("txt", "");
            string FiltereringParameter = control.Text.Trim();

            DataView dvDataSource = (DataView)dgData.DataSource; //Copy existing dataview to new variable

            dvDataSource.RowFilter = ColumnName + " Like '*" + FiltereringParameter + "*'";
            dgData.ClearSelection();

            // Note- No need the following code for the time being.
            //if (FilteredText.Length > 0)
            //{
            //    dvDataSource.RowFilter = controlName + " Like '*" + FilteredText + "*'";

            //    dgData.ClearSelection();
            //}
            //else
            //{
            //    DataView dv = new DataView(dtData, "", "", DataViewRowState.CurrentRows);
            //    dgData.DataSource = dv; dgData.ClearSelection();
            //}

        }

        private void FilterByDate(object sender, EventArgs e)
        {
            /*
            string ColumnName = "EntryDate";
            DateTime FromDate;
            DateTime ToDate;

            Boolean IsFromDateValid = DateTime.TryParseExact(txtFromDate.Text.Trim(), GlobalVariables.InputDateFormatsAllowed, GlobalVariables.CurrentCultureInfo, DateTimeStyles.AllowLeadingWhite, out FromDate);
            if (!IsFromDateValid)
            {
                MessageBox.Show("From date is not valid."); txtFromDate.Focus(); return;
            }

            Boolean IsToDateValid = DateTime.TryParseExact(txtToDate.Text.Trim(), GlobalVariables.InputDateFormatsAllowed, GlobalVariables.CurrentCultureInfo, DateTimeStyles.AllowLeadingWhite, out ToDate);
            if (!IsToDateValid)
            {
                MessageBox.Show("To date is not valid."); txtToDate.Focus(); return;
            }


            DataView dvDataSource = (DataView)dgData.DataSource; //Copy existing dataview to new variable

            dvDataSource.RowFilter = ColumnName + " >= #" + FromDate.ToString("d") + "# and " + ColumnName + " <= #" + ToDate.ToString("d") + "#";
            dgData.ClearSelection();
            */
        }

        #endregion

        #region Print Data
        private void PrintData(object sender, EventArgs e)
        {
            //Print from Dataset
            //try
            //{
            //    btnPrintReceipt.Enabled = false;
            //    CommonForms.frmMsReportViewer frm = new CommonForms.frmMsReportViewer();
            //    frm.rvReportViewer.ProcessingMode = ProcessingMode.Local;

            //    BindingSource bsBookingInfo = new BindingSource();
            //    bsBookingInfo.DataSource = dsAccountChartList;
            //    bsBookingInfo.DataMember = "tblAccountChart";
            //    ReportDataSource rds = new ReportDataSource();
            //    rds.Name = "dsAccountChart_tblAccountChart";
            //    rds.Value = bsBookingInfo;
            //    frm.rvReportViewer.LocalReport.DataSources.Add(rds);

            //    frm.rvReportViewer.LocalReport.ReportEmbeddedResource = "MyProjectTemplate.MyReports.AccountChart.rdlc";

            //    btnPrintReceipt.Enabled = true;
            //    frm.Text = "Account Chart";
            //    frm.Show();

            //}
            //catch (Exception Ex)
            //{
            //    CustomMessageBox.ShowSystemException(Ex);
            //    btnPrintReceipt.Enabled = true;
            //}

        }
        #endregion

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {

            if (dtData.Rows.Count==0)
            {
                MessageBox.Show("No data to filter."); return;
            }

            if (chkFilterByVoucherType.Checked==false && chkFilterByDate.Checked==false && chkFilterByVoucherNo.Checked==false)
            {
                MessageBox.Show("Select filter option."); return;
            }

            String rowFilter = String.Empty;

            //---> check for voucher type
            if (chkFilterByVoucherType.Checked==true)
            {
                if (chkDebitVoucher.Checked==false && chkCreditVoucher.Checked==false && chkJournalVoucher.Checked==false)
                {
                    RedToolTip.Show("Select at least 1 voucher type.", chkFilterByVoucherType, 3000);
                    return;
                }

                if (chkDebitVoucher.Checked==true)
                {
                    rowFilter = " VoucherTypeId=1";
                }

                if (chkCreditVoucher.Checked==true)
                {
                    if (String.IsNullOrEmpty(rowFilter))
                    {
                        rowFilter = " VoucherTypeId=2";
                    }
                    else
                    {
                        rowFilter += " OR VoucherTypeId=2";
                    }
                }

                if (chkJournalVoucher.Checked==true)
                {
                    if (String.IsNullOrEmpty(rowFilter))
                    {
                        rowFilter = " VoucherTypeId=3";
                    }
                    else
                    {
                        rowFilter += " OR VoucherTypeId=3";
                    }
                }
            }

            //<--- check for voucher type
            //---> Check for date
            String DateFilter = string.Empty;
            if (chkFilterByDate.Checked==true)
            {
                DateTime FromDate, ToDate;

                if (!DateTime.TryParseExact(txtFromDate.Text.Trim(),GlobalVariables.InputDateFormatsAllowed,GlobalVariables.CurrentCultureInfo,DateTimeStyles.AllowLeadingWhite,out FromDate))
                {

                    RedToolTip.Show("Invalid date.", txtFromDate, 3000);
                     txtFromDate.Focus(); return;
                }

                if (!DateTime.TryParseExact(txtToDate.Text.Trim(), GlobalVariables.InputDateFormatsAllowed, GlobalVariables.CurrentCultureInfo, DateTimeStyles.AllowLeadingWhite, out ToDate))
                {
                    RedToolTip.Show("Invalid date.", txtToDate, 3000); txtToDate.Focus(); return;
                }

                if (String.IsNullOrEmpty(rowFilter))
                {
                    rowFilter = "EntryDate >= #" + FromDate.ToString("d") + "# AND EntryDate <= #" + ToDate.ToString("d") + "#";
                }
                else
                {
                    rowFilter += " AND EntryDate >= #" + FromDate.ToString("d") + "# AND EntryDate <= #" + ToDate.ToString("d") + "#";
                }

            }
            //<--- Check for date


            //---> Check for voucher number
            if (chkFilterByVoucherNo.Checked==true)
            {
                Int32 FromVoucherNo, ToVoucherNo;

                if (!Int32.TryParse(txtFromVoucherNo.Text.Trim(),out FromVoucherNo))
                {
                    RedToolTip.Show("Invalid Voucher No.", txtFromVoucherNo, 3000);
                    txtFromVoucherNo.Focus(); return;
                }

                if (!Int32.TryParse(txtToVoucherNo.Text.Trim(), out ToVoucherNo))
                {
                    RedToolTip.Show("Invalid Voucher No.", txtToVoucherNo, 3000);
                    txtToVoucherNo.Focus(); return;
                }

                if (String.IsNullOrEmpty(rowFilter))
                {
                    rowFilter = "VoucherId>="+ FromVoucherNo +" AND VoucherId<="+ ToVoucherNo +"";
                }
                else
                {
                    rowFilter += " AND VoucherId>=" + FromVoucherNo + " AND VoucherId<=" + ToVoucherNo + "";
                }
            }

            //<--- Check for voucher number


            DataView dv = new DataView(dtData,rowFilter,"",DataViewRowState.CurrentRows);
            dgData.DataSource = dv;
           // dvDataSource.RowFilter = VoucherTypeFilter;
            dgData.ClearSelection();
        }

        private void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtData, "", "", DataViewRowState.CurrentRows);
            dgData.DataSource = dv; //FormatdgData();
        }

        private void chkFilterByVoucherType_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFilterByVoucherType.Checked==true)
            {
                chkDebitVoucher.Enabled = true;
                chkCreditVoucher.Enabled = true;
                chkJournalVoucher.Enabled = true;
            }
            else
            {
                chkDebitVoucher.Checked = false;
                chkCreditVoucher.Checked = false;
                chkJournalVoucher.Checked = false;
                chkDebitVoucher.Enabled = false;
                chkCreditVoucher.Enabled = false;
                chkJournalVoucher.Enabled = false;
            }
        }

        private void chkFilterByDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFilterByDate.Checked==true)
            {
                txtFromDate.Enabled = true;
                txtToDate.Enabled = true;
            }
            else
            {
                txtFromDate.Clear(); txtFromDate.Enabled = false ;
                txtToDate.Clear(); txtToDate.Enabled = false;
            }
        }

        private void chkFilterByVoucherNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFilterByVoucherNo.Checked==true)
            {
                txtFromVoucherNo.Enabled = true;
                txtToVoucherNo.Enabled = true;
            }
            else
            {
                txtFromVoucherNo.Clear(); txtFromVoucherNo.Enabled = false;
                txtToVoucherNo.Clear(); txtToVoucherNo.Enabled = false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgData.Rows.Count==0)
            {
                MessageBox.Show("No data to print."); return;
            }


            btnPrint.Text = "Wait..";
            btnPrint.Enabled = false;

            MyDatasets.dsVoucherHistory voucherHistoryDataset = new MyDatasets.dsVoucherHistory();
            DataTable dtVoucherHistory = voucherHistoryDataset.Tables[0];

            DataRow DR;
            foreach (DataGridViewRow row in dgData.Rows)
            {
                DR = dtVoucherHistory.NewRow();
                DR["EntryDate"] = row.Cells["EntryDate"].FormattedValue.ToString();
                DR["VoucherNo"] = row.Cells["VoucherNo"].FormattedValue.ToString();
                DR["DrAccount"] = row.Cells["DrAccount"].FormattedValue.ToString();
                DR["CrAccount"] = row.Cells["CrAccount"].FormattedValue.ToString();
                DR["Amount"] = row.Cells["Amount"].FormattedValue.ToString();
                DR["Narration"] = row.Cells["Narration"].FormattedValue.ToString();
                dtVoucherHistory.Rows.Add(DR);
            }

            CommonForms.frmMsReportViewer frm = new CommonForms.frmMsReportViewer();
            frm.MsReportViewer.ProcessingMode = ProcessingMode.Local;

            BindingSource bsVoucherHistory = new BindingSource();
            bsVoucherHistory.DataSource = dtVoucherHistory;

            ReportDataSource rdsVoucherHistory = new ReportDataSource("VoucherHistoryDataset", bsVoucherHistory);
            frm.MsReportViewer.LocalReport.DataSources.Add(rdsVoucherHistory);

            frm.MsReportViewer.LocalReport.ReportEmbeddedResource = "QCash.AllReports.VoucherHistory.rdlc";

            frm.Text = "Voucher History";
            frm.Icon = Properties.Resources.PrinterGreenIco64;
            frm.Show(this.Owner);

            btnPrint.Text = "&Print";
            btnPrint.Enabled = true;
        }

    }
}
