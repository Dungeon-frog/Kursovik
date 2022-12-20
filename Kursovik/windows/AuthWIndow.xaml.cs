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
using System.Windows.Shapes;

namespace Kursovik
{
    /// <summary>
    /// Логика взаимодействия для AuthWIndow.xaml
    /// </summary>
    public partial class AuthWIndow : Window
    {
        public AuthWIndow()
        {
            InitializeComponent();
        }

        private void OnAuth(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(login.Text))
            {
                MessageBox.Show("Введите логин");
                return;
            }
            string uLogin = login.Text.ToLower();
            users user = DBEntities.GetContext().users.FirstOrDefault(u => u.Login.Equals(uLogin));
            if(user == null)
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }
            string hash = password.Password;
            if (!string.IsNullOrEmpty(user.Password))
            {
                var manager = SHA256Managed.Create();
                StringBuilder sb = new StringBuilder();
                var dib = manager.ComputeHash(Encoding.UTF8.GetBytes(password.Password));
                foreach (byte b in dib)
                {
                    sb.Append(b.ToString("x2"));
                }
                hash = sb.ToString();
            }
            if(hash.Equals(user.Password))
            {
                new MainWindow(user).Show();
                Close();
                

            } else MessageBox.Show("Неверный пароль");
        }
    }
}
