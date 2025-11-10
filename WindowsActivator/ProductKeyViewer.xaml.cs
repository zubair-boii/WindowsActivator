using System.Windows;
using System.Windows.Input;

namespace WindowsActivator
{
    /// <summary>
    /// Interaction logic for ProductKeyViewer.xaml
    /// </summary>
    public partial class ProductKeyViewer : Window
    {
        public ProductKeyViewer()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
