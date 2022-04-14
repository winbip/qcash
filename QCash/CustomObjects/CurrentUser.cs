using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CustomObjects
{
    public class CurrentUser
    {
        #region PrivateVariables
        private UserDetails pUserInformation = new UserDetails();
        private CompanyInfo pCompanyInformation = new CompanyInfo();
        private string pPermissionInformation = string.Empty;
        #endregion

        #region PublicProperties
        public UserDetails UserInformation
        {
            get { return pUserInformation; }
            set
            {
                if (!value.Equals(pUserInformation))
                {
                    pUserInformation = value;
                    // MarkDirty();
                    // PropertyHasChanged("UserInformation");

                }
            }
        }

        public CompanyInfo CompanyInformation
        {
            get { return pCompanyInformation; }
            set
            {
                if (!value.Equals(pCompanyInformation))
                {
                    pCompanyInformation = value;
                    // MarkDirty();
                    //PropertyHasChanged("CompanyInformation");
                }
            }
        }

        public string PermissionInformation
        {
            get { return pPermissionInformation; }
            set
            {
                if (!value.Equals(pPermissionInformation))
                {
                    pPermissionInformation = value;
                    //MarkDirty();
                    // PropertyHasChanged("PermissionInformation");
                }
            }
        }

        #endregion

        #region Constructors
        public CurrentUser()
        {
        }

        public CurrentUser(UserDetails User, CompanyInfo Company)
        {
            pUserInformation = User; pCompanyInformation = Company;
        }

        #endregion

        public override string ToString()
        {
            return ".......";
        }


        public bool FindPermission(string MyStr)
        {
            //0=SuperAdmin, 1=Admin. Don't check their permission. They are permitted for all tasks.
            if (UserInformation.UserId < 2)
            {
                return true;
            }
            else
            {
                string[] Src;

                //  If PermissionString.IndexOf(MyStr) < 0 Then
                if (PermissionInformation.IndexOf(MyStr) == -1)
                {
                    // Not found
                    return false;
                }
                else
                {
                    Src = PermissionInformation.Split(new char[] { ',' });
                    bool FoundPermission = false;
                    foreach (string s in Src)
                    {
                        if (MyStr == s)
                        // Found
                        {
                            FoundPermission = true;
                        }
                    }
                    return FoundPermission;
                }
            }

        }


        /*Note- Check permission code template for caller form
                if (GlobalVariables.currentUser == null)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Unauthorized Access", "You are currently not logged in. Please login first."));
                    return;
                }
                else
                {
                    if (!GlobalVariables.currentUser.FindPermission("1"))
                    {
                        CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Unauthorized Access", "You are authorized. Contact your admin."));
                        return;
                    }
                }
        */

    }
}
