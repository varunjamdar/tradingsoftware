using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Linq.Expressions;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace tradingSoftware
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Sale : Window
    {
        TradeDataSet ds;

        public Sale()
        {
            InitializeComponent();

            ds = new TradeDataSet();

            TradeDataSetTableAdapters.ItemGroupTableAdapter itemGroupAdpt =
                new tradingSoftware.TradeDataSetTableAdapters.ItemGroupTableAdapter();
            TradeDataSetTableAdapters.ItemTableAdapter itemAdpt =
                new tradingSoftware.TradeDataSetTableAdapters.ItemTableAdapter();
            TradeDataSetTableAdapters.SaleTableAdapter saleAdpt =
                new tradingSoftware.TradeDataSetTableAdapters.SaleTableAdapter();
            TradeDataSetTableAdapters.SaleItemsTableAdapter saleItemsAdpt =
                new tradingSoftware.TradeDataSetTableAdapters.SaleItemsTableAdapter();
            TradeDataSetTableAdapters.SaleTaxesTableAdapter saleTaxAdpt =
                new tradingSoftware.TradeDataSetTableAdapters.SaleTaxesTableAdapter();

            itemGroupAdpt.Fill(ds.ItemGroup);
            itemAdpt.Fill(ds.Item);
            saleAdpt.Fill(ds.Sale);
            saleItemsAdpt.Fill(ds.SaleItems);
            saleTaxAdpt.Fill(ds.SaleTaxes);

        }

        private void rbPercent_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbValue_Checked(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
