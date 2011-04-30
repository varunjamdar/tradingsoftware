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
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {
        DataLogic dl;
        List<string> purchaseIdList;
        List<string> paymentModeAccounts;
        public Payment()
        {
            InitializeComponent();
            datePickerPayment.Text = DateTime.Today.Date.ToShortDateString();
            dl = new DataLogic();
            lblPaymentId.Content = dl.getPaymentId().ToString();
            //set Purchase Id
            purchaseIdList = new List<string>();
            purchaseIdList = dl.getPurchaseItemIdForPayment();
            foreach (string pid in purchaseIdList)
            {
                cbRefPurchaseId.Items.Add(pid);
            }

            //set Payment Mode
            //get the AccountName of Group Assert
            paymentModeAccounts = new List<string>();
            paymentModeAccounts = dl.getPaymentModeAccounts();
            foreach (string pma in paymentModeAccounts)
            {
                cbPaymentMode.Items.Add(pma);
            }
        }

        private void cbRefPurchaseId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbRefPurchaseId.SelectedIndex != -1)
            {
                //Purchase(Goods receipt note) Details

                //get Supplier Name  Amount of Items and Tax
                Dictionary<string, string> purchaseD = new Dictionary<string, string>();

                purchaseD = dl.getPurchaseDetailsForPayment(Int32.Parse(cbRefPurchaseId.SelectedValue.ToString()));
                lblSupplier.Content = purchaseD["SupplierName"];

                lblItemAmount.Content = purchaseD["AmountItems"];
                lblTaxeAmount.Content = purchaseD["AmountTaxes"];
                txtTotal.Text = (float.Parse(purchaseD["AmountItems"]) + float.Parse(purchaseD["AmountTaxes"])).ToString();
            }
        
        }

        private void btnPayment_Click(object sender, RoutedEventArgs e)
        {
            int PaymentId = Int32.Parse(lblPaymentId.Content.ToString());
            int PurchaseId=Int32.Parse(cbRefPurchaseId.SelectedValue.ToString());
            float TotalAmount=0;
            DateTime paymaentDate = DateTime.Parse( DateTime.Today.Date.ToShortDateString());

            //Validation
            bool isError = false;
            string errorString = "";
            int errorCount=1;
            
           
            //1 Payment Mod
            if (cbPaymentMode.SelectedIndex == -1)
            {
                isError = true;
                errorString += errorCount++ + ". Select Payment Mode ! \n";
            }
            
            //2 DateTime
            try
            {
                paymaentDate = DateTime.Parse(datePickerPayment.Text);
            }
            catch(FormatException fe)
            {
                isError = true;
                errorString += errorCount++ + ". Invalid Date Formate ! \n";
            }

            //3 Purchase Combobox
            if (cbRefPurchaseId.SelectedIndex == -1)
            {
                isError = true;
                errorString += errorCount++ + ". Select Purchase Id ! \n";
            }
            else
            {

                //4 TotalAmount
                if (txtTotal.Text == "")
                {
                    isError = true;
                    errorString += errorCount++ + ". Total Amount is Empty ! \n";
                }
                else
                {
                    try
                    {
                        TotalAmount = float.Parse(txtTotal.Text);
                    }
                    catch (FormatException fe)
                    {
                        isError = true;
                        errorString += errorCount++ + ". Total Amount is not in correct Format ! \n";
                    }
                }
            }
            if (isError == true)
            {
                MessageBox.Show(errorString,"Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                MessageBoxResult mbr = MessageBox.Show("Are You Sure to Make Payment ?", "Varifiacation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (mbr == MessageBoxResult.Yes)
                {
                    dl.makePayment(PaymentId, PurchaseId, cbPaymentMode.SelectedValue.ToString(), paymaentDate, TotalAmount, txtNote.Text);

                    //Clear All Field
                    lblPaymentId.Content = dl.getPaymentId().ToString();
                    cbPaymentMode.SelectedIndex = -1;
                    datePickerPayment.Text = DateTime.Today.Date.ToShortDateString();
                    txtNote.Text = "";

                    cbRefPurchaseId.SelectedIndex = -1;
                    lblItemAmount.Content = "";
                    lblTaxeAmount.Content = "";
                    txtTotal.Text = "";

                }
                else
                {
                }
            }
        }
    }
}
