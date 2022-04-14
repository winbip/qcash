using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.ComponentModel;

using sCommonLib;
using sCommonLib.Exceptions;
using sCommonLib.Messages;

namespace CustomObjects
{
    public class UserLogIn
    {
        private string pConnectionString;


        public UserLogIn(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }

        public CurrentUser PerformLogIn(string LogInName, string LogInPassword, int CompanyId)
        {

            CurrentUser currentUser = new CurrentUser();

            OleDbConnection Connection = new OleDbConnection(pConnectionString);
            string sqlString = "SELECT tblUserDetails.UserId, tblUserDetails.LogInName, tblUserDetails.LogInPassword, tblUserDetails.FullName, tblUserDetails.UserDesignation, tblCompanyInfo.CompanyId, tblCompanyInfo.CompanyName, tblCompanyInfo.AddressLineOne, tblCompanyInfo.AddressLineTwo" +
                                " FROM tblCompanyInfo INNER JOIN tblUserDetails ON tblCompanyInfo.CompanyId = tblUserDetails.CompanyId" +
                                " WHERE tblUserDetails.LogInName='" + LogInName + "' AND tblUserDetails.LogInPassword='" + LogInPassword + "' AND tblCompanyInfo.CompanyId=" + CompanyId + "";

            OleDbCommand cmdLogIn = new OleDbCommand(sqlString, Connection);

            try
            {
                Connection.Open();
                OleDbDataReader reader = cmdLogIn.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        currentUser.UserInformation.UserId = (int)reader["UserId"];
                        currentUser.UserInformation.LogInName = reader["LogInName"].ToString();
                        currentUser.UserInformation.LogInPassword = reader["LogInPassword"].ToString();
                        currentUser.UserInformation.FullName = reader["FullName"].ToString();
                        currentUser.UserInformation.UserDesignation = reader["UserDesignation"].ToString();
                        currentUser.CompanyInformation.CompanyId = (int)reader["CompanyId"];
                        currentUser.CompanyInformation.CompanyName = reader["CompanyName"].ToString();
                        currentUser.CompanyInformation.AddressLineOne = reader["AddressLineOne"].ToString();
                        currentUser.CompanyInformation.AddressLineTwo = reader["AddressLineTwo"].ToString();
                    }
                    OleDbCommand cmdPermission = new OleDbCommand("select PermissionId from tblUserPermission where UserId=" + currentUser.UserInformation.UserId + "", Connection);
                    OleDbDataReader PermissionReader = cmdPermission.ExecuteReader();
                    while (PermissionReader.Read())
                    {
                        currentUser.PermissionInformation += PermissionReader["PermissionId"].ToString() + ",";
                    }
                    if (!PermissionReader.IsClosed)
                    {
                        PermissionReader.Close();
                    }
                }
                else { currentUser = null; } Connection.Close();

                if (!reader.IsClosed)
                {
                    reader.Close();
                }
                return currentUser;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
    }
}
