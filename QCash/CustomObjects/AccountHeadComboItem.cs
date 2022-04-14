using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.ComponentModel;
using sCommonLib.Exceptions;
using sCommonLib.SqlCommander;

namespace CustomObjects
{
    public class AccountHeadComboItem : IDisposable
    {

        #region PrivateVariables
        private Int32 pAccountId;
        private Int32 pAccountCode;
        private String pAccountName;
        private string pConnectionString;
        #endregion

        #region PublicProperties
        public Int32 AccountId
        {
            get { return pAccountId; }
        }

        public Int32 AccountCode
        {
            get { return pAccountCode; }
          
        }

        public String AccountName
        {
            get { return pAccountName; }
       
        }

        public String AccountNameWithCode
        {
            get
            {
                String accounName = (pAccountCode == -1000 || pAccountCode == -5000) ? pAccountName : pAccountName + " (" + pAccountCode.ToString() + ")";

                return accounName;
            }
        }

        #endregion

        #region Constructors
        public AccountHeadComboItem()
        {
        }

        public AccountHeadComboItem(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }
        #endregion


        #region Read Entity

        private static AccountHeadComboItem FillEntity(OleDbDataReader Reader)
        {
            AccountHeadComboItem AHCI = new AccountHeadComboItem();

            AHCI.pAccountId = Convert.ToInt32(Reader["AccountId"]);
            AHCI.pAccountCode = Convert.ToInt32(Reader["AccountCode"]);
            AHCI.pAccountName = Reader["AccountName"].ToString();
            return AHCI;
        }

        public static AccountHeadComboItem GetEntity(Int32 accountId, string ConnectionString)
        {
            AccountHeadComboItem item = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  AccountId, AccountCode, AccountName FROM tblAccountHead WHERE AccountId="+ accountId +"";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        item = FillEntity(Reader);
                       
                       
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return item;
        }

        public static List<AccountHeadComboItem> GetComboList(string ConnectionString)
        {
            List<AccountHeadComboItem> AccountHeadComboItemList = new List<AccountHeadComboItem>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  AccountId, AccountCode, AccountName FROM tblAccountHead WHERE AccountId<>5000 AND IsDeleted=False ORDER BY AccountName ASC";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        AccountHeadComboItem AHCI = FillEntity(Reader);
                        AHCI.pConnectionString = ConnectionString;
                        AccountHeadComboItemList.Add(AHCI);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return AccountHeadComboItemList;
        }


        #endregion


        #region Utility
        /// <summary>
        /// returns Account Id
        /// </summary>
        /// <returns>AccountId</returns>
        public override string ToString()
        {
            return pAccountId.ToString();
        }

        #endregion

        #region iDisposable_mthods

        private bool disposed = false;

        public void Dispose()
        {
            // Call our helper method.
            //Specifying "true" signifies that
            // the object user triggered the cleanup.
            CleanUp(true);

            // Now suppress finalization.
            GC.SuppressFinalize(this);
        }

        private void CleanUp(bool disposing)
        {
            // Be sure we have not already been disposed!
            if (!this.disposed)
            {
                // If disposing equals true, dispose all
                // managed resources.
                if (disposing)
                {
                    // Dispose managed resources.
                }
                // Clean up unmanaged resources here.
            }
            disposed = true;
        }

        ~AccountHeadComboItem()
        {
            CleanUp(false);
        }

        #endregion

    }
}