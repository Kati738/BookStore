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
    /// Логика взаимодействия для EmployeeCard.xaml
    /// </summary>
    public partial class EmployeeCard : Window
    {
        private Employee employee = new Employee();
        public EmployeeCard(Employee selectedEmployee)
        {
            InitializeComponent();

            if (selectedEmployee != null)
                employee = selectedEmployee;
            DataContext = employee;
        }

        private void Undo_Btn(object sender, RoutedEventArgs e)
        {
            EmployeesWindow employeesWindow = new EmployeesWindow();
            employeesWindow.Show();
            Close();
        }

        private void Save_Btn(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(employee.surname))
                sb.AppendLine("Введите фамилию!");
            if (string.IsNullOrWhiteSpace(employee.name))
                sb.AppendLine("Введите имя!");
            if (string.IsNullOrWhiteSpace(employee.patronymic))
                sb.AppendLine("Введите отчество!");
            if (string.IsNullOrWhiteSpace(employee.birthdate))
                sb.AppendLine("Введите дату рождения!");
            if (employee.post_id == null)
                sb.AppendLine("Введите ID должности!");
            if (employee.store_id == null)
                sb.AppendLine("Введите номер ID магазина");

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
                return;
            }
            if (employee.id == 0)
            {
                employee.id++;
                Context.GetContext().Employee.Add(employee);
                return;
            }
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
