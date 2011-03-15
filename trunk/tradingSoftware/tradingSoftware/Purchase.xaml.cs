using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace tradingSoftware
{
    /// <summary>
    /// Interaction logic for Purchase.xaml
    /// </summary>
    public partial class Purchase : Window
    {
        public Purchase()
        {
            InitializeComponent();

            DataTable dt = new DataTable();

            dt.Columns.Add("first");
            dt.Columns.Add("last");
            dt.Columns.Add("city");

            DataView dv = new DataView(dt);
            myList.DataContext = dv;

            Binding bind = new Binding();
            myList.SetBinding(ListView.ItemsSourceProperty, bind);
            
            dt.Rows.Add("bill", "gates", "silicon valley");
            
        }
    }
}
