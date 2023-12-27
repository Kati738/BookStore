using BookStore.Infrastructure;
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

namespace BookStore.Windows.Cards
{
    /// <summary>
    /// Логика взаимодействия для CategoryCard.xaml
    /// </summary>
    public partial class CategoryCard : Window
    {
        ProductCategory productCategory = new ProductCategory();
        public CategoryCard(ProductCategory selectedProductCategory)
        {
            InitializeComponent();

            if (selectedProductCategory != null)
                productCategory = selectedProductCategory;
            DataContext = productCategory;
        }

        private void Save_Btn(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(productCategory.name))
                sb.AppendLine("Введите название!");

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
                return;
            }
            if (productCategory.id == 0)
                Context.GetContext().ProductCategory.Add(productCategory);
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

        private void Undo_Btn(object sender, RoutedEventArgs e)
        {
            CategoriesWindow categoriesWindow = new CategoriesWindow();
            categoriesWindow.Show();
            Close();
        }
    }
}
