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
        DataLogic dl;
        public Taxsetup()
        {
            InitializeComponent();
			
            dl = new DataLogic();

            TradeDataSet ds=new TradeDataSet();
            TradeDataSetTableAdapters.TaxTableAdapter taxAdpt = new tradingSoftware.TradeDataSetTableAdapters.TaxTableAdapter();
            taxAdpt.Fill(ds.Tax);
            listViewTax.DataContext = ds.Tax;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAddTax_Click(object sender, RoutedEventArgs e)
        {
            float taxPer = 0;
            //Validation
           
            if (txtTaxName.Text == "")
            {
                MessageBox.Show("Invalid Tax Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (txtTaxPercentage.Text != "")
            {

                try
                {
                    taxPer = float.Parse(txtTaxPercentage.Text);
                    if (taxPer <= 0)
                    {
                        MessageBox.Show("Invalid Percentage", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                catch (FormatException ce)
                {
                    MessageBox.Show("Incorrect Format of Percentage", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Input Percentage", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            //Add tax to the db
            string info = dl.addTax(txtTaxName.Text, float.Parse(txtTaxPercentage.Text));
            MessageBox.Show(info);
            txtTaxName.IsEnabled = false;
            txtTaxPercentage.IsEnabled = false;

            //refresh the taxListView
            TradeDataSet ds = new TradeDataSet();
            TradeDataSetTableAdapters.TaxTableAdapter taxAdpt = new tradingSoftware.TradeDataSetTableAdapters.TaxTableAdapter();
            taxAdpt.Fill(ds.Tax);
            listViewTax.DataContext = ds.Tax;

            txtTaxName.Text = "";
            txtTaxPercentage.Text = "";
            
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            txtTaxName.IsEnabled = true;
            txtTaxPercentage.IsEnabled = true;
        }

        private void listViewTax_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listViewTax.SelectedIndex != -1)
            {
                txtTaxName.IsEnabled = false;
                System.Data.DataRowView dr = (System.Data.DataRowView)listViewTax.SelectedItem;

                txtTaxName.Text = dr[1].ToString();
                txtTaxPercentage.Text = dr[2].ToString();
                txtTaxPercentage.IsEnabled = true;
            }
        }

        private void btnEditTax_Click(object sender, RoutedEventArgs e)
        {
            if (txtTaxName.IsEnabled == true || txtTaxName.Text=="")
            {
                MessageBox.Show("Select Tax From The List", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            float taxPer = 0;
            //Validation
            if (txtTaxPercentage.Text != "")
            {
                try
                {
                    taxPer = float.Parse(txtTaxPercentage.Text);
                    taxPer = float.Parse(txtTaxPercentage.Text);
                    if (taxPer <= 0)
                    {
                        MessageBox.Show("Invalid Percentage", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                catch (FormatException ce)
                {
                    MessageBox.Show("Incorrect Format of Percentage", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Input Percentage", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Edit the Value to database
            dl.editTax(txtTaxName.Text, float.Parse(txtTaxPercentage.Text));
            MessageBox.Show("Tax Updated Successfully");

            TradeDataSet ds = new TradeDataSet();
            TradeDataSetTableAdapters.TaxTableAdapter taxAdpt = new tradingSoftware.TradeDataSetTableAdapters.TaxTableAdapter();
            taxAdpt.Fill(ds.Tax);
            listViewTax.DataContext = ds.Tax;

            listViewTax.SelectedIndex = -1;
            txtTaxName.Text = "";
            txtTaxName.IsEnabled = false;
            txtTaxPercentage.Text = "";
            txtTaxPercentage.IsEnabled = false;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
