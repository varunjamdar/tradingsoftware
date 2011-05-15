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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Shared;
using tradingSoftware;

namespace tradingSoftware
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PurchaseOrderReportHost : Window
    {
//        private Purchase objRpt;
        private PurchaseOrderReport objRpt;
        private CrystalReportViewer crystalReportViewer1;

        private int PurchaseOrderId=4;

        public PurchaseOrderReportHost(int i)
        {
            InitializeComponent();
            PurchaseOrderId = i;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowsFormsHost host = new WindowsFormsHost();
            crystalReportViewer1 = new CrystalReportViewer();
            objRpt = new PurchaseOrderReport();
            //objRpt = new Accounts();

            //tryCrystalReport.TradeDataSet ds = new TradeDataSet();
            
            //tryCrystalReport.TradeDataSetTableAdapters.PurchaseOrderTableAdapter POAdpt = new tryCrystalReport.TradeDataSetTableAdapters.PurchaseOrderTableAdapter();
            //tryCrystalReport.TradeDataSetTableAdapters.SupplierTableAdapter SuppAdpt = new tryCrystalReport.TradeDataSetTableAdapters.SupplierTableAdapter();
            //tryCrystalReport.TradeDataSetTableAdapters.PurchaseOrderItemsTableAdapter POItem = new tryCrystalReport.TradeDataSetTableAdapters.PurchaseOrderItemsTableAdapter();
            //tryCrystalReport.TradeDataSetTableAdapters.ItemGroupTableAdapter ItemGrpAdpt = new tryCrystalReport.TradeDataSetTableAdapters.ItemGroupTableAdapter();

            
            //POAdpt.Fill(ds.PurchaseOrder);
            //SuppAdpt.Fill(ds.Supplier);
            //POItem.Fill(ds.PurchaseOrderItems);
            //ItemGrpAdpt.Fill(ds.ItemGroup);
            

            //----------------
            SqlDataAdapter adpt = new SqlDataAdapter();
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();

            con.ConnectionString = tradingSoftware.Properties.Settings.Default.TradeConnectionString;
            cmd.CommandType = CommandType.Text;
            
            cmd.CommandText = "Select * from PurchaseOrder where PurchaseOrderId="+PurchaseOrderId;
            cmd.Connection = con;
            adpt.SelectCommand = cmd;
            con.Open();
           
            adpt.Fill(ds,"PurchaseOrder");
            //con.Close();

            cmd.CommandText = "Select * from Supplier where SupplierId=" + ds.Tables["PurchaseOrder"].Rows[0]["SupplierId"].ToString();
            adpt.Fill(ds, "Supplier");

            cmd.CommandText = "Select * from PurchaseOrderItems where PurchaseOrderId=" + PurchaseOrderId;
            adpt.Fill(ds, "PurchaseOrderItems");

            cmd.CommandText = "Select * from Item where ItemId in (Select ItemId from PurchaseOrderItems where PurchaseOrderId="+PurchaseOrderId+")";
            adpt.Fill(ds, "Item");

            cmd.CommandText = "Select 'Total' from Item where ItemId in (Select ItemId from PurchaseOrderItems where PurchaseOrderId=" + PurchaseOrderId + ")";
            adpt.Fill(ds, "Item");

            cmd.CommandText = "Select * from CompanyDetails";
            adpt.Fill(ds, "CompanyDetails");
            
            con.Close();
            //----------------

            objRpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = objRpt;
            host.Child = crystalReportViewer1;
            gridMain.Children.Add(host);
        }
    }
}
