
using Product_1_sh.Pages;
using System.Windows;

namespace Product_1_sh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Nav.NavigationService.Navigate(new Auth());
        }
    }
}