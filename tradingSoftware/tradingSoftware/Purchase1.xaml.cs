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
            //set default date - today
            dtPick_PODate.Text = DateTime.Today.Date.ToShortDateString();
            txt_PurchaseOrderNo.Focus();

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
            txtPurchaseNo.Text= dl.getPurchaseNo().ToString();

            //purchase order
            TradeDataSetTableAdapters.PurchaseOrderTableAdapter purchaseOrderAdpt = new tradingSoftware.TradeDataSetTableAdapters.PurchaseOrderTableAdapter();
            purchaseOrderAdpt.Fill(ds.PurchaseOrder);
            cbRefPO.DataContext = ds.PurchaseOrder;
        }

        public void refreshTaxes()
        {
            //refresh the taxes
            for (int i = 0; i <= listViewTaxDetails.Items.Count - 1; i++)
            {
                ListViewPurchaseTaxDetails lvc = (ListViewPurchaseTaxDetails)listViewTaxDetails.Items[i];
                if (lvc != null)
                {
                    if (lvc.TaxPercentage != 0)
                    {
                        lvc.TaxAmount = lvc.TaxPercentage * (float.Parse(lblTotalAmount.Content.ToString()) / 100);
                    }
                    listViewTaxDetails.Items.Refresh();
                }
            }

            //Display Total Amount Tax
            lblTotalAmountTax.Content = getTotalAmountTax();
            lblItemTaxAmount.Content = getTotalAmountOFListViewPurchase() + getTotalAmountTax();
        }
        private void btn_AddPurchaseItem_Click(object sender, RoutedEventArgs e)
        {
            int IPONO = Int32.Parse(cbRefPO.Text);
            int IQuantity = Int32.Parse(txt_Quantity.Text);
            float FPPU = float.Parse(txt_PPU.Text);
            addRow(cb_ItemGroup.Text,cb_Item.Text,IQuantity,FPPU);


            //refresh the Both Amount Label
            lblTotalAmount.Content = getTotalAmountOFListViewPurchase();
            lblItemTaxAmount.Content = getTotalAmountOFListViewPurchase() + getTotalAmountTax();

            refreshTaxes();
        }

        


        //get Total Amount Purchase Order
        public float getTotalAmountOFListViewPurchase()
        {
            float tAmount = 0;
            for (int i = 0; i <= listViewPurchse.Items.Count - 1; i++)
            {
                ListViewPurchase lvc = (ListViewPurchase)listViewPurchse.Items[i];
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
            listViewPurchse.Items.Add(new ListViewPurchase(v4,v5,v6,v7));
            dtPick_PODate.Text = DateTime.Today.Date.ToShortDateString();
            cb_ItemGroup.Text = "";
            cb_Item.Text = "";
            txt_Quantity.Text = "";
            txt_PPU.Text = "";
            listViewPurchse.SelectedIndex = -1;
        }

        private void listViewPurchse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ListViewPurchase lvpo = (ListViewPurchase)listViewPurchse.SelectedItem;
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
            listViewPurchse.Items.Clear();

            txt_PurchaseOrderNo.Text = "";
            //refresh the Both Amount Label
            lblTotalAmount.Content = 0;
            lblTotalAmountTax.Content = 0;
            lblItemTaxAmount.Content = 0;

            listViewTaxDetails.Items.Clear();
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            dtPick_PODate.Text = DateTime.Today.Date.ToShortDateString();
            cb_Supplier.Text = "";
            cb_ItemGroup.Text = "";
            cb_Item.Text = "";
            txt_Quantity.Text = "";
            txt_PPU.Text = "";

            txt_PurchaseOrderNo.Text = "";
            listViewPurchse.SelectedIndex = -1;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            //
            ListViewPurchase lvc = (ListViewPurchase)listViewPurchse.SelectedItem;
            if (lvc != null)
            {
                lvc.ItemGroup = cb_ItemGroup.Text;
                lvc.Item1 = cb_Item.Text;
                lvc.Quantity = Int32.Parse(txt_Quantity.Text);
                lvc.PricePerUnit = float.Parse(txt_PPU.Text);
                lvc.Rs = Int32.Parse(txt_Quantity.Text) * float.Parse(txt_PPU.Text);
                listViewPurchse.Items.Refresh();
            }
            //
            //RefreshListView(txt_PurchaseOrderNo.Text, dtPick_PODate.Text, cb_Supplier.Text, cb_ItemGroup.Text, cb_Item.Text, txt_Quantity.Text, txt_PPU.Text);
            dtPick_PODate.Text = DateTime.Today.Date.ToShortDateString();
            cb_ItemGroup.Text = "";
            cb_Item.Text = "";
            txt_Quantity.Text = "";
            txt_PPU.Text = "";
            listViewPurchse.SelectedIndex = -1;


            //refresh the Both Amount Label
            lblTotalAmount.Content = getTotalAmountOFListViewPurchase();
            lblItemTaxAmount.Content = getTotalAmountOFListViewPurchase() + getTotalAmountTax();

            refreshTaxes();
        }

        private void btn_RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            listViewPurchse.Items.Remove(listViewPurchse.SelectedItem);
            dtPick_PODate.Text = DateTime.Today.Date.ToShortDateString();
            cb_ItemGroup.Text = "";
            cb_Item.Text = "";
            txt_Quantity.Text = "";
            txt_PPU.Text = "";
            listViewPurchse.SelectedIndex = -1;

            //refresh the Both Amount Label
            lblTotalAmount.Content = getTotalAmountOFListViewPurchase();
            lblItemTaxAmount.Content = getTotalAmountOFListViewPurchase() + getTotalAmountTax();

            refreshTaxes();
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
            lblItemTaxAmount.Content = getTotalAmountOFListViewPurchase() + getTotalAmountTax();
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

            //Display Total Amount Tax
            lblTotalAmountTax.Content = getTotalAmountTax();
            lblItemTaxAmount.Content = getTotalAmountOFListViewPurchase() + getTotalAmountTax();
        }

        private void btnRemoveTax_Click(object sender, RoutedEventArgs e)
        {
            listViewTaxDetails.Items.Remove(listViewTaxDetails.SelectedItem);
            cb_TaxName.Text = "";
            rbPercentage.IsChecked = true;
            rbValue.IsChecked = false;
            txtAmount.Text = "";
            listViewTaxDetails.SelectedIndex = -1;

            //Display Total Amount Tax
            lblTotalAmountTax.Content = getTotalAmountTax();
            lblItemTaxAmount.Content = getTotalAmountOFListViewPurchase() + getTotalAmountTax();
        }

        private void cb_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btnPlacePurchase_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Are You Sure to place purchase Items ?", "Varifiacation", MessageBoxButton.YesNo,MessageBoxImage.Question);

            if (mbr == MessageBoxResult.Yes)
            {
                string supplierName = (string)cb_Supplier.Text;
                
                int supplierId = dl.getSupplierId(supplierName);
                dl.placePurchase_PurchaseTable(Int32.Parse(txtPurchaseNo.Text), Int32.Parse(cbRefPO.Text), DateTime.Parse(dtPick_PODate.Text), supplierId, float.Parse(lblTotalAmount.Content.ToString()), float.Parse(lblTotalAmountTax.Content.ToString()), txtNote.Text);


                //For Each and Every Item place to the PurchaseOrderItems table
                for (int i = 0; i <= listViewPurchse.Items.Count - 1; i++)
                {
                    ListViewPurchase lvc = (ListViewPurchase)listViewPurchse.Items[i];
                    dl.placePurchase_PurchaseItemsTable(Int32.Parse(txtPurchaseNo.Text),dl.getItemId(lvc.Item1), lvc.Quantity, lvc.PricePerUnit);
                }


                //For Each and Every Item Tax to the PurchaseOrderTaxes table
                for (int i = 0; i <= listViewTaxDetails.Items.Count - 1; i++)
                {
                    ListViewPurchaseTaxDetails lvc = (ListViewPurchaseTaxDetails)listViewTaxDetails.Items[i];
                    dl.placePurchase_PurchaseTaxesTable(Int32.Parse(txtPurchaseNo.Text), dl.getTaxId(lvc.TaxName), lvc.TaxType, lvc.TaxAmount);
                }

                MessageBox.Show("Purchase Placed Successfully","Succeeded",MessageBoxButton.OK,MessageBoxImage.Information);
            }

            //clear All
            dtPick_PODate.Text = DateTime.Today.Date.ToShortDateString();
            cb_Supplier.Text = "";
            cb_ItemGroup.Text = "";
            cb_Item.Text = "";
            txt_Quantity.Text = "";
            txt_PPU.Text = "";
            listViewPurchse.Items.Clear();

            txt_PurchaseOrderNo.Text = "";
            //refresh the Both Amount Label
            lblTotalAmount.Content = 0;
            lblTotalAmountTax.Content = 0;
            lblItemTaxAmount.Content = 0;

            listViewTaxDetails.Items.Clear();

            txtPurchaseNo.Text = dl.getPurchaseNo().ToString();
            tabControl1.SelectedIndex = 0;
            cbRefPO.SelectedIndex = -1;
        }

        private void btnViewPO_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int po = Int32.Parse(txt_PurchaseOrderNo.Text);


            }
            catch (FormatException fe)
            {
                MessageBox.Show("Invalid Purchase Order No.","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void txt_PurchaseOrderNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int po = Int32.Parse(txt_PurchaseOrderNo.Text);
                btnViewPO.IsEnabled = true;
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Invalid Purchase Order No.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                btnViewPO.IsEnabled = false;
            }
        }
    }
}
