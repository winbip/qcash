using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sCommonLib.MessageBoxes
{
    public partial class UserExceptionMessageBox : Form
    {
        Exceptions.UserException pUserException;

        public UserExceptionMessageBox()
        {
            InitializeComponent();
        }

        public UserExceptionMessageBox(Exceptions.UserException UEX)
        {
            InitializeComponent();
            pUserException = UEX;
        }

        private void UserExceptionMessageBox_Load(object sender, EventArgs e)
        {
            this.Text = "  " + pUserException.TitleBarMessage.ToString();
            this.lblHeadLine.Text = pUserException.HeadLineMessage.ToString();
            this.lblMessageBody.Text = pUserException.ErrorDescription.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
