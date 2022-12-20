using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursovik.pages
{
    /// <summary>
    /// Логика взаимодействия для StaffInfoPage.xaml
    /// </summary>
    public partial class StaffInfoPage : Page
    {
        private users _user;
        public StaffInfoPage(users user)
        {
            InitializeComponent();
            _user = user;

            if(user != null)
            {
                firstName.Text = user.FirstName;
                lastName.Text = user.LastName;
                middleName.Text = user.MiddleName;
                dateB.SelectedDate = user.BDate;
                role.Text = user.Role;
                login.Text = user.Login;
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {

            if(string.IsNullOrEmpty(firstName.Text))
            {
                MessageBox.Show("Заполните поле Имя");
                return;
            }
            if (string.IsNullOrEmpty(lastName.Text))
            {
                MessageBox.Show("Заполните поле Фамилия");
                return;
            }
            if (string.IsNullOrEmpty(middleName.Text))
            {
                MessageBox.Show("Заполните поле Отчество");
                return;
            }
            if (dateB.SelectedDate == null)
            {
                MessageBox.Show("Заполните поле Дата рождения");
                return;
            }
            if (string.IsNullOrEmpty(role.Text))
            {
                MessageBox.Show("Заполните поле Должность");
                return;
            }
            if (string.IsNullOrEmpty(login.Text))
            {
                MessageBox.Show("Заполните поле Логин");
                return;
            }


            if (_user == null) _user = new users();
            string loginn = login.Text.ToLower();
            users fu = DBEntities.GetContext().users.FirstOrDefault(u => u.Login.Equals(loginn));
            if(fu != null && fu.ID != _user.ID)
            {
                MessageBox.Show("Логин уже используется");
                return;
            }

            _user.FirstName = firstName.Text;
            _user.LastName = lastName.Text;
            _user.MiddleName = middleName.Text;
            _user.BDate = (DateTime)dateB.SelectedDate;
            _user.Role = role.Text;
            _user.Login = login.Text;
            if(!string.IsNullOrEmpty(password.Password) || _user.ID < 1)
            {
                if (string.IsNullOrEmpty(password.Password)) password.Password = "0000";
                var manager = SHA256Managed.Create();
                StringBuilder sb = new StringBuilder();
                var bb = manager.ComputeHash(Encoding.UTF8.GetBytes(password.Password));
                foreach(var b in bb) sb.Append(b.ToString("x2"));
                _user.Password = sb.ToString();
            }
            if(_user.ID < 1)
            {
                DBEntities.GetContext().users.Add(_user);
                MessageBox.Show("Сотрудник добавлен");
            } else
            {
                MessageBox.Show("Информация сохранена");
            }
            DBEntities.GetContext().SaveChanges();
            MainWindow._mf.Navigate(new StaffPage());
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            MainWindow._mf.GoBack();
        }
    }
}
