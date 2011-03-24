using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using XamlGeneratedNamespace;
using System.Data.Sql;
using System.Data.SqlClient;

namespace tradingSoftware
{
    /// <summary>
    /// Interaction logic for Ledger.xaml
    /// </summary>
    public partial class Ledger : Window
    {
        private List<LedgerRow> ledgerSource;
        private TradeDataSet ds;

        public Ledger()
        {
            InitializeComponent();

            ledgerSource = new List<LedgerRow>();

            ds = new TradeDataSet();
            TradeDataSetTableAdapters.AccountTableAdapter adpt = new tradingSoftware.TradeDataSetTableAdapters.AccountTableAdapter();
            adpt.Fill(ds.Account);
            GridLedger.DataContext = ds.Account;
        }

        private void comboBoxLedger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxLedger.Text == "")
            {
                return;
            }

            string ledgerSelected = textBox1.Text;
            if (ledgerSelected.Length>0)
            {
                ledgerSource = getLedgerSource(ledgerSelected);

                #region
                //==============
                //ledgerSource = new List<LedgerRow>();
                //DataTable ledgerTable = dl.getLedger(ledgerSelected);
                //decimal balance = 0;
                //LedgerRow lr;

                //foreach (DataRow dr in ledgerTable.Rows)
                //{
                //    lr = new LedgerRow();
                //    lr.TransactionID = (int)dr[0];
                //    lr.DateOfTransaction = ((DateTime)dr[1]).ToShortDateString();

                //    if (dr[3].ToString() == ledgerSelected)//ByAccountName==ledgerSelected
                //    {
                //        lr.TransactionDetails = dr[5].ToString();
                //        lr.Debit = ((decimal)dr[6]).ToString();
                //        lr.Credit = "";
                //        balance += ((decimal)dr[6]);
                //        lr.Balance = balance.ToString();
                //    }
                //    else //ToAccountName==ledgerSelected
                //    {
                //        lr.TransactionDetails = dr[3].ToString();
                //        lr.Debit = "";
                //        lr.Credit = ((decimal)dr[6]).ToString();
                //        balance -= ((decimal)dr[6]);
                //        lr.Balance = balance.ToString();
                //    }
                //    ledgerSource.Add(lr);
                //}
                #endregion

                if (ledgerSource.Count > 0)
                {
                    InitializeComponent();
                    dataGridLedger.ItemsSource = ledgerSource;
                }
            }
        }

        public static List<LedgerRow> getLedgerSource(string ledgerName)
        {
            List<LedgerRow> ledgerGridSource = new List<LedgerRow>();
            DataLogic dataLogic = new DataLogic();
            DataTable ledgerTable = dataLogic.getLedger(ledgerName);

            decimal balance = 0;
            LedgerRow lr;

            foreach (DataRow dr in ledgerTable.Rows)
            {
                lr = new LedgerRow();
                lr.TransactionID = (int)dr[0];
                lr.DateOfTransaction = ((DateTime)dr[1]).ToShortDateString();

                if (dr[3].ToString() == ledgerName)//ByAccountName==ledgerName
                {
                    lr.TransactionDetails = dr[5].ToString();
                    lr.Debit = ((decimal)dr[6]).ToString();
                    lr.Credit = "";
                    balance += ((decimal)dr[6]);
                    lr.Balance = Math.Abs(balance).ToString();
                }
                else //ToAccountName==ledgerName
                {
                    lr.TransactionDetails = dr[3].ToString();
                    lr.Debit = "";
                    lr.Credit = ((decimal)dr[6]).ToString();
                    balance -= ((decimal)dr[6]);
                    lr.Balance = Math.Abs(balance).ToString();
                }
                ledgerGridSource.Add(lr);
            }
            lr = new LedgerRow();
            lr.TransactionID = -1;
            lr.Balance = lr.DateOfTransaction = "";
            lr.TransactionDetails = "Closing Balance";
            if (balance > 0)
            {
                lr.Debit = balance.ToString();
                lr.Credit = "";
            }
            else if (balance < 0)
            {
                lr.Credit = Math.Abs(balance).ToString();
                lr.Debit = "";
            }
            else
                lr.Debit = lr.Credit = Math.Abs(balance).ToString();

            ledgerGridSource.Add(lr);

            return ledgerGridSource;
        }
    }
}
