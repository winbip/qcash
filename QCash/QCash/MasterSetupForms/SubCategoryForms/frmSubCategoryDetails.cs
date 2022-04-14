using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;


//using Microsoft.Reporting.WinForms;

using CustomObjects;
using sCommonLib;
using sCommonLib.Messages;
using sCommonLib.Exceptions;

using System.Collections;

namespace QCash.MasterSetupForms.SubCategoryForms
{
    public partial class frmSubCategoryDetails : Form
    {

        #region Private Variables
        private List<SubCategoryNode> SubCategories;
        //private Hashtable mHashTable;
        /* TODO: Uncomment needed
        private MyType CurrentEntity;
        */
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

        public frmSubCategoryDetails()
        {
            InitializeComponent();
            RedToolTip.OwnerDraw = true;
            RedToolTip.BackColor = System.Drawing.Color.Red;
            RedToolTip.ForeColor = System.Drawing.Color.White; //if option-A is used.
            AddEventHandlers();
            //AddDataBindings();
            //bsCurrentEntity.AddNew();
        }

        #endregion

        #region Add Event Handlers

        private void AddEventHandlers()
        {

            this.Load += FormLoadHandler;
            btnSave.Click += SaveEntity;
            btnNewEntity.Click += NewEntity;
            btnDelete.Click += DeleteEntity;
            btnClose.Click += CloseForm;

            pbEntityFolder.MouseEnter += EntityFolderMouseEnter;
            pbEntityFolder.MouseLeave += EntityFolderMouseLeave;
            pbEntityFolder.Click += OpenEntityFolder;

            //bsCurrentEntity.AddingNew += OnAddingNew;

            RedToolTip.Draw += new DrawToolTipEventHandler(RedToolTipDraw);


             this.bgwPrimaryWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PrimaryWork);
             this.bgwPrimaryWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.PrimaryProgress);
             this.bgwPrimaryWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.PrimaryWorkCompleted);
   

        }

        #endregion

        #region Event Handlers

        #region FormLoading Event Handler

        private void FormLoadHandler(object sender, EventArgs e)
        {
            StartPrimaryWorker();
        }

        #endregion

        #region Button Click Event Handlers


        private void SaveEntity(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode();
            node.Name = "Hi"; node.Text = "Hello";
            tvSubCat.SelectedNode.Nodes.Add(node);
            /*TODO: Uncomment needed in SaveEntity
            try
            {
                if (GlobalVariables.currentUser == null)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are currently not logged in. Please login first."));
                    return;
                }

                btnSave.Enabled = false;
                if (CurrentEntity.IsDirty)
                {
                    if (CurrentEntity.IsNew)
                    {
                        if (!GlobalVariables.currentUser.FindPermission("6"))
                        {
                            CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are not permitted to do this task. Contact your admin."));
                            return;
                        }
                    }
                    else
                    {
                        if (!GlobalVariables.currentUser.FindPermission("7"))
                        {
                            CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are not permitted to do this task. Contact your admin."));
                            return;
                        }
                    }

                    MyType.SaveEntity(CurrentEntity);
                    CustomMessageBox.ShowSuccessMessage(new SuccessMessage("Success", "Success", "Information successfully saved."));
                    btnDelete.Visible = true; 
                    this.DialogResult = DialogResult.OK;
             
                   // if (!DriverNameSource.Contains(CurrentEntity.DriverName))
                   // {
                   //     DriverNameSource.Add(CurrentEntity.DriverName);
                   // }

                   // if (!TruckNoSource.Contains(CurrentEntity.TruckNo))
                   // {
                   //     TruckNoSource.Add(CurrentEntity.TruckNo);
                   // }

                   // btnPrint.Visible = true;
                   //// PrintData();
                }

                btnSave.Enabled = true; btnSave.Focus();
            }
            catch (ExceptionWithoutControl exceptionWithoutControl)
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage(exceptionWithoutControl.TitleBarMessage, exceptionWithoutControl.HeadLineMessage, exceptionWithoutControl.ErrorDescription));
                btnSave.Enabled = true; btnSave.Focus();
            }
            catch (ExceptionWithControl exceptionWithControl)
            {
                HandleExceptionWithControl(exceptionWithControl);
                btnSave.Enabled = true;
            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
                btnSave.Enabled = true;
            }
            */
        }

        private void DeleteEntity(object sender, EventArgs e)
        {
            tvSubCat.Nodes.Remove(tvSubCat.SelectedNode);

            /*TODO: Uncomment needed at DeleteEntity
            try
            {
                btnDelete.Enabled = false;
                if (GlobalVariables.currentUser == null)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are currently not logged in. Please login first."));
                    btnDelete.Enabled = true; return;
                }


                if (!GlobalVariables.currentUser.FindPermission("7"))
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are not permitted to do this task. Contact your admin."));
                    btnDelete.Enabled = true; return;
                }
                else
                {
                    if (CustomMessageBox.ShowConfirmationMessage(new ConfirmationMessage("Delete Record", "Sure?", "Are you sure to delete this record?")) == DialogResult.Yes)
                    {
                        MyType.DeleteEntity(CurrentEntity);
                        CustomMessageBox.ShowSuccessMessage(new SuccessMessage("Success", "Success", "Information successfully Deleted."));
                        btnDelete.Enabled = true; 
                        AddNewCurrentEntity();
                    }
                    else
                    {
                        btnDelete.Enabled = true;
                    }

                }
            }
            catch (ExceptionWithoutControl exceptionWithoutControl)
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage(exceptionWithoutControl.TitleBarMessage, exceptionWithoutControl.HeadLineMessage, exceptionWithoutControl.ErrorDescription));
                btnDelete.Enabled = true; btnDelete.Focus();
            }
            catch (ExceptionWithControl exceptionWithControl)
            {
                HandleExceptionWithControl(exceptionWithControl);
                btnDelete.Enabled = true;
            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
                btnDelete.Enabled = true;
            }
            */
        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewEntity(object sender, EventArgs e)
        {
            AddNewCurrentEntity();
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

        #region PictureBox MouseEnter,MouseLeave, Click Event Handlers
        private void EntityFolderMouseEnter(object sender, EventArgs e)
        {
           // pbEntityFolder.Image = Properties.Resources.EntityFolderOpenedVertically24;
        }

        private void EntityFolderMouseLeave(object sender, EventArgs e)
        {
          //  pbEntityFolder.Image = Properties.Resources.EntityFolderClosedVertically24;
        }

        private void OpenEntityFolder(object sender, EventArgs e)
        {
            /*TODO: Uncomment & Editing needed at OpenEntityFolder
            frmMyTypeHistory frm = new frmMyTypeHistory();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CurrentEntity = MyType.GetEntity(frm.SelectedEntityId, GlobalVariables.ConnectionString);
                bsCurrentEntity.DataSource = CurrentEntity;
                MastHead.Text = "Editing MyType"; btnDelete.Visible = true;
            }
            */
        }
        #endregion

        #region BackGroundWorker Event Handlers
        //=========================================================For Reference
        // private void btnStart_Click(object sender, EventArgs e)
        //{
        //    string ArgId = txtArgId.Text.Trim();
        //    string Name = txtArgName.Text.Trim();
        //    string Age = txtArgAge.Text.Trim();

        //    object[] Args = new object[] { ArgId, Name, Age };
        //   StartPrimaryWorker(Args);
        //}
        //===========================================================
          
         
        private void PrimaryWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SubCategories = SubCategoryNode.GetEntityList(GlobalVariables.ConnectionString);
            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
        }
         
         
        private void PrimaryProgress(object sender, ProgressChangedEventArgs e)
        {
          //  MyProgressBar.Position = e.ProgressPercentage;
        }
         
        private void PrimaryWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //For Help
                //DataSet dsData = e.Result as DataSet;
                

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
                    FillNode(SubCategories, null);
                }

            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        } 
         
          
    
        #endregion

        #endregion

        #region BindingSource

        private void OnAddingNew(object sender, AddingNewEventArgs e)
        {
            //CreateHashTable();
            //CurrentEntity = new CustomType(GlobalVariables.ConnectionString);
            //e.NewObject = CurrentEntity;
        }

        private void AddNewCurrentEntity()
        {
            /*TODO: Uncomment and Editing needed at AddNewCurrentEntity
            CurrentEntity = new MyType(GlobalVariables.ConnectionString);
           // bsCurrentEntity.Clear();
            bsCurrentEntity.DataSource = CurrentEntity;
            bsCurrentEntity.ResetBindings(false); 
            btnDelete.Visible = false;
            MastHead.Text = "Creating New MyType";
            */
        }

        private void AddDataBindings()
        {
            //TODO: Uncomment and editing needed at AddDataBindings
            //bsCurrentEntity.DataSource = typeof(MyType);
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

        private void FillNode(List<SubCategoryNode> items, TreeNode node)
        {
            var parentID = node != null? (int)node.Tag : 0;

            var nodesCollection = node != null? node.Nodes: tvSubCat.Nodes;

            foreach (var item in items.Where(i => i.ParentId == parentID))
            {
                var newNode = nodesCollection.Add(item.SubCategoryId.ToString(),item.SubCategoryName);
                newNode.Tag = item.NodeTag;
              

                FillNode(items, newNode);
            }
        }

        #region Printing
        private void PrintData(object sender, EventArgs e)
        {
            /* try
             {
                 btnPrint.Enabled = false;
                 CommonForms.frmReportViewer frm = new CommonForms.frmReportViewer();
                 frm.rvReportViewer.ProcessingMode = ProcessingMode.Local;

                 BindingSource bsInvoice = new BindingSource();
                 bsInvoice.DataSource = CurrentEntity;
                 ReportDataSource rds = new ReportDataSource("InvoiceReportDataset", bsInvoice);
                 frm.rvReportViewer.LocalReport.DataSources.Add(rds);

                 BindingSource bsSalesPerson = new BindingSource();
                 bsSalesPerson.DataSource = CurrentEntity.SalesPersonDetails;
                 ReportDataSource rdsSalesPerson = new ReportDataSource("SalesPersonReportDataset", bsSalesPerson);
                 frm.rvReportViewer.LocalReport.DataSources.Add(rdsSalesPerson);

                 ReportParameter[] reportParameters = new ReportParameter[1];
                 reportParameters[0] = new ReportParameter("pOperatingYear", LocalOperatingYear.ToString(), true);

                 frm.rvReportViewer.LocalReport.ReportEmbeddedResource = "ProjectName.AllReports.ReportName.rdlc";
                 frm.rvReportViewer.LocalReport.SetParameters(reportParameters);
               
                 frm.Text = "Print Data";
                 frm.Show();
                 btnPrint.Enabled = true;
             }
             catch (Exception Ex)
             {
                 CustomMessageBox.ShowSystemException(Ex);
                 btnPrint.Enabled = true;
             }
             */
        }
        #endregion

        private void tvSubCat_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = tvSubCat.SelectedNode;
            if (node.Name=="SystemDefinedAccountType")
            {
                MessageBox.Show("This node is system defined. You can not edit it."); return;
            }

            String NodeText = node.Text; String NodeName = node.Name; Int32 NodeTag = Convert.ToInt32(node.Tag);
            MessageBox.Show(node.Text); MessageBox.Show(node.Name); MessageBox.Show(node.Tag.ToString());
        }
        #endregion

    }
}
