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

namespace tradingSoftware
{
    /// <summary>
    /// Interaction logic for Item.xaml
    /// </summary>
    public partial class Item : Window
    {
        public Item()
        {
            InitializeComponent();

            TradeDataSet tds = new TradeDataSet();

            TradeDataSetTableAdapters.ItemGroupTableAdapter itemGrpTableAdpt = new tradingSoftware.TradeDataSetTableAdapters.ItemGroupTableAdapter();
            itemGrpTableAdpt.Fill(tds.ItemGroup);

            TradeDataSetTableAdapters.UnitTableAdapter unitTableAdpt = new tradingSoftware.TradeDataSetTableAdapters.UnitTableAdapter();
            unitTableAdpt.Fill(tds.Unit);

            this.cbxItemGroup.DataContext = tds.ItemGroup;
            this.cbxUnitUsed.DataContext = tds.Unit;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //checking only for item code, item name, item group and unit used..

            if (txtItemCode.Text == "")
            {
                MessageBox.Show("Enter the Item Code, cant proceed further", "Warning");
                return;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Enter the Name of the Item to be configured, cant proceed further", "Warning");
                return;
            }

            if (cbxItemGroup.SelectedItem == null)
            {
                MessageBox.Show("Please select the group under which this item is", "Warning");
                return;
            }

            if (cbxUnitUsed.SelectedItem == null)
            {
                MessageBox.Show("Please select the unit of this item", "Warning");
                return;
            }

            //to store unid id and item group id used .selectedvalue
        }
    }
}
