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
    /// Логика взаимодействия для ScladPage.xaml
    /// </summary>
    public partial class ScladPage : Page
    {
        public ScladPage()
        {
            InitializeComponent();
            var d = DBEntities.GetContext().materials.ToList();
            foreach(var m in d)
            {
                m.ThicknessStr = m.Thickness + " ММ.";
                m.Count = m.OperationMaterial.Select(om => (om.operations.Type ? om.Count : -om.Count)).Sum();
            }
            dataList.ItemsSource = d;
        }
    }
}
