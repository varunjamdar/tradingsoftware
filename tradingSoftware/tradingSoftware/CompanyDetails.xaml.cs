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
        CompanyObject company;
        DataLogic dl;

        public CompanyDetails()
        {
            InitializeComponent();
            DataLogic dl = new DataLogic();
            //this.cmbCompanyState.DataContext = dl.showState();

            TradeDataSet tds = new TradeDataSet();
            TradeDataSetTableAdapters.StateTableAdapter stateadpt = new tradingSoftware.TradeDataSetTableAdapters.StateTableAdapter();
            stateadpt.Fill(tds.State);

            //City adpt and ds are necessary.. ha ha ha
            TradeDataSetTableAdapters.CityTableAdapter cityadpt = new tradingSoftware.TradeDataSetTableAdapters.CityTableAdapter();
            cityadpt.Fill(tds.City);
            
            this.BasicInformationGrid.DataContext = tds.State;

            cmbVatGst.SelectedIndex = 1;

            dl = new DataLogic();
            if (dl.checkFinancialyearSetup())
            {
                company=new CompanyObject();
                company = dl.retrieveCompanyDetails();

                txtCompanyName.Text = company.CompanyName;
                txtCompanyPrintName.Text = company.CompanyPrintName;
                dtFinancialYearBegin.SelectedDate = company.FyStartDate;

                dtFinancialYearBegin.IsEnabled = false;

                dtBooksCommencing.SelectedDate = company.BooksCommencing;
                txtCompanyAddLine1.Text = company.AddLine1;
                txtCompanyAddLine2.Text = company.AddLine2;
                txtCompanyAddLine3.Text = company.AddLine3;
                cmbCompanyCity.SelectedValue = company.City.ToString();
                txtCompanyPin.Text = company.Pin.ToString();
                cmbCompanyState.SelectedValue = company.State.ToString();
                txtCompanyCountry.Text = company.Country;
                txtCompanyPhone1.Text = company.PhoneNo1;
                txtCompanyPhone2.Text = company.PhoneNo2;
                txtCompanyWebsite.Text = company.Website;
                txtCompanyEmailId.Text = company.EmailId;
                txtCompanyFax.Text = company.Fax;
                cmbVatGst.Text = company.VatGst.ToString();
                //txtCompanyTinNo.Text = company.TinNo;
                if (company.TinNo == int.Parse("0").ToString())
                {
                    txtCompanyTinNo.Text = "";
                }
                else
                {
                    txtCompanyTinNo.Text = company.TinNo;
                }
                if (company.VatGstDate == DateTime.Parse("1/1/1800"))
                {
                    dtVatGstDate.SelectedDate = DateTime.MinValue;
                }
                else
                {
                    dtVatGstDate.SelectedDate = company.VatGstDate;
                }

                txtCstNo.Text = company.CstNo;

                if (company.CstDate == DateTime.Parse("1/1/1800"))
                {
                    dtCstDate.SelectedDate = DateTime.MinValue;
                }
                else
                {
                    dtCstDate.SelectedDate = company.CstDate;
                }

                TxtPanNo.Text = company.PanNo;
                TxtServiceTaxNo.Text = company.ServiceTaxNo;
                txtcompanylogo.Text = company.ImagePath;
            }
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
                dtVatGstDate.SelectedDate = DateTime.Today;
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



        private void btnCompanySave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtCompanyName.Text == "")
                {
                    MessageBox.Show("Enter the Company Name", "WARNING");
                    return;
                }

                if (txtCompanyPrintName.Text == "")
                {
                    MessageBox.Show("Enter Company Print Name before proceeding", "WARNING");
                    return;
                }

                if (TxtPanNo.Text == "")
                {
                    MessageBox.Show("Enter PAN NO of the Company before proceeding", "WARNING");
                    return;
                }

                if (txtcompanylogo.Text == "")
                {
                    MessageBox.Show("Browse Path of Company Logo", "WARNING");
                    return;
                }

                company = new CompanyObject();

                company.CompanyName = txtCompanyName.Text.ToString();
                company.CompanyPrintName = txtCompanyPrintName.Text;

                try
                {
                    // Validations.DateValidator(dtFinancialYearBegin.SelectedDate);
                    company.FyStartDate = (DateTime)dtFinancialYearBegin.SelectedDate;
                }
                catch (NullValueException nve)
                {

                    MessageBox.Show("Error in Financial Year : Null Value cannot be entered");
                    return;
                }
                catch (FormatException fe)
                {
                    string str = fe.Message;
                    MessageBox.Show("Error in Financial Year : " + str);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    string str = ioe.Message;
                    MessageBox.Show("Error in Financial Year : " + str);
                    return;
                }

                try
                {
                    //Validations.DateValidator(dtBooksCommencing.SelectedDate);
                    company.BooksCommencing = (DateTime)dtBooksCommencing.SelectedDate;
                }
                catch (NullValueException nve)
                {

                    MessageBox.Show("Error in Books Commencing Date : Null Value cannot be entered");
                    return;
                }
                catch (FormatException fe)
                {
                    string str = fe.Message;
                    MessageBox.Show("Error in Books Commencing Date : " + str);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    string str = ioe.Message;
                    MessageBox.Show("Error in Books Commencing Date : " + str);
                    return;
                }

                try
                {
                    Validations.NullValidator(txtCompanyAddLine1.Text);
                    company.AddLine1 = txtCompanyAddLine1.Text;
                }
                catch (NullValueException nve)
                {
                    string str = nve.Message;
                    MessageBox.Show("Error in Address : " + str);
                    return;
                }
                company.AddLine2 = txtCompanyAddLine2.Text;
                company.AddLine3 = txtCompanyAddLine3.Text;
                company.City = cmbCompanyCity.Text;
                try
                {
                    Validations.NumberValidator(txtCompanyPin.Text);
                    company.Pin = int.Parse(txtCompanyPin.Text);
                }
                catch (FormatException fe)
                {
                    string str = fe.Message;
                    MessageBox.Show("Error in Pin Code : " + str, "WARNING");
                    return;
                }
                company.State = cmbCompanyState.Text;
                company.Country = txtCompanyCountry.Text;
                try
                {
                    Validations.PhoneNoValidator(txtCompanyPhone1.Text);
                    company.PhoneNo1 = txtCompanyPhone1.Text;
                }
                catch (PhoneNoErrorException phe)
                {
                    string str = phe.Message;
                    MessageBox.Show("Error in Phone No 1 : " + str, "Warning");
                    return;
                }
                try
                {
                    Validations.PhoneNoValidator(txtCompanyPhone2.Text);
                    company.PhoneNo2 = txtCompanyPhone2.Text;
                }
                catch (PhoneNoErrorException phe)
                {
                    string str = phe.Message;
                    MessageBox.Show("Error in Phone No 2 : " + str, "Warning");
                    return;
                }
                company.Website = txtCompanyWebsite.Text;
                company.EmailId = txtCompanyEmailId.Text;
                try
                {
                    Validations.PhoneNoValidator(txtCompanyFax.Text);
                    company.Fax = txtCompanyFax.Text;
                }
                catch (PhoneNoErrorException phe)
                {
                    string str = phe.Message;
                    MessageBox.Show("Error in Fax : " + str, "Warning");
                    return;
                }
                company.VatGst = cmbVatGst.Text;
                try
                {
                    Validations.NumberValidator(txtCompanyTinNo.Text);
                    company.TinNo = txtCompanyTinNo.Text;
                }
                catch (FormatException fe)
                {
                    string str = fe.Message;
                    MessageBox.Show("Error in Tin No : " + str, "WARNING");
                    return;
                }
                if (cmbVatGst.SelectedIndex == 1)
                {
                    company.VatGstDate = DateTime.Parse("1/1/1800");
                }
                else
                {
                    company.VatGstDate = (DateTime)dtVatGstDate.SelectedDate;
                }
                try
                {
                    Validations.NumberValidator(txtCstNo.Text);
                    company.CstNo = txtCstNo.Text;
                }
                catch (FormatException fe)
                {
                    string str = fe.Message;
                    MessageBox.Show("Error in CST Number : " + str, "WARNING");
                    return;
                }
                if (cmbVatGst.SelectedValue == null)
                {
                    company.CstDate = DateTime.Parse("1/1/1800");
                }
                else
                {
                    company.CstDate = (DateTime)dtCstDate.SelectedDate;
                }

                //try
                //{
                //    Validations.NumberValidator(TxtPanNo.Text);
                    company.PanNo = TxtPanNo.Text;
                //}
                //catch (FormatException fe)
                //{
                //    string str = fe.Message;
                //    MessageBox.Show("Error in PAN Number : " + str, "WARNING");
                //    return;
                //}

                try
                {
                    Validations.NumberValidator(TxtServiceTaxNo.Text);
                    company.ServiceTaxNo = TxtServiceTaxNo.Text;
                }
                catch (FormatException fe)
                {
                    string str = fe.Message;
                    MessageBox.Show("Error in Service Tax Number : " + str, "WARNING");
                    return;
                }

                try
                {
                    Validations.NullValidator(txtcompanylogo.Text);
                    company.ImagePath = txtcompanylogo.Text;
                }
                catch (NullValueException nve)
                {
                    string str = nve.Message;
                    MessageBox.Show("Error in Image Path : " + str);
                    return;
                }

            }
            catch (Exception exception)
            {
                string str = exception.Message;
                MessageBox.Show("Error in Company Details : " + str);
                return;
            }

                dl = new DataLogic();
                dl.addCompanyDetails(company);

                MessageBox.Show("Your Data has been saved", "Message");
            
        }

        private void txtCompanyName_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtCompanyPrintName.Text = txtCompanyName.Text;
        }

        private void btnCompanyQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dtFinancialYearBegin_TextInput(object sender, TextCompositionEventArgs e)
        {
            dl = new DataLogic();

            if (dl.checkFinancialyearSetup())
            {
                dtFinancialYearBegin.IsEnabled = false;
            }
        }       
    }
}
