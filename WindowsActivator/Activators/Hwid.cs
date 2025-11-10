using iNKORE.UI.WPF.Modern.Controls;
using System.Windows;
using System.Windows.Controls;
using WindowsActivator.Models;
using WindowsActivator.Services;
using WindowsActivator.Utils;

namespace WindowsActivator.Activators
{
    public class Hwid
    {
        public static async void ActivateWindows()
        {
            // get the windows version
            string os = OSHelper.GetOSDetail();
            string edition = os.Remove(0, 11);

            // get the corresponding ticket
            HwidKeyInfo? keyInfo = HwidKeyService.GetByEdition(edition);

            if (keyInfo != null)
            {
                // full ticket file path in the system folder
                string ticketPath = keyInfo.Ticket;

                // paste the ticket
                string destPath = FileSystem.GetGenuineTicketFolder();

                // activate the windows
                bool result = FileSystem.CopyFileToDirectory(ticketPath, destPath, true, false);
                if (result)
                {
                    iNKORE.UI.WPF.Modern.Controls.MessageBox.Show("Process Complete. Now you can copy the key", "Windows Activation Info");
                }

                // show user product key to activate windows
                if (result)
                {
                    var textBox = new TextBox()
                    {
                        Text = keyInfo.Key,
                        IsReadOnly = true,
                        Margin = new Thickness(0, 0, 8, 0),
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 15,
                        Padding = new Thickness(5)
                    };

                    var dialog = new ContentDialog()
                    {
                        Title = "Your Product Key",
                        Content = textBox,
                        SecondaryButtonText = "Close",
                        PrimaryButtonText = "Copy Key",
                        DefaultButton = ContentDialogButton.Primary,
                    };

                    var dialogResult = await dialog.ShowAsync();

                    if (dialogResult == ContentDialogResult.Primary)
                    {
                        Clipboard.SetText(keyInfo.Key);
                        var confirmDialog = new ContentDialog()
                        {
                            Title = "Copied!",
                            Content = "The Product key copied to clipboard. Now you can activate you windows.\n\n1: Go to Activation Settings \n2: Click on \" Change product key\" or something similar \n3: Paste key and activate windows",
                            CloseButtonText = "Close"
                        };
                        await confirmDialog.ShowAsync();

                    }
                    else
                    {
                        var confirmDialog = new ContentDialog()
                        {
                            Title = "Done!",
                            Content = "Now you can activate you windows.\n\n1: Go to Activation Settings \n2: Click on \" Change product key\" or something similar \n3: Paste key you copied and activate windows",
                            CloseButtonText = "Close"
                        };
                        await confirmDialog.ShowAsync();
                    }

                }
            }
            else
            {
                iNKORE.UI.WPF.Modern.Controls.MessageBox.Show("Edition not found!", "Error");
            }

        }
    }
}
