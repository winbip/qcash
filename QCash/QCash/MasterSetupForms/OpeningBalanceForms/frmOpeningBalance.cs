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

namespace QCash.MasterSetupForms.OpeningBalanceForms
{
    public partial class frmOpeningBalance : Form
    {

        #region Private Variables
        private OpeningBalance CurrentEntity;
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

        public frmOpeningBalance()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.OpeningBalanceIco32;
            RedToolTip.OwnerDraw = true;
            RedToolTip.BackColor = System.Drawing.Color.Red;
            RedToolTip.ForeColor = System.Drawing.Color.White; //if option-A is used.
            AddEventHandlers(); AddDataBindings();
            btnDelete.Visible = false;
        }

        #endregion

        #region Add Event Handlers

        private void AddEventHandlers()
        {

            this.Load += FormLoadHandler;
            txtEntryDate.KeyDown += DateTextBoxKeyDown;
            cmbAccount.KeyDown += AccountComboBoxKeyDown;
            txtDebitAmount.KeyDown += DebitAmountTextBoxKeyDown;
            txtCreditAmount.KeyDown += CreditAmountTextBoxKeyDown;

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

        }

        #endregion

        #region Event Handlers

        #region FormLoading Event Handler

        private void FormLoadHandler(object sender, EventArgs e)
        {

            bsAccountHeads.DataSource = AccountHeadComboItem.GetComboList(GlobalVariables.ConnectionString);

            AddNewCurrentEntity();
        }

        #endregion

        #region Button Click Event Handlers


        private void SaveEntity(object sender, EventArgs e)
        {

            try
            {
                if (GlobalVariables.currentUser == null)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Unauthorized Access", "You are currently not logged in. Please login first."));
                    return;
                }

                if (CurrentEntity.IsDirty)
                {

                    if (CurrentEntity.IsNew)
                    {
                        //-->Add Permission Check
                        if (!GlobalVariables.currentUser.FindPermission("4"))
                        {
                            CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Opening Balance", "Unauthorized Access", "You are not permitted. Contact your admin."));
                            return;
                        }
                        //<-- Add Permission check
                    }
                    else
                    {
                        //-->Edit Permission Check
                        if (!GlobalVariables.currentUser.FindPermission("5"))
                        {
                            CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Opening Balance", "Unauthorized Access", "You are not permitted. Contact your admin."));
                            return;
                        }
                        //<--Edit Permission check
                    }


                    if (CurrentEntity.AccountId == 0)
                    {
                        CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Opening Balance", "Information Required", "Select an account head."));
                        cmbAccount.Focus();
                        return;
                    }
                    btnSave.Enabled = false;
                    OpeningBalance.SaveEntity(CurrentEntity);
                    btnSave.Enabled = true;
                    CustomMessageBox.ShowSuccessMessage(new SuccessMessage("Opening Balance", "Success", "Information successfully saved."));
                }
            }
            catch (UserException UEx)
            {
                CustomMessageBox.ShowUserException(UEx); btnSave.Enabled = true;

            }
            catch (ArgumentException AEx) //handing error for late entry or existing entry
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Opening Balance", "Invalid Attempt", AEx.Message)); btnSave.Enabled = true;
            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex); btnSave.Enabled = true;
            }
            // finally { btnSave.Enabled = true; btnDelete.Visible = true; btnSave.Focus(); } 

        }

        private void DeleteEntity(object sender, EventArgs e)
        {
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

        private void DateTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                cmbAccount.Focus();
            }
        }

        private void AccountComboBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtDebitAmount.Focus();
            }
        }

        private void DebitAmountTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtCreditAmount.Focus();
            }
        }

        private void CreditAmountTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSave.Focus();
            }
        }
        
        #endregion

        #region BindingSource

        private void AddNewCurrentEntity()
        {
            CurrentEntity = new OpeningBalance(GlobalVariables.ConnectionString);
            CurrentEntity.EntryDate = DateTime.Today.Date;
            bsCurrentEntity.Clear();
            bsCurrentEntity.DataSource = CurrentEntity;
            btnDelete.Visible = false;
            cmbAccount.Focus();
        }

        private void AddDataBindings()
        {
            bsCurrentEntity.DataSource = typeof(OpeningBalance);
            txtEntryDate.DataBindings.Add("Text", bsCurrentEntity, "EntryDate", true, DataSourceUpdateMode.OnPropertyChanged, null, "d", GlobalVariables.CurrentCultureInfo);
            cmbAccount.DataBindings.Add("SelectedValue", bsCurrentEntity, "AccountId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDebitAmount.DataBindings.Add("Text", bsCurrentEntity, "DebitAmount", true, DataSourceUpdateMode.OnPropertyChanged, 0, "N", GlobalVariables.CurrentCultureInfo);
            txtCreditAmount.DataBindings.Add("Text", bsCurrentEntity, "CreditAmount", true, DataSourceUpdateMode.OnPropertyChanged, 0, "N", GlobalVariables.CurrentCultureInfo);

            bsAccountHeads.DataSource = typeof(AccountHeadComboItem);
            cmbAccount.DataSource = bsAccountHeads;
            cmbAccount.ValueMember = "AccountId"; cmbAccount.DisplayMember = "AccountNameWithCode";
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

        #endregion

    }
}
