using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CustomObjects;
using sCommonLib;
using sCommonLib.Messages;
using sCommonLib.Exceptions;

using System.Collections;

namespace QCash.MasterSetupForms.UserMenuForms
{
    public partial class frmAppUser : Form
    {

        #region Private Variables
        private AppUser CurrentEntity;
        #endregion

        #region Public Properties
        /// <summary>
        /// Returns Client that just have created.
        /// </summary>
        /*TODO: Uncomment needed
        public AppUser NewlyCreatedEntity
        {
            get { return CurrentEntity; }
        }
        */
        #endregion

        #region Constructors

        public frmAppUser()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.UserGroupBlueGreenIco;
            RedToolTip.OwnerDraw = true;
            RedToolTip.BackColor = System.Drawing.Color.Red;
            RedToolTip.ForeColor = System.Drawing.Color.White; //if option-A is used.
            AddEventHandlers(); AddDataBindings();
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

            RedToolTip.Draw += new DrawToolTipEventHandler(RedToolTipDraw);

        }

        #endregion

        #region Event Handlers

        #region FormLoading Event Handler

        private void FormLoadHandler(object sender, EventArgs e)
        {
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
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are currently not logged in. Please login first."));
                    return;
                }

                btnSave.Enabled = false;
                if (CurrentEntity.IsDirty)
                {
                    if (CurrentEntity.IsNew)
                    {
                        if (!GlobalVariables.currentUser.FindPermission("9"))
                        {
                            CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are not permitted to do this task. Contact your admin."));
                            return;
                        }
                    }
                    else
                    {
                        if (!GlobalVariables.currentUser.FindPermission("9"))
                        {
                            CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are not permitted to do this task. Contact your admin."));
                            return;
                        }
                    }

                    AppUser.SaveEntity(CurrentEntity);
                    CustomMessageBox.ShowSuccessMessage(new SuccessMessage("Success", "Success", "Information successfully saved."));
                    btnDelete.Visible = true; txtUserName.ReadOnly = true;
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


                if (!GlobalVariables.currentUser.FindPermission("9"))
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are not permitted to do this task. Contact your admin."));
                    btnDelete.Enabled = true; return;
                }
                else
                {
                    if (CustomMessageBox.ShowConfirmationMessage(new ConfirmationMessage("Delete Record", "Sure?", "Are you sure to delete this record?")) == DialogResult.Yes)
                    {
                        AppUser.DeleteEntity(CurrentEntity);
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
            pbEntityFolder.Image = Properties.Resources.EntityFolderOpenedVertically24;
        }

        private void EntityFolderMouseLeave(object sender, EventArgs e)
        {
            pbEntityFolder.Image = Properties.Resources.EntityFolderClosedVertically24;
        }

        private void OpenEntityFolder(object sender, EventArgs e)
        {
            frmAppUserList frm = new frmAppUserList();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CurrentEntity = AppUser.GetEntity(frm.SelectedEntityId, GlobalVariables.ConnectionString);
                bsCurrentEntity.DataSource = CurrentEntity;
                MastHead.Text = "Editing User"; btnDelete.Visible = true; txtUserName.ReadOnly = true;
            }
        }
        #endregion

        #endregion

        #region BindingSource

        private void AddNewCurrentEntity()
        {
            CurrentEntity = new AppUser(GlobalVariables.ConnectionString);
            bsCurrentEntity.DataSource = CurrentEntity;
            bsCurrentEntity.ResetBindings(false);
            txtUserName.ReadOnly = false;
            btnDelete.Visible = false;
            MastHead.Text = "Creating New User";
            txtUserName.Focus();
        }

        private void AddDataBindings()
        {
            bsCurrentEntity.DataSource = typeof(AppUser);
            txtUserName.DataBindings.Add("Text", bsCurrentEntity, "LogInName", false, DataSourceUpdateMode.OnPropertyChanged);
            txtUserPassword.DataBindings.Add("Text", bsCurrentEntity, "LogInPassword", false, DataSourceUpdateMode.OnPropertyChanged);
            txtFullName.DataBindings.Add("Text", bsCurrentEntity, "FullName", false, DataSourceUpdateMode.OnPropertyChanged);
            txtDesignation.DataBindings.Add("Text", bsCurrentEntity, "UserDesignation", false, DataSourceUpdateMode.OnPropertyChanged);
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
                case "txtUserName": control = txtUserName; break;
                case "txtUserPassword": control = txtUserPassword; break;
                case "txtFullName": control = txtFullName; break;
                case "txtDesignation": control = txtDesignation; break;
                default:
                    break;
            }
           // CustomMessageBox.ShowGeneralMessage(new GeneralMessage(EWC.TitleBarMessage, EWC.HeadLineMessage, EWC.ErrorDescription));
            RedToolTip.Show(EWC.ErrorDescription, control, 3000);
            //MyErrorProvider.SetError(control, EWC.ErrorDescription); 
            control.Focus();
        }
        #endregion

        #endregion

    }
}
