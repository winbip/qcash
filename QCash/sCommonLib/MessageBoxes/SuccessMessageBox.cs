using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sCommonLib.MessageBoxes
{
    public partial class SuccessMessageBox : Form
    {

        Messages.SuccessMessage pSuccessMessage;

        public SuccessMessageBox()
        {
            InitializeComponent();
        }

        public SuccessMessageBox(Messages.SuccessMessage ScsMsg)
        {
            InitializeComponent();
            pSuccessMessage = ScsMsg;
        }

        private void SuccessMessageBox_Load(object sender, EventArgs e)
        {
            this.Text = "  " + pSuccessMessage.TitleBarMessage.ToString();
            this.lblHeadLine.Text = pSuccessMessage.HeadlineMessage.ToString();
            this.lblMessageBody.Text = pSuccessMessage.SuccessMessageText.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }



    }
}
