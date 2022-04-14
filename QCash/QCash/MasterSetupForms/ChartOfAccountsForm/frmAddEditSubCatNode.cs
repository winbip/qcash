using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//using Microsoft.Reporting.WinForms;

using CustomObjects;
using sCommonLib;
using sCommonLib.Messages;
using sCommonLib.Exceptions;

using System.Collections;

namespace QCash.MasterSetupForms.ChartOfAccountsForm
{
    public partial class frmAddEditSubCatNode : Form
    {

        #region Private Variables
        private List<SubCategoryNode> SubCategoryNodes;
        private frmChartOfAccount pChartOfAccount;
        private TreeNode pParentNode;
        private TreeNode pCurrentNode;
        private SubCategory CurrentEntity;
       
        #endregion

        #region Public Properties
        /// <summary>
        /// Returns Client that just have created.
        /// </summary>
        public SubCategory NewlyCreatedEntity
        {
            get { return CurrentEntity; }
        }
        #endregion

        #region Constructors

        public frmAddEditSubCatNode()
        {
            InitializeComponent();
            RedToolTip.OwnerDraw = true;
            RedToolTip.BackColor = System.Drawing.Color.Red;
            RedToolTip.ForeColor = System.Drawing.Color.White; //if option-A is used.
            AddEventHandlers(); 
          }

        public frmAddEditSubCatNode(frmChartOfAccount ChartOfAccount,TreeNode ParentNode, TreeNode CurrentNode)
        {
            InitializeComponent();
            RedToolTip.OwnerDraw = true;
            RedToolTip.BackColor = System.Drawing.Color.Red;
            RedToolTip.ForeColor = System.Drawing.Color.White; //if option-A is used.
            pChartOfAccount = ChartOfAccount;
            pParentNode = ParentNode;
            pCurrentNode = CurrentNode;
            AddEventHandlers();
        }

        #endregion

        #region Add Event Handlers

        private void AddEventHandlers()
        {

            this.Load += FormLoadHandler;
            btnSave.Click += SaveEntity;
            btnDelete.Click += DeleteEntity;
            btnClose.Click += CloseForm;

            pbEntityFolder.MouseEnter += EntityFolderMouseEnter;
            pbEntityFolder.MouseLeave += EntityFolderMouseLeave;
            pbEntityFolder.Click += OpenEntityFolder;

            RedToolTip.Draw += new DrawToolTipEventHandler(RedToolTipDraw);
   
             this.bgwPrimaryWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PrimaryWork);
             this.bgwPrimaryWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.PrimaryProgress);
             this.bgwPrimaryWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.PrimaryWorkCompleted);
           
            AddCommonEventHandlers();

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


        private void SaveEntity(object sender, EventArgs e)
        {
            try
            {
                if (GlobalVariables.currentUser == null)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are currently not logged in. Please login first."));
                    return;
                }

                String SubCatName = txtSubCategoryName.Text.Trim();
                if (String.IsNullOrEmpty(SubCatName))
                {
                    throw new ExceptionWithControl("", "", "Enter Sub-Category Name.", "txtSubCategoryName");
                }

                CurrentEntity.SubCategoryName = SubCatName;

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

                        SubCategory.SaveEntity(CurrentEntity);
                        TreeNode newNode = new TreeNode();
                        newNode.Tag = CurrentEntity.NodeTag;
                        newNode.Name = CurrentEntity.SubCategoryId.ToString(); newNode.Text = CurrentEntity.SubCategoryName;
                        pParentNode.Nodes.Add(newNode);
                        pChartOfAccount.trvChartOfAccount.SelectedNode = newNode;
                        CustomMessageBox.ShowSuccessMessage(new SuccessMessage("Success", "Success", "Information successfully saved."));
                        AddNewCurrentEntity();
                    }
                    else
                    {
                        if (!GlobalVariables.currentUser.FindPermission("7"))
                        {
                            CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are not permitted to do this task. Contact your admin."));
                            return;
                        }

                        SubCategory.SaveEntity(CurrentEntity);
                        pCurrentNode.Text = SubCatName;
                        pChartOfAccount.trvChartOfAccount.SelectedNode = null;
                        CustomMessageBox.ShowSuccessMessage(new SuccessMessage("Success", "Success", "Information successfully saved."));
                        this.DialogResult = DialogResult.OK;
                    }         

                }
                else
                {
                    btnSave.Enabled = true;
                }

              // btnSave.Enabled = true; btnSave.Focus();
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
        
        }

        private void DeleteEntity(object sender, EventArgs e)
        {
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
                        SubCategory.DeleteEntity(CurrentEntity);
                        CustomMessageBox.ShowSuccessMessage(new SuccessMessage("Success", "Success", "Information successfully Deleted."));
                        pChartOfAccount.trvChartOfAccount.Nodes.Remove(pCurrentNode);
                        pChartOfAccount.trvChartOfAccount.SelectedNode = null;
                       this.DialogResult=DialogResult.OK;
      
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

        #region PictureBox MouseEnter,MouseLeave, Click Event Handlers
        private void EntityFolderMouseEnter(object sender, EventArgs e)
        {
          //  pbEntityFolder.Image = Properties.Resources.EntityFolderOpenedVertically24;
        }

        private void EntityFolderMouseLeave(object sender, EventArgs e)
        {
          //  pbEntityFolder.Image = Properties.Resources.EntityFolderClosedVertically24;
        }

        private void OpenEntityFolder(object sender, EventArgs e)
        {
            /*TODO: Uncomment & Editing needed at OpenEntityFolder
            frmSubCategoryHistory frm = new frmSubCategoryHistory();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CurrentEntity = SubCategory.GetEntity(frm.SelectedEntityId, GlobalVariables.ConnectionString);
                bsCurrentEntity.DataSource = CurrentEntity;
                MastHead.Text = "Editing SubCategory"; btnDelete.Visible = true;
            }
            */
        }
        #endregion

        #region Commen Enter,Leave, KeyDown EventHandlers
        //These are the common method for all control 

        private void AddCommonEventHandlers()
        {

        }

        private void EnterEventHandlerForTextBox(object sender, EventArgs e)
        {
            //Control control = sender as Control;
            ComponentFactory.Krypton.Toolkit.KryptonTextBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            control.StateCommon.Back.Color1 = Color.White;
        }

        private void LeaveEventHandlerForTextBox(object sender, EventArgs e)
        {
            // Control control = sender as Control;
            ComponentFactory.Krypton.Toolkit.KryptonTextBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            control.StateCommon.Back.Color1 = SystemColors.GradientActiveCaption;
            MyErrorProvider.SetError(control, "");
        }

        private void EnterEventHandlerForComboBox(object sender, EventArgs e)
        {
            //Control control = sender as Control;
            ComponentFactory.Krypton.Toolkit.KryptonComboBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonComboBox;
            control.StateCommon.ComboBox.Back.Color1 = Color.White;
            // pbAddNewClientType.Visible = true;
        }

        private void LeaveEventHandlerForComboBox(object sender, EventArgs e)
        {
            // Control control = sender as Control;
            //control.BackColor = GlobalVariables.LostFocusBackColor;
            //control.ForeColor = GlobalVariables.LostFocusForeColor;
            ComponentFactory.Krypton.Toolkit.KryptonComboBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonComboBox;
            control.StateCommon.ComboBox.Back.Color1 = SystemColors.GradientActiveCaption;
            // pbAddNewClientType.Visible = false;
            MyErrorProvider.SetError(control, "");
        }

        private void KeyDownEventHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ChangeFocusToNextControl(sender);
            }
        }

        #endregion

        #region BackGroundWorker Event Handlers
        
        private void PrimaryWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //object[] Args = (object[])e.Argument;
                //string ArgId = Args[0].ToString();
                //string Name = Args[1].ToString();
                //string Age = Args[2].ToString();

                //e.Result = new object[] { ArgId,Name,Age};

                 SubCategoryNodes = SubCategoryNode.GetEntityList(GlobalVariables.ConnectionString);
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
                   cmbSubCategoryNode.DataSource=SubCategoryNodes;
                   cmbSubCategoryNode.ValueMember="SubCategoryId";
                   cmbSubCategoryNode.DisplayMember="SubCategoryName";

                   cmbSubCategoryNode.SelectedValue = Convert.ToInt32( pParentNode.Name);
                   cmbSubCategoryNode.Enabled = false;

                   if (pCurrentNode==null)
                   {
                       AddNewCurrentEntity();
                   }
                   else
                   {
                       CurrentEntity = SubCategory.GetEntity(Convert.ToInt32(pCurrentNode.Name), GlobalVariables.ConnectionString);
                       txtSubCategoryName.Text = CurrentEntity.SubCategoryName;
                       btnDelete.Visible = true;
                   }
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

        #region BindingSource

        private void AddNewCurrentEntity()
        {
            CurrentEntity = new SubCategory(GlobalVariables.ConnectionString);
            CurrentEntity.ParentId = Convert.ToInt32( cmbSubCategoryNode.SelectedValue);
            btnDelete.Visible = false;
            btnSave.Enabled = true;
            txtSubCategoryName.Clear();
            MastHead.Text = "Creating New SubCategory";
          
        }

        #endregion

        #region Helper Methods

        #region Custom Exception Hander

        private void HandleExceptionWithControl(ExceptionWithControl EWC)
        {
            string strControlName = EWC.ControlName;
            Control control = null;
            switch (strControlName)
            {
                case "txtSubCategoryName":
                    control = txtSubCategoryName;
                    break;
                default:
                    break;
            }
           // CustomMessageBox.ShowGeneralMessage(new GeneralMessage(EWC.TitleBarMessage, EWC.HeadLineMessage, EWC.ErrorDescription));
            RedToolTip.Show(EWC.ErrorDescription, control, 3000);
            //MyErrorProvider.SetError(control, EWC.ErrorDescription); 
            control.Focus();
        }
        #endregion

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


        #region Set Focus Order and Change Focus

        private DataTable dtFocusOrder;
        private Control DefaultControl;

        private void CreateFocusOrderTable()
        {
            DefaultControl = btnSave;

            dtFocusOrder = new DataTable();
            dtFocusOrder.Columns.Add("ControlName", typeof(string));

            dtFocusOrder.Rows.Add("txtBookingNo");//TODO: Editing needed at CreateFocusOrderTable
        }

        private void ChangeFocusToNextControl(object sender)
        {
            Control control = (Control)sender;

            int i = 0;
            foreach (DataRow row in dtFocusOrder.Rows)
            {
                if (row["ControlName"] == control.Name.ToString())
                {
                    break;
                }
                i++;
            }

            if (i < dtFocusOrder.Rows.Count - 1)
            {
                string NextControlName = dtFocusOrder.Rows[i + 1]["ControlName"].ToString();
                Control[] tb = this.Controls.Find(NextControlName, true);

                tb[0].Focus();
            }
            else
            {
                string NextControlName = dtFocusOrder.Rows[0]["ControlName"].ToString();
                Control[] tb = this.Controls.Find(NextControlName, true);

                tb[0].Focus();

                // DefaultControl.Focus(); //Set default focus to save button
            }
        }
        #endregion

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
        #endregion

    }
}
