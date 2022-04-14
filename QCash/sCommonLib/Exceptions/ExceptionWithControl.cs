using System;

namespace sCommonLib.Exceptions
{
    public class ExceptionWithControl : Exception
    {
        private string pTitleBarMessage;
        private string pHeadLineMessage;
        private string pErrorDescription;
        private string pControlName;


        public string TitleBarMessage
        {
            get { return pTitleBarMessage; }
        }

        public string HeadLineMessage
        {
            get { return pHeadLineMessage; }
        }


        public string ErrorDescription
        {
            get { return pErrorDescription; }
        }

        public string ControlName
        {
            get { return pControlName; }
        }

        public ExceptionWithControl(string TitleBarText, string HeadLineText, string ErrorMessage, string NameOfControl)
        {
            pTitleBarMessage = TitleBarText;
            pHeadLineMessage = HeadLineText;
            pErrorDescription = ErrorMessage;
            pControlName = NameOfControl;
        }
    }
}
