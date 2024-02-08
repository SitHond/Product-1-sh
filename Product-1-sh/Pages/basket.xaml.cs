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
        public void GetDataGrid()
        {
            var context = DbContext.Context;
            List<ItemList> prods = context.itemLists.ToList();
            listView.ItemsSource = prods;
        }
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

        private List<ItemList> GetItemsForUser(int currentUser)
        {
            return DbContext.Context.userToItems.Where(uti => uti.Users.Id == currentUser).Select(uti => uti.Item).ToList();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CatalogItems());
        }

        private void DelItem_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            UserToItem userToItem = (UserToItem)button.Tag;

            if (userToItem != null)
            {
                // Получаем текущего авторизованного пользователя
                var currentUser = CurrentUser.AuthUser;

                if (currentUser != null)
                {
                    // Удаляем элемент из таблицы UserToItem по его идентификатору
                    var itemDel = DbContext.Context.userToItems.FirstOrDefault(uti => uti.Id == userToItem.Id);
                    if (itemDel != null)
                    {
                        DbContext.Context.userToItems.Remove(itemDel);
                        DbContext.Context.SaveChanges();
                        GetDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("Элемент не найден.");
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь не авторизован.");
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления.");
            }
        }

    }
}
