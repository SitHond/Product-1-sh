
using DBShop.Models;
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
        public void GetListViev()
        {
            var context = DbContext.Context;
            List<ItemList> prods = context.itemLists.ToList();
            listView.ItemsSource = prods;
        }
        public CatalogItems()
        {
            InitializeComponent();

            GetListViev();

            if (CurrentUser.AuthUser.IsAdmin == true)
            {
                TextProver.Content = "Админ";
                TextProver.Visibility = Visibility.Visible;
                AdminButton.Visibility = Visibility.Visible;  
            }
            else if (CurrentUser.AuthUser.IsManager == true)
            {
                TextProver.Content = "Менеджер";
                TextProver.Visibility = Visibility.Visible;
                AdminButton.Visibility = Visibility.Visible;
            }
            else if (CurrentUser.AuthUser.IsGuest == true)
            {
                TextProver.Content = "Гость";
                TextProver.Visibility = Visibility.Visible;
                AdminButton.Visibility = Visibility.Collapsed;
            }
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminZone());
        }

        private void ExitAcc_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Auth());
        }

        private void AddBuket_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ItemList prod = (ItemList)button.Tag;

            if (prod != null)
            {
                var currentUser = CurrentUser.AuthUser;

                if (currentUser != null)
                {
                    // Получаем доступное количество товара из таблицы ItemList
                    int availableQuantity = prod.count;

                    // Проверяем, достаточно ли товара для добавления в корзину
                    if (availableQuantity > 0)
                    {
                        // Создаем запись UserToItem для добавления в корзину
                        UserToItem userToItem = new UserToItem
                        {
                            Users = currentUser,
                            Item = prod
                        };

                        // Добавляем запись в корзину
                        DbContext.Context.userToItems.Add(userToItem);
                        DbContext.Context.SaveChanges();

                        // Уменьшаем количество товара в базе данных на 1
                        prod.count--;

                        // Обновляем список товаров в корзине
                        GetListViev();
                    }
                    else
                    {
                        MessageBox.Show("Извините, этот товар временно недоступен.");
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь не авторизован.");
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент для добавления.");
            }
        }


        private void OpenBuket_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new basket());
        }
    }
}
