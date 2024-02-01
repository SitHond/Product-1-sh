
using Product_1_sh.Controller;
using System.Windows;
using System.Windows.Controls;
using static Product_1_sh.Pages.Auth;

namespace Product_1_sh.Pages
{
    /// <summary>
    /// Логика взаимодействия для CatalogItems.xaml
    /// </summary>
    /// 
    public partial class CatalogItems : Page
    {
        private readonly AuthorizationController authorizationController;

        public CatalogItems()
        {
            InitializeComponent();
            if (CurrentUser.AuthUser.IsAdmin == true)
            {
                TextProver.Content = "Админ";
                TextProver.Visibility = Visibility.Visible;
            }
            else if (CurrentUser.AuthUser.IsManager == true)
            {
                TextProver.Content = "Менеджер";
                TextProver.Visibility = Visibility.Visible;
            }
            else if (CurrentUser.AuthUser.IsGuest == true)
            {
                TextProver.Content = "Гость";
                TextProver.Visibility = Visibility.Visible;
            }
        }
    }
}
