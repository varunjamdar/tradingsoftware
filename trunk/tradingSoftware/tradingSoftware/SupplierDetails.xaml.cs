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
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class SupplierDetails : Window
    {
        public SupplierDetails()
        {
            InitializeComponent();

            TradeDataSet tds = new TradeDataSet();

            TradeDataSetTableAdapters.StateTableAdapter stateadpt = new tradingSoftware.TradeDataSetTableAdapters.StateTableAdapter();
            stateadpt.Fill(tds.State);

            TradeDataSetTableAdapters.CityTableAdapter cityadpt = new tradingSoftware.TradeDataSetTableAdapters.CityTableAdapter();
            cityadpt.Fill(tds.City);

            this.SupplierInformationGrid.DataContext = tds.State;

        }

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
