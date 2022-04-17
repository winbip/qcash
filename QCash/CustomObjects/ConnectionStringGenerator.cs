using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CustomObjects
{
    public class ConnectionStringGenerator
    {
        //TODO: Change DatabasePrifix
        public static string DatabasePrefix = "QCash"; //used before operating year.

        public static string GenerateForAccess2003(string DatabaseDirectory, string OperatingYear)
        {
            string ProviderInfo = "Microsoft.Jet.OLEDB.4.0"; //for Access 2003
            //string ProviderInfo = "Microsoft.ACE.OLEDB.12.0"; // for Access 2007

            string DatabaseName = DatabasePrefix + OperatingYear + ".mdb";
            //string DatabaseName = DatabasePrefix + OperatingYear + ".accdb";
            string DatabasePassword = "BigBoss";

            //string DatabaseSecurityInfo = "Persist Security Info =False"; //if no password
            string DatabaseSecurityInfo = "Jet OLEDB:Database Password=" + DatabasePassword + ""; //if password

            string ConString = string.Empty;
            ConString = "Provider=" + ProviderInfo + ";Data Source= " + DatabaseDirectory + "\\" + DatabaseName + ";" + DatabaseSecurityInfo + ";";

            return ConString;

            /*
        '------------------------------------------------------------
        'dbLocation = "\\" & computername & "\Employee\Employee.mdb"
        'dbLocation ="\\sumon\NUCS (D)\SpdSoft2009\Database\spdsys.mdb"
        '------------------------------------------------------------
             */
        }

        public static string GenerateForSQLite3(string DatabaseDirectory, string OperatingYear)
        {
            //Data Source=c:\mydb.db;Version=3;


            string DatabaseName = DatabasePrefix + OperatingYear + ".db";
            //string DatabasePassword = "BigBoss";


            string ConString = string.Empty;
            ConString = "Data Source= " + DatabaseDirectory + "\\" + DatabaseName + "; Version=3;";

            return ConString;

            /*
        '------------------------------------------------------------
        'dbLocation = "\\" & computername & "\Employee\Employee.mdb"
        'dbLocation ="\\sumon\NUCS (D)\SpdSoft2009\Database\spdsys.mdb"
        '------------------------------------------------------------
             */
        }

        public static string GetDatabaseDirectory(string ServerName)
        {


            string DatabaseDirectory = string.Empty;

            if (ServerName.ToUpper() == "LOCAL")
            {
                DatabaseDirectory = Path.GetDirectoryName(typeof(ConnectionStringGenerator).Assembly.Location) + @"\Data";
            }
            else
            {
                DatabaseDirectory = @"\\" + ServerName + @"\Data";
            }

            return DatabaseDirectory;


        }

        public static string SQLServerInstanceName = "SQLEXPRESS";
        public string PortNumber = "";// or use ",2301"
        //    'Start Note
        //    '  MyConnectionString value will be set in this module for MS Access database
        //    '  MyConnectionString value will be set in frmStartupProgressBar from for SQLServer database
        //    'End Note


        #region Access_Databse_Connection_String
        //Public DBNameAndPath As String = Application.StartupPath & "\data\" & MyDatabaseName & ".mdb"
        //Public MyConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=   " & DBNameAndPath & ";Jet OLEDB:Database Password=123654;"
        #endregion

        #region SQL_Server_connection_string
        //For SQL Server in Network Environment by using Computer Name
        //"Data Source=" & ServerAddress & "\" & SQLServerInstanceName & "'; Database=" & MyDatabaseName & "; Integrated Security=SSPI; "
        //"Server=" & ServerAddress & "\" & SQLServerInstanceName & ";Database=" & MyDatabaseName & ";Trusted_Connection = True;" 

        //For SQL Server in Network Environment by using IP
        //"Data Source=" & ServerAddress & PortNumber & "\" & SQLServerInstanceName & "'; Database=" & MyDatabaseName & "; Integrated Security=SSPI; "
        //"Server=" & ServerAddress & PortNumber & "\" & SQLServerInstanceName & ";Database=" & MyDatabaseName & ";Trusted_Connection = True;"

        //For SQL Server in Locat Environment
        //"Data Source=.\" & SQLServerInstanceName & "; Database=" & MyDatabaseName & "; Integrated Security=SSPI; "
        //"Server=.\" & SQLServerInstanceName & ";Database=" & MyDatabaseName & ";Trusted_Connection = True;" 

        //For SQL Server in Local Environment and using AttachDBFileName
        // "Data Source=.\" & MyInstanceName & "; Initial Catalog=; Integrated Security=True; AttachDBFileName='" & DBNameAndPath & "';Timeout=60;Application Name=BMDA;"

        #endregion


    }
}
