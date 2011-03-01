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

            Database.TradeDataSet ds = new tradingSoftware.Database.TradeDataSet();
            Database.TradeDataSetTableAdapters.AccountTableAdapter adpt = new tradingSoftware.Database.TradeDataSetTableAdapters.AccountTableAdapter();
            adpt.Fill(ds.Account);
            GridAdd.DataContext = ds.Account;

            DataTable dt = new DataLogic().getTransactions();
            //dataGrid1.Items.Add(
            //foreach (DataRow dr in dt.Rows)
            //{
            //    dataGrid1.Items.Add();
            //}
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
            DateTime dt = (DateTime)datePickerAdd.SelectedDate;
            string fromAccountname, toAccountName;
            decimal amount;

            if (comboBoxCD1.Text == "C")
            {
                //Crediter
                toAccountName = comboBoxParticulars1.Text;
                fromAccountname = comboBoxParticulars2.Text;
                
                amount = decimal.Parse(textBoxCredit1.Text);
            }
            else
            {
                //Debiter
                fromAccountname = comboBoxParticulars1.Text;
                toAccountName = comboBoxParticulars2.Text;
                
                amount = decimal.Parse(textBoxDebit1.Text);
            }

            dl.addJournalEntry(dt, fromAccountname, toAccountName, amount);
        }

    }
}
