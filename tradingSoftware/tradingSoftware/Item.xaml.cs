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

            TradeDataSetTableAdapters.ItemTableAdapter itemTableAdpt = new tradingSoftware.TradeDataSetTableAdapters.ItemTableAdapter();
            itemTableAdpt.Fill(tds.Item);

            this.cbxItemGroup.DataContext = tds.ItemGroup;
            this.cbxUnitUsed.DataContext = tds.Unit;
            //this.ItemId.DataContext = tds.Item;
            txtItemId.IsEnabled = false;
            txtItemCode.IsEnabled = false;
            txtName.IsEnabled = false;


        }

        DataLogic dl;
        ItemObject item;
        ItemsFind itemsfind;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //checking only for item code, item name, item group and unit used..
            if (txtItemId.Text == "")
            {
                MessageBox.Show("Click New To add NEW Value", "WARNING");
                return;
            }

            if (txtItemCode.Text == "")
            {
                MessageBox.Show("Enter/Select the Item Code, cant proceed further", "Warning");
                return;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Enter/Select the Name of the Item to be configured, cant proceed further", "Warning");
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

            item.ItemID = int.Parse(txtItemId.Text.ToString());
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

            txtItemId.Text = "";
            txtItemCode.Text = "";
            cbxItemGroup.SelectedIndex = -1;
            txtName.Text = "";
            txtDesc.Text = "";
            cbxUnitUsed.SelectedIndex = - 1;
            dtOpenDate.SelectedDate = null;
            txtOpenStockQty.Text = "";
            txtOpenStockValue.Text = "";
            txtPurchasePrice.Text = "";
            txtSalePrice.Text = "";
            txtMrp.Text = "";
            txtMinSalePrice.Text = "";
            txtInsuranceAmt.Text = "";
            txtHsnCode.Text = "";
            txtImcoClass.Text = "";
            txtCasNo.Text = "";
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            itemsfind = new ItemsFind(this);
            itemsfind.ShowDialog();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        ItemObject io;
        public void populate(string Itemcode,string ItemName)
        {
            dl = new DataLogic();
            io = new ItemObject();

            io = dl.getDetailsofItemCode(Itemcode, ItemName);

            txtItemId.Text = io.ItemID.ToString();
            txtItemCode.Text = io.ItemCode;
            cbxItemGroup.Text = io.ItemGroup;
            txtName.Text = io.ItemName;
            txtDesc.Text = io.ItemDescription;
            cbxUnitUsed.Text = io.Unit;
            dtOpenDate.SelectedDate = io.OpenDate;
            txtOpenStockQty.Text = io.OpenStockQuantity.ToString();
            txtOpenStockValue.Text = io.OpenStockValue.ToString();
            txtPurchasePrice.Text = io.PurchasePrice.ToString();
            txtSalePrice.Text = io.SalePrice.ToString();
            txtMrp.Text = io.Mrp.ToString();
            txtMinSalePrice.Text = io.MinimumSalePrice.ToString();
            txtInsuranceAmt.Text = io.InsuranceAmount.ToString();
            txtHsnCode.Text = io.HsnCode;
            txtImcoClass.Text = io.IMCOClass;
            txtCasNo.Text = io.CasNo;

            txtItemCode.IsEnabled = false;
            txtName.IsEnabled = false;
            
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            txtItemId.Text = "";
            txtItemCode.Text = "";
            cbxItemGroup.SelectedIndex = -1;
            txtName.Text = "";
            txtDesc.Text = "";
            cbxUnitUsed.SelectedIndex = -1;
            dtOpenDate.SelectedDate = null;
            txtOpenStockQty.Text = "";
            txtOpenStockValue.Text = "";
            txtPurchasePrice.Text = "";
            txtSalePrice.Text = "";
            txtMrp.Text = "";
            txtMinSalePrice.Text = "";
            txtInsuranceAmt.Text = "";
            txtHsnCode.Text = "";
            txtImcoClass.Text = "";
            txtCasNo.Text = "";

            txtItemCode.IsEnabled = true;
            txtName.IsEnabled = true;

            dl = new DataLogic();
            int nextId;
            nextId = dl.getNextItemId();
            //MessageBox.Show("" + nextId);
            txtItemId.Text = nextId.ToString();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtItemId.Text == "")
            {
                MessageBox.Show("Select an Item that Has to be deleted", "WARNING");
                return;
            }

            int Itemid = int.Parse(txtItemId.Text);

            dl = new DataLogic();
            string str = dl.DeleteItem(Itemid);

            MessageBox.Show("" + str);
        }
    }
}
