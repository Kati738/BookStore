using BookStore.Infrastructure.Consts;
using BookStore.Windows.Chapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientMainWindowWindow.xaml
    /// </summary>
    public partial class ClientMainMenuWindow : Window
    {
        public ClientMainMenuWindow()
        {
            InitializeComponent();

            Application.Current.Resources[UserInfoConsts.RoleId] = 1;
            Application.Current.Resources[UserInfoConsts.RoleName] = "Клиент";
            Application.Current.Resources[UserInfoConsts.UserName] = "Клиент";
        }

        private void Quit_Btn(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти из аккаунта?", "",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                EntryWindow entryWindow = new EntryWindow();
                Close();
                entryWindow.Show();
            }
        }

        private void Product_Btn(object sender, RoutedEventArgs e)
        {
            ProductsWindow productsWindow = new ProductsWindow();
            productsWindow.Show();
            Close();
        }

        private void Categories_Btn(object sender, RoutedEventArgs e)
        {
            CategoriesWindow categoriesWindow = new CategoriesWindow();
            categoriesWindow.Show();
            Close();
        }

        private void Discount_Btn(object sender, RoutedEventArgs e)
        {
            DiscountsWindow discountsWindow = new DiscountsWindow();
            discountsWindow.Show();
            Close();
        }

        private void Genres_Btn(object sender, RoutedEventArgs e)
        {
            GenresWindow genresWindow = new GenresWindow();
            genresWindow.Show();
            Close();
        }
    }
}
