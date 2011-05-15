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
    /// Interaction logic for PurchaseOrder.xaml
    /// </summary>
    public partial class PurchaseOrder : Window
    {
        DataLogic dl = new DataLogic();
        public PurchaseOrder()
        {
            InitializeComponent();
            dtPick_PODate.Text = DateTime.Today.Date.ToShortDateString();
            txt_PurchaseNo.Focus();

            TradeDataSet ds = new TradeDataSet();

            
            //---Supplier
            cb_Supplier.Items.Clear();
            List<string> supplierNameList = new List<string>();
            supplierNameList = dl.getSupplierName();
            foreach (string sn in supplierNameList)
            {
                cb_Supplier.Items.Add(sn.ToString());
            }
            //
            //---Item Group
            TradeDataSetTableAdapters.ItemGroupTableAdapter itemGroupAdpt = new tradingSoftware.TradeDataSetTableAdapters.ItemGroupTableAdapter();
            itemGroupAdpt.Fill(ds.ItemGroup);
            PurchaseOrder2Grid.DataContext = ds.ItemGroup;
            //----Item
            TradeDataSetTableAdapters.ItemTableAdapter itemAdpt = new tradingSoftware.TradeDataSetTableAdapters.ItemTableAdapter();
            itemAdpt.Fill(ds.Item);

            //--Max Purchase Id
            txt_PurchaseNo.Text = dl.getPurchaseOrderNo().ToString();
        }


        private void btn_AddPurchaseItem_Click(object sender, RoutedEventArgs e)
        {

            //Validation
            bool Boolerror = false;
            Dictionary<int, string> error = new Dictionary<int, string>();
            int count = 0;

            //Date Validation
            try
            {
                DateTime dt = DateTime.Parse(dtPick_PODate.Text);
            }
            catch (FormatException)
            {
                error[count++] = "Invalid Date";
                Boolerror = true;
            }

            //
            if (cb_Supplier.Text == "")
            {
                error[count++]="Select 'Supplier'";
                Boolerror = true;
            }
            else if (cb_ItemGroup.Text == "")
            {
                error[count++]="Select 'Item Group'";
                Boolerror = true;
            }
            if (cb_Item.Text == "")
            {
                error[count++]="Select 'Item'";
                Boolerror = true;
            }

            try
            {
                int q = Int32.Parse(txt_Quantity.Text);
                if (q <= 0)
                {
                    error[count++] = "Quantity must be greater than 0";
                    Boolerror = true;
                }
                
            }
            catch (FormatException)
            {
                error[count++] = "Invalid 'Quantity'";
                Boolerror = true;
            }

            

            try
            {
                float p = float.Parse(txt_PPU.Text);
                if (p <= 0)
                {
                    error[count++] = "Invalid Nagative 'Price'";
                    Boolerror = true;
                }
            }
            catch (FormatException)
            {
                error[count++]="Invalid 'Price'";
                Boolerror = true;
            }


            if (Boolerror == true)
            {
                string errorMsg="";
                for(int i=0;i<error.Count;i++)
                {
                    errorMsg+=(i+1) +". "+ error[i]+"\n";
                }

                MessageBox.Show(@errorMsg,"Error !",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            //
            int IPONO = Int32.Parse(txt_PurchaseNo.Text);
            int IQuantity = Int32.Parse(txt_Quantity.Text);
            float FPPU = float.Parse(txt_PPU.Text);
            addRow(cb_ItemGroup.Text, cb_Item.Text, IQuantity, FPPU);


            //refresh the Both Amount Label
            lblTotalAmount.Content = getTotalAmountOFListViewPurchaseOrder();
        }

        //get Total Amount of Only ListView
        public float getTotalAmountOFListViewPurchaseOrder()
        {
            float tAmount = 0;
            for (int i = 0; i <= listViewPurchseOrder.Items.Count - 1; i++)
            {
                ListViewPurchaseOrder lvc = (ListViewPurchaseOrder)listViewPurchseOrder.Items[i];
                //MessageBox.Show(lvc.PONo + " " + lvc.PODate);
                tAmount += lvc.Rs;
            }
            return tAmount;
        }

        private void RefreshListView(int v1, string v2, string v3, string v4, string v5, int v6, float v7)
        {

        }

        public void addRow(string v4, string v5, int v6, float v7)
        {
            listViewPurchseOrder.Items.Add(new ListViewPurchaseOrder(v4, v5, v6, v7));
            dtPick_PODate.Text = DateTime.Today.Date.ToShortDateString();
            cb_ItemGroup.Text = "";
            cb_Item.Text = "";
            txt_Quantity.Text = "";
            txt_PPU.Text = "";
            listViewPurchseOrder.SelectedIndex = -1;
        }

        private void listViewPurchseOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ListViewPurchaseOrder lvpo = (ListViewPurchaseOrder)listViewPurchseOrder.SelectedItem;
                cb_ItemGroup.Text = lvpo.ItemGroup;
                cb_Item.Text = lvpo.Item1;
                txt_Quantity.Text = lvpo.Quantity.ToString();

                txt_PPU.Text = lvpo.PricePerUnit.ToString();
            }
            catch (NullReferenceException nre) { }

        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_ResetItems_Click(object sender, RoutedEventArgs e)
        {
            dtPick_PODate.Text = DateTime.Today.Date.ToShortDateString();
            cb_Supplier.Text = "";
            cb_ItemGroup.Text = "";
            cb_Item.Text = "";
            txt_Quantity.Text = "";
            txt_PPU.Text = "";
            listViewPurchseOrder.Items.Clear();

            //refresh the Both Amount Label
            lblTotalAmount.Content = getTotalAmountOFListViewPurchaseOrder();

            //lblItemTaxAmount.Content = getTotalAmountOFListViewPurchaseOrder() + getTotalAmountTax();

        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            dtPick_PODate.Text = DateTime.Today.Date.ToShortDateString();
            cb_Supplier.Text = "";
            cb_ItemGroup.Text = "";
            cb_Item.Text = "";
            txt_Quantity.Text = "";
            txt_PPU.Text = "";
            listViewPurchseOrder.SelectedIndex = -1;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            //
            ListViewPurchaseOrder lvc = (ListViewPurchaseOrder)listViewPurchseOrder.SelectedItem;
            if (lvc != null)
            {
                lvc.ItemGroup = cb_ItemGroup.Text;
                lvc.Item1 = cb_Item.Text;
                lvc.Quantity = Int32.Parse(txt_Quantity.Text);
                lvc.PricePerUnit = float.Parse(txt_PPU.Text);
                lvc.Rs = Int32.Parse(txt_Quantity.Text) * float.Parse(txt_PPU.Text);
                listViewPurchseOrder.Items.Refresh();
            }
            //
            //RefreshListView(txt_PurchaseNo.Text, dtPick_PODate.Text, cb_Supplier.Text, cb_ItemGroup.Text, cb_Item.Text, txt_Quantity.Text, txt_PPU.Text);
            dtPick_PODate.Text = DateTime.Today.Date.ToShortDateString();
            cb_ItemGroup.Text = "";
            cb_Item.Text = "";
            txt_Quantity.Text = "";
            txt_PPU.Text = "";
            listViewPurchseOrder.SelectedIndex = -1;


            //refresh the Both Amount Label
            lblTotalAmount.Content = getTotalAmountOFListViewPurchaseOrder();

            //lblItemTaxAmount.Content = getTotalAmountOFListViewPurchaseOrder() + getTotalAmountTax();
        }

        private void btn_RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            listViewPurchseOrder.Items.Remove(listViewPurchseOrder.SelectedItem);
            dtPick_PODate.Text = DateTime.Today.Date.ToShortDateString();
            cb_ItemGroup.Text = "";
            cb_Item.Text = "";
            txt_Quantity.Text = "";
            txt_PPU.Text = "";
            listViewPurchseOrder.SelectedIndex = -1;

            //refresh the Both Amount Label
            lblTotalAmount.Content = getTotalAmountOFListViewPurchaseOrder();

            //lblItemTaxAmount.Content = getTotalAmountOFListViewPurchaseOrder() + getTotalAmountTax();
        }

        //Place purchase order

        private void btnPlacePurchaseOrder_Click(object sender, RoutedEventArgs e)
        {
            
            if (listViewPurchseOrder.Items.Count == 0)
            {
                MessageBox.Show("Please Add Item", "Error !", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult mbr = MessageBox.Show("Are You Sure to place purchase Order ?", "Varifiacation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (mbr == MessageBoxResult.Yes)
            {
                string supplierName = (string)cb_Supplier.Text;

                int supplierId = dl.getSupplierId(supplierName);
                dl.placePurchaseOrder_PurchaseOrderTable(Int32.Parse(txt_PurchaseNo.Text), DateTime.Parse(dtPick_PODate.Text), supplierId, float.Parse(lblTotalAmount.Content.ToString()));


                //For Each and Every Item place to the PurchaseOrderItems table
                for (int i = 0; i <= listViewPurchseOrder.Items.Count - 1; i++)
                {
                    ListViewPurchaseOrder lvc = (ListViewPurchaseOrder)listViewPurchseOrder.Items[i];
                    dl.placePurchaseOrder_PurchaseOrderItemsTable(Int32.Parse(txt_PurchaseNo.Text), dl.getItemId(lvc.Item1), lvc.Quantity, lvc.PricePerUnit);
                }

                /*
                //For Each and Every Item Tax to the PurchaseOrderTaxes table
                for (int i = 0; i <= listViewTaxDetails.Items.Count - 1; i++)
                {
                    ListViewPurchaseTaxDetails lvc = (ListViewPurchaseTaxDetails)listViewTaxDetails.Items[i];
                    dl.placePurchaseOrder_PurchaseOrderTaxesTable(Int32.Parse(txt_PurchaseNo.Text), dl.getTaxId(lvc.TaxName), lvc.TaxType, lvc.TaxAmount);
                }
                */
                MessageBox.Show("Order Placed Successfully", "Succeeded", MessageBoxButton.OK, MessageBoxImage.Information);

                //--Max Purchase Id
                //Remaining. cant get max id, reset all
                //MessageBox.Show(dl.getPurchaseOrderNo().ToString());
                //txt_PurchaseNo.Text = dl.getPurchaseOrderNo().ToString();
                //btn_ResetItems_Click();
                //InitializeComponent();
                listViewPurchseOrder.Items.Clear();
                lblTotalAmount.Content = 0;
                txt_PurchaseNo.Text = dl.getPurchaseOrderNo().ToString();
            }
        }
    }
}
