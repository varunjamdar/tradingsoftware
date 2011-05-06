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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void CompanyConfig_Click(object sender, RoutedEventArgs e)
        {
            CompanyDetails cd = new CompanyDetails();
            cd.ShowDialog();
        }

        private void Unit_Click(object sender, RoutedEventArgs e)
        {
            //open unit form
            Unit unitForm = new Unit();
            unitForm.ShowDialog();
        }

        private void CustomerDetails_Click(object sender, RoutedEventArgs e)
        {
            CustomerDetails custdet = new CustomerDetails();
            custdet.ShowDialog();
        }

        private void Location_Click(object sender, RoutedEventArgs e)
        {
            Location locationForm = new Location();
            locationForm.ShowDialog();
        }

        private void Accounts_Click(object sender, RoutedEventArgs e)
        {
            AccountSetup accountsetupform = new AccountSetup();
            accountsetupform.ShowDialog();
        }

        private void Journal_Click(object sender, RoutedEventArgs e)
        {
            Journal journalForm = new Journal();
            journalForm.ShowDialog();
        }

        private void Ledger_Click(object sender, RoutedEventArgs e)
        {
            tradingSoftware.Ledger ledgerForm = new Ledger();
            ledgerForm.ShowDialog();
        }

        private void TrialBalance_Click(object sender, RoutedEventArgs e)
        {
            tradingSoftware.TrialBalance trialBalanceForm = new TrialBalance();
            trialBalanceForm.ShowDialog();
        }

        private void ItemGroup_Click(object sender, RoutedEventArgs e)
        {
            tradingSoftware.ItemGroup itemGroupForm = new ItemGroup();
            itemGroupForm.ShowDialog();
        }
      
        private void PurchaseOrder_Click(object sender, RoutedEventArgs e)
        {
            PurchaseOrder purchaseOrderForm = new PurchaseOrder();
            purchaseOrderForm.ShowDialog();
        }

        private void GoodsReceipt_Click(object sender, RoutedEventArgs e)
        {
            Purchase1 purchaseForm = new Purchase1();
            purchaseForm.ShowDialog();
        }

        private void Payment_Click(object sender, RoutedEventArgs e)
        {
            Payment paymentForm = new Payment();
            paymentForm.ShowDialog();
        }

        private void Sale_Click(object sender, RoutedEventArgs e)
        {
            Sales salesform = new Sales();
            salesform.ShowDialog();
        }

        private void Receipt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Item_Click(object sender, RoutedEventArgs e)
        {
            Item itemForm = new Item();
            itemForm.ShowDialog();
        }

        private void SupplierCustomerConfig_Click(object sender, RoutedEventArgs e)
        {
            SupplierDetails sd = new SupplierDetails();
            sd.ShowDialog();
        }

        private void Tax_Click(object sender, RoutedEventArgs e)
        {
            Taxsetup taxform = new Taxsetup();
            taxform.ShowDialog();
        }

        private void Upgrade_Click(object sender, RoutedEventArgs e)
        {
            tradingSoftware.Upgrade upgradeform = new Upgrade();
            upgradeform.ShowDialog();
        }

        private void RestoreDb_Click(object sender, RoutedEventArgs e)
        {
            Restore restoreDbForm = new Restore();
            restoreDbForm.ShowDialog();
        }

        private void BackupDb_Click(object sender, RoutedEventArgs e)
        {
            Backup backupDbForm = new Backup();
            backupDbForm.ShowDialog();
        }

        private void NewFinancialYear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeFinancialYear_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
