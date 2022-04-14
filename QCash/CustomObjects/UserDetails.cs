using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.ComponentModel;
using sCommonLib.SqlCommander;
using sCommonLib.Exceptions;
using sCommonLib.Messages;

namespace CustomObjects
{
    public class UserDetails : ObjectBase
    {

        #region PrivateVariables
        private string pConnectionString;

        private int pUserId;
        private string pLogInName;
        private string pLogInPassword;
        private string pFullName;
        private string pUserDesignation;
        private CompanyInfo pCompanyDetails = new CompanyInfo();

        #endregion

        #region PublicProperties
        public int UserId
        {
            get { return pUserId; }
            set
            {
                if (!value.Equals(pUserId))
                {
                    pUserId = value;
                    MarkDirty();
                    PropertyHasChanged("UserId");

                }
            }
        }

        public string LogInName
        {
            get { return pLogInName; }
            set
            {
                if (!value.Equals(pLogInName))
                {
                    pLogInName = value;
                    MarkDirty();
                    PropertyHasChanged("LogInName");
                }
            }
        }

        public string LogInPassword
        {
            get { return pLogInPassword; }
            set
            {
                if (!value.Equals(pLogInPassword))
                {
                    pLogInPassword = value;
                    MarkDirty();
                    PropertyHasChanged("LogInPassword");
                }
            }
        }

        public string FullName
        {
            get { return pFullName; }
            set
            {
                if (!value.Equals(pFullName))
                {
                    pFullName = value;
                    MarkDirty();
                    PropertyHasChanged("FullName");
                }
            }
        }

        public string UserDesignation
        {
            get { return pUserDesignation; }
            set
            {
                if (!value.Equals(pUserDesignation))
                {
                    pUserDesignation = value;
                    MarkDirty();
                    PropertyHasChanged("UserDesignation");
                }
            }
        }

        public CompanyInfo CompanyDetails
        {
            get { return pCompanyDetails; }
            set
            {
                if (!value.Equals(pCompanyDetails))
                {
                    pCompanyDetails = value;
                    MarkDirty();
                    PropertyHasChanged("CompanyDetails");
                }
            }
        }

        #endregion

        #region Constructors
        public UserDetails()
        {
        }

        public UserDetails(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }
        #endregion

        #region Save Entity
        public static UserDetails SaveEntity(UserDetails userdetails)
        {
            if (userdetails.IsNew)
            {
                return UserDetails.CreateEntity(userdetails);
            }
            else
            {
                return UserDetails.UpdateEntity(userdetails);
            }
        }

        private static UserDetails CreateEntity(UserDetails userdetails)
        {
            OleDbConnection Connection = new OleDbConnection(userdetails.pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand();
            cmdCommand.Connection = Connection;

            OleDbTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdCommand.Transaction = transaction;

                Access2003SqlCommander SqlFunction = new Access2003SqlCommander(cmdCommand);

                if (SqlFunction.SearchString("select LogInName from tblUserDetails where LogInName='" + userdetails.pLogInName + "' and CompanyId=" + userdetails.pCompanyDetails.CompanyId + ""))
                {
                    throw new ExceptionWithControl("Error", "Login Name Exists", "This Login Name already in use. Try different Login Name.", "LogInName");
                }

                userdetails.pUserId = SqlFunction.CreateNewId("tblUserDetails", "UserId");

                SqlFunction.InsertRecord("INSERT INTO tblUserDetails(UserId, LogInName, LogInPassword, FullName, UserDesignation, CompanyId) VALUES(" + userdetails.pUserId + ",'" + userdetails.pLogInName + "','" + userdetails.pLogInPassword + "','" + userdetails.pFullName + "','" + userdetails.pUserDesignation + "',1)");

                transaction.Commit();
                Connection.Close();
                SqlFunction.Dispose();
                userdetails.MarkOld();
                return userdetails;
            }
            catch (ExceptionWithoutControl WithoutControlException)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw WithoutControlException;
            }
            catch (ExceptionWithControl WithControlException)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw WithControlException;
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw ex;
            }
        }

        private static UserDetails UpdateEntity(UserDetails userdetails)
        {
            OleDbConnection Connection = new OleDbConnection(userdetails.pConnectionString);
            OleDbCommand cmdUpdate = new OleDbCommand("UPDATE tblUserDetails SET LogInPassword='" + userdetails.pLogInPassword + "', FullName='" + userdetails.pFullName + "', UserDesignation='" + userdetails.pUserDesignation + "'  WHERE UserId=" + userdetails.pUserId + "", Connection);
            OleDbTransaction trans = null;
            try
            {
                Connection.Open();
                trans = Connection.BeginTransaction();
                cmdUpdate.Transaction = trans;
                cmdUpdate.ExecuteNonQuery();
                trans.Commit();
                Connection.Close();
                userdetails.MarkClean();
                return userdetails;
            }
            catch (Exception ex)
            {
                if (trans != null)
                {
                    trans.Rollback();
                }
                throw ex;
            }
        }

        #endregion

        #region Read Entity

        public static UserDetails FillEntity(OleDbDataReader Reader)
        {
            UserDetails userdetails = new UserDetails();
            userdetails.pUserId = (int)Reader["UserId"];
            userdetails.pLogInName = Reader["LogInName"].ToString();
            userdetails.pLogInPassword = Reader["LogInPassword"].ToString();
            userdetails.pFullName = Reader["FullName"].ToString();
            userdetails.pUserDesignation = Reader["UserDesignation"].ToString();
            userdetails.pCompanyDetails.CompanyId = (int)Reader["CompanyId"];
            userdetails.MarkOld();
            return userdetails;
        }

        public static UserDetails GetEntity(int userid, string ConnectionString)
        {
            UserDetails userdetails = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT UserId, LogInName, LogInPassword, FullName, UserDesignation, CompanyId FROM tblUserDetails WHERE UserId=" + userid + "";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (Reader.HasRows)
                    {
                        Reader.Read();
                        userdetails = FillEntity(Reader);
                        userdetails.pConnectionString = ConnectionString;
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return userdetails;
        }

        public static List<UserDetails> GetEntityList(string ConnectionString)
        {
            List<UserDetails> UserDetailsList = new List<UserDetails>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  UserId, LogInName, LogInPassword, FullName, UserDesignation, CompanyDetails FROM tblUserDetails ORDER BY ---";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        UserDetails userdetails = FillEntity(Reader);
                        userdetails.pConnectionString = ConnectionString;
                        UserDetailsList.Add(userdetails);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return UserDetailsList;
        }


        public static UserDetails FillUserEntityOnly(OleDbDataReader Reader)
        {
            UserDetails userdetails = new UserDetails();
            userdetails.UserId = (int)Reader["UserId"];
            userdetails.LogInName = Reader["LogInName"].ToString();
            userdetails.LogInPassword = Reader["LogInPassword"].ToString();
            userdetails.FullName = Reader["FullName"].ToString();
            userdetails.UserDesignation = Reader["UserDesignation"].ToString();
            userdetails.MarkOld();
            return userdetails;
        }

        /// <summary>
        /// This method only returns User details without his company info.
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Connection"></param>
        /// <returns></returns>
        public static UserDetails GetUserEntityOnly(int userId, OleDbConnection Connection)
        {
            UserDetails userdetails = null;

            string sqlSelect = "SELECT UserId, LogInName, LogInPassword, FullName, UserDesignation FROM tblUserDetails WHERE UserId=" + userId + "";
            using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
            {
                OleDbDataReader Reader = cmd.ExecuteReader();
                if (Reader.HasRows)
                {
                    Reader.Read();
                    userdetails = FillUserEntityOnly(Reader);
                }
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }
            }

            return userdetails;
        }
        #endregion

        #region Delete Entity
        public void DeleteEntity()
        {
            using (OleDbConnection Connection = new OleDbConnection(pConnectionString))
            {
                Connection.Open();
                string sqlDelete = "DELETE UserId, LogInName, LogInPassword, FullName, UserDesignation, CompanyDetails FROM tblUserDetails WHERE UserId=" + this.pUserId + "";
                OleDbCommand cmdDelete = new OleDbCommand(sqlDelete, Connection);
                Connection.Close();
            }
        }

        #endregion

        #region Utility
        /// <summary>
        /// Returns LogInName
        /// </summary>
        /// <returns>LogInName</returns>
        public override string ToString()
        {
            return pLogInName;
        }
        public void SetConnectionString(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }

        #endregion
    }
}
