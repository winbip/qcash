using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sCommonLib.MessageBoxes
{
    public partial class SystemExceptionMessageBox : Form
    {
        Exception pException;

        public SystemExceptionMessageBox()
        {
            InitializeComponent();
        }

        public SystemExceptionMessageBox(Exception ExceptionDetails)
        {
            InitializeComponent();
            pException = ExceptionDetails;
        }

        private void SystemExceptionMessageBox_Load(object sender, EventArgs e)
        {
            string ErrorMessage = pException.Message;
            lblMessageBody.Text = ErrorMessage + Environment.NewLine + Environment.NewLine + "An error log has been created.";

            // txtStackTrace.Text = pException.StackTrace;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void lblViewDetails_Click(object sender, EventArgs e)
        {
            frmStackTraceDetails frm = new frmStackTraceDetails(pException.StackTrace);
            frm.ShowDialog();
        }

        private void lblDetailIcon_Click(object sender, EventArgs e)
        {
            frmStackTraceDetails frm = new frmStackTraceDetails(pException.StackTrace);
            frm.ShowDialog();
        }

        //private void UserExceptionMessageBox_Load(object sender, EventArgs e)
        //{
        //    this.Text = "  " + pUserException.TitleBarMessage.ToString();
        //    this.lblHeadLine.Text = pUserException.HeadLineMessage.ToString();
        //    this.lblMessageBody.Text = pUserException.ErrorDescription.ToString();
        //}

        //private void btnOk_Click(object sender, EventArgs e)
        //{
        //    
        //}
    }
}
