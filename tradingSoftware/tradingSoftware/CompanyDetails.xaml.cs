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
using System.IO;
using Microsoft.Win32;


namespace tradingSoftware
{
    /// <summary>
    /// Interaction logic for CompanyDetails.xaml
    /// </summary>
    public partial class CompanyDetails : Window
    {
        public CompanyDetails()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.DefaultExt = ".ico";
            ofd.Filter = " icon files (*.ico)|*.ico|Bitmap files (*.bmp)|*.bmp|gif files (*.gif)|*.gif|jpeg files (*.jpeg)|*.jpeg|jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;

            Nullable<bool> result = ofd.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = ofd.FileName;
                txtcompanylogo.Text = filename;
            }


        }

        private void cmbVatGst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string x = cmbVatGst.SelectedItem.ToString();
            //MessageBox.Show(x);
            if (x == "System.Windows.Controls.ComboBoxItem: Yes")
            {
                cmbVatGstType.IsHitTestVisible = true;
                //cmbVatGstType.IsEditable = true;
                cmbVatGstType.IsEnabled = true;
                txtCompanyTinNo.IsEnabled = true;
                
                dtVatGstDate.IsEnabled = true;
            }
            else
            {
                cmbVatGstType.IsHitTestVisible = false;
                cmbVatGstType.IsEditable = false;
                cmbVatGstType.IsEnabled = false;
                cmbVatGstType.SelectedValue = "";

                txtCompanyTinNo.Text = "";
                txtCompanyTinNo.IsEnabled = false;

                dtVatGstDate.Text = "";
                dtVatGstDate.IsEnabled = false;
            }
        }

        DataLogic dl = new DataLogic();

        private void btnCompanySave_Click(object sender, RoutedEventArgs e)
        {
            dl.addCompanyDetails(txtCompanyName.Text, txtCompanyPrintName.Text, (DateTime)dtFinancialYearBegin.SelectedDate, (DateTime)dtBooksCommencing.SelectedDate, txtCompanyAddLine1.Text, txtCompanyAddLine2.Text, txtCompanyAddLine3.Text, cmbCompanyCity.Text, int.Parse(txtCompanyPin.Text), cmbCompanyState.Text, txtCompanyCountry.Text, int.Parse(txtCompanyPhone1.Text), int.Parse(txtCompanyPhone2.Text), txtCompanyWebsite.Text, txtCompanyEmailId.Text, int.Parse(txtCompanyFax.Text), cmbVatGstType.Text, int.Parse(txtCompanyTinNo.Text), (DateTime)dtVatGstDate.SelectedDate, int.Parse(txtCstNo.Text), (DateTime)dtCstDate.SelectedDate, int.Parse(TxtPanNo.Text), int.Parse(TxtServiceTaxNo.Text), txtcompanylogo.Text);
        }

           

        
    }
}
