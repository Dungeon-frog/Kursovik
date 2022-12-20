using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kursovik.windows
{
    /// <summary>
    /// Логика взаимодействия для OperationMaterialWindow.xaml
    /// </summary>
    public partial class OperationMaterialWindow : Window
    {
        private OperationMaterial _om;
        private operations _operation;
        public OperationMaterialWindow(operations operation, OperationMaterial om)
        {
            InitializeComponent();
            this._om = om;
            this._operation = operation;
            if(om != null)
            {
                mName.Text = om.materials.Name;
                price.Text = om.materials.Price.ToString();
                count.Text = om.Count.ToString();
                Thickness.Text = om.materials.Thickness.ToString();
                size.Text = om.materials.Size.ToString();
                nds.Text = om.Nds.ToString();
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            int p = int.Parse(price.Text);
            int c = int.Parse(count.Text);
            int t = int.Parse(Thickness.Text);

            if(_om == null)
            {
                _om = new OperationMaterial();
                _om.operations = _operation;
                var mm = DBEntities.GetContext().materials.FirstOrDefault(md => md.Thickness == t && md.Price == p && md.Name.Equals(mName.Text));
                if(mm == null)
                {
                    mm = new materials();
                    DBEntities.GetContext().materials.Add(mm);
                }
                _om.materials = mm;
            }
            _om.Count = c;
            _om.Nds = int.Parse(nds.Text);
            var m = _om.materials;
            m.Name = mName.Text;
            m.Thickness = t;
            m.Price = p;
            m.Size = size.Text;
            if(_om.ID < 1)
            {
                //DBEntities.GetContext().OperationMaterial.Add(_om);
                _operation.OperationMaterial.Add(_om);
            }
            DBEntities.GetContext().SaveChanges();
            Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
