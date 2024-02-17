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
        private void ShowCartItems()
        {
            // Получаем текущего авторизованного пользователя
            var currentUser = CurrentUser.AuthUser;

            if (currentUser != null)
            {
                // Получаем все записи из таблицы UserToItem для текущего пользователя
                List<UserToItem> userCartItems = DbContext.Context.userToItems.Where(uti => uti.Users.Id == currentUser.Id).ToList();

                // Создаем список для хранения информации о товарах в корзине
                List<ItemList> cartItems = new List<ItemList>();

                // Для каждой записи UserToItem получаем соответствующий товар и добавляем его в список
                foreach (UserToItem userToItem in userCartItems)
                {
                    ItemList item = DbContext.Context.itemLists.FirstOrDefault(i => i.Id == userToItem.Item.Id);
                    if (item != null)
                    {
                        cartItems.Add(item);
                    }
                }
                // Обновляем источник данных ListView
                listView.ItemsSource = cartItems;
            }
            else
            {
                MessageBox.Show("Пользователь не авторизован.");
            }
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
            // Получаем кнопку, на которую было нажато
            Button button = (Button)sender;

            // Получаем товар, который нужно удалить, из параметра CommandParameter кнопки
            ItemList selectedItem = (ItemList)button.CommandParameter;

            if (selectedItem != null)
            {
                // Получаем текущего авторизованного пользователя
               var currentUser = CurrentUser.AuthUser;

                if (currentUser != null)
                {
                    // Находим соответствующую запись в таблице UserToItem для текущего пользователя и выбранного товара
                    UserToItem userCartItem = DbContext.Context.userToItems.FirstOrDefault(uti => uti.Users.Id == currentUser.Id && uti.Item.Id == selectedItem.Id);

                    if (userCartItem != null)
                    {
                        // Удаляем запись из базы данных
                        DbContext.Context.userToItems.Remove(userCartItem);
                        DbContext.Context.SaveChanges();
                        selectedItem.Count++;

                        // Обновляем содержимое корзины
                        ShowCartItems();
                    }
                    else
                    {
                        MessageBox.Show("Товар не найден в корзине текущего пользователя.");
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь не авторизован.");
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления.");
            }
        }


    }
}
