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

        public void addCompanyDetails(string CompName, string CompPrintName, DateTime FYStartDate, DateTime BooksCommFrom, string AddLine1, string AddLine2, string AddLine3, string City, int Pin, string State, string Country, int PhoneNo1, int PhoneNo2, string Website, string Email, int Fax, string VatGst, int TinNo, DateTime VatGstDate, int CstNo, DateTime CstDate, int PanNo, int ServiceTaxNo, string Image)
        {
            conn.Open();
            cmd.CommandText = "Insert into CompanyDetails (CompanyName, CompanyPrintName, FYStartDate, BooksCommencingFrom, AddressLine1, Addressline2, AddressLine3, City, Pin, State, Country, PhoneNo1, PhoneNo2, Website, EmailId, Fax, VatGst, TinNo, VatGstDate, CstNo, CstDate, PanNo, ServiceTaxNo, Image) values ('" + CompName + "','" + CompPrintName + "','" + FYStartDate + "','" + BooksCommFrom + "','" + AddLine1 + "','" + AddLine2 + "','" + AddLine3 + "','" + City + "'," + Pin + ",'" + State + "','" + Country + "'," + PhoneNo1 + "," + PhoneNo2 + ",'" + Website + "','" + Email + "'," + Fax + ",'" + VatGst + "','" + TinNo + "','" + VatGstDate + "'," + CstNo + ",'" + CstDate + "'," + PanNo + "," + ServiceTaxNo + ",'" + Image + "');";

            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public void addCompanyDetails(string CompName,string CompPrintName,DateTime FYStartDate, DateTime BooksCommFrom, string AddLine1, string AddLine2, string AddLine3, string City, int Pin, string State, string Country, int PhoneNo1, int PhoneNo2, string Website, string Email, int Fax, string VatGst, int TinNo, DateTime VatGstDate, int CstNo, DateTime CstDate, int PanNo, int ServiceTaxNo, string Image)
        {
            conn.Open();
            cmd.CommandText = "Insert into CompanyDetails (CompanyName, CompanyPrintName, FYStartDate, BooksCommencingFrom, AddressLine1, Addressline2, AddressLine3, City, Pin, State, Country, PhoneNo1, PhoneNo2, Website, EmailId, Fax, VatGst, TinNo, VatGstDate, CstNo, CstDate, PanNo, ServiceTaxNo, Image) values ('" + CompName + "','" + CompPrintName + "','" + FYStartDate + "','" + BooksCommFrom + "','" + AddLine1 + "','" + AddLine2 + "','" + AddLine3 + "','" + City + "'," + Pin + ",'" + State + "','" + Country + "'," + PhoneNo1 + "," + PhoneNo2 + ",'" + Website + "','" + Email + "'," + Fax + ",'" + VatGst + "','" + TinNo + "','" + VatGstDate + "'," + CstNo + ",'" + CstDate + "'," + PanNo + "," + ServiceTaxNo + ",'" + Image + "');";

            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public DataTable getTransactions()
        {
            ds.Clear();
            cmd.CommandText = "SELECT t.TransactionID, t.Date, t.ByAccountID, a.AccountName AS 'By Account', t.ToAccountID, b.AccountName AS 'To Account', t.Amount, t.Narration FROM Transactions AS t INNER JOIN Account AS a ON t.ByAccountID = a.AccountID INNER JOIN Account AS b ON t.ToAccountID = b.AccountID";
            conn.Open();
            adpt.SelectCommand = cmd;

            adpt.Fill(ds, "Transactions");
            conn.Close();
            return ds.Tables["Transactions"];
            //You can directly set the datagrid Itemssource; or you can create a IDictionary<string, Transaction> create transaction objects based on the dataset rows and then set the datagrid data..
        }

        public void addJournalEntry(DateTime dt, string FromAccountName, string ToAccountName, decimal amount)
        {
            ds.Clear();

            cmd.CommandText = "SELECT AccountID FROM Account WHERE AccountName='" + FromAccountName + "'";
            adpt.SelectCommand = cmd;
            conn.Open();


            conn.Open();
            adpt.Fill(ds);
            int byAccountID = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            ds.Clear();
            cmd.CommandText = "SELECT AccountID FROM Account WHERE AccountName='" + ToAccountName + "'";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds);
            int toAccountID = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            ds.Clear();

            cmd.CommandText = "INSERT into [Transactions] (Date, ByAccountID, ToAccountID, Amount) values('" + dt + "'," + byAccountID + "," + toAccountID + "," + amount + ")";

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void updateJournal(int transactionID, DateTime dateOfTransaction, int byAccountID, int toAccountID, decimal amount, string narration)
        {

        }

        public DataTable getLedger(string LedgerName)
        {

            ds = new DataSet();
            cmd.CommandText = "SELECT AccountID FROM ACCOUNT WHERE AccountName='" + LedgerName + "'";
            adpt.SelectCommand = cmd;

            ds = new DataSet();
            cmd.CommandText = "SELECT AccountID FROM ACCOUNT WHERE AccountName='"+LedgerName+"'";
            adpt.SelectCommand = cmd;

            conn.Open();
            adpt.Fill(ds);
            int accountID = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            ds.Tables.Clear();
            cmd.CommandText = @"SELECT t.TransactionID, t.Date, t.ByAccountID, a.AccountName AS 'By Account', t.ToAccountID, b.AccountName AS 'To Account', t.Amount, t.Narration FROM Transactions AS t INNER JOIN Account AS a ON t.ByAccountID = a.AccountID INNER JOIN Account AS b ON t.ToAccountID = b.AccountID WHERE t.ByAccountID=" + accountID + " OR t.ToAccountID=" + accountID + "";
            adpt.Fill(ds);
            conn.Close();
            return ds.Tables[0];
        }

        //public bool numberCheck(int i)
        //{
        //    if ((i > 47 && i < 58) || (i == 55) || (i == 56) || (i == 8))
        //        return false;// in these cases no check is to be issued
        //    else return true;//true only if char is present
        //}
    }
}
