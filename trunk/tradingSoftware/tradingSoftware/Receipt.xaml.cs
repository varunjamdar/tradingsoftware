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
    /// Interaction logic for Receipt.xaml
    /// </summary>
    public partial class Receipt : Window
    {
        DataLogic dl;
        List<string> saleIdList;
        List<string> paymentModeAccounts;

        public Receipt()
        {
            InitializeComponent();
            datePickerReceipt.Text = DateTime.Today.Date.ToShortDateString();
            dl = new DataLogic();
            lblReceiptId.Content = dl.getReceiptId().ToString();
            //set Sale Id
            saleIdList = dl.getSaleItemIdForReceipt();
            foreach (string sid in saleIdList)
            {
                cbRefSaleId.Items.Add(sid);
            }

            //set Receipt Mode
            //get the AccountName of Group Asset
            paymentModeAccounts = dl.getPaymentModeAccounts();
            foreach (string pma in paymentModeAccounts)
            {
                cbReceiptMode.Items.Add(pma);
            }

            //---Customer

            cbCustomer.Items.Clear();
            List<string> customerNameList = dl.getCustomerName();
            foreach (string sn in customerNameList)
            {
                cbCustomer.Items.Add(sn.ToString());
            }
        }

        private void cbRefSaleId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbRefSaleId.SelectedIndex != -1)
            {
                //Sale Details

                //get Customer Name  Amount of Items and Tax
                Dictionary<string, string> saleD = dl.getSaleDetailsForReceipt(Int32.Parse(cbRefSaleId.SelectedValue.ToString()));
                lblItemAmount.Content = saleD["AmountItems"];
                lblTaxeAmount.Content = saleD["AmountTaxes"];
                txtTotal.Text = (float.Parse(saleD["AmountItems"]) + float.Parse(saleD["AmountTaxes"])).ToString();
            }
        }

        private void btnReceipt_Click(object sender, RoutedEventArgs e)
        {
            int ReceiptId = Int32.Parse(lblReceiptId.Content.ToString());
            
            float TotalAmount=0;
            DateTime receiptDate = DateTime.Today;

            //Validation
            string errorString = "";
            int errorCount=1;
            
           
            //1 Receipt Mod
            if (cbReceiptMode.SelectedIndex == -1)
            {
                errorString += errorCount++ + ". Select Receipt Mode ! \n";
            }
            
            //2 DateTime
            try
            {
                receiptDate = DateTime.Parse(datePickerReceipt.Text);
            }
            catch(FormatException fe)
            {
                errorString += errorCount++ + ". Invalid Date Format ! \n";
            }

            //3 Customer
            if (cbCustomer.SelectedIndex==-1)
            {
                errorString += errorCount++ + ". Select Customer ! \n";
            }

            //4 Sale Combobox
            if (cbRefSaleId.SelectedIndex == -1)
            {
                errorString += errorCount++ + ". Select Sale Id ! \n";
            }
            else
            {

                //5 TotalAmount
                if (txtTotal.Text == "")
                {
                    errorString += errorCount++ + ". Total Amount is Empty ! \n";
                }
                else
                {
                    try
                    {
                        TotalAmount = float.Parse(txtTotal.Text);
                        if (TotalAmount <= 0)
                            errorString += errorCount++ + ". Total Amount must be more than zero ! \n";
                    }
                    catch (Exception fe)
                    {
                        errorString += errorCount++ + ". Total Amount is not in correct Format ! \n";
                    }
                }
            }

            if (errorCount>1)
            {
                MessageBox.Show(errorString,"Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                int SaleId = Int32.Parse(cbRefSaleId.SelectedValue.ToString());
                MessageBoxResult mbr = MessageBox.Show("Are You Sure to Make Receipt ?", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (mbr == MessageBoxResult.Yes)
                {
                    dl.makeReceipt(ReceiptId, SaleId, cbReceiptMode.SelectedValue.ToString(), receiptDate, TotalAmount, txtNote.Text);

                    //Accounting Entry
                    dl.addJournalEntry(receiptDate, cbCustomer.SelectedValue.ToString(), cbReceiptMode.SelectedValue.ToString(), decimal.Parse(lblItemAmount.Content.ToString()));

                    Dictionary<string,float> taxes = dl.getTaxesOfSale(SaleId);

                    foreach (KeyValuePair<string,float> kvp in taxes)
                    {
                        dl.addJournalEntry(receiptDate, cbCustomer.SelectedValue.ToString(), kvp.Key, decimal.Parse(kvp.Value.ToString()));
                    }


                    //Clear All Field
                    lblReceiptId.Content = dl.getReceiptId().ToString();
                    cbReceiptMode.SelectedIndex = -1;
                    datePickerReceipt.Text = DateTime.Today.Date.ToShortDateString();
                    txtNote.Text = "";

                    cbRefSaleId.SelectedIndex = -1;
                    lblItemAmount.Content = "";
                    lblTaxeAmount.Content = "";
                    txtTotal.Text = "";

                    cbRefSaleId.Items.Clear();
                    //set Sale Id
                    saleIdList = dl.getSaleItemIdForReceipt();
                    foreach (string pid in saleIdList)
                    {
                        cbRefSaleId.Items.Add(pid);
                    }

                }
                else
                {
                }
            }
        }

        private void cbCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //filter the Sale order as per Customer
            if (cbCustomer.SelectedIndex != -1)
            {
                List<int> sIdList = dl.getSaleIdForCustomer(cbCustomer.SelectedValue.ToString());

                cbRefSaleId.Items.Clear();
                foreach (int sid in sIdList)
                {
                    cbRefSaleId.Items.Add(sid.ToString());
                }
            }
        }
    }
}
