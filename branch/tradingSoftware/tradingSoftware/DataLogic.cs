using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace tradingSoftware
{
    class DataLogic
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;

        SqlDataAdapter adpt = null;
        DataSet ds = null;

        public DataLogic()
        {
            conn = new SqlConnection();
            conn.ConnectionString = tradingSoftware.Properties.Settings.Default.TradeConnectionString;
            
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            adpt = new SqlDataAdapter();
            ds = new DataSet();
        }

        public DataTable getTransactions()
        {
            cmd.CommandText = "SELECT t.Date, a.AccountName AS 'By Account', b.AccountName AS 'To Account', t.Amount FROM Transactions AS t INNER JOIN Account AS a ON t.ByAccountID = a.AccountID INNER JOIN Account AS b ON t.ToAccountID = b.AccountID";
            conn.Open();
            adpt.SelectCommand = cmd;

            adpt.Fill(ds,"Transaction"); 
            conn.Close();
            DataTable dt=ds.Tables["Transaction"];
            ds.Clear();
            return dt; //You can directly set the datagrid Itemssource; or you can create a IDictionary<string, Transaction> create transaction objects based on the dataset rows and then set the datagrid data..
            
        }

        public void addJournalEntry(DateTime dt, string FromAccountName, string ToAccountName, decimal amount)
        {
            conn.Open();
            cmd.CommandText="SELECT AccountID FROM Account WHERE AccountName='"+FromAccountName+"'";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds);
            int byAccountID = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            ds.Clear();
            cmd.CommandText = "SELECT AccountID FROM Account WHERE AccountName='" + ToAccountName + "'";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds);
            int toAccountID = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            ds.Clear();
            
            cmd.CommandText = "INSERT into Transaction (Date, ByAccountID, ToAccountID, Amount) values('" + dt + "',"+byAccountID+","+toAccountID+","+amount+")";
            
            cmd.ExecuteNonQuery();
            conn.Close();
           
        }
    }
}
