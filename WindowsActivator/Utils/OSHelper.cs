using Microsoft.Win32;
using System.Management;

namespace WindowsActivator.Utils
{
    class OSHelper
    {
        static public string GetOSDetail()
        {
            try
            {
                using (var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
                {
                    string? productName = key?.GetValue("ProductName")?.ToString();
                    return productName ?? "Unknown Windows Edition";
                }
            }
            catch (Exception e)
            {
                return "Unknown Windows Edition";
            }
        }

        static public string GetActivationStatus()
        {

            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT LicenseStatus, Name FROM SoftwareLicensingProduct WHERE PartialProductKey IS NOT NULL AND Name LIKE '%Windows%'"))
                {
                    foreach (var obj in searcher.Get())
                    {
                        int status = Convert.ToInt32(obj["LicenseStatus"]);
                        return status switch
                        {
                            0 => "Unlicensed ❌",
                            1 => "Licensed ✔",
                            2 => "Out-of-Box Grace Period",
                            3 => "Out-of-Tolerance Grace Period",
                            4 => "Non-Genuine Grace Period",
                            5 => "Notification",
                            6 => "Extended Grace Period",
                            _ => "Unknown"
                        };
                    }
                }
            }
            catch
            {
                return "Unable to determine activation stauts";
            }

            return "Unknown";
        }
    }
}
