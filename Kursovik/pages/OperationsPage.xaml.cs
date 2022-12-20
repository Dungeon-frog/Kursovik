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
    /// Логика взаимодействия для OperationsPage.xaml
    /// </summary>
    public partial class OperationsPage : Page
    {
        public OperationsPage()
        {
            InitializeComponent();
            updateDate();
        }

        private void dataList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            operations u = (e.OriginalSource as FrameworkElement).DataContext as operations;
            if (u == null) return;
            MainWindow._mf.Navigate(new OperationInfoPage(u));
        }

        private void updateDate()
        {
            var d = DBEntities.GetContext().operations.ToList();
            foreach (var o in d)
            {
                o.TypeStr = o.Type ? "Приход" : "Отгрузка";
                o.Sum = o.OperationMaterial.Sum(om => om.Count * om.materials.Price);
            }
            dataList.ItemsSource = d;
        }

        private void OnDocCreate(object sender, RoutedEventArgs e)
        {
            MainWindow._mf.Navigate(new OperationInfoPage(null));
        }
    }
}
