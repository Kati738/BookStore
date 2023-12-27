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
    /// Логика взаимодействия для DiscountCard.xaml
    /// </summary>
    public partial class DiscountCard : Window
    {
        private Discount discount = new Discount();
        public DiscountCard(Discount selectedDiscount )
        {
            InitializeComponent();

            if (selectedDiscount != null)
                discount = selectedDiscount;
            DataContext = discount;
        }

        private void Undo_Btn(object sender, RoutedEventArgs e)
        {
            DiscountsWindow discountsWindow = new DiscountsWindow();
            discountsWindow.Show();
            Close();
        }

        private void Save_Btn(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(discount.name))
                sb.AppendLine("Введите название!");
            if (discount.value == null)
                sb.AppendLine("Введите значение!");
            if (string.IsNullOrWhiteSpace(discount.comment))
                sb.AppendLine("Введите комментарий!");

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
                return;
            }
            if (discount.id == 0)
                Context.GetContext().Discount.Add(discount);
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
