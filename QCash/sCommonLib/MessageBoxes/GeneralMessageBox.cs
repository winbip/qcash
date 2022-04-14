using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sCommonLib.MessageBoxes
{
    public partial class GeneralMessageBox : Form
    {

        Messages.GeneralMessage pGeneralMessage;

        public GeneralMessageBox()
        {
            InitializeComponent();
        }

        public GeneralMessageBox(Messages.GeneralMessage GenMsg)
        {
            InitializeComponent(); pGeneralMessage = GenMsg;
        }

        private void GeneralMessageBox_Load(object sender, EventArgs e)
        {
            this.Text = "  " + pGeneralMessage.TitleBarMessage.ToString();
            this.lblHeadLine.Text = pGeneralMessage.HeadlineMessage.ToString();
            this.lblMessageBody.Text = pGeneralMessage.GeneralMessageText.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

    }
}
