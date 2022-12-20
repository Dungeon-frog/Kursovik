using Kursovik.windows;
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
    /// Логика взаимодействия для OperationInfoPage.xaml
    /// </summary>
    public partial class OperationInfoPage : Page
    {
        private operations _operation;
        public OperationInfoPage(operations operation)
        {
            InitializeComponent();
            Provider.ItemsSource = new List<string>() { "ООО Сима", "ОАО Тундра" };
            Provider.SelectedIndex = 0;
            Status.ItemsSource = new List<string>() { "Проверенно", "Не проверенно" };
            Status.SelectedIndex = 0;
            DataContext = this;
            this._operation = operation;
            if(operation != null)
            {
                if (operation.Type) TypeT.IsChecked = true;
                else TypeF.IsChecked = true;
                Status.Text = operation.Status;
                Provider.Text = operation.Provider;
                DateDoc.SelectedDate = operation.DateDoc;
                DateFact.SelectedDate = operation.DateFact;
            } else
            {
                _operation = new operations();
            }
            dataList.ItemsSource = _operation.OperationMaterial;
            updateItems();
        }

        public void updateItems()
        {
            foreach(var item in _operation.OperationMaterial)
            {
                item.Sum = item.Count * item.materials.Price;
            }
            dataList.Items.Refresh();
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {

            if(string.IsNullOrEmpty(Status.Text))
            {
                MessageBox.Show("Заполните поле Статус");
                return;
            }
            if (string.IsNullOrEmpty(Provider.Text))
            {
                MessageBox.Show("Заполните поле Поставщик");
                return;
            }
            if (DateDoc.SelectedDate == null)
            {
                MessageBox.Show("Заполните поле Дата(Док)");
                return;
            }
            if (DateFact.SelectedDate == null)
            {
                MessageBox.Show("Заполните поле Дата(Факт)");
                return;
            }
            if (dataList.Items.Count < 1)
            {
                MessageBox.Show("Добавьте хотя бы 1 материал");
                return;
            }

            //if (_operation == null) _operation = new operations();
            _operation.Type = (bool)TypeT.IsChecked;
            _operation.Status = Status.Text;
            _operation.Provider = Provider.Text;
            _operation.DateDoc = (DateTime)DateDoc.SelectedDate;
            _operation.DateFact = (DateTime)DateFact.SelectedDate;
            if(_operation.ID < 1)
            {
                DBEntities.GetContext().operations.Add(_operation);
                MessageBox.Show("Операция добавлена");
            } else MessageBox.Show("Изменения сохранены");
            DBEntities.GetContext().SaveChanges();
            MainWindow._mf.Navigate(new OperationsPage());
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            if (_operation != null && _operation.ID > 0) DBEntities.GetContext().Entry(_operation).Reload();
            MainWindow._mf.GoBack();
        }

        private void AddM(object sender, RoutedEventArgs e)
        {
            if (_operation == null) _operation = new operations();
            new OperationMaterialWindow(_operation, null).ShowDialog();
            updateItems();
        }

        private void RemoveM(object sender, RoutedEventArgs e)
        {
            var m = dataList.SelectedItem as OperationMaterial;
            if (m == null) return;
            _operation.OperationMaterial.Remove(m);
            DBEntities.GetContext().OperationMaterial.Remove(m);
            updateItems();
        }

        private void dataList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var mm = (e.OriginalSource as FrameworkElement).DataContext as OperationMaterial;
            if(mm == null) return;
            if (_operation == null) _operation = new operations();
            new OperationMaterialWindow(_operation, mm).ShowDialog();
            updateItems();
        }
    }
}
