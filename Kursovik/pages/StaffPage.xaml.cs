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

namespace Kursovik.pages
{
    /// <summary>
    /// Логика взаимодействия для StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Page
    {
        public StaffPage()
        {
            InitializeComponent();
            dataList.ItemsSource = DBEntities.GetContext().users.ToList();
        }

        private void OnAdd(object sender, RoutedEventArgs e)
        {
            MainWindow._mf.Navigate(new StaffInfoPage(null));
        }

        private void OnEdit(object sender, RoutedEventArgs e)
        {
            var u = dataList.SelectedItem as users;
            if(u == null)
            {
                MessageBox.Show("Выберите пользователя");
                return;
            }
            MainWindow._mf.Navigate(new StaffInfoPage(u));
        }

        private void OnRemove(object sender, RoutedEventArgs e)
        {
            var u = dataList.SelectedItem as users;
            if (u == null)
            {
                MessageBox.Show("Выберите пользователя");
                return;
            }
            DBEntities.GetContext().users.Remove(u);
            DBEntities.GetContext().SaveChanges();
            (dataList.ItemsSource as List<users>).Remove(u);
            dataList.Items.Refresh();
        }

        private void dataList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            users u = (e.OriginalSource as FrameworkElement).DataContext as users;
            if (u == null) return;
            MainWindow._mf.Navigate(new StaffInfoPage(u));
        }
    }
}
