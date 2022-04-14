using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QCash
{
    public partial class frmEventMaker : Form
    {
        public frmEventMaker()
        {
            InitializeComponent();
        }

        private void frmEventMaker_Load(object sender, EventArgs e)
        {
            frmMain frm = new frmMain(); //Change Form Name here.

            MakeEvents(frm);
        }


        /*Note- Detail Handlers. If following code block create problems, then use this block.
        txtEnterEvents.AppendText(control.Name.ToString() + ".Enter += new System.EventHandler(HandleCommonEnterEvent);" + Environment.NewLine);
        txtLeaveEvents.AppendText(control.Name.ToString() + ".Leave += new System.EventHandler(HandleCommonLeaveEvent);" + Environment.NewLine);
        txtKeyDownEvents.AppendText(control.Name.ToString() + ".KeyDown += new System.Windows.Forms.KeyEventHandler( HandleCommonEnterKeyDownEvent);" + Environment.NewLine);
        txtFocusOrder.AppendText("dtFocusOrder.Rows.Add(\"" + control.Name.ToString() + "\");" + Environment.NewLine);
        */
        private void MakeEvents(Control ctrl)
        {
            foreach (Control control in ctrl.Controls)
            {
                if (control is TextBox || control is ComponentFactory.Krypton.Toolkit.KryptonTextBox)
                {

                    txtEnterEvents.AppendText(control.Name.ToString() + ".Enter += EnterEventHandler;" + Environment.NewLine);
                    txtLeaveEvents.AppendText(control.Name.ToString() + ".Leave += LeaveEventHandler;" + Environment.NewLine);
                    txtKeyDownEvents.AppendText(control.Name.ToString() + ".KeyDown += KeyDownEventHandler;" + Environment.NewLine);
                    txtFocusOrder.AppendText("dtFocusOrder.Rows.Add(\"" + control.Name.ToString() + "\");" + Environment.NewLine);
                }
                else if (control is ComboBox || control is ComponentFactory.Krypton.Toolkit.KryptonComboBox)
                {
                    txtEnterEvents.AppendText(control.Name.ToString() + ".Enter += EnterEventHandler;" + Environment.NewLine);
                    txtLeaveEvents.AppendText(control.Name.ToString() + ".Leave += LeaveEventHandler;" + Environment.NewLine);
                    txtKeyDownEvents.AppendText(control.Name.ToString() + ".KeyDown += KeyDownEventHandler;" + Environment.NewLine);
                    txtFocusOrder.AppendText("dtFocusOrder.Rows.Add(\"" + control.Name.ToString() + "\");" + Environment.NewLine);
                }
                else if (control is CheckBox)
                {
                    txtEnterEvents.AppendText(control.Name.ToString() + ".Enter += EnterEventHandler;" + Environment.NewLine);
                    txtLeaveEvents.AppendText(control.Name.ToString() + ".Leave += LeaveEventHandler;" + Environment.NewLine);
                    txtKeyDownEvents.AppendText(control.Name.ToString() + ".KeyDown += KeyDownEventHandler;" + Environment.NewLine);
                    txtFocusOrder.AppendText("dtFocusOrder.Rows.Add(\"" + control.Name.ToString() + "\");" + Environment.NewLine);
                }
                else if (control is Button || control is ComponentFactory.Krypton.Toolkit.KryptonButton)
                {
                    txtFocusOrder.AppendText("dtFocusOrder.Rows.Add(\"" + control.Name.ToString() + "\");" + Environment.NewLine);
                }

                MakeEvents(control);
            }
        }

        private void toolStripButtonCopyAll_Click(object sender, EventArgs e)
        {
            string AllEvents = string.Empty;
            AllEvents += txtEnterEvents.Text + Environment.NewLine;
            AllEvents += "==================" + Environment.NewLine;
            AllEvents += txtLeaveEvents.Text + Environment.NewLine;
            AllEvents += "==================" + Environment.NewLine;
            AllEvents += txtKeyDownEvents.Text + Environment.NewLine;
            AllEvents += "==================" + Environment.NewLine;
            AllEvents += txtFocusOrder.Text;

            Clipboard.SetText(AllEvents);
        }
    }
}
