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
    /// Interaction logic for Sale.xaml
    /// </summary>
    public partial class Sale : Window
    {
        DataLogic dl = new DataLogic();

        List<int> poIdList;
        public Sale()
        {
            InitializeComponent();
            //set default date - today
            dtPick_SaleDate.Text = DateTime.Today.Date.ToShortDateString();

            //-------tax detail--
            TradeDataSet ds = new TradeDataSet();
            TradeDataSetTableAdapters.TaxTableAdapter taxApdt = new tradingSoftware.TradeDataSetTableAdapters.TaxTableAdapter();
            taxApdt.Fill(ds.Tax);
            GridTaxDetails.DataContext = ds.Tax;


            //---Supplier
            
            cb_Customer.Items.Clear();
            List<string> customerNameList = dl.getCustomerName();
            foreach (string sn in customerNameList)
            {
                cb_Customer.Items.Add(sn.ToString());
            }

            //---Item Group
            TradeDataSetTableAdapters.ItemGroupTableAdapter itemGroupAdpt = new tradingSoftware.TradeDataSetTableAdapters.ItemGroupTableAdapter();
            itemGroupAdpt.Fill(ds.ItemGroup);
            GridSale.DataContext = ds.ItemGroup;
            //----Item
            TradeDataSetTableAdapters.ItemTableAdapter itemAdpt = new tradingSoftware.TradeDataSetTableAdapters.ItemTableAdapter();
            itemAdpt.Fill(ds.Item);

            //--Max Sale Id
            txtSaleNo.Text= dl.getSaleNo().ToString();

            //purchase order
            //TradeDataSetTableAdapters.PurchaseOrderTableAdapter purchaseOrderAdpt = new tradingSoftware.TradeDataSetTableAdapters.PurchaseOrderTableAdapter();
            //purchaseOrderAdpt.Fill(ds.PurchaseOrder);
            //cbRefPO.DataContext = ds.PurchaseOrder;

            cb_Customer.SelectedIndex = -1;
            
        }

        public void refreshTaxes()
        {
            //refresh the taxes
            for (int i = 0; i <= listViewTaxDetails.Items.Count - 1; i++)
            {
                ListViewSaleTaxDetails lvc = (ListViewSaleTaxDetails)listViewTaxDetails.Items[i];
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
            lblItemTaxAmount.Content = getTotalAmountOFListViewSale() + getTotalAmountTax();
        }
        private void btn_AddSaleItem_Click(object sender, RoutedEventArgs e)
        {
            //
            //Validation
            bool Boolerror = false;
            Dictionary<int, string> error = new Dictionary<int, string>();
            int count = 0;

            //Date Validation
            try
            {
                DateTime dt = DateTime.Parse(dtPick_SaleDate.Text);
            }
            catch (FormatException)
            {
                error[count++] = "Invalid Date";
                Boolerror = true;
            }

            //
            if (cb_Customer.Text == "")
            {
                error[count++] = "Select 'Supplier'";
                Boolerror = true;
            }
            else if (cb_ItemGroup.Text == "")
            {
                error[count++] = "Select 'Item Group'";
                Boolerror = true;
            }
            //
            if (txtRefPO.Text=="")
            {
                error[count++] = "Select 'Reference Purchase Order'";
                Boolerror = true;
            }


            if (cb_Item.Text == "")
            {
                error[count++] = "Select 'Item'";
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
                error[count++] = "Invalid 'Price'";
                Boolerror = true;
            }


            if (Boolerror == true)
            {
                string errorMsg = "";
                for (int i = 0; i < error.Count; i++)
                {
                    errorMsg += (i + 1) + ". " + error[i] + "\n";
                }

                MessageBox.Show(@errorMsg, "Error !", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //
            //
            int IPONO = Int32.Parse(txtRefPO.Text);
            int IQuantity = Int32.Parse(txt_Quantity.Text);
            float FPPU = float.Parse(txt_PPU.Text);
            addRow(cb_ItemGroup.Text,cb_Item.Text,IQuantity,FPPU);


            //refresh the Both Amount Label
            lblTotalAmount.Content = getTotalAmountOFListViewSale();
            lblItemTaxAmount.Content = getTotalAmountOFListViewSale() + getTotalAmountTax();

            refreshTaxes();
        }

        


        //get Total Amount Sale
        public float getTotalAmountOFListViewSale()
        {
            float tAmount = 0;
            for (int i = 0; i <= listViewSales.Items.Count - 1; i++)
            {
                ListViewSale lvc = (ListViewSale)listViewSales.Items[i];
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
            listViewSales.Items.Add(new ListViewSale(v4,v5,v6,v7));
            dtPick_SaleDate.Text = DateTime.Today.Date.ToShortDateString();
            cb_ItemGroup.Text = "";
            cb_Item.Text = "";
            txt_Quantity.Text = "";
            txt_PPU.Text = "";
            listViewSales.SelectedIndex = -1;
        }

        private void listViewSales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ListViewSale lvpo = (ListViewSale)listViewSales.SelectedItem;
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
            dtPick_SaleDate.Text = DateTime.Today.Date.ToShortDateString();
            cb_Customer.Text = "";
            cb_ItemGroup.Text = "";
            cb_Item.Text = "";
            txt_Quantity.Text = "";
            txt_PPU.Text = "";
            listViewSales.Items.Clear();

            //refresh the Both Amount Label
            lblTotalAmount.Content = 0;
            lblTotalAmountTax.Content = 0;
            lblItemTaxAmount.Content = 0;

            listViewTaxDetails.Items.Clear();
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            dtPick_SaleDate.Text = DateTime.Today.Date.ToShortDateString();
            cb_Customer.Text = "";
            cb_ItemGroup.Text = "";
            cb_Item.Text = "";
            txt_Quantity.Text = "";
            txt_PPU.Text = "";

            listViewSales.SelectedIndex = -1;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            //
            ListViewSale lvc = (ListViewSale)listViewSales.SelectedItem;
            if (lvc != null)
            {
                lvc.ItemGroup = cb_ItemGroup.Text;
                lvc.Item1 = cb_Item.Text;
                lvc.Quantity = Int32.Parse(txt_Quantity.Text);
                lvc.PricePerUnit = float.Parse(txt_PPU.Text);
                lvc.Rs = Int32.Parse(txt_Quantity.Text) * float.Parse(txt_PPU.Text);
                listViewSales.Items.Refresh();
            }
            //
            //RefreshListView(txt_PurchaseOrderNo.Text, dtPick_SaleDate.Text, cb_Customer.Text, cb_ItemGroup.Text, cb_Item.Text, txt_Quantity.Text, txt_PPU.Text);
            dtPick_SaleDate.Text = DateTime.Today.Date.ToShortDateString();
            cb_ItemGroup.Text = "";
            cb_Item.Text = "";
            txt_Quantity.Text = "";
            txt_PPU.Text = "";
            listViewSales.SelectedIndex = -1;


            //refresh the Both Amount Label
            lblTotalAmount.Content = getTotalAmountOFListViewSale();
            lblItemTaxAmount.Content = getTotalAmountOFListViewSale() + getTotalAmountTax();

            refreshTaxes();
        }

        private void btn_RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            listViewSales.Items.Remove(listViewSales.SelectedItem);
            dtPick_SaleDate.Text = DateTime.Today.Date.ToShortDateString();
            cb_ItemGroup.Text = "";
            cb_Item.Text = "";
            txt_Quantity.Text = "";
            txt_PPU.Text = "";
            listViewSales.SelectedIndex = -1;

            //refresh the Both Amount Label
            lblTotalAmount.Content = getTotalAmountOFListViewSale();
            lblItemTaxAmount.Content = getTotalAmountOFListViewSale() + getTotalAmountTax();

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
            lblItemTaxAmount.Content = getTotalAmountOFListViewSale() + getTotalAmountTax();
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
                ListViewSaleTaxDetails lvc = (ListViewSaleTaxDetails)listViewTaxDetails.Items[i];
                if (lvc.TaxType == "Exclusive")
                {
                    tAmountTax += lvc.TaxAmount;
                }
            }
            return tAmountTax;

        }

        private void btnAddTax_Click(object sender, RoutedEventArgs e)
        {
            bool BoolerrorTax = false;
            Dictionary<int, string> errorTax = new Dictionary<int, string>();
            int countTax = 0;

            //
            //Validation

            if (cb_TaxName.SelectedIndex == -1)
            {
                errorTax[countTax++] = "Select 'Purchase Order'";
                BoolerrorTax = true;
            }

            if (cb_Type.SelectedIndex == -1)
            {
                errorTax[countTax++] = "Select Tax Type";
                BoolerrorTax = true;
            }

            if (rbValue.IsChecked==true)
            {
                try
                {
                    int q = Int32.Parse(txtAmount.Text);
                    if (q <= 0)
                    {
                        errorTax[countTax++] = "Price must be greater than 0";
                        BoolerrorTax = true;
                    }

                }
                catch (FormatException)
                {
                    errorTax[countTax++] = "Invalid Tax Amount";
                    BoolerrorTax = true;
                }
            }

            if (BoolerrorTax == true)
            {
                string errorMsgTax = "";
                for (int i = 0; i < errorTax.Count; i++)
                {
                    errorMsgTax += (i + 1) + ". " + errorTax[i] + "\n";
                }

                MessageBox.Show(@errorMsgTax, "Error !", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //

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
            listViewTaxDetails.Items.Add(new ListViewSaleTaxDetails(cb_TaxName.Text,p,a,cb_Type.Text,float.Parse(lblTotalAmount.Content.ToString())));
            cb_TaxName.Text = "";
            rbPercentage.IsChecked = true;
            rbValue.IsChecked = false;
            txtAmount.Text = "";
            cb_Type.SelectedIndex = 0;
            listViewTaxDetails.SelectedIndex = -1;

            cb_Type.SelectedIndex = -1;

            //Display Total Amount Tax
            lblTotalAmountTax.Content = getTotalAmountTax();
            lblItemTaxAmount.Content = getTotalAmountOFListViewSale() + getTotalAmountTax();
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
            lblItemTaxAmount.Content = getTotalAmountOFListViewSale() + getTotalAmountTax();
        }

        private void cb_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btnPlaceSale_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<int, string> errorSales = new Dictionary<int, string>();
            int countError = -1;
            //
            //validation
            if (listViewSales.Items.Count == 0)
            {
                errorSales[++countError] = "Select 'Add Items'";
            }
            if (listViewTaxDetails.Items.Count == 0)
            {
                errorSales[++countError] = "Select 'Add Taxes'";
            }
            if (chkBIsChallan.IsChecked.HasValue && chkBIsChallan.IsChecked.Value)
            {
                int i;
                try
                {
                     i= Int32.Parse(txtDeliveryNoteNo.Text);
                }
                catch (ArgumentNullException ae)
                {
                    errorSales.Add(++countError, "Enter Delivery Note Number.");
                }
                catch (Exception fe)
                {
                    errorSales.Add(++countError, "Invalid Delivery Note Number.");
                }

                if (dtPick_ChallanDate.Text == "")
                {
                    errorSales.Add(++countError, "Select Challan Date.");
                }
                else
                {
                    if (dtPick_ChallanDate.SelectedDate.Value.CompareTo(dtPick_SaleDate.SelectedDate.Value) < 0)
                        errorSales.Add(++countError, "Challan cannot be created before Sale Date.");
                }

                if (cBPaymentMode.SelectedIndex < 0)
                    errorSales.Add(++countError, "Select Mode of Payment.");

                try
                {
                    i = Int32.Parse(txtLRNo.Text);
                }
                catch (ArgumentNullException ane)
                {
                    errorSales.Add(++countError, "Enter Lorry Receipt Number.");
                }
                catch (Exception ex)
                {
                    errorSales.Add(++countError, "Invalid Lorry Receipt Number.");
                }
                
                if(txtDespatchThru.Text=="")
                    errorSales.Add(++countError, "Enter Despatched Through Details.");

                if(txtDestination.Text=="")
                    errorSales.Add(++countError, "Enter Destination.");
            }
            
            if (countError>=0)
            {
                string errorMsg = "";
                for (int i = 0; i <= countError; i++)
                {
                    errorMsg += (i + 1) + ". " + errorSales[i] + "\n";
                }

                MessageBox.Show(errorMsg, "Error !", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //
            MessageBoxResult mbr = MessageBox.Show("Are You Sure to place sale ?", "Verification", MessageBoxButton.YesNo,MessageBoxImage.Question);

            if (mbr == MessageBoxResult.Yes)
            {
                string customerName = (string)cb_Customer.Text;
                
                int customerId = dl.getCustomerId(customerName);
                dl.placeSale_SaleTable(Int32.Parse(txtSaleNo.Text), Int32.Parse(txtRefPO.Text), DateTime.Parse(dtPick_SaleDate.Text), customerId, float.Parse(lblTotalAmount.Content.ToString()), float.Parse(lblTotalAmountTax.Content.ToString()), txtNote.Text);


                //For Each and Every Item place to the PurchaseOrderItems table
                for (int i = 0; i <= listViewSales.Items.Count - 1; i++)
                {
                    ListViewSale lvc = (ListViewSale)listViewSales.Items[i];
                    dl.placeSale_SaleItemsTable(Int32.Parse(txtSaleNo.Text),dl.getItemId(lvc.Item1), lvc.Quantity, lvc.PricePerUnit);
                }


                //For Each and Every Item Tax to the PurchaseOrderTaxes table
                for (int i = 0; i <= listViewTaxDetails.Items.Count - 1; i++)
                {
                    ListViewSaleTaxDetails lvc = (ListViewSaleTaxDetails)listViewTaxDetails.Items[i];
                    dl.placeSale_SaleTaxesTable(Int32.Parse(txtSaleNo.Text), dl.getTaxId(lvc.TaxName), lvc.TaxType, lvc.TaxAmount);
                }
                
                //Challan
                if (chkBIsChallan.IsChecked.HasValue && chkBIsChallan.IsChecked.Value)
                {
                    dl.placeSale_ChallanTable(Int32.Parse(txtDeliveryNoteNo.Text), Int32.Parse(txtSaleNo.Text), dtPick_ChallanDate.SelectedDate.Value, cBPaymentMode.Text, Int32.Parse(txtLRNo.Text), txtDespatchThru.Text, txtDestination.Text);
                }

                MessageBox.Show("Sale Placed Successfully","Succeeded",MessageBoxButton.OK,MessageBoxImage.Information);
            
                
                //clear All
                dtPick_SaleDate.Text = DateTime.Today.Date.ToShortDateString();
                cb_Customer.Text = "";
                cb_ItemGroup.Text = "";
                cb_Item.Text = "";
                txt_Quantity.Text = "";
                txt_PPU.Text = "";
                listViewSales.Items.Clear();

                //refresh the Both Amount Label
                lblTotalAmount.Content = 0;
                lblTotalAmountTax.Content = 0;
                lblItemTaxAmount.Content = 0;

                listViewTaxDetails.Items.Clear();

                txtSaleNo.Text = dl.getSaleNo().ToString();
                tabControl1.SelectedIndex = 0;
                txtRefPO.Text = "";

            }

            
        }

        private void cb_Customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //no need to filter purchase order as per customer, since we are not storing sales order
            
        }

        private void chkBIsChallan_Checked(object sender, RoutedEventArgs e)
        {
            txtDeliveryNoteNo.IsEnabled = true;
            dtPick_ChallanDate.IsEnabled = true;
            cBPaymentMode.IsEnabled = true;
            txtLRNo.IsEnabled = true;
            txtDespatchThru.IsEnabled = true;
            txtDestination.IsEnabled = true;

        }

        private void chkBIsChallan_Unchecked(object sender, RoutedEventArgs e)
        {
            txtDeliveryNoteNo.Text = "";
            dtPick_ChallanDate.Text = "";
            cBPaymentMode.SelectedIndex = -1;
            txtLRNo.Text = "";
            txtDespatchThru.Text = "";
            txtDestination.Text = "";

            txtDeliveryNoteNo.IsEnabled = false;
            dtPick_ChallanDate.IsEnabled = false;
            cBPaymentMode.IsEnabled = false;
            txtLRNo.IsEnabled = false;
            txtDespatchThru.IsEnabled = false;
            txtDestination.IsEnabled = false;
        }
    }
}