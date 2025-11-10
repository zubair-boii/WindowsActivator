using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WindowsActivator.Activators;
using WindowsActivator.Utils;

namespace WindowsActivator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            hwidRB.IsChecked = true;

            string os = OSHelper.GetOSDetail();
            OSValue.Text = os;

            string activation = OSHelper.GetActivationStatus();
            if (activation.Contains("Licensed"))
            {
                actValue.Text = activation;
            }
            else if (activation.Contains("Unlicensed"))
            {
                actValue.Text = activation;
                actValue.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                actValue.Text = activation.ToString();
                actValue.Foreground = new SolidColorBrush(Colors.AliceBlue);
            }
        }

        private void SimpleStackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            //var diaglog = new ContentDialog
            //{
            //    Title = "Confirm Exit",
            //    Content = "Are you Sure you want to exit the app?",
            //    PrimaryButtonText = "Exit",
            //    CloseButtonText = "Cancel",
            //    DefaultButton = ContentDialogButton.Close,
            //};

            //var result = await diaglog.ShowAsync();

            //if (result == ContentDialogResult.Primary)
            //{
            //    Close();
            //}

            Close();
        }

        private RadioButton? FindSelectedRadioButton(List<RadioButton> radioButtons)
        {
            foreach (RadioButton rb in radioButtons)
            {
                if (rb.IsChecked == true)
                {
                    return rb;
                }
            }

            return null;
        }

        private void minButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaxButton_Click(object sender, RoutedEventArgs e)
        {


            if (WindowState != WindowState.Maximized)
            {
                WindowState = WindowState.Maximized;
                MaxBtnText.Text = "❐";
            }
            else
            {
                WindowState = WindowState.Normal;
                MaxBtnText.Text = "⬜";
            }
        }

        private async void ActivateBtn_Click(object sender, RoutedEventArgs e)
        {
            List<RadioButton> radioButtons = new List<RadioButton> { hwidRB, kms38RB, ohookRB, tsforgeRB };

            RadioButton? selectedRadioButton = FindSelectedRadioButton(radioButtons);

            switch (selectedRadioButton?.Name)
            {
                case nameof(hwidRB):
                    Hwid.ActivateWindows();
                    break;
                case nameof(kms38RB):
                    await Kms38.ActivateWindows();
                    break;
                case nameof(ohookRB):
                    await Ohook.ActivateWindowsAsync();
                    break;

                case nameof(tsforgeRB):
                    await TSforge.ActivateWindowsAsync();
                    break;
                default:
                    iNKORE.UI.WPF.Modern.Controls.MessageBox.Show("No option selected");
                    break;
            }
        }
    }
}