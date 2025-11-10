
using iNKORE.UI.WPF.Modern.Controls;
using System.IO;


namespace WindowsActivator.Activators
{
    public class Ohook
    {
        public static async Task ActivateWindowsAsync()
        {
            try
            {
                string fileName = "Activators\\ohook_activation.cmd";
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
