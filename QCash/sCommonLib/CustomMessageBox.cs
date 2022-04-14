using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace sCommonLib
{
    public static class CustomMessageBox
    {
        //This Class is the entry point
        //to invoke all kind of MessageBox

        public static void ShowGeneralMessage(Messages.GeneralMessage GeneralMessageDetails)
        {
            MessageBoxes.GeneralMessageBox frm = new MessageBoxes.GeneralMessageBox(GeneralMessageDetails);
            frm.ShowDialog();
        }

        public static void ShowSuccessMessage(Messages.SuccessMessage SuccessMessageDetails)
        {
            MessageBoxes.SuccessMessageBox frm = new MessageBoxes.SuccessMessageBox(SuccessMessageDetails);
            frm.ShowDialog();
        }

        public static DialogResult ShowConfirmationMessage(Messages.ConfirmationMessage Message)
        {
            MessageBoxes.ConfirmationMessageBox frm = new MessageBoxes.ConfirmationMessageBox(Message);
            return frm.ShowDialog();
        }

        public static void ShowUserException(Exceptions.UserException ExceptionDetails)
        {
            MessageBoxes.UserExceptionMessageBox frm = new MessageBoxes.UserExceptionMessageBox(ExceptionDetails);
            frm.ShowDialog();
        }

        public static void ShowSystemException(Exception ExceptionDetails)
        {
            string ErrorMessage = "Created on: " + DateTime.Now.ToString("dd-MMM-yyyy, hh.mm.ss tt");
            ErrorMessage += Environment.NewLine + "Error Description: " + ExceptionDetails.Message;
            ErrorMessage += Environment.NewLine + "StackTrace: " + ExceptionDetails.StackTrace + Environment.NewLine + "________________________________________________________________________" + Environment.NewLine;
            StreamFunctions.CreateErrorLog(ErrorMessage);

            MessageBoxes.SystemExceptionMessageBox frm = new MessageBoxes.SystemExceptionMessageBox(ExceptionDetails);
            frm.ShowDialog();
        }


    }
}
