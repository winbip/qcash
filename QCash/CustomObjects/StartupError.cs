using System;
using System.Collections.Generic;
using System.Text;

namespace CustomObjects
{
    public class StartupError
    {
        private bool pIsError;
        private int pErrorId;
        private string pErrorDetails;


        public int StartupErrorId
        {
            get { return pErrorId; }

            set
            {
                if (pErrorId != value)
                {
                    pErrorId = value;
                    pIsError = true;
                }
            }
        }


        public string ErrorDetails
        {
            get { return pErrorDetails; }
            set
            {
                if (pErrorDetails != value)
                {
                    pErrorDetails = value;
                    pIsError = true;
                }
            }
        }

        public bool ErrorFound
        {
            get { return pIsError; }
        }

        public StartupError()
        {
            pIsError = false;
        }

        public StartupError(int ErrorId, string ErrorDetail)
        {
            pIsError = true;
            pErrorId = ErrorId; pErrorDetails = ErrorDetail;
        }

    }
}
