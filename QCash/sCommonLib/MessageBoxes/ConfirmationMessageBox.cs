using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sCommonLib.MessageBoxes
{
    public partial class ConfirmationMessageBox : Form
    {
        Messages.ConfirmationMessage pConfirmationMessage;

        public ConfirmationMessageBox()
        {
            InitializeComponent();

            this.ControlBox = false;
            this.MinimizeBox = false; this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.BackColor = Color.SlateGray;
        }

        public ConfirmationMessageBox(Messages.ConfirmationMessage ConfirmationQuestion)
        {
            InitializeComponent();
            pConfirmationMessage = ConfirmationQuestion;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void ConfirmationMessageBox_Load(object sender, EventArgs e)
        {
            this.Text = "  " + pConfirmationMessage.TitleBarMessage.ToString();
            this.lblHeadLine.Text = pConfirmationMessage.HeadlineMessage.ToString();
            this.lblQuestionDetails.Text = pConfirmationMessage.QuestionDetails.ToString();
        }
    }
}
