using DBShop.Models;
using System.Windows.Controls;
using static Product_1_sh.Pages.Auth;
using System.Windows;

namespace Product_1_sh.Pages
{
    /// <summary>
    /// Логика взаимодействия для basket.xaml
    /// </summary>
    public partial class basket : Page
    {
        public basket()
        {
            InitializeComponent();

            var currentUser = CurrentUser.AuthUser.Id;

            if (currentUser != null)
            {
                List<ItemList> items = GetItemsForUser(currentUser);

                listView.ItemsSource = items;
            }
            else
            {
                MessageBox.Show("Пользователь не найден.");
            }
        }

        private List<ItemList> GetItemsForUser(int currentUser)
        {
                return DbContext.Context.userToItems.Where(uti => uti.Users.Id == currentUser).Select(uti => uti.Item).ToList();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CatalogItems());
        }
    }
}
