using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using InputDialogBox;
using System.IO;
using Microsoft.Reporting.WinForms;

using CustomControls;
using CustomObjects;
using sCommonLib;
using sCommonLib.Messages;
using sCommonLib.Exceptions;

using System.Collections;

namespace QCash.VoucherMenuForms
{
    public partial class frmVoucher : Form
    {

        #region Private Variables
            private Boolean DataBindingAdded = false;
            private Boolean DataBindingRemoved = true;
            private Voucher CurrentEntity;
            private Int32 pVoucherTypeId;
            private Int32? pCurrentEntityId = null;
            private Int32? CashbookAccountId;
            private String LocalOperatingYear;
            private string LocalConnectionString;

            private CommaSeparatedNumberToolTip AmountToolTip;
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

        public frmVoucher(Int32 voucherTypeId,Int32? CurrentEntityId)
        {
            InitializeComponent();
            pVoucherTypeId = voucherTypeId;
            pCurrentEntityId = CurrentEntityId;

            switch (pVoucherTypeId)
            {
                case 1: //"Debit voucher"
                    this.Icon = Properties.Resources.CashPaymentIco32;
                    MastHead.Values.Image = Properties.Resources.CashPayment32;
                    MastHead.Text = "Add New Debit Voucher";
                    break;

                case 2: // "Credit voucher"
                    this.Icon = Properties.Resources.CashReceiveIco32;
                    MastHead.Values.Image = Properties.Resources.CashReceive32;
                    MastHead.Text = "Add New Credit Voucher";
                    break;

                case 3: // "Credit voucher"
                    this.Icon = Properties.Resources.JrVoucherIco;
                    MastHead.Values.Image = Properties.Resources.JrVoucher32;
                    MastHead.Text = "Add New Journal Voucher";
                    break;

                default:
                    break;
            }

            AmountToolTip = new CommaSeparatedNumberToolTip(260, 40);
            AmountToolTip.AutoPopDelay = 15000;
            AmountToolTip.InitialDelay = 15000;
            AmountToolTip.ReshowDelay = 15500; AmountToolTip.AutomaticDelay = 15000;

            RedToolTip.OwnerDraw = true;
            RedToolTip.BackColor = System.Drawing.Color.Red;
            RedToolTip.ForeColor = System.Drawing.Color.White; //if option-A is used.
            AddEventHandlers(); 
         
            btnDelete.Visible = false;
        }

        #endregion

        #region Add Event Handlers

        private void AddEventHandlers()
        {

            this.Load += FormLoadHandler;
            //<----------------------------------------------------->
            this.bgwPrimaryWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PrimaryWork);
            this.bgwPrimaryWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.PrimaryProgress);
            this.bgwPrimaryWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.PrimaryWorkCompleted);
            //<----------------------------------------------------->
            txtVoucherId.Enter += EnteredIntoVoucherIdTextBox;
            txtVoucherId.TextChanged += VoucherIdTextBoxChanged;
            txtVoucherId.KeyDown += KeyDownedOnVoucherIdTextBox;
            txtVoucherId.Leave += LeftFromVoucherIdTextBox;
            //<----------------------------------------------------->
            pbSearch.MouseMove += MouseMovedToSearchIcon;
            pbSearch.MouseLeave += MouseLeftFromSearchIcon;
            pbSearch.Click += ClickedOnSearchIcon;
            //<----------------------------------------------------->
            pbFirstRecord.MouseMove += MouseMovedToFirstRecord;
            pbFirstRecord.MouseLeave += MouseLeftFromFirstRecord;
            pbFirstRecord.Click += ClickedOnFirstRecord;
            //<----------------------------------------------------->
            pbPreviousRecord.MouseMove += MouseMovedToPreviousRecord;
            pbPreviousRecord.MouseLeave += MouseLeftFromPreviousRecord;
            pbPreviousRecord.Click += ClickedOnPreviousRecord;
            //<----------------------------------------------------->
            pbNextRecord.MouseMove += MouseMovedToNextRecord;
            pbNextRecord.Click += ClickedOnNextRecord;
            pbNextRecord.MouseLeave += MouseLeftFromNextRecord;
            //<----------------------------------------------------->
            pbLastRecord.MouseMove += MouseMovedToLastRecord;
            pbLastRecord.Click += ClickedOnLastRecord;
            pbLastRecord.MouseLeave += MouseLeftFromLastRecord;
            //<----------------------------------------------------->
            pbPrint.MouseMove += MouseMovedToPrintIcon;
            pbPrint.Click += PrintData;//ClickedOnPrintIcon;
            pbPrint.MouseLeave += MouseLeftFromPrintIcon;
            //<----------------------------------------------------->
            txtEntryDate.Enter += EnteredIntoDateTextBox;
            txtEntryDate.KeyDown += EntryDateKeyDownHandler;
            txtEntryDate.Leave += LeftFromDateTextBox;
            mcDate.DateSelected += DateSelected;
            //<----------------------------------------------------->
            txtAmount.Enter += EnteredIntoAmountTextBox;
            txtAmount.KeyUp += AmountTextChanged; //Catch number & letters keys
            txtAmount.KeyDown += KeyDownedOnAmountTextBox; //Catch Enter, Tab & Backspace keys
            txtAmount.Leave += LeftFromAmountTextBox;
            //<----------------------------------------------------->
            cmbDebitAccount.Enter += EnteredIntoDebitAccount;
            pbAddDebitAccount.Click += AddDebitAccount;
            cmbDebitAccount.KeyDown += KeyDownedOnDebitAccount;
            cmbDebitAccount.Leave += LeftFromDebitAccount;
            //<----------------------------------------------------->
            cmbCreditAccount.Enter += EnteredIntoCreditAccount;
            pbAddCreditAccount.Click += AddCreditAccount;
            cmbCreditAccount.KeyDown += KeyDownedOnCreditAccount;
            cmbCreditAccount.Leave += LeftFromCreditAccount;
            //<----------------------------------------------------->
            txtNarration.Enter += TextBoxEnterEventHandler;
            txtNarration.KeyDown += NarrationKeyDownHandler;
            txtNarration.Leave += TextboxLeaveEventHandler;
            //<----------------------------------------------------->
            btnSave.Click += SaveEntity;
            btnNewEntity.Click += NewEntity;
            btnDelete.Click += DeleteEntity;
            btnClose.Click += CloseForm;
            //<----------------------------------------------------->
            pbEntityFolder.MouseEnter += EntityFolderMouseEnter;
            pbEntityFolder.MouseLeave += EntityFolderMouseLeave;
            pbEntityFolder.Click += OpenEntityFolder;
            //<----------------------------------------------------->
            RedToolTip.Draw += new DrawToolTipEventHandler(RedToolTipDraw);
            //<----------------------------------------------------->
            txtOperatingYear.Enter += TextBoxEnterEventHandler;
            txtOperatingYear.KeyDown += OperatingYearKeyDownHandler;
            txtOperatingYear.Leave += TextboxLeaveEventHandler;
        }

        #endregion

        #region Event Handlers

        #region FormLoading Event Handler

        private void FormLoadHandler(object sender, EventArgs e)
        {
            LocalOperatingYear = GlobalVariables.OperatingYear;
            LocalConnectionString = GlobalVariables.ConnectionString; //Project default connection string
            txtOperatingYear.Text = LocalOperatingYear;

            StartPrimaryWorker();
        }

        #endregion

        #region BackGroundWorker Event Handlers

        private void PrimaryWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                List<AccountHeadComboItem> DebitAccountHeadList = AccountHeadComboItem.GetComboList(LocalConnectionString);

                object[] objResult = new object[4];

                //--> Check if whether any account head exists in database
                if (DebitAccountHeadList.Count > 1) // Because there is always a blank account head
                {//--> if account head exists
                    objResult[0] = true;
                    List<AccountHeadComboItem> CreditAccountHeadList = new List<AccountHeadComboItem>(DebitAccountHeadList);


                    objResult[1] = DebitAccountHeadList;
                    objResult[2] = CreditAccountHeadList;

                    Object objCashBookAccount = AccountHead.GetCashBookAccountId(LocalConnectionString);

                    if (objCashBookAccount == null)
                    {
                        objResult[3] = false;
                        CashbookAccountId = null;
                    }
                    else
                    {
                        objResult[3] = true;
                        CashbookAccountId = (Int32)objCashBookAccount;
                    }


                }//<-- if account head exists
                else
                {//--> if no account head exists
                    objResult[0] = false; objResult[1] = null; objResult[2] = null; objResult[3] = false;
                }//<-- if no account head exists
                //<-- Check if whether any account head exists in database


                e.Result = objResult;
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
                    if (e.Result != null)
                    {
                        object[] Result = (object[])e.Result;
                        bool IsAnyAccountHeadFound = (bool)Result[0];
                        List<AccountHeadComboItem> DebitAccountHeadList = (List<AccountHeadComboItem>)Result[1];
                        List<AccountHeadComboItem> CreditAccountHeadList = (List<AccountHeadComboItem>)Result[2];
                        bool IsCashBookAccountFound = (bool)Result[3];

                        if (!IsAnyAccountHeadFound)
                        {
                            MessageBox.Show("No Account Head found.");
                            btnSave.Enabled = false; btnNewEntity.Enabled = false; btnDelete.Enabled = false;
                            return;
                        }
                        else
                        {
                            if (!IsCashBookAccountFound)
                            {
                                MessageBox.Show("Default Cashbook Account not found.");
                                btnSave.Enabled = false; btnNewEntity.Enabled = false; btnDelete.Enabled = false;
                                return;
                            }
                            else
                            {
                                cmbDebitAccount.DataSource = DebitAccountHeadList;
                                cmbDebitAccount.ValueMember = "AccountId";
                                cmbDebitAccount.DisplayMember = "AccountNameWithCode";

                                cmbCreditAccount.DataSource = CreditAccountHeadList;
                                cmbCreditAccount.ValueMember = "AccountId";
                                cmbCreditAccount.DisplayMember = "AccountNameWithCode";


                                if (pCurrentEntityId == null)
                                {
                                    AddNewCurrentEntity();
                                    //if (GlobalVariables.OperatingYear.Equals(LocalDbName))
                                    //{
                                    //    btnSave.Enabled = true; btnNewEntity.Enabled = true; btnDelete.Enabled = true;
                                    //}
                                    //else
                                    //{
                                    //    btnSave.Enabled = false; btnNewEntity.Enabled = false; btnDelete.Enabled = false;
                                    //}
                                }
                                else
                                {
                                    Voucher voucher = Voucher.GetEntity((int)pCurrentEntityId, pVoucherTypeId, LocalConnectionString);

                                    SetToCurrentEntity(voucher);
                                    txtVoucherId.ReadOnly = true; btnSave.Enabled = false; btnDelete.Visible = true; ShowNavigationAndPrintButton(true); pbSearch.Visible = false;
                                    txtVoucherId.Focus(); txtVoucherId.Select(0, txtVoucherId.Text.Trim().Length);

                                 }

                                GetDebitAccountBalance(); GetCreditAccountBalance();

                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("e.Result found empty.");
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

        #region Voucher Id Related Event Handlers

        //<-------------------------------------------------------------------->

        private void EnteredIntoVoucherIdTextBox(object sender, EventArgs e)
        {
            ComponentFactory.Krypton.Toolkit.KryptonTextBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            control.StateCommon.Back.Color1 = Color.White;
            pbSearch.BackColor = Color.White;
            pbFirstRecord.BackColor = Color.White;
            pbPreviousRecord.BackColor = Color.White;
            pbNextRecord.BackColor = Color.White;
            pbLastRecord.BackColor = Color.White;
            pbPrint.BackColor = Color.White;

            txtVoucherId.Select(0, txtVoucherId.Text.Length);
        }

        private void VoucherIdTextBoxChanged(object sender, EventArgs e)
        {

            ShowNavigationAndPrintButton(false);

            if (txtVoucherId.Text.Trim().Length > 0)
            {
                pbSearch.Visible = true;
            }
            else
            {
                pbSearch.Visible = false;
            }
        }

        private void LeftFromVoucherIdTextBox(object sender, EventArgs e)
        {
            if (this.ActiveControl.Name != "pbSearch" || this.ActiveControl.Name != "pbFirstRecord" || this.ActiveControl.Name != "pbPreviousRecord" || this.ActiveControl.Name != "pbNextRecord" || this.ActiveControl.Name != "pbLastRecord")
            {
                ComponentFactory.Krypton.Toolkit.KryptonTextBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
                control.StateCommon.Back.Color1 = SystemColors.GradientActiveCaption;
                pbSearch.BackColor = SystemColors.GradientActiveCaption;
                pbFirstRecord.BackColor = SystemColors.GradientActiveCaption;
                pbPreviousRecord.BackColor = SystemColors.GradientActiveCaption;
                pbNextRecord.BackColor = SystemColors.GradientActiveCaption;
                pbLastRecord.BackColor = SystemColors.GradientActiveCaption;
                pbPrint.BackColor = SystemColors.GradientActiveCaption;

                pbSearch.Visible = false;
                ShowNavigationAndPrintButton(false);
            }

            if (CurrentEntity != null)
            {
                txtVoucherId.ReadOnly = true;
            }
        }

        private void KeyDownedOnVoucherIdTextBox(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;

                    //--> Check whether txtVoucherId read only
                    if (txtVoucherId.ReadOnly == true)
                    { //-->if ready only
                        CurrentEntity = null;
                        bsCurrentEntity.Clear();
                        RemoveDataBindings();
                        txtVoucherId.ReadOnly = false;
                        txtVoucherId.Clear();
                        txtEntryDate.Clear();
                        cmbDebitAccount.SelectedIndex = 0;
                        cmbCreditAccount.SelectedIndex = 0;
                        txtAmount.Clear();
                        txtAmountInWords.Clear();
                        txtNarration.Clear();
                        btnSave.Enabled = false; btnDelete.Visible = false;
                        ShowNavigationAndPrintButton(false);
                        pbPrint.Visible = false;

                    } //<--if ready only
                    else
                    { //--> if not ready only
                        String strVoucherNo = txtVoucherId.Text.Trim();

                        if (String.IsNullOrEmpty(strVoucherNo))
                        {
                            RedToolTip.Show("Enter a voucher number.", VoucherLabel, 4000); Console.Beep(1000, 400);
                            txtVoucherId.Focus();
                            txtVoucherId.Select(0, txtVoucherId.Text.Length);
                            return;
                        }

                        Int32 voucherNo;
                        Boolean IsVoucherNoValid = Int32.TryParse(strVoucherNo, out voucherNo);


                        if (!IsVoucherNoValid)
                        {
                            RedToolTip.Show("Enter numeric value only.", VoucherLabel, 4000); Console.Beep(1000, 400);
                            txtVoucherId.Focus();
                            txtVoucherId.Select(0, txtVoucherId.Text.Length);
                            return;
                        }

                        Voucher voucher = Voucher.GetEntity((Int32)voucherNo, pVoucherTypeId, LocalConnectionString);

                        if (voucher == null)
                        {
                            AddNewCurrentEntity();
                            CurrentEntity.SetVoucherId(voucherNo); bsCurrentEntity.ResetBindings(false);
                            txtEntryDate.Focus(); txtEntryDate.Select(0, txtEntryDate.Text.Trim().Length);
                            return;
                        }
                        else
                        {
                            SetToCurrentEntity(voucher);
                            txtVoucherId.ReadOnly = true; btnSave.Enabled = false; btnDelete.Visible = true; ShowNavigationAndPrintButton(true); pbSearch.Visible = false;
                            txtVoucherId.Focus(); txtVoucherId.Select(0, txtVoucherId.Text.Trim().Length);
                        }

                    }  //<-- if not ready only

                    //<-- Check whether txtVoucherId read only           

                }
            }
            catch (ExceptionWithoutControl exceptionWithoutControl)
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage(exceptionWithoutControl.TitleBarMessage, exceptionWithoutControl.HeadLineMessage, exceptionWithoutControl.ErrorDescription));
            }
            catch (ExceptionWithControl exceptionWithControl)
            {
                HandleExceptionWithControl(exceptionWithControl);
            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
        }


        //<-------------------------------------------------------------------->

        private void MouseMovedToSearchIcon(object sender, MouseEventArgs e)
        {
            pbSearch.Image = Properties.Resources.SearchGreenHandle32;
        }

        private void MouseLeftFromSearchIcon(object sender, EventArgs e)
        {
            pbSearch.Image = Properties.Resources.SearchGreenHandle16;
        }

        private void ClickedOnSearchIcon(object sender, EventArgs e)
        {
            try
            {

                //--> Check whether txtVoucherId read only
                if (txtVoucherId.ReadOnly == true)
                { //-->if ready only
                    CurrentEntity = null;
                    bsCurrentEntity.Clear();
                    RemoveDataBindings();
                    txtVoucherId.ReadOnly = false;
                    txtVoucherId.Clear();
                    txtEntryDate.Clear();
                    cmbDebitAccount.SelectedIndex = 0;
                    cmbCreditAccount.SelectedIndex = 0;
                    txtAmount.Clear();
                    txtAmountInWords.Clear();
                    txtNarration.Clear();
                    btnSave.Enabled = false; btnDelete.Visible = false;
                    ShowNavigationAndPrintButton(false);
                    pbPrint.Visible = false;

                } //<--if ready only
                else
                { //--> if not ready only
                    String strVoucherNo = txtVoucherId.Text.Trim();

                    if (String.IsNullOrEmpty(strVoucherNo))
                    {
                        RedToolTip.Show("Enter a voucher number.", VoucherLabel, 4000); Console.Beep(1000, 400);
                        txtVoucherId.Focus();
                        txtVoucherId.Select(0, txtVoucherId.Text.Length);
                        return;
                    }

                    Int32 voucherNo;
                    Boolean IsVoucherNoValid = Int32.TryParse(strVoucherNo, out voucherNo);


                    if (!IsVoucherNoValid)
                    {
                        RedToolTip.Show("Enter numeric value only.", VoucherLabel, 4000); Console.Beep(1000, 400);
                        txtVoucherId.Focus();
                        txtVoucherId.Select(0, txtVoucherId.Text.Length);
                        return;
                    }

                    Voucher voucher = Voucher.GetEntity((Int32)voucherNo, pVoucherTypeId, LocalConnectionString);

                    if (voucher == null)
                    {
                        RedToolTip.Show("Not found.", VoucherLabel, 4000); Console.Beep(1000, 400);
                        txtVoucherId.Focus();
                        txtVoucherId.Select(0, txtVoucherId.Text.Length);
                        return;
                    }
                    else
                    {
                        SetToCurrentEntity(voucher);
                        txtVoucherId.ReadOnly = true; btnSave.Enabled = false; btnDelete.Visible = true; ShowNavigationAndPrintButton(true); pbSearch.Visible = false;
                        txtVoucherId.Focus(); txtVoucherId.Select(0, txtVoucherId.Text.Trim().Length);
                    }

                }  //<-- if not ready only

                //<-- Check whether txtVoucherId read only           


            }
            catch (ExceptionWithoutControl exceptionWithoutControl)
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage(exceptionWithoutControl.TitleBarMessage, exceptionWithoutControl.HeadLineMessage, exceptionWithoutControl.ErrorDescription));
            }
            catch (ExceptionWithControl exceptionWithControl)
            {
                HandleExceptionWithControl(exceptionWithControl);
            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
        }

        //<-------------------------------------------------------------------->

        private void MouseMovedToFirstRecord(object sender, MouseEventArgs e)
        {
            pbFirstRecord.Image = Properties.Resources.WhiteArrowFirstst32;
        }

        private void MouseLeftFromFirstRecord(object sender, EventArgs e)
        {
            pbFirstRecord.Image = Properties.Resources.WhiteArrowFirst16;
        }

        private void ClickedOnFirstRecord(object sender, EventArgs e)
        {
            try
            {
                Voucher fristVoucher = Voucher.GetFirstEntity(pVoucherTypeId, LocalConnectionString);

                if (fristVoucher == null)
                {
                    RedToolTip.Show("Not found.", VoucherLabel, 4000); Console.Beep(1000, 400);
                    txtVoucherId.Focus();
                    txtVoucherId.Select(0, txtVoucherId.Text.Length);
                    return;
                }
                else
                {
                    SetToCurrentEntity(fristVoucher);
                    txtVoucherId.ReadOnly = true; btnSave.Enabled = false; btnDelete.Visible = true; ShowNavigationAndPrintButton(true); pbSearch.Visible = false;
                    txtVoucherId.Focus(); txtVoucherId.Select(0, txtVoucherId.Text.Trim().Length);
                }

            }
            catch (Exception Ex) { CustomMessageBox.ShowSystemException(Ex); }
        }

        //<-------------------------------------------------------------------->

        private void MouseMovedToPreviousRecord(object sender, MouseEventArgs e)
        {
            pbPreviousRecord.Image = Properties.Resources.WhiteArrowPrev32;
        }

        private void MouseLeftFromPreviousRecord(object sender, EventArgs e)
        {
            pbPreviousRecord.Image = Properties.Resources.WhiteArrowPrev16;
        }

        private void ClickedOnPreviousRecord(object sender, EventArgs e)
        {
            try
            {
                if (CurrentEntity == null)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Search Voucher", "No Record.", "No current voucher."));
                    bsCurrentEntity.Clear(); txtVoucherId.Focus();
                    txtVoucherId.Select(0, txtVoucherId.Text.Length); return;
                }

                Int32 CurrentVoucherId = CurrentEntity.VoucherId;

                //If current voucher id=1, don't go to search prev record.
                if (CurrentVoucherId == 1)
                {
                    RedToolTip.Show("No previous record.", VoucherLabel, 4000); Console.Beep(1000, 400);
                    txtVoucherId.Focus();
                    txtVoucherId.Select(0, txtVoucherId.Text.Length);
                    return;
                }

                Voucher PrevEntity = Voucher.GetPreviousEntity(CurrentVoucherId, pVoucherTypeId, GlobalVariables.ConnectionString);
                if (PrevEntity == null)
                {
                    RedToolTip.Show("No previous record.", VoucherLabel, 4000); Console.Beep(1000, 400);
                    txtVoucherId.Focus();
                    txtVoucherId.Select(0, txtVoucherId.Text.Length);
                }
                else
                {
                    SetToCurrentEntity(PrevEntity);
                    txtVoucherId.ReadOnly = true; btnSave.Enabled = false; btnDelete.Visible = true; ShowNavigationAndPrintButton(true); pbSearch.Visible = false;
                    txtVoucherId.Focus(); txtVoucherId.Select(0, txtVoucherId.Text.Trim().Length);
                }
            }
            catch (Exception Ex) { CustomMessageBox.ShowSystemException(Ex); }
        }
        //<-------------------------------------------------------------------->
        private void MouseMovedToNextRecord(object sender, MouseEventArgs e)
        {
            pbNextRecord.Image = Properties.Resources.WhiteArrowNext32;
        }

        private void ClickedOnNextRecord(object sender, EventArgs e)
        {
            try
            {

                if (CurrentEntity == null)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Search Voucher", "No Record.", "No current voucher."));
                    bsCurrentEntity.Clear(); txtVoucherId.Focus();
                    txtVoucherId.Select(0, txtVoucherId.Text.Length);
                }

                else
                {
                    Int32 CurrentVoucherId = CurrentEntity.VoucherId;

                    Voucher NextEntity = Voucher.GetNextEntity(CurrentVoucherId, pVoucherTypeId, GlobalVariables.ConnectionString);
                    if (NextEntity == null)
                    {
                        RedToolTip.Show("This is last voucher.", VoucherLabel, 4000); Console.Beep(1000, 400);
                        txtVoucherId.Focus();
                        txtVoucherId.Select(0, txtVoucherId.Text.Length);
                    }
                    else
                    {
                        SetToCurrentEntity(NextEntity);
                        txtVoucherId.ReadOnly = true; btnSave.Enabled = false; btnDelete.Visible = true; ShowNavigationAndPrintButton(true); pbSearch.Visible = false;
                        txtVoucherId.Focus(); txtVoucherId.Select(0, txtVoucherId.Text.Trim().Length);           
                    }
                }

            }
            catch (Exception Ex) { CustomMessageBox.ShowSystemException(Ex); }
        }

        private void MouseLeftFromNextRecord(object sender, EventArgs e)
        {
            pbNextRecord.Image = Properties.Resources.WhiteArrowNext16;
        }

        //<-------------------------------------------------------------------->

        private void MouseMovedToLastRecord(object sender, MouseEventArgs e)
        {
            pbLastRecord.Image = Properties.Resources.WhiteArrowLast32;
        }

        private void ClickedOnLastRecord(object sender, EventArgs e)
        {
            try
            {
                Voucher LastVoucher = Voucher.GetLastEntity(pVoucherTypeId, LocalConnectionString);

                if (LastVoucher == null)
                {
                    RedToolTip.Show("Not found.", VoucherLabel, 4000); Console.Beep(1000, 400);
                    txtVoucherId.Focus();
                    txtVoucherId.Select(0, txtVoucherId.Text.Length);
                    return;
                }
                else
                {
                    SetToCurrentEntity(LastVoucher);
                    txtVoucherId.ReadOnly = true; btnSave.Enabled = false; btnDelete.Visible = true; ShowNavigationAndPrintButton(true); pbSearch.Visible = false;
                    txtVoucherId.Focus(); txtVoucherId.Select(0, txtVoucherId.Text.Trim().Length);  
                }

            }
            catch (Exception Ex) { CustomMessageBox.ShowSystemException(Ex); }
        }

        private void MouseLeftFromLastRecord(object sender, EventArgs e)
        {
            pbLastRecord.Image = Properties.Resources.WhiteArrowLast16;
        }

        //<-------------------------------------------------------------------->

        private void MouseMovedToPrintIcon(object sender, MouseEventArgs e)
        {
            pbPrint.Image = Properties.Resources.PrinterGreen32;
        }

        private void ClickedOnPrintIcon(object sender, EventArgs e)
        {

        }

        private void MouseLeftFromPrintIcon(object sender, EventArgs e)
        {
            //lblPrintCaption.Visible = false;
            pbPrint.Image = Properties.Resources.PrinterGreen16;
        }

        #endregion

        #region Date Related Controls Event Handlers

        private void EnteredIntoDateTextBox(object sender, EventArgs e)
        {
            txtEntryDate.StateCommon.Back.Color1 = Color.White;
            // pbCalender.BackColor = Color.White;
            mcDate.Visible = true;
            // pbCalender.Visible = true;
        }

        private void DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = mcDate.SelectionStart;
            txtEntryDate.Text = selectedDate.ToString("d", GlobalVariables.CurrentCultureInfo);
            txtEntryDate.Focus();
            txtEntryDate.Select(0, txtEntryDate.Text.Length);
            // mcDate.Visible = false;
        }

        private void EntryDateKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (String.IsNullOrEmpty(txtEntryDate.Text.Trim()))
                {
                    DateTime currentDate = DateTime.Today.Date;
                    txtEntryDate.Text = currentDate.ToString("d", GlobalVariables.CurrentCultureInfo);
                }
                else
                {
                    DateTime entryDate;
                    bool isDate = DateTime.TryParseExact(txtEntryDate.Text.Trim(), GlobalVariables.InputDateFormatsAllowed, GlobalVariables.CurrentCultureInfo, DateTimeStyles.AllowLeadingWhite, out entryDate);
                    if (!isDate)
                    {
                        Console.Beep(1000, 400);
                        RedToolTip.Show("Invalid date", txtEntryDate, 2000);
                        txtEntryDate.Focus(); txtEntryDate.Select(0, txtEntryDate.Text.Trim().Length);
                        return;
                    }
                }



                switch (pVoucherTypeId)
                {
                    case 1: //"Debit voucher"
                    case 3: // "Journal Voucher"
                        cmbDebitAccount.Focus();
                        break;

                    case 2: // "Credit voucher"
                        cmbCreditAccount.Focus();
                        break;

                    default:
                        break;
                }
            }
        }

        private void LeftFromDateTextBox(object sender, EventArgs e)
        {
            if (this.ActiveControl.Name != "mcDate")
            {
                ComponentFactory.Krypton.Toolkit.KryptonTextBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
                control.StateCommon.Back.Color1 = SystemColors.GradientActiveCaption;
                //pbCalender.BackColor = SystemColors.GradientActiveCaption;

                DateTime selectedDate;
                Boolean isValid = DateTime.TryParseExact(txtEntryDate.Text.Trim(), GlobalVariables.InputDateFormatsAllowed,
                    GlobalVariables.CurrentCultureInfo, DateTimeStyles.AllowLeadingWhite, out selectedDate);
                if (!isValid)
                {
                    MessageBox.Show("hi");
                }

                mcDate.Visible = false;
            }


        }

        private void MouseMovedToCalenderIcon(object sender, MouseEventArgs e)
        {
            //pbCalender.Image = Properties.Resources.CalendarBluePng32;

        }

        private void MouseLeftFromCalenderIcon(object sender, EventArgs e)
        {
            //pbCalender.Image = Properties.Resources.CalendarBluePng16;
        }

        private void ClickedOnCalenderIcon(object sender, EventArgs e)
        {
            //   mcDate.Visible = true;
            //    mcDate.Focus();
        }
        #endregion

        #region ComboBoxes

        private void EnteredIntoDebitAccount(object sender, EventArgs e)
        {
            ComponentFactory.Krypton.Toolkit.KryptonComboBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonComboBox;
            control.StateCommon.ComboBox.Back.Color1 = Color.White;
            pbAddDebitAccount.Visible = true;
        }       

        private void KeyDownedOnDebitAccount(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (CurrentEntity.DebitAccountId < 5001)
                {
                    Console.Beep(1000, 400);
                    RedToolTip.Show("Select Debit Account.", cmbDebitAccount, 2000);
                    cmbDebitAccount.Focus();
                    return;
                }

                switch (pVoucherTypeId)
                {
                    case 1: //"Debit voucher"

                        //if (CurrentEntity.DebitAccountId < 5001)
                        //{
                        //    Console.Beep(1000, 400);
                        //    RedToolTip.Show("Select Debit Account.", cmbDebitAccount, 2000);
                        //    cmbDebitAccount.Focus();
                        //    return;
                        //}
                        txtAmount.Focus();
                        txtAmount.Select(0, txtAmount.Text.Trim().Length);
                        break;

                    case 2: // "Credit voucher"
                        cmbCreditAccount.Focus();
                        break;
                    case 3: // "Journal Voucher"
                        cmbCreditAccount.Focus();
                        break;
                    default:
                        break;
                }
            }
        }

        private void LeftFromDebitAccount(object sender, EventArgs e)
        {
            if (this.ActiveControl.Name != "pbAddDebitAccount")
            {
                ComponentFactory.Krypton.Toolkit.KryptonComboBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonComboBox;
                control.StateCommon.ComboBox.Back.Color1 = SystemColors.GradientActiveCaption;
                pbAddDebitAccount.Visible = false;
            }

            GetDebitAccountBalance();
 
        }

        private void GetDebitAccountBalance()
        {
            try
            {
                Int32 accountId = Convert.ToInt32(cmbDebitAccount.SelectedValue);
                using (OleDbConnection Connection = new OleDbConnection(LocalConnectionString))
                {
                    Connection.Open();
                    String sql = "Select sum(DebitAmount) as TotalDebit, sum(CreditAmount) as TotalCredit from tblLedger where AccountId=" + accountId + "  group by AccountId";

                    DataTable dt = new DataTable();
                    using (OleDbDataAdapter da = new OleDbDataAdapter(sql, Connection))
                    {
                        da.Fill(dt);
                    }

                    Connection.Close();

                    if (dt.Rows.Count > 0)
                    {
                        Object debitTotal = dt.Rows[0][0];
                        Object creditTotal = dt.Rows[0][1];

                        Decimal TotalDebit = (debitTotal == DBNull.Value || debitTotal == null) ? 0 : Convert.ToDecimal(debitTotal);
                        Decimal TotalCredit = (creditTotal == DBNull.Value || creditTotal == null) ? 0 : Convert.ToDecimal(creditTotal);

                        if (TotalDebit > TotalCredit)
                        {
                            Decimal difference=TotalDebit - TotalCredit;
                            lblDebitAccountBalance.Text = "Dr. Balance- " + difference.ToString("N",GlobalVariables.CurrentCultureInfo);
                        }
                        else
                        {
                            Decimal difference = TotalCredit - TotalDebit;
                            lblDebitAccountBalance.Text = "Cr. Balance- " + difference.ToString("N", GlobalVariables.CurrentCultureInfo);
                        }
                    }
                    else
                    {
                        lblDebitAccountBalance.Text = "Balance - 0.00";
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void EnteredIntoCreditAccount(object sender, EventArgs e)
        {
            ComponentFactory.Krypton.Toolkit.KryptonComboBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonComboBox;
            control.StateCommon.ComboBox.Back.Color1 = Color.White;
            pbAddCreditAccount.Visible = true;
        }

        private void LeftFromCreditAccount(object sender, EventArgs e)
        {
            if (this.ActiveControl.Name != "pbAddCreditAccount")
            {
                ComponentFactory.Krypton.Toolkit.KryptonComboBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonComboBox;
                control.StateCommon.ComboBox.Back.Color1 = SystemColors.GradientActiveCaption;
                pbAddCreditAccount.Visible = false;
            }

            GetCreditAccountBalance();

        }

        private void GetCreditAccountBalance()
        {
            try
            {
                Int32 accountId = Convert.ToInt32(cmbCreditAccount.SelectedValue);
                using (OleDbConnection Connection = new OleDbConnection(LocalConnectionString))
                {
                    Connection.Open();
                    String sql = "Select sum(DebitAmount) as TotalDebit, sum(CreditAmount) as TotalCredit from tblLedger where AccountId=" + accountId + "  group by AccountId";

                    DataTable dt = new DataTable();
                    using (OleDbDataAdapter da = new OleDbDataAdapter(sql, Connection))
                    {
                        da.Fill(dt);
                    }

                    Connection.Close();

                    if (dt.Rows.Count > 0)
                    {
                        Object debitTotal = dt.Rows[0][0];
                        Object creditTotal = dt.Rows[0][1];

                        Decimal TotalDebit = (debitTotal == DBNull.Value || debitTotal == null) ? 0 : Convert.ToDecimal(debitTotal);
                        Decimal TotalCredit = (creditTotal == DBNull.Value || creditTotal == null) ? 0 : Convert.ToDecimal(creditTotal);

                        if (TotalDebit > TotalCredit)
                        {
                            Decimal difference = TotalDebit - TotalCredit;
                            lblCreditAccountBalance.Text = "Dr. Balance- " + difference.ToString("N", GlobalVariables.CurrentCultureInfo);
                        }
                        else
                        {
                            Decimal difference = TotalCredit - TotalDebit;
                            lblCreditAccountBalance.Text = "Cr. Balance- " + difference.ToString("N", GlobalVariables.CurrentCultureInfo);
                        }

                    }
                    else
                    {
                        lblCreditAccountBalance.Text = "Balance - 0.00";
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void KeyDownedOnCreditAccount(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (CurrentEntity.CreditAccountId < 5001)
                {
                    Console.Beep(1000, 400);
                    RedToolTip.Show("Select Credit Account.", cmbCreditAccount, 2000);
                    cmbCreditAccount.Focus();
                    return;
                }

                txtAmount.Focus();
                txtAmount.Select(0, txtAmount.Text.Trim().Length);



            }
        }

        #endregion

        #region Amount Related
        //<-------------------------------------------------------------------->

        private void EnteredIntoAmountTextBox(object sender, EventArgs e)
        {
            ComponentFactory.Krypton.Toolkit.KryptonTextBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            control.StateCommon.Back.Color1 = Color.White;

            control.Select(0, control.Text.Length);
        }

        private void AmountTextChanged(object sender, KeyEventArgs e)
        {

            decimal NumberToSpell;
            bool isDecimal = decimal.TryParse(txtAmount.Text.Trim(), NumberStyles.Any, GlobalVariables.CurrentCultureInfo, out NumberToSpell);
            AmountToolTip.Show(NumberToSpell.ToString("N", GlobalVariables.CurrentCultureInfo), txtAmount, 0, -50, 3000);

            try
            {
                if (isDecimal)
                {
                    txtAmountInWords.Text = Spell.SpellAmount.InWrods(NumberToSpell);
                }

            }
            catch (Exception Ex)
            {
                // CustomMessageBox.ShowSystemException(Ex); //Note - Don't show exceptions
            }
        }

        private void KeyDownedOnAmountTextBox(object sender, KeyEventArgs e)  //Catch Enter, Tab & Backspace keys
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (CurrentEntity.Amount == 0)
                {
                    Console.Beep(1000, 400);
                    RedToolTip.Show("Enter Amount.", txtAmount, 2000);
                    txtAmount.Focus(); txtAmount.Select(0, txtAmount.Text.Trim().Length);
                    return;
                }

                txtNarration.Focus();
            }
        }

        private void LeftFromAmountTextBox(object sender, EventArgs e)
        {
            ComponentFactory.Krypton.Toolkit.KryptonTextBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            control.StateCommon.Back.Color1 = SystemColors.GradientActiveCaption;
        }

        #endregion

        #region Narration Related

        //Note - Enter & Leave events are handled in Common Event Handlers section.

        private void NarrationKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (CurrentEntity.Narration.Length > 255)
                {
                    Console.Beep(1000, 400);
                    RedToolTip.Show("Maximum 255 characters allowed. You have entered " + CurrentEntity.Narration.Length + " characters.", txtNarration, 300);
                    txtNarration.Focus(); txtNarration.Select(0, txtNarration.Text.Length);
                    return;
                }

                btnSave.Focus();
            }
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

                //AccountId |  AccountName
                //--------- |  -----------
                //    1     |  Opening Balance
                //    2     |  Blank dummy account (to use in combobox)


                btnSave.Enabled = false;
                if (CurrentEntity.IsDirty)
                {
                    if (CurrentEntity.IsNew)
                    {
                        if (!GlobalVariables.currentUser.FindPermission("6"))
                        {
                            CustomMessageBox.ShowGeneralMessage(new GeneralMessage("User Denied", "Unauthorized Access", "You are not permitted to add voucher . Contact your admin."));
                            return;
                        }
                    }
                    else
                    {
                        if (!GlobalVariables.currentUser.FindPermission("7"))
                        {
                            CustomMessageBox.ShowGeneralMessage(new GeneralMessage("User Denied", "Unauthorized Access", "You are not permitted to edit voucher . Contact your admin."));
                            return;
                        }
                    }

                    if (CurrentEntity.DebitAccountId < 5001)
                    {
                        Console.Beep(1000, 400);
                        RedToolTip.Show("Select Debit Account.", cmbDebitAccount, 2000);
                        cmbDebitAccount.Focus();
                        return;
                    }

                    if (CurrentEntity.CreditAccountId < 5001)
                    {
                        Console.Beep(1000, 400);
                        RedToolTip.Show("Select Credit Account.", cmbCreditAccount, 2000);
                        cmbCreditAccount.Focus();
                        return;
                    }

                    Voucher.SaveEntity(CurrentEntity);
                    ShowNavigationAndPrintButton(true);
                    pbSearch.Visible = false;
                    CustomMessageBox.ShowSuccessMessage(new SuccessMessage("Add New Voucher", "Success", "Information successfully saved."));

                }

                btnSave.Enabled = false; // It will be auto enble if user change any property of current object.
                GetDebitAccountBalance(); GetCreditAccountBalance();
                btnNewEntity.Focus(); //Let user add a new entity.

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


                if (!GlobalVariables.currentUser.FindPermission("8"))
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are not permitted to do this task. Contact your admin."));
                    btnDelete.Enabled = true; return;
                }
                else
                {
                    if (CustomMessageBox.ShowConfirmationMessage(new ConfirmationMessage("Delete Record", "Sure?", "Are you sure to delete this record?")) == DialogResult.Yes)
                    {
                        CurrentEntity.DeleteEntity();
                        CustomMessageBox.ShowSuccessMessage(new SuccessMessage("Success", "Success", "Information successfully Deleted."));
                        btnDelete.Enabled = true;
                        btnDelete.Visible = false;
                      // AddNewCurrentEntity();
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
          //  pbEntityFolder.Image = Properties.Resources.EntityFolderOpenedVertically24;
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

        #region Common Event Handlers

        private void TextBoxEnterEventHandler(object sender, EventArgs e)
        {
            //Control control = sender as Control;
            ComponentFactory.Krypton.Toolkit.KryptonTextBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            control.StateCommon.Back.Color1 = Color.White;
            // control.BackColor = GlobalVariables.GotFocusBackColor;
            //control.ForeColor = GlobalVariables.GotFocusForeColor;
        }

        private void TextboxLeaveEventHandler(object sender, EventArgs e)
        {
            //Control control = sender as Control;
            // control.StateCommon.Back.Color1 = System.Drawing.SystemColors.GradientActiveCaption;
            //control.BackColor = GlobalVariables.LostFocusBackColor;
            //control.ForeColor = GlobalVariables.LostFocusForeColor;
            ComponentFactory.Krypton.Toolkit.KryptonTextBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            control.StateCommon.Back.Color1 = SystemColors.GradientActiveCaption;
        }



        #endregion

        private void CurrentEntityChanged(object sender, PropertyChangedEventArgs e)
        {
            btnSave.Enabled = true;
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

        #endregion

        #region BindingSource

        private void AddNewCurrentEntity()
        {
            CurrentEntity = new Voucher(GlobalVariables.ConnectionString, pVoucherTypeId);          

            switch (pVoucherTypeId)
            {
                case 1: //"Debit voucher"
                    CurrentEntity.SetDebitAccountId(-5000); // dummy accountId
                    CurrentEntity.SetCreditAccountId ( (Int32)CashbookAccountId);
                    break;

                case 2: // "Credit voucher"
                    CurrentEntity.SetDebitAccountId((Int32)CashbookAccountId);
                    CurrentEntity.SetCreditAccountId(-5000); // dummy accountId
                    break;
                case 3: // "Journal voucher"
                    CurrentEntity.SetDebitAccountId(-5000);
                    CurrentEntity.SetCreditAccountId(-5000); // dummy accountId
                    break;

                default:
                    break;
            }


            AddDataBindings();
            bsCurrentEntity.DataSource = CurrentEntity;
            bsCurrentEntity.ResetBindings(false);
           
            CurrentEntity.PropertyChanged += new PropertyChangedEventHandler(CurrentEntityChanged);
            txtVoucherId.ReadOnly = false; btnSave.Enabled = false; btnDelete.Visible = false; ShowNavigationAndPrintButton(false); pbSearch.Visible = false;
            txtAmountInWords.Text = Spell.SpellAmount.InWrods(CurrentEntity.Amount);
            //txtVoucherId.Focus(); txtVoucherId.Select(0, txtVoucherId.Text.Trim().Length);


            switch (pVoucherTypeId)
            {
                case 1: //"Debit voucher"
                    cmbDebitAccount.Focus();
                    break;

                case 2: // "Credit voucher"
                    cmbCreditAccount.Focus();
                    break;
                case 3: // "Journal voucher"
                    cmbDebitAccount.Focus();
                    break;

                default:
                    break;
            }

        }

        private void SetToCurrentEntity(Voucher voucher)
        {
            CurrentEntity = voucher;

            AddDataBindings();
            bsCurrentEntity.DataSource = CurrentEntity;
            bsCurrentEntity.ResetBindings(false);

            CurrentEntity.PropertyChanged += new PropertyChangedEventHandler(CurrentEntityChanged);
            txtAmountInWords.Text = Spell.SpellAmount.InWrods(CurrentEntity.Amount);


        }
       
        private void AddDataBindings()
        {
            if (!DataBindingAdded)
            {
                bsCurrentEntity.DataSource = typeof(Voucher);
                txtVoucherId.DataBindings.Add("Text", bsCurrentEntity, "VoucherId", false, DataSourceUpdateMode.OnPropertyChanged);
                txtEntryDate.DataBindings.Add("Text", bsCurrentEntity, "EntryDate", true, DataSourceUpdateMode.OnPropertyChanged, null, "d", GlobalVariables.CurrentCultureInfo);
                cmbDebitAccount.DataBindings.Add("SelectedValue", bsCurrentEntity, "DebitAccountId", true, DataSourceUpdateMode.OnPropertyChanged);
                cmbCreditAccount.DataBindings.Add("SelectedValue", bsCurrentEntity, "CreditAccountId", true, DataSourceUpdateMode.OnPropertyChanged);
                txtAmount.DataBindings.Add("Text", bsCurrentEntity, "Amount", true, DataSourceUpdateMode.OnPropertyChanged, 0, "N", GlobalVariables.CurrentCultureInfo);
                txtNarration.DataBindings.Add("Text", bsCurrentEntity, "Narration", false, DataSourceUpdateMode.OnPropertyChanged);
              
                DataBindingAdded = true;
              
            }

        }

        private void RemoveDataBindings()
        {
            if (!DataBindingRemoved)
            {
                CurrentEntity.PropertyChanged -= new PropertyChangedEventHandler(CurrentEntityChanged);
                bsCurrentEntity.Clear();
                bsCurrentEntity.DataSource = null;
                txtVoucherId.DataBindings.Clear();
                txtEntryDate.DataBindings.Clear();
                cmbDebitAccount.DataBindings.Clear();
                cmbCreditAccount.DataBindings.Clear();
                txtAmount.DataBindings.Clear();
                txtNarration.DataBindings.Clear();
                DataBindingRemoved = true;              
            }

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
                case "txtEntryDate": control = txtEntryDate; break;
                case "txtVoucherId": control = txtVoucherId; break;
                case "cmbDebitAccount": control = cmbDebitAccount; break;
                case "cmbCreditAccount": control = cmbCreditAccount; break;
                case "txtAmount": control = txtAmount; break;
                case "txtNarration": control = txtNarration; break;

                default:
                    break;
            }
           // CustomMessageBox.ShowGeneralMessage(new GeneralMessage(EWC.TitleBarMessage, EWC.HeadLineMessage, EWC.ErrorDescription));
            RedToolTip.Show(EWC.ErrorDescription, control, 3000); Console.Beep(1000, 400);
            //MyErrorProvider.SetError(control, EWC.ErrorDescription); 
            control.Focus();
        }
        
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

        #region Printing
        private void PrintData(object sender, EventArgs e)
        {
            try
             {
                 VoucherReceipt voucher = new VoucherReceipt();

                 switch (pVoucherTypeId)
                 {
                     case 1: voucher.VoucherTypeName = "Debit Voucher"; break;
                     case 2: voucher.VoucherTypeName = "Credit Voucher"; break;
                     case 3: voucher.VoucherTypeName = "Journal Voucher"; break;
                     default:
                         break;
                 }

                 voucher.VoucherDate = txtEntryDate.Text;
                 voucher.VoucherNo = txtVoucherId.Text;
                 voucher.DebitAccountName = cmbDebitAccount.Text;
                 voucher.CreditAccountName = cmbCreditAccount.Text;
                 voucher.Amount = txtAmount.Text;
                 voucher.AmountInWords = txtAmountInWords.Text;
                 voucher.Narration = txtNarration.Text;

                 pbPrint.Enabled = false;
                 CommonForms.frmMsReportViewer frm = new CommonForms.frmMsReportViewer();
               
                 frm.MsReportViewer.ProcessingMode = ProcessingMode.Local;

                 BindingSource bsVoucher = new BindingSource();
                 bsVoucher.DataSource = voucher;
                 ReportDataSource rds = new ReportDataSource("VoucherReceiptDataSet", bsVoucher);
                 frm.MsReportViewer.LocalReport.DataSources.Add(rds);

                 BindingSource bsCompanyInfomation = new BindingSource();
                 bsCompanyInfomation.DataSource = GlobalVariables.currentUser.CompanyInformation;
                 ReportDataSource rdsCompanyInfo = new ReportDataSource("CompanyInfoDataset", bsCompanyInfomation);
                 frm.MsReportViewer.LocalReport.DataSources.Add(rdsCompanyInfo);

                 frm.MsReportViewer.LocalReport.ReportEmbeddedResource = "QCash.AllReports.VoucherReceipt.rdlc";
               
                 frm.Text = "Print Voucher";
                 frm.Icon = this.Icon;
                frm.Show(this.Owner);

                 pbPrint.Enabled = true;
             }
             catch (Exception Ex)
             {
                 CustomMessageBox.ShowSystemException(Ex);
                 pbPrint.Enabled = true;
             }
        }
        #endregion

        private void ShowNavigationAndPrintButton(Boolean ShowIcons)
        {
            pbFirstRecord.Visible = ShowIcons;
            pbPreviousRecord.Visible = ShowIcons;
            pbNextRecord.Visible = ShowIcons;
            pbLastRecord.Visible = ShowIcons;
            pbPrint.Visible = ShowIcons;
        }
        
        #endregion



        private void AddDebitAccount(object sender, EventArgs e)
        {
            MasterSetupForms.ChartOfAccountsForm.frmAccountHeadDetails frm =
                new MasterSetupForms.ChartOfAccountsForm.frmAccountHeadDetails(null, null, null, false);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                AccountHeadComboItem newItem = AccountHeadComboItem.GetEntity(frm.NewlyCreatedEntity, GlobalVariables.ConnectionString);
                List<AccountHeadComboItem> OldList = (List<AccountHeadComboItem>)cmbDebitAccount.DataSource;
                OldList.Add(newItem);
                cmbDebitAccount.DataSource = null;
                cmbDebitAccount.DataSource = OldList;
                cmbDebitAccount.ValueMember = "AccountId";
                cmbDebitAccount.DisplayMember = "AccountNameWithCode";
                cmbDebitAccount.SelectedValue = newItem.AccountId;
            } 
        }

        private void AddCreditAccount(object sender, EventArgs e)
        {
            MasterSetupForms.ChartOfAccountsForm.frmAccountHeadDetails frm =
                new MasterSetupForms.ChartOfAccountsForm.frmAccountHeadDetails(null, null, null, false);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                AccountHeadComboItem newItem = AccountHeadComboItem.GetEntity(frm.NewlyCreatedEntity, GlobalVariables.ConnectionString);
                List<AccountHeadComboItem> OldList = (List<AccountHeadComboItem>)cmbCreditAccount.DataSource;
                OldList.Add(newItem);
                cmbCreditAccount.DataSource = null;
                cmbCreditAccount.DataSource = OldList;
                cmbCreditAccount.ValueMember = "AccountId";
                cmbCreditAccount.DisplayMember = "AccountNameWithCode";
                cmbCreditAccount.SelectedValue = newItem.AccountId;
            } 
        }


        private void ChangeOperatingYearDatabase()
        {
            string NewOperatingYear = txtOperatingYear.Text.Trim();

            if (LocalOperatingYear == NewOperatingYear)
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
                RedToolTip.Show("Operating Year not found.", txtOperatingYear, 4000);
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

            StartPrimaryWorker();
        }



    }
}
