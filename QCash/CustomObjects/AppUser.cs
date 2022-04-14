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
    public class AppUser : ObjectBase
    {

        #region PrivateVariables
        private Int32 pUserId;
        private String pLogInName;
        private String pLogInPassword;
        private String pFullName;
        private String pUserDesignation;
        private Int32 pCompanyId;
        private Boolean pIsDeleted;
        private string pConnectionString;
        #endregion

        #region PublicProperties
        public Int32 UserId
        {
            get { return pUserId; }
            set
            {
                if (!value.Equals(pUserId))
                {
                    pUserId = value;
                    PropertyHasChanged("UserId");
                }
            }
        }

        public String LogInName
        {
            get { return pLogInName; }
            set
            {
                if (!value.Equals(pLogInName))
                {
                    pLogInName = value;
                    PropertyHasChanged("LogInName");
                }
            }
        }

        public String LogInPassword
        {
            get { return pLogInPassword; }
            set
            {
                if (!value.Equals(pLogInPassword))
                {
                    pLogInPassword = value;
                    PropertyHasChanged("LogInPassword");
                }
            }
        }

        public String FullName
        {
            get { return pFullName; }
            set
            {
                if (!value.Equals(pFullName))
                {
                    pFullName = value;
                    PropertyHasChanged("FullName");
                }
            }
        }

        public String UserDesignation
        {
            get { return pUserDesignation; }
            set
            {
                if (!value.Equals(pUserDesignation))
                {
                    pUserDesignation = value;
                    PropertyHasChanged("UserDesignation");
                }
            }
        }

        public Int32 CompanyId
        {
            get { return pCompanyId; }
            set
            {
                if (!value.Equals(pCompanyId))
                {
                    pCompanyId = value;
                    PropertyHasChanged("CompanyId");
                }
            }
        }

        public Boolean IsDeleted
        {
            get { return pIsDeleted; }
            set
            {
                if (!value.Equals(pIsDeleted))
                {
                    pIsDeleted = value;
                    PropertyHasChanged("IsDeleted");
                }
            }
        }

        #endregion

        #region Constructors
        public AppUser()
        {
        }

        public AppUser(string ConnectionString)
        {
            pConnectionString = ConnectionString;
            this.pIsDeleted = false; this.pCompanyId = 1;
        }
        #endregion

        #region Save Entity
        public static AppUser SaveEntity(AppUser AU)
        {
            if (AU.IsNew)
            {
                return AppUser.CreateEntity(AU);
            }
            else
            {
                return AppUser.UpdateEntity(AU);
            }
        }

        private static AppUser CreateEntity(AppUser AU)
        {
            OleDbConnection Connection = new OleDbConnection(AU.pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
            OleDbTransaction transaction = null;
            try
            {

                if (String.IsNullOrEmpty(AU.pLogInName))
                {
                    throw new ExceptionWithControl("", "", "Login Name Required.", "txtUserName");
                }

               if (String.IsNullOrEmpty(AU.pLogInPassword))
                {
                    throw new ExceptionWithControl("", "", "Login Password Required.", "txtUserPassword");
                }

                Connection.Open();

                transaction = Connection.BeginTransaction();
                cmdCommand.Transaction = transaction;
                Access2003SqlCommander sqlFunction = new Access2003SqlCommander(cmdCommand);

                if (sqlFunction.SearchString("Select LogInName from tblUserDetails Where  LogInName='"+ AU.pLogInName +"' AND CompanyId="+ AU.pCompanyId +" AND IsDeleted=False"))
                {
                    throw new ExceptionWithControl("", "", "Login name already in use.", "txtUserName");
                }

                AU.pUserId = sqlFunction.CreateNewId("tblUserDetails", "UserId");
                sqlFunction.InsertRecord("INSERT INTO tblUserDetails(UserId, LogInName, LogInPassword, FullName, UserDesignation, CompanyId, IsDeleted) VALUES(" + AU.pUserId + ",'" + AU.pLogInName + "','" + AU.pLogInPassword + "','" + AU.pFullName + "','" + AU.pUserDesignation + "'," + AU.pCompanyId + "," + AU.pIsDeleted + ")");

                transaction.Commit();
                Connection.Close();
                sqlFunction.Dispose();
                AU.MarkOld();
                return AU;
            }
            catch (ExceptionWithoutControl WithoutControlException) { if (transaction != null) { transaction.Rollback(); } throw WithoutControlException; }
            catch (ExceptionWithControl WithControlException) { if (transaction != null) { transaction.Rollback(); } throw WithControlException; }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw ex;
            }
        }

        private static AppUser UpdateEntity(AppUser AU)
        {
            OleDbConnection Connection = new OleDbConnection(AU.pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
            OleDbTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdCommand.Transaction = transaction;
                Access2003SqlCommander sqlFunction = new Access2003SqlCommander(cmdCommand);
                sqlFunction.UpdateRecord("UPDATE tblUserDetails SET LogInName='" + AU.pLogInName + "', LogInPassword='" + AU.pLogInPassword + "', FullName='" + AU.pFullName + "', UserDesignation='" + AU.pUserDesignation + "', CompanyId=" + AU.pCompanyId + ", IsDeleted=" + AU.pIsDeleted + "  WHERE UserId=" + AU.pUserId + "");

                transaction.Commit();
                Connection.Close();
                sqlFunction.Dispose();
                AU.MarkClean();
                return AU;
            }
            catch (ExceptionWithoutControl WithoutControlException) { if (transaction != null) { transaction.Rollback(); } throw WithoutControlException; }
            catch (ExceptionWithControl WithControlException) { if (transaction != null) { transaction.Rollback(); } throw WithControlException; }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw ex;
            }
        }

        #endregion

        #region Read Entity

        public static AppUser FillEntity(OleDbDataReader Reader)
        {
            AppUser AU = new AppUser();
            AU.pUserId = Convert.ToInt32(Reader["UserId"]);
            AU.pLogInName = Reader["LogInName"].ToString();
            AU.pLogInPassword = Reader["LogInPassword"].ToString();
            AU.pFullName = Reader["FullName"].ToString();
            AU.pUserDesignation = Reader["UserDesignation"].ToString();
            AU.pCompanyId = Convert.ToInt32(Reader["CompanyId"]);
            AU.pIsDeleted = Convert.ToBoolean(Reader["IsDeleted"]);
            AU.MarkOld();
            return AU;
        }

        public static AppUser GetEntity(int userid, string ConnectionString)
        {
            AppUser AU = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                Connection.Open();
                AU = AppUser.GetEntity(userid, Connection);
                AU.pConnectionString = ConnectionString;
                Connection.Close();
            }
            return AU;
        }

        public static AppUser GetEntity(int userid, OleDbConnection Connection)
        {
            AppUser AU = null;
            string sqlSelect = "SELECT UserId, LogInName, LogInPassword, FullName, UserDesignation, CompanyId, IsDeleted FROM tblUserDetails WHERE UserId=" + userid + "";
            using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
            {
                OleDbDataReader Reader = cmd.ExecuteReader();
                if (Reader.HasRows)
                {
                    Reader.Read();
                    AU = FillEntity(Reader);
                }
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }
            }
            return AU;
        }

        public static List<AppUser> GetEntityList(string ConnectionString)
        {
            List<AppUser> AppUserList = new List<AppUser>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  UserId, LogInName, LogInPassword, FullName, UserDesignation, CompanyId, IsDeleted FROM tblUserDetails ORDER BY ";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        AppUser AU = FillEntity(Reader);
                        AU.pConnectionString = ConnectionString;
                        AppUserList.Add(AU);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return AppUserList;
        }

        public static List<AppUser> GetComboList(string ConnectionString)
        {
            List<AppUser> AppUserList = new List<AppUser>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  UserId, LogInName, LogInPassword, FullName, UserDesignation, CompanyId, IsDeleted FROM tblUserDetails ORDER BY ";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        AppUser AU = FillEntity(Reader);
                        AU.pConnectionString = ConnectionString;
                        AppUserList.Add(AU);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return AppUserList;
        }

        public static DataTable GetEntityTable(string ConnectionString)
        {
            DataTable AppUserTable = new DataTable();
            string sqlSelect = "SELECT  UserId, LogInName, FullName, UserDesignation FROM tblUserDetails Where IsDeleted=False  ORDER BY LogInName asc";
            using (OleDbDataAdapter daData = new OleDbDataAdapter(sqlSelect, ConnectionString))
            {
                daData.Fill(AppUserTable);
            }
            return AppUserTable;
        }

        #endregion

        #region Delete Entity
        public static void DeleteEntity(AppUser AU)
        {
            OleDbConnection Connection = new OleDbConnection(AU.pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
            OleDbTransaction transaction = null;
            try
            {
                if (AU.pUserId==1)
                {
                    throw new ExceptionWithControl("", "", "Admin user can not be deleted.", "txtUserName");
                }

                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdCommand.Transaction = transaction;
                Access2003SqlCommander sqlFunction = new Access2003SqlCommander(cmdCommand);
                sqlFunction.UpdateRecord("UPDATE tblUserDetails SET IsDeleted=True  WHERE UserId=" + AU.pUserId + "");

                transaction.Commit();
                Connection.Close();
                sqlFunction.Dispose();
            }
            catch (ExceptionWithoutControl WithoutControlException) { if (transaction != null) { transaction.Rollback(); } throw WithoutControlException; }
            catch (ExceptionWithControl WithControlException) { if (transaction != null) { transaction.Rollback(); } throw WithControlException; }
            catch (Exception ex) { if (transaction != null) { transaction.Rollback(); } throw ex; }
        }

        #endregion

        #region Utility
        public override string ToString()
        {
            return ".......";
        }
        public void SetConnectionString(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }

        #endregion

    }
}