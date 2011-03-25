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

        }

        private void btn_AddPurchaseItem_Click(object sender, RoutedEventArgs e)
        {
            addRow(txt_PurchaseNo.Text, dtPick_PODate.Text,cb_Supplier.Text,cb_ItemGroup.Text,cb_Item.Text,txt_Quantity.Text,txt_PPU.Text);
        }



        private void RefreshListView(string v1, string v2, string v3, string v4, string v5, string v6, string v7)
        {
            ListViewPurchaseOrder lvc = (ListViewPurchaseOrder)listViewPurchseOrder.SelectedItem;
            if (lvc != null)
            {
                lvc.PONo = v1;
                lvc.PODate = v2;
                lvc.Supplier = v3;
                lvc.ItemGroup = v4;
                lvc.Item1 = v5;
                lvc.Quantity = v6;
                lvc.PricePerUnit = v7;
                
                listViewPurchseOrder.Items.Refresh();
            }
        }

        public void addRow(string v1,string v2,string v3,string v4,string v5,string v6,string v7)
        {
            listViewPurchseOrder.Items.Add(new ListViewPurchaseOrder(v1,v2,v3,v4,v5,v6,v7));
            txt_PurchaseNo.Text = "";
            dtPick_PODate.Text = DateTime.Today.Date.ToShortDateString();
            cb_Supplier.Text = "";
            cb_ItemGroup.Text = "";
            cb_Item.Text = "";
            txt_Quantity.Text = "";
            txt_PPU.Text = "";
            listViewPurchseOrder.SelectedIndex = -1;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            for(int i=0;i<=listViewPurchseOrder.Items.Count-1;i++)
            {
                ListViewPurchaseOrder lvc = (ListViewPurchaseOrder)listViewPurchseOrder.Items[i];
                MessageBox.Show(lvc.PONo+" "+lvc.PODate);
            }
        }

        private void listViewPurchseOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ListViewPurchaseOrder lvpo = (ListViewPurchaseOrder)listViewPurchseOrder.SelectedItem;
                txt_PurchaseNo.Text = lvpo.PONo;
                dtPick_PODate.Text = lvpo.PODate;
                cb_Supplier.Text = lvpo.Supplier;
                cb_ItemGroup.Text = lvpo.ItemGroup;
                cb_Item.Text = lvpo.Item1;
                txt_Quantity.Text = lvpo.Quantity;
         
                txt_PPU.Text = lvpo.PricePerUnit;
            }
            catch (NullReferenceException nre) { }
            
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_ResetItems_Click(object sender, RoutedEventArgs e)
        {
            txt_PurchaseNo.Text = "";
            dtPick_PODate.Text = DateTime.Today.Date.ToShortDateString();
            cb_Supplier.Text = "";
            cb_ItemGroup.Text = "";
            cb_Item.Text = "";
            txt_Quantity.Text = "";
            txt_PPU.Text = "";
            listViewPurchseOrder.Items.Clear();

        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            txt_PurchaseNo.Text = "";
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
            RefreshListView(txt_PurchaseNo.Text, dtPick_PODate.Text, cb_Supplier.Text, cb_ItemGroup.Text, cb_Item.Text, txt_Quantity.Text, txt_PPU.Text);
            txt_PurchaseNo.Text = "";
            dtPick_PODate.Text = DateTime.Today.Date.ToShortDateString();
            cb_Supplier.Text = "";
            cb_ItemGroup.Text = "";
            cb_Item.Text = "";
            txt_Quantity.Text = "";
            txt_PPU.Text = "";
            listViewPurchseOrder.SelectedIndex = -1;
        }

        private void btn_RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            listViewPurchseOrder.Items.Remove(listViewPurchseOrder.SelectedItem);
            txt_PurchaseNo.Text = "";
            dtPick_PODate.Text = DateTime.Today.Date.ToShortDateString();
            cb_Supplier.Text = "";
            cb_ItemGroup.Text = "";
            cb_Item.Text = "";
            txt_Quantity.Text = "";
            txt_PPU.Text = "";
            listViewPurchseOrder.SelectedIndex = -1;
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

        private void btnAddTax_Click(object sender, RoutedEventArgs e)
        {
            string p="", a="";
            if(rbPercentage.IsChecked==true)
            {
                p = lblPercentageTax.Content.ToString();//txtPercentage.Text;
            }
            else
            {
                a=txtAmount.Text;
            }
            listViewTaxDetails.Items.Add(new ListViewPurchaseTaxDetails(cb_TaxName.Text,p,a,cb_Type.Text));
            cb_TaxName.Text = "";
            rbPercentage.IsChecked = true;
            rbValue.IsChecked = false;
            txtAmount.Text = "";
            cb_Type.SelectedIndex = 0;
            listViewTaxDetails.SelectedIndex = -1;
        }

        private void btnRemoveTax_Click(object sender, RoutedEventArgs e)
        {
            listViewTaxDetails.Items.Remove(listViewTaxDetails.SelectedItem);
            cb_TaxName.Text = "";
            rbPercentage.IsChecked = true;
            rbValue.IsChecked = false;
            txtAmount.Text = "";
            listViewTaxDetails.SelectedIndex = -1;
        }

    }
}
