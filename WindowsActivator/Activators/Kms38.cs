using iNKORE.UI.WPF.Modern.Controls;
using System.IO;
using WindowsActivator.Models;
using WindowsActivator.Services;
using WindowsActivator.Utils;

namespace WindowsActivator.Activators
{
    public class Kms38
    {
        public static async Task ActivateWindows()
        {
            string os = OSHelper.GetOSDetail();
            string edition = os.Length > 11 ? os[11..] : os; // safer substring
            string kmsTicketPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tickets", "KMS38.xml");

            Kms38GenericKeyModel? kms38GenericKey = Kms38GenericKeyService.GetByEdition(edition);

            if (kms38GenericKey != null)
            {
                string key = kms38GenericKey.GenericKey;
                string command = $"cscript //B //NOLOGO %windir%\\system32\\slmgr.vbs /ipk {key}";

                // install generic key
                await ConsoleHelper.RunCommandAsync(command, true);

                // copy the ticket
                bool copyResult = FileSystem.CopyFileToDirectory(kmsTicketPath, "C:\\", true, false);

                if (copyResult)
                {
                    string cmd = "clipup.exe -v -o -altto C:\\";
                    string res = await ConsoleHelper.RunCommandAsync(cmd);

                    // check for success
                    if (!string.IsNullOrWhiteSpace(res) &&
                        (res.Contains("Successfully converted", StringComparison.OrdinalIgnoreCase) &&
                         res.Contains("Done.", StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("Windows Activation Successful.", "Windows Activation");
                    }
                    else
                    {
                        MessageBox.Show($"Got an error while activating with KMS38.", "Windows Activation");
                    }

                    // delete the ticket after processing
                    string ticketPath = Path.Combine("C:\\", "KMS38.xml");
                    if (File.Exists(ticketPath))
                        File.Delete(ticketPath);
                }
                else
                {
                    MessageBox.Show("Failed to copy KMS ticket.", "Windows Activation");
                }
            }
            else
            {
                MessageBox.Show($"No generic key found for edition: {edition}", "Windows Activation");
            }
        }
    }
}
