using BookStore.Infrastructure.Consts;
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
using System.Windows.Controls.Primitives;
using BookStore.Windows.Cards;

namespace BookStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private User user = new User();
        private Client client = new Client();
        private Employee employee = new Employee();

        public AuthWindow()
        {
            InitializeComponent();
        }

        public void Undo_Btn(object sender, RoutedEventArgs e)
        {
            EntryWindow entryWindow = new EntryWindow();
            Close();
            entryWindow.Show();
        }

        private void Registration_Btn(object sender, RoutedEventArgs e)
        {
            string login = TextBoxlogin.Text.Trim();
            string password = TextBoxPassword.Text.Trim();
            string surname = TextBoxsurname.Text.Trim();
            string name = TextBoxname.Text.Trim();
            string patronymic = TextBoxpatronymic.Text.Trim();

            Employee emp = null;
            User use = null;
            Client clien = null;

            using (Context db = new Context())
            {
                use = db.User.Where(b => b.login == user.login && password == user.password).FirstOrDefault();
                //emp = db.Employee.Where(x => x.surname == employee.surname && name == employee.name && patronymic == employee.patronymic).FirstOrDefault();
                clien = db.Client.Where(x => x.surname == client.surname && name == client.name && patronymic == client.patronymic).FirstOrDefault();
            }

            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(client.surname)) sb.AppendLine("Введите фамилию!");
            if (string.IsNullOrWhiteSpace(name)) sb.AppendLine("Введите имя!");
            if (string.IsNullOrWhiteSpace(patronymic)) sb.AppendLine("Введите отчество!");
            if (string.IsNullOrWhiteSpace(login)) sb.AppendLine("Введите логин!");
            if (use != null) sb.AppendLine("Ваш логин совпадает с логином другого пользователя придумайте новый!");
            if (string.IsNullOrWhiteSpace(password)) sb.AppendLine("Введите пороль!");



            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
                return;
            }
            if (user.id == 0)
                Context.GetContext().User.Add(user);
            if (client.id == 0)
                Context.GetContext().Client.Add(client);
            try
            {
                Context.GetContext().SaveChanges();
                MessageBox.Show("Данные были успешно добавлены, перейдите в окно авторизации.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
