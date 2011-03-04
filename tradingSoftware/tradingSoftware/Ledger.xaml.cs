using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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
        private DataLogic dl;
        private List<LedgerRow> ledgerSource;
        private TradeDataSet ds;

        public Ledger()
        {
            InitializeComponent();

            dl = new DataLogic();
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
            //System.Windows.Forms.MessageBox.Show("fired");
            string ledgerSelected = textBox1.Text;
            if (ledgerSelected.Length>0)
            {
                //System.Windows.Forms.MessageBox.Show("inside IF");

                ledgerSource = new List<LedgerRow>();
                DataTable ledgerTable = dl.getLedger(ledgerSelected);
                decimal balance = 0;
                LedgerRow lr;

                foreach (DataRow dr in ledgerTable.Rows)
                {
                    //System.Windows.Forms.MessageBox.Show("foreach : " + dr[0]);
                    lr = new LedgerRow();
                    lr.TransactionID = (int)dr[0];
                    lr.DateOfTransaction = ((DateTime)dr[1]).ToShortDateString();

                    if (dr[3].ToString() == ledgerSelected)//ByAccountName==ledgerSelected
                    {
                        lr.TransactionDetails = dr[5].ToString();
                        lr.Debit = ((decimal)dr[6]).ToString();
                        lr.Credit = "";
                        balance += ((decimal)dr[6]);
                        lr.Balance = balance.ToString();
                    }
                    else //ToAccountName==ledgerSelected
                    {
                        lr.TransactionDetails = dr[3].ToString();
                        lr.Debit = "";
                        lr.Credit = ((decimal)dr[6]).ToString();
                        balance -= ((decimal)dr[6]);
                        lr.Balance = balance.ToString();
                    }
                    ledgerSource.Add(lr);
                    //System.Windows.Forms.MessageBox.Show("Added in LedgerSource : "+lr.TransactionID+" "+lr.TransactionDetails);
                }
                if (ledgerSource.Count > 0)
                {
                    //dataGridLedger = new Microsoft.Windows.Controls.DataGrid();
                    //dataGridLedger.AutoGenerateColumns = false;
                    //dataGridLedger.Margin = new Thickness(25, 52, 31, 28);
                    InitializeComponent();

                    dataGridLedger.ItemsSource = ledgerSource;
                    //System.Windows.Forms.MessageBox.Show("last");
                }
            }
        }
    }
}
