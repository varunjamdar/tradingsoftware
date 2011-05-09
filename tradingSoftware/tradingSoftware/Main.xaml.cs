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
using System.Threading;
using System.Windows.Threading;

namespace tradingSoftware
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private DispatcherTimer timer;
        //public System.Timers.Timer timer = new System.Timers.Timer(1000);

        
        public Window2()
        {
            InitializeComponent();

            //string hr = "";
            //string hrstatus = "am";
            //if (Int32.Parse(DateTime.Now.Hour.ToString()) > 12)
            //{
            //    hr = (Int32.Parse(DateTime.Now.Hour.ToString()) - 12).ToString();
            //    hrstatus = "pm";
            //}
            //labelTime.Content = hr + " : " + DateTime.Now.Minute.ToString() + " : " + DateTime.Now.Second.ToString() + "  " + hrstatus;
            //labelDate.Content = DateTime.Today.Date;
            //Loaded += new RoutedEventHandler(Window_Loaded);



            //--vj updated
            int hr = DateTime.Now.Hour, min = DateTime.Now.Minute, sec = DateTime.Now.Second;
            string hrstatus = "am";

            if (hr > 12)
            {
                hr -=  12;
                hrstatus = "pm";
            }

            labelTime.Content = (hr > 9 ? hr.ToString() : "0" + hr.ToString()) + " : " + (min > 9 ? min.ToString() : "0" + min.ToString()) + " : " + (sec > 9 ? sec.ToString() : "0" + sec.ToString()) + "  " + hrstatus;
            int dd = DateTime.Today.Day, mm = DateTime.Today.Month, yy = DateTime.Today.Year;
            labelDate.Content = (dd > 9 ? dd.ToString() : "0" + dd.ToString())+"/"+(mm>9?mm.ToString():"0"+mm.ToString())+"/"+yy;
            Loaded += new RoutedEventHandler(Window_Loaded);

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
            tradingSoftware.Receipt receiptForm = new Receipt();
            receiptForm.ShowDialog();
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
            tradingSoftware.NewFinancialYear newFY = new NewFinancialYear();
            newFY.ShowDialog();
        }

        private void ChangeFinancialYear_Click(object sender, RoutedEventArgs e)
        {
            tradingSoftware.ChangeFinancialYear changeFY = new ChangeFinancialYear();
            changeFY.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            timer = new DispatcherTimer();

            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Tick += timer1_Tick;



            timer.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            //string hr = "";
            //string hrstatus="am";
            //if (Int32.Parse(DateTime.Now.Hour.ToString()) > 12)
            //{
            //    hr = (Int32.Parse(DateTime.Now.Hour.ToString())-12).ToString();
            //    hrstatus = "pm";
            //}
            //labelTime.Content = hr +" : " + DateTime.Now.Minute.ToString() + " : " + DateTime.Now.Second.ToString()+"  "+hrstatus;
            //labelDate.Content = DateTime.Today.Date;



            //--vj updated
            int hr = DateTime.Now.Hour, min = DateTime.Now.Minute, sec = DateTime.Now.Second;
            int dd = DateTime.Today.Day, mm = DateTime.Today.Month, yy = DateTime.Today.Year;
            string hrstatus = "am";

            if (hr > 12)
            {
                hr -= 12;
                hrstatus = "pm";
            }

            labelTime.Content = (hr > 9 ? hr.ToString() : "0" + hr.ToString()) + " : " + (min > 9 ? min.ToString() : "0" + min.ToString()) + " : " + (sec > 9 ? sec.ToString() : "0" + sec.ToString()) + "  " + hrstatus;
            labelDate.Content = (dd > 9 ? dd.ToString() : "0" + dd.ToString()) + "/"+(mm > 9 ? mm.ToString() : "0" + mm.ToString()) + "/" + yy;
        }
    }
}
