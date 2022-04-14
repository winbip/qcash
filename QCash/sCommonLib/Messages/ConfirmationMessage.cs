using System;
using System.Collections.Generic;
using System.Text;

namespace sCommonLib.Messages
{
    public class ConfirmationMessage
    {

        private string pTitleBarMessage;
        private string pHeadLineMessage;
        private string pQuestionDetails;

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

        public string QuestionDetails
        {
            get { return pQuestionDetails; }
            set { pQuestionDetails = value; }
        }

        public ConfirmationMessage(string TitleBarText, string HeadLineText, string ConfirmationQuestion)
        {
            pTitleBarMessage = TitleBarText;
            pHeadLineMessage = HeadLineText;
            pQuestionDetails = ConfirmationQuestion;
        }

    }
}
