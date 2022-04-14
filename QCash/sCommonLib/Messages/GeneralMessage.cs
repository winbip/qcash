using System;
using System.Collections.Generic;
using System.Text;

namespace sCommonLib.Messages
{
    public class GeneralMessage
    {
        private string pTitleBarMessage;
        private string pHeadLineMessage;
        private string pGeneralMessageText;

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

        public string GeneralMessageText
        {
            get { return pGeneralMessageText; }
            set { pGeneralMessageText = value; }
        }

        public GeneralMessage(string TitleBarText, string HeadLineText, string GeneralMessageDetails)
        {
            pTitleBarMessage = TitleBarText;
            pHeadLineMessage = HeadLineText;
            pGeneralMessageText = GeneralMessageDetails;
        }
    }
}
