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
    /// Interaction logic for CustSuppDetails.xaml
    /// </summary>
    public partial class CustomerDetails : Window
    {
        DataLogic dl;
        CustomerObject co;
        CustomersFind customerfind;

        public CustomerDetails()
        {
            InitializeComponent();

            InitializeComponent();

            TradeDataSet tds = new TradeDataSet();

            TradeDataSetTableAdapters.StateTableAdapter stateadpt = new tradingSoftware.TradeDataSetTableAdapters.StateTableAdapter();
            stateadpt.Fill(tds.State);

            TradeDataSetTableAdapters.CityTableAdapter cityadpt = new tradingSoftware.TradeDataSetTableAdapters.CityTableAdapter();
            cityadpt.Fill(tds.City);

            this.CustomerInformationGrid.DataContext = tds.State;

            cmbVatGst.SelectedIndex = 1;
        }

        private void cmbVatGst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbVatGst.SelectedIndex == 0)
            {
                cmbVatGstType.IsHitTestVisible = true;
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

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            txtSupplierId.Text = "";
            txtSupplierCompany.Text = "";
            txtContactPerson.Text = "";
            txtAddLine1.Text = "";
            txtAddLine2.Text = "";
            txtAddLine3.Text = "";
            cmbCity.SelectedIndex = -1;
            txtPin.Text = "";
            cmbState.SelectedIndex = -1;
            txtPhone1.Text = "";
            txtPhone2.Text = "";
            txtWebsite.Text = "";
            txtEmail.Text = "";
            txtFax.Text = "";
            cmbVatGst.SelectedItem = 1;
            txtCompanyTinNo.Text = "";
            dtVatGstDate.SelectedDate = null;
            txtCstNo.Text = "";
            dtCstDate.SelectedDate = null;
            TxtPanNo.Text = "";
            TxtServiceTaxNo.Text = "";
            txtCreditCapacity.Text = "";
            cmbCreditRating.SelectedIndex = -1;
            txtPaymentTerms.Text = "";
            txtDelivery.Text = "";
            txtPaymentMode.Text = "";
            txtFreightTerms.Text = "";
            txtInsurance.Text = "";
            txtPacking.Text = "";
            txtPenalty.Text = "";


            txtSupplierCompany.IsEnabled = true;

            dl = new DataLogic();
            int custId = dl.getNextCustomerId();
            txtSupplierId.Text = custId.ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtSupplierId.Text == "")
                {
                    MessageBox.Show("Click NEW to add NEW value", "WARNING");
                    return;
                }

                if (txtSupplierCompany.Text == "")
                {
                    MessageBox.Show("Customer Information cannot be stored without the name of the company", "WARNING");
                    return;
                }

                if (TxtPanNo.Text == "")
                {
                    MessageBox.Show("Customer PAN Number Cannot Be null", "WARNING");
                    return;
                }

                co = new CustomerObject();

                co.CustomerId = int.Parse(txtSupplierId.Text.ToString());
                co.CustomerCompany = txtSupplierCompany.Text.ToString();
                co.ContactPerson = txtContactPerson.Text.ToString();
                co.AddLine1 = txtAddLine1.Text.ToString();
                co.AddLine2 = txtAddLine2.Text.ToString();
                co.AddLine3 = txtAddLine3.Text.ToString();
                co.City = cmbCity.Text.ToString();
                co.Pin = txtPin.Text.ToString();
                co.State = cmbCity.Text.ToString();

                if (txtPhone1.Text != "")
                {
                    try
                    {
                        Validations.PhoneNoValidator(txtPhone1.Text);
                        co.PhoneNo1 = txtPhone1.Text;
                    }
                    catch (PhoneNoErrorException phe)
                    {
                        string str = phe.Message;
                        MessageBox.Show("Error in Phone No 1 : " + str, "Warning");
                        return;
                    }
                }
                else
                {
                    co.PhoneNo1 = txtPhone1.Text;
                }

                if (txtPhone2.Text != "")
                {
                    try
                    {
                        Validations.PhoneNoValidator(txtPhone2.Text);
                        co.PhoneNo2 = txtPhone2.Text;
                    }
                    catch (PhoneNoErrorException phe)
                    {
                        string str = phe.Message;
                        MessageBox.Show("Error in Phone No 2 : " + str, "Warning");
                        return;
                    }
                }
                else
                {
                    co.PhoneNo2 = txtPhone2.Text;
                }
                co.Website = txtWebsite.Text;
                co.EmailId = txtEmail.Text;
                if (txtFax.Text != "")
                {
                    try
                    {
                        Validations.PhoneNoValidator(txtFax.Text);
                        co.Fax = txtFax.Text;
                    }
                    catch (PhoneNoErrorException phe)
                    {
                        string str = phe.Message;
                        MessageBox.Show("Error in Fax : " + str, "Warning");
                        return;
                    }
                }
                else
                {
                    co.Fax = txtFax.Text;
                }
                co.VatGst = cmbVatGst.Text;
                try
                {
                    Validations.NumberValidator(txtCompanyTinNo.Text);
                    co.TinNo = txtCompanyTinNo.Text;
                }
                catch (FormatException fe)
                {
                    string str = fe.Message;
                    MessageBox.Show("Error in Tin No : " + str, "WARNING");
                    return;
                }
                if (cmbVatGst.SelectedIndex == 1)
                {
                    co.VatGstDate = DateTime.Parse("1/1/1800");
                }
                else
                {
                    co.VatGstDate = (DateTime)dtVatGstDate.SelectedDate;
                }
                try
                {
                    Validations.NumberValidator(txtCstNo.Text);
                    co.CstNo = txtCstNo.Text;
                }
                catch (FormatException fe)
                {
                    string str = fe.Message;
                    MessageBox.Show("Error in CST Number : " + str, "WARNING");
                    return;
                }
                //if ()
                //{
                //    so.CstDate = DateTime.Parse("1/1/1800");
                //}
                //else
                //{
                //    so.CstDate = (DateTime)dtCstDate.SelectedDate;
                //}
                try
                {
                    co.CstDate = (DateTime)dtCstDate.SelectedDate;
                }
                catch (Exception excep)
                {
                    co.CstDate = DateTime.Parse("1/1/1800");
                }
                try
                {
                    Validations.NumberValidator(TxtPanNo.Text);
                    co.PanNo = TxtPanNo.Text;
                }
                catch (FormatException fe)
                {
                    string str = fe.Message;
                    MessageBox.Show("Error in PAN Number : " + str, "WARNING");
                    return;
                }

                try
                {
                    Validations.NumberValidator(TxtServiceTaxNo.Text);
                    co.ServiceTaxNo = TxtServiceTaxNo.Text;
                }
                catch (FormatException fe)
                {
                    string str = fe.Message;
                    MessageBox.Show("Error in Service Tax Number : " + str, "WARNING");
                    return;
                }

                try
                {
                    Validations.NumberValidator(txtCreditCapacity.Text);
                    co.CreditCapacity = txtCreditCapacity.Text.ToString();
                }
                catch (FormatException fe)
                {
                    string str = fe.Message;
                    MessageBox.Show("Error in Credit Capacity Offered : " + str, "WARNING");
                    return;
                }

                //so.CreditCapacity = txtCreditCapacity.Text.ToString();
                co.Rating = cmbCreditRating.Text.ToString();
                co.PaymentTerms = txtPaymentTerms.Text.ToString();
                co.Delivery = txtDelivery.Text.ToString();
                co.PaymentMode = txtPaymentMode.Text;
                co.FreightTerms = txtFreightTerms.Text;
                co.Insurance = txtInsurance.Text;
                co.Packing = txtPacking.Text.ToString();
                co.Penalty = txtPenalty.Text.ToString();
            }
            catch (Exception exception)
            {
                string str = exception.Message;
                MessageBox.Show("Error in parameters of Supplier : " + str, "WARNING");
                return;
            }

            dl = new DataLogic();
            //try
            //{

            string reply = dl.AddCustomer(co);
            MessageBox.Show("" + reply);
            //}
            //catch (Exception exception)
            //{
            //    string str = exception.Message;
            //    MessageBox.Show("Error in Adding Supplier Details: " + str, "WARNING");
            //    return;
            //}


            txtSupplierId.Text = "";
            txtSupplierCompany.Text = "";
            txtContactPerson.Text = "";
            txtAddLine1.Text = "";
            txtAddLine2.Text = "";
            txtAddLine3.Text = "";
            cmbCity.Text = "";
            txtPin.Text = "";
            cmbState.Text = "";
            txtPhone1.Text = "";
            txtPhone2.Text = "";
            txtWebsite.Text = "";
            txtEmail.Text = "";
            txtFax.Text = "";
            cmbVatGst.Text = "";
            txtCompanyTinNo.Text = "";
            dtVatGstDate.SelectedDate = null;
            txtCstNo.Text = "";
            dtCstDate.SelectedDate = null;
            TxtPanNo.Text = "";
            TxtServiceTaxNo.Text = "";
            txtCreditCapacity.Text = "";
            cmbCreditRating.SelectedIndex = -1;
            txtPaymentTerms.Text = "";
            txtDelivery.Text = "";
            txtPaymentMode.Text = "";
            txtFreightTerms.Text = "";
            txtInsurance.Text = "";
            txtPacking.Text = "";
            txtPenalty.Text = "";
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            customerfind = new CustomersFind(this);
            customerfind.ShowDialog();
        }

        public void populate(int custId)
        {
            dl = new DataLogic();

            co = new CustomerObject();

            co = dl.getDetailsOfCustomerId(custId);

            txtSupplierId.Text = co.CustomerId.ToString();
            txtSupplierCompany.Text = co.CustomerCompany.ToString();
            txtContactPerson.Text = co.ContactPerson.ToString();
            txtAddLine1.Text = co.AddLine1.ToString();
            txtAddLine2.Text = co.AddLine2.ToString();
            txtAddLine3.Text = co.AddLine3.ToString();
            cmbCity.Text = co.City.ToString();
            txtPin.Text = co.Pin.ToString();
            cmbState.Text = co.State.ToString();
            if (co.PhoneNo1 == int.Parse("0").ToString())
            {
                txtPhone1.Text = "";
            }
            else
            {
                txtPhone1.Text = co.PhoneNo1;
            }
            if (co.PhoneNo2 == int.Parse("0").ToString())
            {
                txtPhone2.Text = "";
            }
            else
            {
                txtPhone2.Text = co.PhoneNo2;
            }
            txtWebsite.Text = co.Website.ToString();
            txtEmail.Text = co.EmailId.ToString();
            if (co.Fax == int.Parse("0").ToString())
            {
                txtFax.Text = "";
            }
            else
            {
                txtFax.Text = co.Fax;
            }
            cmbVatGst.Text = co.VatGst.ToString();

            if (co.TinNo == int.Parse("0").ToString())
            {
                txtCompanyTinNo.Text = "";
            }
            else
            {
                txtCompanyTinNo.Text = co.TinNo.ToString();
            }

            if (co.VatGstDate == DateTime.Parse("1/1/1800"))
            {
                dtVatGstDate.SelectedDate = null;
            }
            else
            {
                dtVatGstDate.SelectedDate = co.VatGstDate;
            }

            txtCstNo.Text = co.CstNo.ToString();
            if (co.CstNo == int.Parse("0").ToString())
            {
                txtCstNo.Text = "";
            }
            else
            {
                txtCstNo.Text = co.CstNo.ToString();
            }

            if (co.CstDate == DateTime.Parse("1/1/1800"))
            {
                dtCstDate.SelectedDate = null;
            }
            else
            {
                dtCstDate.SelectedDate = co.CstDate;
            }
            TxtPanNo.Text = co.PanNo.ToString();


            if (co.ServiceTaxNo.ToString() == int.Parse("0").ToString())
            {
                TxtServiceTaxNo.Text = "";
            }
            else
            {
                TxtServiceTaxNo.Text = co.ServiceTaxNo.ToString();
            }


            if (co.CreditCapacity == int.Parse("0").ToString())
            {
                txtCreditCapacity.Text = "";
            }
            else
            {
                txtCreditCapacity.Text = co.CreditCapacity.ToString();
            }

            cmbCreditRating.Text = co.CreditCapacity.ToString();
            txtPaymentTerms.Text = co.PaymentTerms.ToString();
            txtDelivery.Text = co.Delivery.ToString();
            txtPaymentMode.Text = co.PaymentMode.ToString();
            txtFreightTerms.Text = co.FreightTerms.ToString();
            txtInsurance.Text = co.Insurance.ToString();
            txtPacking.Text = co.Packing.ToString();
            txtPenalty.Text = co.Penalty.ToString();

            txtSupplierCompany.IsEnabled = false;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
