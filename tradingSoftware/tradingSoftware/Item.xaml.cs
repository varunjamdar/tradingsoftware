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

        DataLogic dl;
        ItemObject item;
        ItemsFind itemsfind;

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
            item = new ItemObject();

            item.ItemCode=txtItemCode.Text;
            item.ItemGroup=cbxItemGroup.Text.ToString();
            item.ItemName = txtName.Text;
            item.ItemDescription = txtDesc.Text;
            item.Unit = cbxUnitUsed.Text.ToString();
            item.OpenDate = (DateTime)dtOpenDate.SelectedDate;
            item.OpenStockQuantity = int.Parse(txtOpenStockQty.Text);
            item.OpenStockValue = float.Parse(txtOpenStockValue.Text);
            item.PurchasePrice = float.Parse(txtPurchasePrice.Text);
            item.SalePrice = float.Parse(txtSalePrice.Text);
            item.Mrp = float.Parse(txtMrp.Text);
            item.MinimumSalePrice = float.Parse(txtMinSalePrice.Text);
            item.InsuranceAmount = float.Parse(txtInsuranceAmt.Text);
            item.HsnCode = txtHsnCode.Text;
            item.IMCOClass = txtImcoClass.Text;
            item.CasNo = txtCasNo.Text;

            dl = new DataLogic();

            string reply = dl.AddItem(item);

            MessageBox.Show("" + reply);
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            itemsfind = new ItemsFind();
            itemsfind.ShowDialog();
        }
    }
}
