using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace sCommonLib
{
    class WindowsRegistryFunctions : IDisposable
    {
        private string MyKeyName;
        private RegistryKey MyRegistryKey;

        public string KeyName
        {
            get { return MyKeyName; }
            set { MyKeyName = value; }
        }

        public bool IsKeyFound()
        {
            MyRegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\" + MyKeyName, false);

            if (MyRegistryKey == null)
            {
                return false;
            }
            else
            {
                MyRegistryKey.Close();
                return true;
            }
        }

        public void CreateKey()
        {
            try
            {
                MyRegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
                MyRegistryKey.CreateSubKey(MyKeyName);
                MyRegistryKey.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteKey()
        {
            try
            {
                MyRegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
                MyRegistryKey.DeleteSubKey(MyKeyName);
                MyRegistryKey.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public bool IsValueNameFound(string ValueName)
        {
            MyRegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\", true);
            bool ValueNameFound = false;
            string[] ValueNames = MyRegistryKey.GetValueNames();
            foreach (string value in ValueNames)
            {
                if (value == ValueName)
                {
                    ValueNameFound = true;

                }
            }
            return ValueNameFound;
        }


        public void CreateValuePair(string ValueName, object ValueData, RegistryValueKind ValueType)
        {
            try
            {
                MyRegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\" + MyKeyName, true);
                MyRegistryKey.SetValue(ValueName, ValueData, ValueType);
                MyRegistryKey.Flush();
                MyRegistryKey.Close();
            }
            catch (Exception ex)
            { throw ex; }
        }


        public string ReadValueData(string ValueName)
        {
            MyRegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\" + MyKeyName, false);
            object ValueData;
            ValueData = MyRegistryKey.GetValue(ValueName);
            MyRegistryKey.Close();
            return ValueData.ToString();
        }
        public void UpdateValueData(string ValueName, object ValueData)
        {
            try
            {
                MyRegistryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\" + MyKeyName, true);
                MyRegistryKey.SetValue(ValueName, ValueData);
                MyRegistryKey.Flush();
                MyRegistryKey.Close();

            }
            catch (Exception ex)
            { throw ex; }
        }


        public void DeleteValuePair(string ValueName)
        {
            try
            {
                MyRegistryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\" + MyKeyName, false);
                MyRegistryKey.DeleteValue(ValueName);
                MyRegistryKey.Close();
            }
            catch (Exception ex)
            { throw ex; }
        }

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

        ~WindowsRegistryFunctions()
        {
            CleanUp(false);
        }

        #endregion
    }
}
