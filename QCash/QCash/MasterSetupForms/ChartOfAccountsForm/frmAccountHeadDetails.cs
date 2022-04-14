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
    public partial class frmAccountHeadDetails : Form
    {

        #region Private Variables
      
        private AccountHead CurrentEntity;
        private Int32? LastCreatedAccountHeadId=null;
        private TreeNode pRootNode;
        private TreeNode pParentNode;
        private TreeNode pAccountNodeToEdit; //if user select any head from Account chart form.
        private Boolean pOpenAccountChartForm;
       
        #endregion

        #region Public Properties
        /// <summary>
        /// Returns Client that just have created.
        /// </summary>
        public Int32 NewlyCreatedEntity
        {
            get { return (Int32)LastCreatedAccountHeadId; }
        }
       
        #endregion

        #region Constructors

        public frmAccountHeadDetails(TreeNode AccountNodeToEdit, TreeNode ParentNode, TreeNode RootNode, Boolean OpenAccountChartForm)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.AccountHeadIco32;
            pAccountNodeToEdit = AccountNodeToEdit;
            pParentNode = ParentNode;
            pRootNode = RootNode;
            pOpenAccountChartForm = OpenAccountChartForm;
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
            btnSave.Click += SaveEntity;
            btnNewEntity.Click += NewEntity;
            btnDelete.Click += DeleteEntity;
            btnClose.Click += CloseForm;

            RedToolTip.Draw += new DrawToolTipEventHandler(RedToolTipDraw);
            /*
             dgData.CellMouseEnter += dgData_CellMouseEnter;
             dgData.CellMouseLeave += dgData_CellMouseLeave;
             dgData.CellDoubleClick += dgData_CellDoubleClick;

             this.bgwPrimaryWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PrimaryWork);
             this.bgwPrimaryWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.PrimaryProgress);
             this.bgwPrimaryWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.PrimaryWorkCompleted);
            */
            AddCommonEventHandlers();
           

        }

        #endregion


        #region Event Handlers

        #region FormLoading Event Handler

        private void FormLoadHandler(object sender, EventArgs e)
        {

            if (pAccountNodeToEdit==null)
            {
                AddNewCurrentEntity();
            }
            else
            {
                Int32 accountId = Convert.ToInt32(pAccountNodeToEdit.Name);
                LastCreatedAccountHeadId = accountId;
                CurrentEntity = AccountHead.GetEntity(accountId, GlobalVariables.ConnectionString);
                if (CurrentEntity.AccountCode!=0)
                {
                    txtAccountCode.Text = CurrentEntity.AccountCode.ToString();
                }

                txtAccountName.Text = CurrentEntity.AccountName;
                chkCashBookDefault.Checked = CurrentEntity.IsCashBookDefault;

                //if default cash book account is already defined, then disable the checkbox.
                if (AccountHead.IsCashBookAccountDefined(GlobalVariables.ConnectionString))
                {
                    if (CurrentEntity.IsCashBookDefault) //but not for the default cash account
                    {
                        chkCashBookDefault.Enabled = true;
                    }
                    else
                    {
                        chkCashBookDefault.Enabled = false;
                    }                 
                }

                MastHead.Text = "Editing Account Head";

                if (pRootNode != null)
                {
                    String rootNodeName = pRootNode.Name.ToString();
                    switch (rootNodeName)
                    {
                        case "1":

                            radioOptionA.Checked = true;
                            if (pParentNode.Name != "1")
                            {
                                txtPathA.Text = pParentNode.FullPath.Replace(pRootNode.Text + "\\", "");
                            }
                            txtPathA.Visible = true;btnSelectA.Visible=true;
                            CurrentEntity.AccountTypeId = Convert.ToInt32(rootNodeName);
                            CurrentEntity.SubCategoryId = Convert.ToInt32(pParentNode.Name);
                            break;
                        case "2":
                            radioOptionB.Checked = true;
                            if (pParentNode.Name != "2")
                            {
                                txtPathB.Text = pParentNode.FullPath.Replace(pRootNode.Text + "\\", "");
                            }
                             txtPathB.Visible = true;btnSelectB.Visible=true;
                            CurrentEntity.AccountTypeId = Convert.ToInt32(rootNodeName);
                            CurrentEntity.SubCategoryId = Convert.ToInt32(pParentNode.Name);
                            break;
                        case "3":
                            radioOptionC.Checked = true;
                            if (pParentNode.Name != "3")
                            {
                                txtPathC.Text = pParentNode.FullPath.Replace(pRootNode.Text + "\\", "");
                            }
                            
                            txtPathC.Visible = true; btnSelectC.Visible=true;
                            CurrentEntity.AccountTypeId = Convert.ToInt32(rootNodeName);
                            CurrentEntity.SubCategoryId = Convert.ToInt32(pParentNode.Name);
                            break;
                        default:
                            break;
                    }
                }

                radioOptionA.CheckedChanged += OptionAChanged;
                radioOptionB.CheckedChanged += OptionBChanged;
                radioOptionC.CheckedChanged += OptionCChanged;
            }

            pRootNode = null; pParentNode = null;
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

                String strAccountCode = txtAccountCode.Text.Trim();
                if (String.IsNullOrEmpty(strAccountCode))
                {
                    CurrentEntity.AccountCode = 0;
                }
                else
                {
                    Int32 intAccountCode;
                    Boolean IsAccountCodeValid = Int32.TryParse(strAccountCode, out intAccountCode);
                    if (IsAccountCodeValid)
                    {
                        CurrentEntity.AccountCode = intAccountCode;
                    }
                    else
                    {
                        throw new ExceptionWithControl("", "", "Account Code must be numeric.", "txtAccountCode");
                    }
                }

                String accountName = txtAccountName.Text.Trim();
                if (String.IsNullOrEmpty(accountName))
                {
                    throw new ExceptionWithControl("", "", "Enter Account Name.", "txtAccountName");
                }
                else
                {
                    CurrentEntity.AccountName = txtAccountName.Text.Trim();
                }              
               
                CurrentEntity.IsCashBookDefault = chkCashBookDefault.Checked;

                if (radioOptionA.Checked==false && radioOptionB.Checked==false && radioOptionC.Checked==false)
                {
                    throw new ExceptionWithControl("", "", "Select Account Type.", "radioOptionA");
                }

                btnSave.Enabled = false;
                if (CurrentEntity.IsDirty)
                {
                    if (CurrentEntity.IsNew)
                    {
                        if (!GlobalVariables.currentUser.FindPermission("1"))
                        {
                            CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are not permitted to do this task. Contact your admin."));
                            return;
                        }
                    }
                    else
                    {
                        if (!GlobalVariables.currentUser.FindPermission("2"))
                        {
                            CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are not permitted to do this task. Contact your admin."));
                            return;
                        }
                    }

                    AccountHead.SaveEntity(CurrentEntity);
                    if (pOpenAccountChartForm)
                    {
                         CustomMessageBox.ShowSuccessMessage(new SuccessMessage("Success", "Success", "Information successfully saved."));
                        btnDelete.Visible = true; 
                    }
                   
                    LastCreatedAccountHeadId = CurrentEntity.AccountId;

                    this.DialogResult = DialogResult.OK;
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


                if (!GlobalVariables.currentUser.FindPermission("10"))
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are not permitted to do this task. Contact your admin."));
                    btnDelete.Enabled = true; return;
                }
                else
                {
                    if (CustomMessageBox.ShowConfirmationMessage(new ConfirmationMessage("Delete Record", "Sure?", "Are you sure to delete this record?")) == DialogResult.Yes)
                    {
                        AccountHead.DeleteEntity(CurrentEntity);
                        CustomMessageBox.ShowSuccessMessage(new SuccessMessage("Success", "Success", "Information successfully Deleted."));
                        btnDelete.Enabled = true;
                        LastCreatedAccountHeadId = null;
                        pRootNode = null;
                        pParentNode = null;
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
            frmAccountHeadHistory frm = new frmAccountHeadHistory();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CurrentEntity = AccountHead.GetEntity(frm.SelectedEntityId, GlobalVariables.ConnectionString);
                bsCurrentEntity.DataSource = CurrentEntity;
                MastHead.Text = "Editing AccountHead"; btnDelete.Visible = true;
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

     

        #endregion

        #region BackGroundWorker Event Handlers
        /*
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
                object[] Args = (object[])e.Argument;
                string ArgId = Args[0].ToString();
                string Name = Args[1].ToString();
                string Age = Args[2].ToString();

                e.Result = new object[] { ArgId,Name,Age};
            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
        }
         
         
        private void PrimaryProgress(object sender, ProgressChangedEventArgs e)
        {
            MyProgressBar.Position = e.ProgressPercentage;
        }
         
        private void PrimaryWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //For Help
                //DataSet dsData = e.Result as DataSet;
                

                if (e.Cancelled)
                {
                    //CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Cancelled", "Tasks Cancelled", "Tasks have been cancelled. Please try again."));
                }
                else if (e.Error != null)
                {
                    //CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Error", "Error", e.Error.Message));
                }
                else
                {
                    if (e.Result != null)
                    {
                        object[] Result;

                        Result = (object[])e.Result;
                        string ArgId = Result[0].ToString();
                        string Name = Result[1].ToString();
                        string Age = Result[2].ToString();

                        txtResultId.Text = ArgId;
                        txtResultName.Text = Name;
                        txtResultAge.Text = Age;
                    }
                    else
                    {
                        //Show message if result is empty.
                    }
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
         
          
        */
        #endregion

        
        #endregion

        #region BindingSource

        private void AddNewCurrentEntity()
        {

            radioOptionA.CheckedChanged -= OptionAChanged;
            radioOptionB.CheckedChanged -= OptionBChanged;
            radioOptionC.CheckedChanged -= OptionCChanged;

            chkCashBookDefault.Checked = false;
            //if default cash book account is already defined, then disable the checkbox.
            if (AccountHead.IsCashBookAccountDefined(GlobalVariables.ConnectionString))
            {
                chkCashBookDefault.Enabled = false;
            }

            MastHead.Text = "Creating New Account Head";

            CurrentEntity = new AccountHead(GlobalVariables.ConnectionString);

          

            txtAccountCode.Text = CurrentEntity.AccountCode.ToString();
            txtAccountName.Clear();

            if (pRootNode!=null)
            {
                String rootNodeName = pRootNode.Name.ToString();
                switch (rootNodeName)
                {
                    case "1":
                       
                        radioOptionA.Checked = true;
                        if (pParentNode.Name!="1")
                        {
                            txtPathA.Text = pParentNode.FullPath.Replace(pRootNode.Text + "\\", "");
                        }
                        txtPathA.Visible = true;btnSelectA.Visible=true;
                        CurrentEntity.AccountTypeId = Convert.ToInt32(rootNodeName);
                        CurrentEntity.SubCategoryId = Convert.ToInt32(pParentNode.Name);
                        break;
                    case "2":
                        radioOptionB.Checked = true;
                        if (pParentNode.Name!="2")
                        {
                            txtPathB.Text = pParentNode.FullPath.Replace(pRootNode.Text + "\\", "");
                        }
                         txtPathB.Visible = true;btnSelectB.Visible=true;
                        CurrentEntity.AccountTypeId = Convert.ToInt32(rootNodeName);
                        CurrentEntity.SubCategoryId = Convert.ToInt32(pParentNode.Name);
                        break;
                    case "3":
                        radioOptionC.Checked = true;
                        if (pParentNode.Name != "3")
                        {
                            txtPathC.Text = pParentNode.FullPath.Replace(pRootNode.Text + "\\", "");
                        }
                         txtPathC.Visible = true;btnSelectC.Visible=true;
                        CurrentEntity.AccountTypeId = Convert.ToInt32(rootNodeName);
                        CurrentEntity.SubCategoryId = Convert.ToInt32(pParentNode.Name);
                        break;
                    default:
                        break;
                }

                  pRootNode = null; pParentNode = null;
            }
            else
            {
             
                radioOptionA.Checked = false; txtPathA.Visible = false; btnSelectA.Visible = false;
                radioOptionB.Checked = false; txtPathB.Visible = false; btnSelectB.Visible = false;
                radioOptionC.Checked = false; txtPathC.Visible = false; btnSelectC.Visible = false;
               
               
            }

            radioOptionA.CheckedChanged += OptionAChanged;
            radioOptionB.CheckedChanged += OptionBChanged;
            radioOptionC.CheckedChanged += OptionCChanged;

            btnDelete.Visible = false;
            txtAccountCode.Focus();

            
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
                case "txtAccountCode":  control = txtAccountCode; break;
                case "txtAccountName": control = txtAccountName; break;
                case "radioOptionA": control = radioOptionA; break; 
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
        /*
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
          
        private void ReportSpinningProgress()
        {
            Application.DoEvents();
            MyProgressDisk.Value++;
            System.Threading.Thread.Sleep(50);
        } 
         
         */
        #endregion

        

        private void OptionAChanged(object sender, EventArgs e)
        {
            ComponentFactory.Krypton.Toolkit.KryptonRadioButton radioButton = (ComponentFactory.Krypton.Toolkit.KryptonRadioButton)sender;
            if (radioButton.Checked)
            {
                txtPathA.Visible = true; txtPathA.Text = "None";
                btnSelectA.Visible = true;
                CurrentEntity.AccountTypeId = 1;
                CurrentEntity.SubCategoryId = 1;
            }
            else
            {
                txtPathA.Visible = false; btnSelectA.Visible = false;
            }
        }
        #endregion

        private void OptionBChanged(object sender, EventArgs e)
        {
            ComponentFactory.Krypton.Toolkit.KryptonRadioButton radioButton = (ComponentFactory.Krypton.Toolkit.KryptonRadioButton)sender;
            if (radioButton.Checked)
            {
                txtPathB.Visible = true; txtPathB.Text = "None";
                btnSelectB.Visible = true;
                CurrentEntity.AccountTypeId = 2;
                CurrentEntity.SubCategoryId = 2;
            }
            else
            {
                txtPathB.Visible = false; btnSelectB.Visible = false;
            }
        }

        private void OptionCChanged(object sender, EventArgs e)
        {
            ComponentFactory.Krypton.Toolkit.KryptonRadioButton radioButton = (ComponentFactory.Krypton.Toolkit.KryptonRadioButton)sender;
            if (radioButton.Checked)
            {
                txtPathC.Visible = true; txtPathC.Text = "None";
                btnSelectC.Visible = true;
                CurrentEntity.AccountTypeId = 3;
                CurrentEntity.SubCategoryId = 3;
            }
            else
            {
                txtPathC.Visible = false; btnSelectC.Visible = false;
            }
        }

        private void btnSelectA_Click(object sender, EventArgs e)
        {
            frmSelectSubCategoryNode frm = new frmSelectSubCategoryNode(CurrentEntity.AccountTypeId, CurrentEntity.SubCategoryId);
            if (frm.ShowDialog()==DialogResult.OK)
            {
                txtPathA.Text = frm.SelectedNode.FullPath;
                CurrentEntity.SubCategoryId = Convert.ToInt32(frm.SelectedNode.Name);
            } 
        }

        private void btnSelectB_Click(object sender, EventArgs e)
        {
            frmSelectSubCategoryNode frm = new frmSelectSubCategoryNode(CurrentEntity.AccountTypeId, CurrentEntity.SubCategoryId);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtPathB.Text = frm.SelectedNode.FullPath;
                CurrentEntity.SubCategoryId = Convert.ToInt32(frm.SelectedNode.Name);
            } 
        }

        private void btnSelectC_Click(object sender, EventArgs e)
        {
            frmSelectSubCategoryNode frm = new frmSelectSubCategoryNode(CurrentEntity.AccountTypeId, CurrentEntity.SubCategoryId);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtPathC.Text = frm.SelectedNode.FullPath;
                CurrentEntity.SubCategoryId = Convert.ToInt32(frm.SelectedNode.Name);
            } 
        }

        private void frmAccountHeadDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pOpenAccountChartForm)
            {
                frmChartOfAccount frm = new frmChartOfAccount();

                if (LastCreatedAccountHeadId != null)
                {
                    frm.NodeIdToSelect = (Int32)LastCreatedAccountHeadId;
                }

                frm.Show(this.Owner);
            }

        }

    }
}
