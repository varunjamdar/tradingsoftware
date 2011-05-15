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
        DataLogic dl;
        SupplierObject so;
        SuppliersFind supplpierfind;

        public SupplierDetails()
        {
            InitializeComponent();

            TradeDataSet tds = new TradeDataSet();

            TradeDataSetTableAdapters.StateTableAdapter stateadpt = new tradingSoftware.TradeDataSetTableAdapters.StateTableAdapter();
            stateadpt.Fill(tds.State);

            TradeDataSetTableAdapters.CityTableAdapter cityadpt = new tradingSoftware.TradeDataSetTableAdapters.CityTableAdapter();
            cityadpt.Fill(tds.City);

            this.SupplierInformationGrid.DataContext = tds.State;

            cmbVatGst.SelectedIndex = 1;

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
            int suppId = dl.getNextSupplierId();
            txtSupplierId.Text = suppId.ToString();

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
                    MessageBox.Show("Supplier Information cannot be stored without the name of the company", "WARNING");
                    return;
                }

                if (TxtPanNo.Text == "")
                {
                    MessageBox.Show("Supplier PAN Number Cannot Be null", "WARNING");
                    return;
                }

                so = new SupplierObject();

                so.SupplierId = int.Parse(txtSupplierId.Text.ToString());
                so.SupplierCompany = txtSupplierCompany.Text.ToString();
                so.ContactPerson = txtContactPerson.Text.ToString();
                so.AddLine1 = txtAddLine1.Text.ToString();
                so.AddLine2 = txtAddLine2.Text.ToString();
                so.AddLine3 = txtAddLine3.Text.ToString();
                so.City = cmbCity.Text.ToString();
                so.Pin = txtPin.Text.ToString();
                so.State = cmbCity.Text.ToString();

                if (txtPhone1.Text != "")
                {
                    try
                    {
                        Validations.PhoneNoValidator(txtPhone1.Text);
                        so.PhoneNo1 = txtPhone1.Text;
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
                    so.PhoneNo1 = txtPhone1.Text;
                }

                if (txtPhone2.Text != "")
                {
                    try
                    {
                        Validations.PhoneNoValidator(txtPhone2.Text);
                        so.PhoneNo2 = txtPhone2.Text;
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
                    so.PhoneNo2 = txtPhone2.Text;
                }
                so.Website = txtWebsite.Text;
                so.EmailId = txtEmail.Text;
                if (txtFax.Text != "")
                {
                    try
                    {
                        Validations.PhoneNoValidator(txtFax.Text);
                        so.Fax = txtFax.Text;
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
                    so.Fax = txtFax.Text;
                }
                so.VatGst = cmbVatGst.Text;
                try
                {
                    Validations.NumberValidator(txtCompanyTinNo.Text);
                    so.TinNo = txtCompanyTinNo.Text;
                }
                catch (FormatException fe)
                {
                    string str = fe.Message;
                    MessageBox.Show("Error in Tin No : " + str, "WARNING");
                    return;
                }
                if (cmbVatGst.SelectedIndex == 1)
                {
                    so.VatGstDate = DateTime.Parse("1/1/1800");
                }
                else
                {
                    so.VatGstDate = (DateTime)dtVatGstDate.SelectedDate;
                }
                try
                {
                    Validations.NumberValidator(txtCstNo.Text);
                    so.CstNo = txtCstNo.Text;
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
                    so.CstDate = (DateTime)dtCstDate.SelectedDate;
                }
                catch (Exception excep)
                {
                    so.CstDate = DateTime.Parse("1/1/1800");
                }
                try
                {
                    Validations.NumberValidator(TxtPanNo.Text);
                    so.PanNo = TxtPanNo.Text;
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
                    so.ServiceTaxNo = TxtServiceTaxNo.Text;
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
                    so.CreditCapacity = txtCreditCapacity.Text.ToString();
                }
                catch (FormatException fe)
                {
                    string str = fe.Message;
                    MessageBox.Show("Error in Credit Capacity Offered : " + str, "WARNING");
                    return;
                }

                //so.CreditCapacity = txtCreditCapacity.Text.ToString();
                so.Rating = cmbCreditRating.Text.ToString();
                so.PaymentTerms = txtPaymentTerms.Text.ToString();
                so.Delivery = txtDelivery.Text.ToString();
                so.PaymentMode = txtPaymentMode.Text;
                so.FreightTerms = txtFreightTerms.Text;
                so.Insurance = txtInsurance.Text;
                so.Packing = txtPacking.Text.ToString();
                so.Penalty = txtPenalty.Text.ToString();
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

                string reply = dl.AddSupplier(so);
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
                cmbCreditRating.SelectedIndex=-1;
                txtPaymentTerms.Text = "";
                txtDelivery.Text = "";
                txtPaymentMode.Text = "";
                txtFreightTerms.Text = "";
                txtInsurance.Text = "";
                txtPacking.Text = "";
                txtPenalty.Text = "";
            

            
        }

        private void cmbVatGst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // string x = cmbVatGst.SelectedItem.ToString();
            //MessageBox.Show(x);
            //if (x == "System.Windows.Controls.ComboBoxItem: Yes")
            if(cmbVatGst.SelectedIndex==0)
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

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            supplpierfind = new SuppliersFind(this);
            supplpierfind.ShowDialog();
        }
        public void populate(int suppId)
        {
            dl = new DataLogic();

            so = new SupplierObject();

            so = dl.getDetailsOfSupplierId(suppId);

            txtSupplierId.Text = so.SupplierId.ToString();
            txtSupplierCompany.Text = so.SupplierCompany.ToString();
            txtContactPerson.Text = so.ContactPerson.ToString() ;
            txtAddLine1.Text = so.AddLine1.ToString();
            txtAddLine2.Text = so.AddLine2.ToString();
            txtAddLine3.Text = so.AddLine3.ToString();
            cmbCity.Text = so.City.ToString();
            txtPin.Text = so.Pin.ToString();
            cmbState.Text = so.State.ToString();
            if (so.PhoneNo1 == int.Parse("0").ToString())
            {
                txtPhone1.Text = "";
            }
            else
            {
                txtPhone1.Text = so.PhoneNo1;
            }
            if (so.PhoneNo2 == int.Parse("0").ToString())
            {
                txtPhone2.Text = "";
            }
            else
            {
                txtPhone2.Text = so.PhoneNo2;
            }
            txtWebsite.Text = so.Website.ToString();
            txtEmail.Text = so.EmailId.ToString();
            if (so.Fax == int.Parse("0").ToString())
            {
                txtFax.Text = "";
            }
            else
            {
                txtFax.Text = so.Fax;
            }
            cmbVatGst.Text = so.VatGst.ToString();

            if (so.TinNo == int.Parse("0").ToString())
            {
                txtCompanyTinNo.Text = "";
            }
            else
            {
                txtCompanyTinNo.Text = so.TinNo.ToString();
            }

            if (so.VatGstDate == DateTime.Parse("1/1/1800"))
            {
                dtVatGstDate.SelectedDate = null;
            }
            else
            {
                dtVatGstDate.SelectedDate = so.VatGstDate;
            }

            txtCstNo.Text = so.CstNo.ToString();
            if (so.CstNo == int.Parse("0").ToString())
            {
                txtCstNo.Text = "";
            }
            else
            {
                txtCstNo.Text = so.CstNo.ToString();
            }

            if (so.CstDate == DateTime.Parse("1/1/1800"))
            {
                dtCstDate.SelectedDate = null;
            }
            else
            {
                dtCstDate.SelectedDate = so.CstDate;
            }
            TxtPanNo.Text = so.PanNo.ToString();
            

            if (so.ServiceTaxNo.ToString() == int.Parse("0").ToString())
            {
                TxtServiceTaxNo.Text = "";
            }
            else
            {
                TxtServiceTaxNo.Text = so.ServiceTaxNo.ToString();
            }
            

            if (so.CreditCapacity == int.Parse("0").ToString())
            {
                txtCreditCapacity.Text = "";
            }
            else
            {
                txtCreditCapacity.Text = so.CreditCapacity.ToString();
            }

            cmbCreditRating.Text = so.CreditCapacity.ToString();
            txtPaymentTerms.Text = so.PaymentTerms.ToString();
            txtDelivery.Text = so.Delivery.ToString();
            txtPaymentMode.Text = so.PaymentMode.ToString();
            txtFreightTerms.Text = so.FreightTerms.ToString();
            txtInsurance.Text = so.Insurance.ToString();
            txtPacking.Text = so.Packing.ToString();
            txtPenalty.Text = so.Penalty.ToString();
            
            txtSupplierCompany.IsEnabled = false;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
