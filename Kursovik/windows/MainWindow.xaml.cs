using Kursovik.pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursovik
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static Frame _mf;
        public static users _user;

        public MainWindow(users user)
        {
            InitializeComponent();
            _user = user;
            _mf = MF;
            _mf.Navigate(new PreviewPage());

            UserName.Text = "ID: " + user.Login;
            if (_user.ID == 1)
            {
                OnStaff.Visibility = Visibility.Visible;
            }
            else
            {
                OnStaff.Visibility = Visibility.Collapsed;
            }
        }

        private void OnScladClick(object sender, RoutedEventArgs e)
        {
            _mf.Navigate(new ScladPage());
        }

        private void OnOperationsClick(object sender, RoutedEventArgs e)
        {
            _mf.Navigate(new OperationsPage());
        }

        private void OnStaffClick(object sender, RoutedEventArgs e)
        {
            _mf.Navigate(new StaffPage());
        }
        
        private void OnClickLogout(object sender, RoutedEventArgs e)
        {
            new AuthWIndow().Show();
            Close();
        }
    }
}
