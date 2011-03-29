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
    /// Interaction logic for Purchase1.xaml
    /// </summary>
    public partial class Purchase1 : Window
    {
        DataLogic dl = new DataLogic();
        public Purchase1()
        {
            InitializeComponent();
            dtPick_PODate.Text = DateTime.Today.Date.ToShortDateString();
            txt_PurchaseNo.Focus();

            //-------tax detail--

            TradeDataSet ds = new TradeDataSet();
            TradeDataSetTableAdapters.TaxTableAdapter taxApdt = new tradingSoftware.TradeDataSetTableAdapters.TaxTableAdapter();
            taxApdt.Fill(ds.Tax);
            TaxDetailsGrid.DataContext = ds.Tax;


            //---Supplier
            TradeDataSetTableAdapters.SupplierTableAdapter supplierApdt = new tradingSoftware.TradeDataSetTableAdapters.SupplierTableAdapter();
            supplierApdt.Fill(ds.Supplier);
            cb_Supplier.DataContext = ds.Supplier;

            //---Item Group
            TradeDataSetTableAdapters.ItemGroupTableAdapter itemGroupAdpt = new tradingSoftware.TradeDataSetTableAdapters.ItemGroupTableAdapter();
            itemGroupAdpt.Fill(ds.ItemGroup);
            PurchaseOrder2Grid.DataContext = ds.ItemGroup;
            //----Item
            TradeDataSetTableAdapters.ItemTableAdapter itemAdpt = new tradingSoftware.TradeDataSetTableAdapters.ItemTableAdapter();
            itemAdpt.Fill(ds.Item);

            //--Max Purchase Id
            txt_PurchaseNo.Text= dl.getPurchaseOrderNo().ToString();
        }

        private void btn_AddPurchaseItem_Click(object sender, RoutedEventArgs e)
        {
            int IPONO = Int32.Parse(txt_PurchaseNo.Text);
            int IQuantity = Int32.Parse(txt_Quantity.Text);
            float FPPU = float.Parse(txt_PPU.Text);
            addRow(cb_ItemGroup.Text,cb_Item.Text,IQuantity,FPPU);


            //refresh the Both Amount Label
            lblTotalAmount.Content = getTotalAmountOFListViewPurchaseOrder();
            lblItemTaxAmount.Content = getTotalAmountOFListViewPurchaseOrder() + getTotalAmountTax();
        }

        //get Total Amount
        public float getTotalAmountOFListViewPurchaseOrder()
        {
            float tAmount=0;
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

        public void addRow(string v4,string v5,int v6,float v7)
        {
            listViewPurchseOrder.Items.Add(new ListViewPurchaseOrder(v4,v5,v6,v7));
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
            lblItemTaxAmount.Content = getTotalAmountOFListViewPurchaseOrder() + getTotalAmountTax();

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
            lblItemTaxAmount.Content = getTotalAmountOFListViewPurchaseOrder() + getTotalAmountTax();
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
            lblItemTaxAmount.Content = getTotalAmountOFListViewPurchaseOrder() + getTotalAmountTax();
        }
//------------------Tax Tab----------------------------------------------------
        private void btnCloseTax_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnClearTax_Click(object sender, RoutedEventArgs e)
        {
            cb_TaxName.Text = "";
            //cb_ValuePer.SelectedIndex = 0;
            txtAmount.Text = "";
            cb_Type.SelectedIndex = 0;
        }

        private void listViewTaxDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnResetAllTax_Click(object sender, RoutedEventArgs e)
        {
            cb_TaxName.Text = "";
            rbPercentage.IsChecked = true;
            rbValue.IsChecked = false;
            txtAmount.Text = "";
            cb_Type.SelectedIndex = 0;
            listViewTaxDetails.Items.Clear();

            //Displat Total Amount Tax
            lblTotalAmountTax.Content = getTotalAmountTax();
            lblItemTaxAmount.Content = getTotalAmountOFListViewPurchaseOrder() + getTotalAmountTax();
        }

        private void rbPercentage_Checked(object sender, RoutedEventArgs e)
        {
           // txtPercentage.Visibility;
           // txtAmount.Visibility = Visibility.Hidden;
        }

        private void rbValue_Checked(object sender, RoutedEventArgs e)
        {
            //txtPercentage.Visibility = Visibility.Hidden;
            //txtAmount.Visibility = Visibility.Visible;
        }

        public float getTotalAmountTax()
        {
            float tAmountTax = 0;
            for (int i = 0; i <= listViewTaxDetails.Items.Count - 1; i++)
            {
                ListViewPurchaseTaxDetails lvc = (ListViewPurchaseTaxDetails)listViewTaxDetails.Items[i];
                if (lvc.TaxType == "Exclusive")
                {
                    tAmountTax += lvc.TaxAmount;
                }
            }
            return tAmountTax;

        }

        private void btnAddTax_Click(object sender, RoutedEventArgs e)
        {
            float p=0, a=0;
            if(rbPercentage.IsChecked==true)
            {
            //    MessageBox.Show(lblPercentageTax.Content.ToString());
                p = float.Parse( lblPercentageTax.Content.ToString());//txtPercentage.Text;
            }
            else
            {
                if (txtAmount.Text == "")
                {
                    txtAmount.Text = "0";
                }
                a=float.Parse(txtAmount.Text);
            }
            listViewTaxDetails.Items.Add(new ListViewPurchaseTaxDetails(cb_TaxName.Text,p,a,cb_Type.Text,float.Parse(lblTotalAmount.Content.ToString())));
            cb_TaxName.Text = "";
            rbPercentage.IsChecked = true;
            rbValue.IsChecked = false;
            txtAmount.Text = "";
            cb_Type.SelectedIndex = 0;
            listViewTaxDetails.SelectedIndex = -1;

            cb_Type.SelectedIndex = -1;

            //Displat Total Amount Tax
            lblTotalAmountTax.Content = getTotalAmountTax();
            lblItemTaxAmount.Content = getTotalAmountOFListViewPurchaseOrder() + getTotalAmountTax();
        }

        private void btnRemoveTax_Click(object sender, RoutedEventArgs e)
        {
            listViewTaxDetails.Items.Remove(listViewTaxDetails.SelectedItem);
            cb_TaxName.Text = "";
            rbPercentage.IsChecked = true;
            rbValue.IsChecked = false;
            txtAmount.Text = "";
            listViewTaxDetails.SelectedIndex = -1;

            //Displat Total Amount Tax
            lblTotalAmountTax.Content = getTotalAmountTax();
            lblItemTaxAmount.Content = getTotalAmountOFListViewPurchaseOrder() + getTotalAmountTax();
        }

        private void cb_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (cb_Type.Text == "Inclusive")
            //{
                

            //    rbPercentage.Visibility = Visibility.Visible;
            //    rbValue.Visibility = Visibility.Visible;
            //    lblPercentageTax.Visibility = Visibility.Visible;
            //    txtAmount.Visibility = Visibility.Visible;
            //}

            //if (cb_Type.Text == "Exclusive")
            //{
            //    rbPercentage.Visibility = Visibility.Hidden;
            //    rbValue.Visibility = Visibility.Hidden;
            //    lblPercentageTax.Visibility = Visibility.Hidden;
            //    txtAmount.Visibility = Visibility.Hidden;
            //}
        }

        private void btnPlacePurchaseOrder_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Are You Sure to place purchase Order ?", "Varifiacation", MessageBoxButton.YesNo,MessageBoxImage.Question);

            if (mbr == MessageBoxResult.Yes)
            {
                string supplierName = (string)cb_Supplier.Text;
                
                int supplierId = dl.getSupplierId(supplierName);
                dl.placePurchaseOrder_PurchaseOrderTable(Int32.Parse(txt_PurchaseNo.Text), DateTime.Parse(dtPick_PODate.Text),supplierId, float.Parse(lblTotalAmount.Content.ToString()), float.Parse(lblTotalAmountTax.Content.ToString()));


                //For Each and Every Item place to the PurchaseOrderItems table
                for (int i = 0; i <= listViewPurchseOrder.Items.Count - 1; i++)
                {
                    ListViewPurchaseOrder lvc = (ListViewPurchaseOrder)listViewPurchseOrder.Items[i];
                    dl.placePurchaseOrder_PurchaseOrderItemsTable(Int32.Parse(txt_PurchaseNo.Text),dl.getItemId(lvc.Item1), lvc.Quantity, lvc.PricePerUnit);
                }


                //For Each and Every Item Tax to the PurchaseOrderTaxes table
                for (int i = 0; i <= listViewTaxDetails.Items.Count - 1; i++)
                {
                    ListViewPurchaseTaxDetails lvc = (ListViewPurchaseTaxDetails)listViewTaxDetails.Items[i];
                    dl.placePurchaseOrder_PurchaseOrderTaxesTable(Int32.Parse(txt_PurchaseNo.Text), dl.getTaxId(lvc.TaxName), lvc.TaxType, lvc.TaxAmount);
                }

                MessageBox.Show("Order Placed Successfully","Succeeded",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }

    }
}
