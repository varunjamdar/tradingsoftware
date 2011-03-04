using System;
using System.Data;
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
    /// Interaction logic for TrialBalance.xaml
    /// </summary>
    public partial class TrialBalance : Window
    {
        public TrialBalance()
        {
            InitializeComponent();

            
            TradeDataSet dataset = new TradeDataSet();
            TradeDataSetTableAdapters.AccountTableAdapter adpt = new tradingSoftware.TradeDataSetTableAdapters.AccountTableAdapter();
            adpt.Fill(dataset.Account);

            List<TrialBalanceRow> trialBalanceSource = new List<TrialBalanceRow>();
            TrialBalanceRow tbr;
            List<LedgerRow> ledgerList;
            LedgerRow lr;
            decimal debitTotal = 0, creditTotal = 0;
            decimal temp;

            foreach (DataRow dr in dataset.Account.Rows)
            {
                tbr = new TrialBalanceRow();
                tbr.AccountID = (int)dr[0];
                tbr.AccountName = "" + dr[1];

                ledgerList = Ledger.getLedgerSource(tbr.AccountName);
                lr = ledgerList.Last();
                tbr.Debit = lr.Debit;
                tbr.Credit = lr.Credit;

                //if (tbr.Credit == "")
                //    debitTotal += decimal.Parse(tbr.Debit);
                //else if (tbr.Debit == "")
                //    creditTotal += decimal.Parse(tbr.Credit);

                temp = tbr.Credit == "" ? (debitTotal += decimal.Parse(tbr.Debit)) : (tbr.Debit == "" ? (creditTotal += decimal.Parse(tbr.Credit)) : 0);
                trialBalanceSource.Add(tbr);
            }
            trialBalanceSource.Add(new TrialBalanceRow()
            {
                AccountID = 0,
                AccountName = "Total",
                Credit = creditTotal.ToString(),
                Debit = debitTotal.ToString()
            });

            dataGridTrialBalance.ItemsSource = trialBalanceSource;
        }
    }
}
