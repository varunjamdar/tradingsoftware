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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;


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

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adpt = new SqlDataAdapter();
            System.Data.DataSet ds = new System.Data.DataSet();

            con.ConnectionString = tradingSoftware.Properties.Settings.Default.TradeConnectionString;
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT t.Date, a.AccountName, b.AccountName AS Expr1, t.Amount FROM Transactions AS t INNER JOIN Account AS a ON t.ByAccountID = a.AccountID INNER JOIN Account AS b ON t.ToAccountID = b.AccountID";
            con.Open();
            adpt.SelectCommand = cmd;

            adpt.Fill(ds);
            //dataGrid2.ItemsSource = ds.Tables[0].DefaultView; //You can directly set the datagrid Itemssource; or you can create a IDictionary<string, Transaction> create transaction objects based on the dataset rows and then set the datagrid data..
        }

        private void textBox13_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
