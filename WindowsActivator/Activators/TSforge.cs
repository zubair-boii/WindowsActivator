using iNKORE.UI.WPF.Modern.Controls;
using System.IO;

namespace WindowsActivator.Activators
{
    public class TSforge
    {
        public static async Task ActivateWindowsAsync()
        {
            try
            {
                string fileName = "Activators\\tsforge_activation.cmd";
                string activationScript = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);




                await ConsoleHelper.RunCmdFileAsync(activationScript);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Got an error: \n{ex}", "Ohook Activation");
            }
        }
    }
}
