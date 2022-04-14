using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CustomObjects;
using sCommonLib;
using sCommonLib.Messages;
using sCommonLib.Exceptions;
using System.Collections;

namespace QCash.MasterSetupForms
{
    public partial class frmCompanyInfo : Form
    {
        private CompanyInfo mCompanyInfo;
        private Hashtable mHashTable;

        public frmCompanyInfo()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.OfficeTreeIco16;
            bsCurrentEntity.DataSource = typeof(CompanyInfo);

            txtCompanyName.DataBindings.Add("Text", bsCurrentEntity, "CompanyName");
            txtAddressLineOne.DataBindings.Add("Text", bsCurrentEntity, "AddressLineOne");
            txtAddressLineTwo.DataBindings.Add("Text", bsCurrentEntity, "AddressLineTwo");
            bsCurrentEntity.AddingNew += OnAddingNew;
        }

        #region HashtableMethods

        private void CreateHashTable()
        {
            mHashTable = new Hashtable();
            mHashTable.Add(txtCompanyName, "Enter company name.");
        }

        private bool ValidateInputFields()
        {
            bool IsValidationOk = true;

            string ErrorMessage = string.Empty;
            if (mHashTable.Count > 0)
            {
                IsValidationOk = false;
                MyErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                foreach (DictionaryEntry Item in mHashTable)
                {
                    MyErrorProvider.SetError((Control)Item.Key, Item.Value.ToString());
                    ErrorMessage += Item.Value.ToString();
                    ErrorMessage += Environment.NewLine;
                }

                CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Company Setup", "Invalid Information", ErrorMessage));
            }

            return IsValidationOk;
        }

        private void UpdateHashTable(Control ControlName, string ErrorMessage)
        {
            if (mHashTable.ContainsKey(ControlName))
            {
                mHashTable[ControlName] = ErrorMessage;
            }
            else
            {
                mHashTable.Add(ControlName, ErrorMessage);
            }
        }

        #endregion

        private void OnAddingNew(object sender, AddingNewEventArgs e)
        {
            mCompanyInfo = new CompanyInfo(GlobalVariables.ConnectionString);
            e.NewObject = mCompanyInfo;
            CreateHashTable();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputFields())
                {
                    return;
                }

                if (mCompanyInfo.IsDirty)
                {
                    CompanyInfo.SaveEntity(mCompanyInfo);
                }

                CustomMessageBox.ShowSuccessMessage(new SuccessMessage("Company Info", "Success", "Company Information successfully saved."));
            }
            catch (UserException UEx)
            {
                CustomMessageBox.ShowUserException(UEx);

            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
        }

        private void txtCompanyName_Validating(object sender, CancelEventArgs e)
        {
            MyErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
            string CompanyName = txtCompanyName.Text.Trim();
            string ErrMsg = string.Empty;
            if (string.IsNullOrEmpty(CompanyName))
            {
                ErrMsg = "Enter Company Name.";
                MyErrorProvider.SetError(txtCompanyName, ErrMsg);
                UpdateHashTable(txtCompanyName, ErrMsg);
                return;
            }
            else if (CompanyName.Length > 255)
            {
                ErrMsg = "Company Name is too long. It can not be more than 255 characters.";
                MyErrorProvider.SetError(txtCompanyName, ErrMsg);
                UpdateHashTable(txtCompanyName, ErrMsg);
                return;
            }
            else
            {
                MyErrorProvider.SetError(txtCompanyName, "");
                mHashTable.Remove(txtCompanyName);
            }
        }

        private void frmCompanyInfo_Load(object sender, EventArgs e)
        {
            try
            {
                mCompanyInfo = CompanyInfo.GetEntity(1, GlobalVariables.ConnectionString);

                if (mCompanyInfo == null)
                {
                    bsCurrentEntity.AddNew();
                }
                else
                {
                    mCompanyInfo.SetConnectionString(GlobalVariables.ConnectionString);
                    bsCurrentEntity.DataSource = mCompanyInfo;
                    mHashTable = new Hashtable();
                }
            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
        }


    }
}
