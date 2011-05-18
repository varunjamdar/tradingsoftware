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
    /// Interaction logic for PurchaseOrderReportSelector.xaml
    /// </summary>
    public partial class PurchaseOrderReportSelector : Window
    {
        public PurchaseOrderReportSelector()
        {
            InitializeComponent();

            TradeDataSet tds = new TradeDataSet();
            tradingSoftware.TradeDataSetTableAdapters.SupplierTableAdapter suppAdpt = new tradingSoftware.TradeDataSetTableAdapters.SupplierTableAdapter();
            tradingSoftware.TradeDataSetTableAdapters.PurchaseOrderTableAdapter poAdpt = new tradingSoftware.TradeDataSetTableAdapters.PurchaseOrderTableAdapter();

            suppAdpt.Fill(tds.Supplier);
            poAdpt.Fill(tds.PurchaseOrder);

            GridPOSelect.DataContext = tds.Supplier;
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = Int32.Parse(cBPOId.Text);
                PurchaseOrderReportHost POHost = new PurchaseOrderReportHost(i);
                POHost.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Select Purchase Order ID !!");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
