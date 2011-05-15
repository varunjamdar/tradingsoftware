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
using System.Data.Sql;
using System.Data.SqlClient;

namespace tradingSoftware
{
    /// <summary>
    /// Interaction logic for Journal.xaml
    /// </summary>
    public partial class Journal : Window
    {
        public Journal()
        {
            InitializeComponent();

            TradeDataSet ds = new tradingSoftware.TradeDataSet();
            TradeDataSetTableAdapters.AccountTableAdapter adpt = new tradingSoftware.TradeDataSetTableAdapters.AccountTableAdapter();
            adpt.Fill(ds.Account);
            dgAddJournalEntry.DataContext = ds.Account;

            DataTable transactionTable = new DataLogic().getTransactions();
            
            List<JournalRow> journalSource = new List<JournalRow>(); //list that implements IEnumerable. so that it can be set as item source of grid.
            List<Transaction> transactions = new List<Transaction>();

            foreach (DataRow dr in transactionTable.Rows)
            {
                journalSource.Add(new JournalRow()
                {
                    TransactionID = (int)dr[0],
                    DateOfTransaction = ((DateTime)dr[1]).ToShortDateString(),
                    DebitOrCredit = "D",
                    TransactionDetails = "" + dr[3],
                    Debit = ((decimal)dr[6]).ToString(),
                    Credit = "",
                    Narration = "" + dr[7]
                });

                journalSource.Add(new JournalRow()
                {
                    TransactionID = (int)dr[0],
                    DateOfTransaction = "",
                    DebitOrCredit = "C",
                    TransactionDetails = "To  " + dr[5],
                    Debit = "",
                    Credit = ((decimal)dr[6]).ToString(),
                    Narration = "" + dr[7]
                });

                transactions.Add(new Transaction()
                {
                    TransactionID = (int)dr[0],
                    DateOfTransaction = (DateTime)dr[1],
                    ByAccountID = (int)dr[2],
                    ToAccountID = (int)dr[4],
                    Amount = (decimal)dr[6],
                    Narration = "" + dr[7]
                });
            }
            dgViewEditJournal.ItemsSource = journalSource;

        }

        private void comboBoxCD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxCD1.Text == "")
            {
                //bcz initially text is null
            }
            else if (comboBoxCD1.Text == "C")
            {
                //First Row C
                //Second Row D

                textBoxDebit1.IsEnabled = true;
                textBoxDebit2.IsEnabled =false;
                textBoxDebit2.Text = "";
                
                textBoxCredit1.IsEnabled = false;
                textBoxCredit1.Text = "";
                textBoxCredit2.IsEnabled = true;

                textBoxCD2.Text = "C";
            }
            else
            {
                //First Row D
                //Second Row C
                
                textBoxDebit1.IsEnabled = false;
                textBoxDebit1.Text = "";
                textBoxDebit2.IsEnabled = true;

                textBoxCredit1.IsEnabled = true;
                textBoxCredit2.IsEnabled = false;
                textBoxCredit2.Text = "";

                textBoxCD2.Text = "D";
            }
        }
       
        private void textBoxDebit1_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBoxCredit2.Text = textBoxDebit1.Text;
        }

        private void textBoxCredit1_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBoxDebit2.Text = textBoxCredit1.Text;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DataLogic dl = new DataLogic();
            DateTime dt=DateTime.Today;
            string fromAccountname="", toAccountName="";
            decimal amount=0;

            string errorString = "";
            int errorCount=0;

            if (comboBoxCD1.Text == "C")
            {
                //Crediter

                toAccountName = comboBoxParticulars1.Text;
                fromAccountname = comboBoxParticulars2.Text;

                try
                {
                    amount = decimal.Parse(textBoxCredit1.Text);
                }
                catch (FormatException fe)
                {
                    errorCount++;
                    errorString += "Invalid Amount !\n";
                }
                catch (Exception ex)
                {
                    errorCount++;
                    errorString += "Invalid Input ! \n";
                }
            }
            else
            {
                //Debiter
                fromAccountname = comboBoxParticulars1.Text;
                toAccountName = comboBoxParticulars2.Text;

                try
                {
                    amount = decimal.Parse(textBoxDebit1.Text);
                }
                catch (FormatException fe1)
                {
                    errorCount++;
                    errorString += "Invalid Amount !\n";
                }
                catch (Exception e1)
                {
                    errorCount++;
                    errorString += "Invalid Input ! \n";
                }
            }

            if (comboBoxParticulars1.SelectedIndex == -1)
            {
                errorCount++;
                errorString += "Select Account !\n";
            }

            if (comboBoxParticulars2.SelectedIndex == -1)
            {
                errorCount++;
                errorString += "Select Account !\n";
            }

            try
            {
                dt = DateTime.Parse(datePickerAdd.Text);
            }
            catch (Exception ex2)
            {
                errorCount++;
                errorString += "Invalid Date ! \n";
               
            }


            if (errorCount > 0)
            {
                MessageBox.Show(errorString,"Warning !");
            }
            else
            {
                dl.addJournalEntry(dt, fromAccountname, toAccountName, amount);
                MessageBox.Show("Journal Entry made successfully !!");
            }
        }

    }
}
