using System;
using System.Collections.Generic;
using System.Text;

namespace sCommonLib.Messages
{
    public class SuccessMessage
    {
        private string pTitleBarMessage;
        private string pHeadLineMessage;
        private string pSuccessMessageText;

        public string TitleBarMessage
        {
            get { return pTitleBarMessage; }
            set { pTitleBarMessage = value; }
        }

        public string HeadlineMessage
        {
            get { return pHeadLineMessage; }
            set { pHeadLineMessage = value; }
        }

        public string SuccessMessageText
        {
            get { return pSuccessMessageText; }
            set { pSuccessMessageText = value; }
        }

        public SuccessMessage(string TitleBarText, string HeadLineText, string SuccessMessageDetails)
        {
            pTitleBarMessage = TitleBarText;
            pHeadLineMessage = HeadLineText;
            pSuccessMessageText = SuccessMessageDetails;
        }

    }
}
