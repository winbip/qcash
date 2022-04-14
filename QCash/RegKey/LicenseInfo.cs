using System;
using System.Management;
using System.Text;

namespace RegKey
{
    public class LicenseInfo
    {
        #region Private Fields
        private string CalculatedLicenseKey;
        private bool pIsRegistered;
        private string pProductKey;
        private char[] separators;
        private string SuppliedLicenseKey;
        #endregion

        #region Public Properties

        public bool IsRegistered
        {
            get
            {
                return this.pIsRegistered;
            }
        }

        public string ProductKey
        {
            get
            {
                return this.pProductKey;
            }
        }

        #endregion

        #region Constructors

        public LicenseInfo(string LicenseKey, string ApplicationName)
        {
            int num;
            string str2;
            byte[] bytes;
            this.separators = new char[] { ' ', '.', ',', ':', '-', '_', '/', '\\', '(', ')', '{', '}', '[', ']', '&' };
            this.SuppliedLicenseKey = string.Empty;
            this.CalculatedLicenseKey = string.Empty;
            this.SuppliedLicenseKey = LicenseKey;
            this.pProductKey = string.Empty;
            this.pIsRegistered = false;

            string data = this.GetComputerSystemInfo() + this.GetOperatingSystemInfo() + this.GetBiosInfo() + this.GetMotherboardInfo() + this.GetProcessorInfo() + this.GetLogicalDiskInfo() + this.GetVideoControllerInfo();// +this.GetNetworkAdapterInfo();

            this.pProductKey = this.ExtractProductKey(data, 0);

            //-->Note- When a client send me ProductKey, i will need this code block.
            for (num = 0; num < this.pProductKey.Length; num++)
            {
                str2 = this.pProductKey.Substring(num, 1);
                bytes = Encoding.ASCII.GetBytes(str2);
                foreach (byte num2 in bytes)
                {
                    CalculatedLicenseKey = CalculatedLicenseKey + num2.ToString();
                }
            }

            CalculatedLicenseKey = ExtractLicenseKey(CalculatedLicenseKey, 0);

            for (num = 0; num < ApplicationName.Length; num++)
            {
                str2 = ApplicationName.Substring(num, 1);
                bytes = Encoding.ASCII.GetBytes(str2);
                foreach (byte num2 in bytes)
                {
                    CalculatedLicenseKey = this.CalculatedLicenseKey + num2.ToString();
                }
            }
            //<--Note- When a client send me ProductKey, i will need this code block.

            if (CalculatedLicenseKey.Equals(SuppliedLicenseKey))
            {
                pIsRegistered = true;
            }
        }

        #endregion

        private string ExtractLicenseKey(string data, int StartingPosition)
        {
            string str = string.Empty;
            int length = data.Length;
            if (length > 25)
            {
                int num = length / 3;
                if (num > 25)
                {
                    for (int i = StartingPosition; i < length; i += 3)
                    {
                        str = str + data.Substring(i, 1);
                    }
                    this.ExtractLicenseKey(str, StartingPosition++);
                    return str;
                }
                return data;
            }
            return data;
        }

        private string ExtractProductKey(string data, int StartingPosition)
        {
            string str = string.Empty;
            int length = data.Length;
            if (length > 25)
            {
                int num = length / 3;
                if (num > 25)
                {
                    for (int i = StartingPosition; i < length; i += 3)
                    {
                        str = str + data.Substring(i, 1);
                    }
                    this.ExtractProductKey(str, StartingPosition++);
                    return str;
                }
                return data;
            }
            return data;
        }

        private string GetBiosInfo()
        {
            try
            {
                string str = string.Empty;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\CIMV2", "SELECT * FROM Win32_BIOS");
                foreach (ManagementObject obj2 in searcher.Get())
                {
                    if (obj2["BIOSVersion"] == null)
                    {
                        str = str + obj2["BIOSVersion"].ToString();
                    }
                    else
                    {
                        string[] strArray = (string[])obj2["BIOSVersion"];
                        foreach (string str2 in strArray)
                        {
                            str = str + str2;
                        }
                    }
                    str = str + ((obj2["Manufacturer"] == null) ? string.Empty : obj2["Manufacturer"].ToString());
                    str = str + ((obj2["SerialNumber"] == null) ? string.Empty : obj2["SerialNumber"].ToString());
                    str = str + ((obj2["Version"] == null) ? string.Empty : obj2["Version"].ToString());
                }
                string[] strArray2 = str.Split(this.separators, StringSplitOptions.RemoveEmptyEntries);
                return string.Join(string.Empty, strArray2);
            }
            catch (ManagementException)
            {
                return string.Empty;
            }
        }

        private string GetComputerSystemInfo()
        {
            try
            {
                string str = string.Empty;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\CIMV2", "SELECT * FROM Win32_ComputerSystem");
                foreach (ManagementObject obj2 in searcher.Get())
                {
                    str = str + ((obj2["Manufacturer"] == null) ? string.Empty : obj2["Manufacturer"].ToString());
                    str = str + ((obj2["Model"] == null) ? string.Empty : obj2["Model"].ToString());
                    str = str + ((obj2["TotalPhysicalMemory"] == null) ? string.Empty : obj2["TotalPhysicalMemory"].ToString());
                }
                string[] strArray = str.Split(this.separators, StringSplitOptions.RemoveEmptyEntries);
                return string.Join(string.Empty, strArray);
            }
            catch (ManagementException)
            {
                return string.Empty;
            }
        }

        private string GetLogicalDiskInfo()
        {
            try
            {
                string str = string.Empty;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\CIMV2", "SELECT * FROM Win32_LogicalDisk");
                int num = 0;
                foreach (ManagementObject obj2 in searcher.Get())
                {
                    if (num < 2)
                    {
                        str = str + ((obj2["VolumeSerialNumber"] == null) ? string.Empty : obj2["VolumeSerialNumber"].ToString());
                    }
                    num++;
                }
                string[] strArray = str.Split(this.separators, StringSplitOptions.RemoveEmptyEntries);
                return string.Join(string.Empty, strArray);
            }
            catch (ManagementException)
            {
                return string.Empty;
            }
        }

        private string GetMotherboardInfo()
        {
            try
            {
                string str = string.Empty;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\CIMV2", "SELECT * FROM Win32_BaseBoard");
                foreach (ManagementObject obj2 in searcher.Get())
                {
                    str = str + ((obj2["Manufacturer"] == null) ? string.Empty : obj2["Manufacturer"].ToString());
                    str = str + ((obj2["Product"] == null) ? string.Empty : obj2["Product"].ToString());
                }
                string[] strArray = str.Split(this.separators, StringSplitOptions.RemoveEmptyEntries);
                return string.Join(string.Empty, strArray);
            }
            catch (ManagementException)
            {
                return string.Empty;
            }
        }

        //Note- it has been removed from method call, because it creates problem while internet modem is online.
        private string GetNetworkAdapterInfo()
        {
            try
            {
                string str = string.Empty;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\CIMV2", "SELECT * FROM Win32_NetworkAdapter");
                foreach (ManagementObject obj2 in searcher.Get())
                {
                    if (obj2 != null)
                    {
                        str = str + ((obj2["GUID"] == null) ? string.Empty : obj2["GUID"].ToString());
                        str = str + ((obj2["MACAddress"] == null) ? string.Empty : obj2["MACAddress"].ToString());
                    }
                }
                string[] strArray = str.Split(this.separators, StringSplitOptions.RemoveEmptyEntries);
                return string.Join(string.Empty, strArray);
            }
            catch (ManagementException)
            {
                return string.Empty;
            }
        }

        private string GetOperatingSystemInfo()
        {
            try
            {
                string str = string.Empty;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\CIMV2", "SELECT * FROM Win32_OperatingSystem");
                foreach (ManagementObject obj2 in searcher.Get())
                {
                    str = str + ((obj2["BuildNumber"] == null) ? string.Empty : obj2["BuildNumber"].ToString());
                    str = str + ((obj2["SerialNumber"] == null) ? string.Empty : obj2["SerialNumber"].ToString());
                    str = str + ((obj2["Version"] == null) ? string.Empty : obj2["Version"].ToString());
                }
                string[] strArray = str.Split(this.separators, StringSplitOptions.RemoveEmptyEntries);
                return string.Join(string.Empty, strArray);
            }
            catch (ManagementException)
            {
                return string.Empty;
            }
        }

        private string GetProcessorInfo()
        {
            try
            {
                string str = string.Empty;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\CIMV2", "SELECT * FROM Win32_Processor");
                foreach (ManagementObject obj2 in searcher.Get())
                {
                    str = str + ((obj2["Caption"] == null) ? string.Empty : obj2["Caption"].ToString());
                    str = str + ((obj2["Name"] == null) ? string.Empty : obj2["Name"].ToString());
                    str = str + ((obj2["ProcessorId"] == null) ? string.Empty : obj2["ProcessorId"].ToString());
                }
                string[] strArray = str.Split(this.separators, StringSplitOptions.RemoveEmptyEntries);
                return string.Join(string.Empty, strArray);
            }
            catch (ManagementException)
            {
                return string.Empty;
            }
        }

        private string GetVideoControllerInfo()
        {
            try
            {
                string str = string.Empty;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\CIMV2", "SELECT * FROM Win32_VideoController");
                foreach (ManagementObject obj2 in searcher.Get())
                {
                    str = str + ((obj2["DriverVersion"] == null) ? string.Empty : obj2["DriverVersion"].ToString());
                    str = str + ((obj2["PNPDeviceID"] == null) ? string.Empty : obj2["PNPDeviceID"].ToString());
                }
                string[] strArray = str.Split(this.separators, StringSplitOptions.RemoveEmptyEntries);
                return string.Join(string.Empty, strArray);
            }
            catch (ManagementException)
            {
                return string.Empty;
            }
        }


    }
}
