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
    /// Interaction logic for Taxsetup.xaml
    /// </summary>
    public partial class Taxsetup : Window
    {
        public Taxsetup()
        {
            InitializeComponent();

            TradeDataSet tds = new TradeDataSet();
            TradeDataSetTableAdapters.TaxTableAdapter adpt = new tradingSoftware.TradeDataSetTableAdapters.TaxTableAdapter();
            adpt.Fill(tds.Tax);

            dataGrid1.DataContext = tds.Tax;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnNewTax_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddTax_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdatetax_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
