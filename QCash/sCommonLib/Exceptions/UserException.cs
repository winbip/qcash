using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace sCommonLib.Exceptions
{
    public class UserException : System.Exception
    {
        private string mTitleBarMessage;
        private string mHeadLineMessage;
        private string mErrorDescription;


        public string TitleBarMessage
        {
            get { return mTitleBarMessage; }
        }

        public string HeadLineMessage
        {
            get { return mHeadLineMessage; }
        }


        public string ErrorDescription
        {
            get { return mErrorDescription; }
        }

        public UserException(string TitleBarText, string HeadLineText, string ErrorMessage)
        {
            mTitleBarMessage = TitleBarText;
            mHeadLineMessage = HeadLineText;
            mErrorDescription = ErrorMessage;
        }


        public UserException(string TitleBarText, string HeadLineText, string ErrorMessage, Control ControlName)
        {
            mTitleBarMessage = TitleBarText;
            mHeadLineMessage = HeadLineText;
            mErrorDescription = ErrorMessage;
            ControlName.Focus();
        }

        public UserException(string TitleBarText, string HeadLineText, string ErrorMessage, Control ControlName, ErrorProvider ErrorProviderName)
        {
            mTitleBarMessage = TitleBarText;
            mHeadLineMessage = HeadLineText;
            mErrorDescription = ErrorMessage;
            ErrorProviderName.SetError(ControlName, ErrorMessage);
            ControlName.Focus();
        }
    }
}
