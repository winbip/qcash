using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using CustomObjects;
using sCommonLib;
using sCommonLib.Messages;

//using Guifreaks;
//using Guifreaks.Common;
//using Guifreaks.NavigationBar;


namespace QCash.MasterSetupForms.UserMenuForms
{
    public partial class frmAppUserList : Form
    {

        #region Private Variables
        private DataTable dtData;
        private Int32 pSelectedEntityId;
        // private frmMain mainForm;
        #endregion

        #region Public Properties

        public int SelectedEntityId
        {
            get { return pSelectedEntityId; }
        }

        #endregion

        #region Constructors

        public frmAppUserList()//frmMain MainForm
        {
            InitializeComponent();
            this.Icon = Properties.Resources.UserGroupBlueGreenIco;
            //mainForm = MainForm;
            AddEventHandlers();
        }

        #endregion

        #region Assigning Event Handlers

        private void AddEventHandlers()
        {

            this.Load += FormLoadHandler;
            btnClose.Click += CloseForm;
            txtLogInName.TextChanged += FilterDataGridView;

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

            dgData.Columns[0].Visible = false;

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

                  dtData=AppUser.GetEntityTable(GlobalVariables.ConnectionString); 
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

        #region Filter DataGridView

        private void FilterDataGridView(object sender, EventArgs e)
        {

            Control control = (Control)sender;

            string ColumnName = control.Name.ToString().Replace("txt", "");
            string FiltereringParameter = control.Text.Trim();

            DataView dvDataSource = (DataView)dgData.DataSource; //Copy existing dataview to new variable

            dvDataSource.RowFilter = ColumnName + " Like '*" + FiltereringParameter + "*'";
            dgData.ClearSelection();
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

    }
}
