using BookStore.Infrastructure;
using BookStore.Infrastructure.Database;
using BookStore.Windows.Chapters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookStore.Windows.Cards
{
    /// <summary>
    /// Логика взаимодействия для ProductCard.xaml
    /// </summary>
    public partial class ProductCard : Window
    {
        private Product product = new Product();
        private BookStoreRepository bookStoreRepository;
        public ProductCard(Product selectedProduct)
        {
            InitializeComponent();

            if (selectedProduct != null)
                product = selectedProduct;
            DataContext = product;
        }
        /*private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string fd = bookStoreRepository.GetByAddress().ToString();
            List<BookStoreRepository> products = new List<BookStoreRepository>();
            bookStoreRepository = new BookStoreRepository();
            Stores.ItemsSource = ;
        }*/

        private void Undo_Btn(object sender, RoutedEventArgs e)
        {
            ProductsWindow productsWindow = new ProductsWindow();
            productsWindow.Show();
            Close();
        }

        private void Save_Btn(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(product.name))
                sb.AppendLine("Введите название!");
            if (product.price == null)
                sb.AppendLine("Введите цену!");
            if (product.quantity == null)
                sb.AppendLine("Введите количество!");
            if (product.store_id == null)
                sb.AppendLine("Введите ID магазина!");
            if (product.product_category_id == null)
                sb.AppendLine("Введите ID категории!");
            if (product.genre_id == null)
                sb.AppendLine("Введите ID жанра!");

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
                return;
            }
            if (product.id == 0)
                Context.GetContext().Product.Add(product);
            try
            {
                Context.GetContext().SaveChanges();
                MessageBox.Show("Данные были успешно добавлены");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
