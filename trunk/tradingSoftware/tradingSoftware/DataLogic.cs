using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace tradingSoftware
{
    public class DataLogic
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;

        SqlDataAdapter adpt = null;
        DataSet ds = null;
        DataSet ds1 = null;

        ItemObject io;
        AccountObject ao;

        public DataLogic()
        {
            conn = new SqlConnection();
			
            conn.ConnectionString = tradingSoftware.Properties.Settings.Default.TradeConnectionString;

            //string dbPath = Environment.CurrentDirectory + @"\" + tradingSoftware.Properties.Settings.Default.DBFile;
            //conn.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename="+dbPath+";Integrated Security=True;User Instance=True";
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            adpt = new SqlDataAdapter();
            ds = new DataSet();
            ds1 = new DataSet();
        }

        public void addCompanyDetails(CompanyObject company)
        {
            //cmd.CommandText = "Select CompanyId from CompanyDetails where CompanyId=" + company.CompanyId;
            cmd.CommandText = "Select CompanyId from CompanyDetails where CompanyId=1";
            adpt.SelectCommand = cmd;
            ds.Clear();
            conn.Open();
            adpt.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count == 0)
            {
                cmd.CommandText = "Insert into CompanyDetails (CompanyId, CompanyName, CompanyPrintName, FYStartDate, BooksCommencingFrom, AddressLine1, Addressline2, AddressLine3, City, Pin, State, Country, PhoneNo1, PhoneNo2, Website, EmailId, Fax, VatGst, TinNo, VatGstDate, CstNo, CstDate, PanNo, ServiceTaxNo, Image) values (1,@CompanyName, @CompanyPrintName, @FYStartDate, @BooksCommencingFrom, @AddressLine1, @Addressline2, @AddressLine3, @City, @Pin, @State, @Country, @PhoneNo1, @PhoneNo2, @Website, @EmailId, @Fax, @VatGst, @TinNo, @VatGstDate, @CstNo, @CstDate, @PanNo, @ServiceTaxNo, @Image);";

                cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar);
                cmd.Parameters.Add("@CompanyPrintName", SqlDbType.VarChar);
                cmd.Parameters.Add("@FYStartDate", SqlDbType.DateTime);
                cmd.Parameters.Add("@BooksCommencingFrom", SqlDbType.DateTime);
                cmd.Parameters.Add("@AddressLine1", SqlDbType.VarChar);
                cmd.Parameters.Add("@AddressLine2", SqlDbType.VarChar);
                cmd.Parameters.Add("@AddressLine3", SqlDbType.VarChar);
                cmd.Parameters.Add("@City", SqlDbType.VarChar);
                cmd.Parameters.Add("@Pin", SqlDbType.Int);
                cmd.Parameters.Add("@State", SqlDbType.VarChar);
                cmd.Parameters.Add("@Country", SqlDbType.VarChar);
                cmd.Parameters.Add("@PhoneNo1", SqlDbType.VarChar);
                cmd.Parameters.Add("@PhoneNo2", SqlDbType.VarChar);
                cmd.Parameters.Add("@Website", SqlDbType.VarChar);
                cmd.Parameters.Add("@EmailId", SqlDbType.VarChar);
                cmd.Parameters.Add("@Fax", SqlDbType.VarChar);
                cmd.Parameters.Add("@VatGst", SqlDbType.VarChar);
                cmd.Parameters.Add("@TinNo", SqlDbType.VarChar);
                cmd.Parameters.Add("@VatGstDate", SqlDbType.DateTime);
                cmd.Parameters.Add("@CstNo", SqlDbType.VarChar);
                cmd.Parameters.Add("@CstDate", SqlDbType.DateTime);
                cmd.Parameters.Add("@PanNo", SqlDbType.VarChar);
                cmd.Parameters.Add("@ServiceTaxNo", SqlDbType.VarChar);
                cmd.Parameters.Add("@Image", SqlDbType.VarChar);

                cmd.Parameters["@CompanyName"].Value = company.CompanyName;
                cmd.Parameters["@CompanyPrintName"].Value = company.CompanyPrintName;
                cmd.Parameters["@FYStartDate"].Value = company.FyStartDate;
                cmd.Parameters["@BooksCommencingFrom"].Value = company.BooksCommencing;
                cmd.Parameters["@AddressLine1"].Value = company.AddLine1;
                cmd.Parameters["@AddressLine2"].Value = company.AddLine2;
                cmd.Parameters["@AddressLine3"].Value = company.AddLine3;
                cmd.Parameters["@City"].Value = company.City;
                cmd.Parameters["@Pin"].Value = company.Pin;
                cmd.Parameters["@State"].Value = company.State;
                cmd.Parameters["@Country"].Value = company.Country;
                cmd.Parameters["@PhoneNo1"].Value = company.PhoneNo1;
                cmd.Parameters["@PhoneNo2"].Value = company.PhoneNo2;
                cmd.Parameters["@Website"].Value = company.Website;
                cmd.Parameters["@EmailId"].Value = company.EmailId;
                cmd.Parameters["@Fax"].Value = company.Fax;
                cmd.Parameters["@VatGst"].Value = company.VatGst;
                cmd.Parameters["@TinNo"].Value = company.TinNo;
                cmd.Parameters["@VatGstDate"].Value = company.VatGstDate;
                cmd.Parameters["@CstNo"].Value = company.CstNo;
                cmd.Parameters["@CstDate"].Value = company.CstDate;
                cmd.Parameters["@PanNo"].Value = company.PanNo;
                cmd.Parameters["@ServiceTaxNo"].Value = company.ServiceTaxNo;
                cmd.Parameters["@Image"].Value = company.ImagePath;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                //financial year can never b editted...
                cmd.CommandText="Update CompanyDetails SET  CompanyName=@CompanyName, CompanyPrintName=@CompanyPrintName, BooksCommencingFrom=@BooksCommencingFrom, AddressLine1=@AddressLine1, Addressline2=@Addressline2, AddressLine3= @AddressLine3, City=@City, Pin=@Pin, State=@State, Country=@Country, PhoneNo1=@PhoneNo1, PhoneNo2=@PhoneNo2, Website=@Website, EmailId=@EmailId, Fax=@Fax, VatGst=@VatGst, TinNo=@TinNo, VatGstDate=@VatGstDate, CstNo=@CstNo, CstDate=@CstDate, PanNo=@PanNo, ServiceTaxNo=@ServiceTaxNo, Image=@Image where CompanyId=1";

                cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar);
                cmd.Parameters.Add("@CompanyPrintName", SqlDbType.VarChar);
                cmd.Parameters.Add("@BooksCommencingFrom", SqlDbType.DateTime);
                cmd.Parameters.Add("@AddressLine1", SqlDbType.VarChar);
                cmd.Parameters.Add("@AddressLine2", SqlDbType.VarChar);
                cmd.Parameters.Add("@AddressLine3", SqlDbType.VarChar);
                cmd.Parameters.Add("@City", SqlDbType.VarChar);
                cmd.Parameters.Add("@Pin", SqlDbType.Int);
                cmd.Parameters.Add("@State", SqlDbType.VarChar);
                cmd.Parameters.Add("@Country", SqlDbType.VarChar);
                cmd.Parameters.Add("@PhoneNo1", SqlDbType.VarChar);
                cmd.Parameters.Add("@PhoneNo2", SqlDbType.VarChar);
                cmd.Parameters.Add("@Website", SqlDbType.VarChar);
                cmd.Parameters.Add("@EmailId", SqlDbType.VarChar);
                cmd.Parameters.Add("@Fax", SqlDbType.VarChar);
                cmd.Parameters.Add("@VatGst", SqlDbType.VarChar);
                cmd.Parameters.Add("@TinNo", SqlDbType.VarChar);
                cmd.Parameters.Add("@VatGstDate", SqlDbType.DateTime);
                cmd.Parameters.Add("@CstNo", SqlDbType.VarChar);
                cmd.Parameters.Add("@CstDate", SqlDbType.DateTime);
                cmd.Parameters.Add("@PanNo", SqlDbType.VarChar);
                cmd.Parameters.Add("@ServiceTaxNo", SqlDbType.VarChar);
                cmd.Parameters.Add("@Image", SqlDbType.VarChar);

                cmd.Parameters["@CompanyName"].Value = company.CompanyName;
                cmd.Parameters["@CompanyPrintName"].Value = company.CompanyPrintName;
                cmd.Parameters["@BooksCommencingFrom"].Value = company.BooksCommencing;
                cmd.Parameters["@AddressLine1"].Value = company.AddLine1;
                cmd.Parameters["@AddressLine2"].Value = company.AddLine2;
                cmd.Parameters["@AddressLine3"].Value = company.AddLine3;
                cmd.Parameters["@City"].Value = company.City;
                cmd.Parameters["@Pin"].Value = company.Pin;
                cmd.Parameters["@State"].Value = company.State;
                cmd.Parameters["@Country"].Value = company.Country;
                cmd.Parameters["@PhoneNo1"].Value = company.PhoneNo1;
                cmd.Parameters["@PhoneNo2"].Value = company.PhoneNo2;
                cmd.Parameters["@Website"].Value = company.Website;
                cmd.Parameters["@EmailId"].Value = company.EmailId;
                cmd.Parameters["@Fax"].Value = company.Fax;
                cmd.Parameters["@VatGst"].Value = company.VatGst;
                cmd.Parameters["@TinNo"].Value = company.TinNo;
                cmd.Parameters["@VatGstDate"].Value = company.VatGstDate;
                cmd.Parameters["@CstNo"].Value = company.CstNo;
                cmd.Parameters["@CstDate"].Value = company.CstDate;
                cmd.Parameters["@PanNo"].Value = company.PanNo;
                cmd.Parameters["@ServiceTaxNo"].Value = company.ServiceTaxNo;
                cmd.Parameters["@Image"].Value = company.ImagePath;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public CompanyObject retrieveCompanyDetails()
        {
            cmd.CommandText = "Select * from CompanyDetails";
            ds.Tables.Clear();
            adpt.SelectCommand = cmd;

            conn.Open();
            adpt.Fill(ds);
            conn.Close();

            CompanyObject company = new CompanyObject();

            company.CompanyId =int.Parse(ds.Tables[0].Rows[0]["CompanyId"].ToString());
            company.CompanyName = ds.Tables[0].Rows[0]["CompanyName"].ToString();
            company.CompanyPrintName = ds.Tables[0].Rows[0]["CompanyPrintName"].ToString();
            company.FyStartDate = DateTime.Parse(ds.Tables[0].Rows[0]["FYStartDate"].ToString());
            company.BooksCommencing = DateTime.Parse(ds.Tables[0].Rows[0]["BooksCommencingFrom"].ToString());
            company.AddLine1 = ds.Tables[0].Rows[0]["AddressLine1"].ToString();
            company.AddLine2 = ds.Tables[0].Rows[0]["AddressLine2"].ToString();
            company.AddLine3 = ds.Tables[0].Rows[0]["AddressLine3"].ToString();
            company.City = ds.Tables[0].Rows[0]["City"].ToString();
            company.Pin = int.Parse(ds.Tables[0].Rows[0]["Pin"].ToString());
            company.State = ds.Tables[0].Rows[0]["State"].ToString();
            company.Country = ds.Tables[0].Rows[0]["Country"].ToString();
            company.PhoneNo1 = ds.Tables[0].Rows[0]["PhoneNo1"].ToString();
            company.PhoneNo2 = ds.Tables[0].Rows[0]["PhoneNo2"].ToString();
            company.Website = ds.Tables[0].Rows[0]["Website"].ToString();
            company.EmailId = ds.Tables[0].Rows[0]["EmailId"].ToString();
            company.Fax = ds.Tables[0].Rows[0]["Fax"].ToString();
            company.VatGst = ds.Tables[0].Rows[0]["VatGst"].ToString();
            company.TinNo = ds.Tables[0].Rows[0]["TinNo"].ToString();
            company.VatGstDate=DateTime.Parse(ds.Tables[0].Rows[0]["VatGstDate"].ToString());
            company.CstNo = ds.Tables[0].Rows[0]["CstNo"].ToString();
            company.CstDate = DateTime.Parse(ds.Tables[0].Rows[0]["CstDate"].ToString());
            company.PanNo = ds.Tables[0].Rows[0]["PanNo"].ToString();
            company.ServiceTaxNo = ds.Tables[0].Rows[0]["ServiceTaxNo"].ToString();
            company.ImagePath = ds.Tables[0].Rows[0]["Image"].ToString();

            return company;
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

        public string addStateCity(string stateName, string city)
        {
            string Msg = "";
            bool stateExist = false;
            int stateId = 0;//For Already added State in Table
            adpt = new SqlDataAdapter();
            ds = new DataSet();

            if (stateName == "--add State--" || city == "--add City--")
            {
                Msg = "Inproper Inputs";
            }
            else
            {
                Msg = "Succeed";

                //check that state is not exist in the state table
                conn.Open();
                cmd.CommandText = "SELECT * FROM State";
                adpt.SelectCommand = cmd;
                adpt.Fill(ds, "State");
                conn.Close();

                foreach (DataRow dr in ds.Tables["State"].Rows)
                {
                    if (stateName == dr["StateName"].ToString())
                    {
                        stateExist = true;
                        stateId = Int32.Parse(dr["StateID"].ToString());
                    }

                }

                if (stateExist == true)
                {
                    //check that state in City is not exist in the City Table
                    conn.Open();
                    cmd.CommandText = @"SELECT CityName FROM City WHERE
                             (StateID IN
                             (SELECT        StateID
                               FROM            State
                               WHERE        (StateName = '" + stateName + "')))";
                    adpt.SelectCommand = cmd;
                    adpt.Fill(ds, "City");
                    conn.Close();

                    if (ds.Tables["City"].Rows.Count == 0)
                    {//First Time Entry
                        conn.Open();
                        cmd.CommandText = "INSERT INTO City (StateId,CityName) VALUES(" + stateId + ",'" + city + "')";
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        Msg = "City In State Added Successfully";

                    }

                    foreach (DataRow dr2 in ds.Tables["City"].Rows)
                    {
                        if (city == dr2["CityName"].ToString())
                        {
                            Msg = "Dublicate State-City Entry";
                        }
                        else
                        {
                            //add the city in city table
                            conn.Open();
                            cmd.CommandText = "INSERT INTO City (StateId,CityName) VALUES(" + stateId + ",'" + city + "')";
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            Msg = "City Added Successfully";
                            break;
                        }
                    }
                }
                else
                {//add New State

                    //add the state in state table
                    conn.Open();
                    cmd.CommandText = "INSERT INTO State (StateName) VALUES('" + stateName + "')";
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    //Get New State's Id
                    ds = new DataSet();
                    adpt = new SqlDataAdapter();
                    conn.Open();
                    cmd.CommandText = "SELECT StateID FROM State WHERE StateName='" + stateName + "'";
                    adpt.SelectCommand = cmd;
                    adpt.Fill(ds, "State");
                    stateId = Int32.Parse(ds.Tables["State"].Rows[0]["StateID"].ToString());
                    conn.Close();

                    //add the city in city table
                    conn.Open();
                    cmd.CommandText = "INSERT INTO City (StateId,CityName) VALUES(" + stateId + ",'" + city + "')";
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Msg = "State and City Added Successfully";
                }
            }
            return Msg;
        }

        public DataTable showState()
        {
            conn.Open();
            cmd.CommandText = "SELECT StateName FROM State";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds, "State");
            conn.Close();
            return ds.Tables["State"];
        }

        public string updateStateCity(string StateIDS, string State, string CityIDS, string City)
        {
            int StateID = Int32.Parse(StateIDS);
            int CityID = 0;
            if (CityIDS == "")
            {
                CityID = 0;
            }
            else
            {
                CityID = Int32.Parse(CityIDS);//updated StateIDS
            }
            bool stateExist = false; bool cityExist = false; string Msg = "Nothing Updated";
            ds = new DataSet();
            //check that state is not exist in DB
            conn.Open();
            cmd.CommandText = "SELECT * FROM State";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds, "State");
            conn.Close();
            
            foreach (DataRow dr in ds.Tables["State"].Rows)
            {
                if (State == dr["StateName"].ToString())
                {
                    stateExist = true;

                    ds = new DataSet();
                    if (CityID != 0)
                    {
                        //check that state in City is not exist in the City Table
                        conn.Open();
                        cmd.CommandText = @"SELECT CityName FROM City WHERE
                             (StateID IN
                             (SELECT        StateID
                               FROM            State
                               WHERE        (StateName = '" + State + "')))";
                        adpt.SelectCommand = cmd;
                        adpt.Fill(ds, "City");
                        conn.Close();

                        foreach (DataRow dr2 in ds.Tables["City"].Rows)
                        {
                            if (City == dr2["CityName"].ToString())
                            {
                                cityExist = true;
                                Msg = "Error ! " + City + " city is already exist in " + State + " state";
                            }
                        }

                        if (cityExist == false)
                        {
                            {
                                //Update the City
                                conn.Open();
                                cmd.CommandText = "UPDATE City SET CityName = '" + City + "'Where CityID=" + CityID + "";
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                Msg = "Successfully Updated ( " + City + " city in " + State + " state )";
                            }
                        }
                    }
                }
            }

            if (stateExist == false)
            {
                //update state
                conn.Open();
                cmd.CommandText = "UPDATE State SET StateName = '" + State + "' Where StateID=" + StateID + "";
                cmd.ExecuteNonQuery();
                conn.Close();
                //update city
                if (CityID == 0)
                {
                    Msg = "Successfully Updated. ( " + State + " state )";
                }
                else
                {
                    conn.Open();
                    cmd.CommandText = "UPDATE City SET CityName = '" + City + "' Where CityID=" + CityID + "";
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Msg = "Successfully Updated. ( " + City + " city in " + State + " state )";
                }
            }
            return Msg;
        }

        public void deleteCity(int cityID)
        {
            conn.Open();
            cmd.CommandText = "DELETE FROM City WHERE (CityID = " + cityID + ")";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void deleteState(int StateID)
        {
            conn.Open();
            cmd.CommandText = "DELETE FROM State WHERE (StateID = " + StateID + ")";
            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            cmd.CommandText = "DELETE FROM City WHERE (StateID = " + StateID + ")";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void addUnit(UnitObject unitobject)
        {
            conn.Open();
            cmd = conn.CreateCommand();

            cmd.CommandText = "Insert into Unit(UnitName, UnitPrintName) values (@UnitName,@UnitPrintName)";

            cmd.Parameters.Add("@UnitName", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@UnitPrintName", SqlDbType.VarChar, 50);

            cmd.Parameters["@UnitName"].Value = unitobject.UnitName;
            cmd.Parameters["@unitPrintName"].Value = unitobject.UnitPrintName;

            cmd.ExecuteNonQuery();

            conn.Close();

        }

        public int getUnitId(UnitObject unitObject)
        {
            conn.Open();
            cmd = conn.CreateCommand();

            cmd.CommandText = "Select UnitId from Unit where UnitName=@UnitName AND UnitPrintName=@UnitPrintName;";

            cmd.Parameters.Add("@UnitName", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@UnitPrintName", SqlDbType.VarChar, 50);

            cmd.Parameters["@UnitName"].Value = unitObject.UnitName;
            cmd.Parameters["@UnitPrintName"].Value = unitObject.UnitPrintName;

            return (int)cmd.ExecuteScalar();

            conn.Close();
            
        }

        //public void editUnit(UnitObject originalUnitObject,UnitObject newUnitObject)
        //{
        //    int id = getUnitId(originalUnitObject);

        //    cmd = conn.CreateCommand();
        //    conn.Open();

        //    cmd.CommandText = "UPDATE Unit SET UnitName=@UnitName, UnitPrintName=@UnitPrintName WHERE UnitId=@UnitId";

        //    cmd.Parameters.Add("@UnitName", SqlDbType.VarChar, 50);
        //    cmd.Parameters.Add("@UnitPrintName", SqlDbType.VarChar, 50);
        //    cmd.Parameters.Add("@UnitId", SqlDbType.Int);

        //    cmd.Parameters["@UnitName"].Value = newUnitObject.UnitName;
        //    cmd.Parameters["@UnitPrintName"].Value = newUnitObject.UnitPrintName;
        //    cmd.Parameters["@UnitId"].Value = id;

        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //}

        public void deleteUnit(UnitObject unitObject)
        {
            conn.Open();
            cmd = conn.CreateCommand();

            cmd.CommandText = "Delete From Unit where UnitName=@UnitName AND UnitPrintName=@UnitPrintName;";

            cmd.Parameters.Add("@UnitName", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@UnitPrintName", SqlDbType.VarChar, 50);

            cmd.Parameters["@UnitName"].Value = unitObject.UnitName;
            cmd.Parameters["@UnitPrintName"].Value = unitObject.UnitPrintName;

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public String AddItemGroup(ItemGroupObject itemGroupObj)
        {
            conn.Open();
            
            cmd.CommandText = "Select * from ItemGroup";
            adpt.SelectCommand = cmd;
            

            bool itemgroupexists=false;

            adpt.Fill(ds, "ItemGrp");

            foreach (DataRow dr in ds.Tables["ItemGrp"].Rows)
            {
                if (itemGroupObj.ItemGroupName == dr["ItemGroupName"].ToString())
                    itemgroupexists = true;
            }

            if (itemgroupexists == true)
            {
                String str = "" + itemGroupObj.ItemGroupName + " already exists.";
                return str;
            }

            //SqlCommand cmd1 = new SqlCommand();
            //cmd1.Connection = conn;
            cmd = conn.CreateCommand();
            cmd.CommandText = @"Insert into ItemGroup(ItemGroupName, ItemGroupDesc) values (@ItemGroupName, @ItemGroupDesc)";

            cmd.Parameters.Add("@ItemGroupName", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@ItemGroupDesc", SqlDbType.VarChar);

            cmd.Parameters["@ItemGroupName"].Value = itemGroupObj.ItemGroupName;
            cmd.Parameters["@ItemGroupDesc"].Value = itemGroupObj.ItemGroupDesc;

            cmd.ExecuteNonQuery();

            conn.Close();

            String str1 = "Item Group : \""+itemGroupObj.ItemGroupName+"\" , Added into Database";
            return str1;
        }

        //public float getValueOfTax(string TaxName)
        //{
        //    MessageBox.Show(TaxName);
        //    conn.Open();
        //    cmd.CommandText = "SELECT Value FROM Tax Where TaxName='"+TaxName+"'";
        //    adpt.SelectCommand = cmd;
        //    adpt.Fill(ds, "Tax");
        //    conn.Close();
        //    return float.Parse(ds.Tables["Tax"].Rows[0][0].ToString());
        //}

        //get Max purchase order no
        public int getPurchaseOrderNo()
        {
            conn.Open();
            cmd.CommandText = "SELECT Max(PurchaseOrderId) From PurchaseOrder";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds, "PurchaseOrder");
            conn.Close();
            return Int32.Parse(ds.Tables["PurchaseOrder"].Rows[0][0].ToString())+1;
            
        }

        //--get ItemId
        public int getItemId(string ItemName)
        {
            conn.Open();
            cmd.CommandText = "SELECT ItemId From Item where ItemName='"+ItemName+"'";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds, "Item");
            conn.Close();
            return Int32.Parse(ds.Tables["Item"].Rows[0][0].ToString());
        }

        //--get taxId
        public int getTaxId(string TaxName)
        {
            conn.Open();
            cmd.CommandText = "SELECT TaxID From Tax where TaxName='" + TaxName + "'";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds, "Tax");
            conn.Close();
            return Int32.Parse(ds.Tables["Tax"].Rows[0][0].ToString());
        }

        public Dictionary<string, float> getTaxesOfPurchase(int purchaseId)
        {
            ds.Clear();
            cmd.CommandText = "SELECT T.TaxName, PT.Amount FROM PurchaseTaxes AS PT INNER JOIN Tax AS T ON PT.TaxId = T.TaxID WHERE (PT.PurchaseId = "+purchaseId+")";
            conn.Open();
            adpt.Fill(ds);
            conn.Close();

            Dictionary<string, float> taxes = new Dictionary<string, float>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                taxes.Add(dr[0].ToString(), float.Parse(dr[1].ToString()));
            }

            return taxes;
        }

        //update Purchae Order Table PO Completed = true
        public void setPOCompletedTrue(int purchaseOrderId)
        {
            conn.Open();
            cmd.CommandText = "UPDATE PurchaseOrder SET POCompleted = '" + true + "' Where PurchaseOrderId=" + purchaseOrderId + "";
            adpt.SelectCommand = cmd;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //--get SupplierId
        public int getSupplierId(string SupplierName)
        {
            conn.Open();
            ds = new DataSet();
            cmd.CommandText = "SELECT SupplierId From Supplier Where SupplierCompany='" + SupplierName + "'";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds, "Supplier");
            conn.Close();
            return Int32.Parse(ds.Tables["Supplier"].Rows[0][0].ToString());
        }

        public List<string> getSupplierName()
        {
            conn.Open();
            ds = new DataSet();
            cmd.CommandText = "SELECT SupplierCompany From Supplier";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds, "Supplier");
            conn.Close();

            List<string> supplierNameList = new List<string>();
            foreach (DataRow i in ds.Tables["Supplier"].Rows)
            {
                supplierNameList.Add(i[0].ToString());
            }

            return supplierNameList;
        }

        public void placePurchaseOrder_PurchaseOrderTable(int PurchaseOrderId,DateTime PurchaseOrderDate,int SupplierId,float AmountItems)
        {
            //PurchaseOrder table
            conn.Open();
            cmd.CommandText = "Insert into PurchaseOrder (PurchaseOrderId, PurchaseOrderDate, SupplierId, AmountItems) values ("+PurchaseOrderId+",'"+PurchaseOrderDate+"',"+SupplierId+","+AmountItems+")";     
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void placePurchaseOrder_PurchaseOrderItemsTable(int PurchseOrderId, int ItemId, int Quantity, float PricePerUnit)
        {
            //PurchaseOrderItems table
            conn.Open();
            cmd.CommandText = "Insert into PurchaseOrderItems (PurchaseOrderId, ItemId, Quantity, PricePerUnit) values (" + PurchseOrderId + "," + ItemId + "," + Quantity + ",'" + PricePerUnit + "')";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void placePurchaseOrder_PurchaseOrderTaxesTable(int PurchaseOrderId, int TaxId, string TaxType, float TaxAmount)
        {
            //PurchaseOrderTaxes table
            conn.Open();
            cmd.CommandText = "Insert into PurchaseOrderTaxes (PurchaseOrderId, TaxId, Type, Amount) values (" + PurchaseOrderId + "," + TaxId + ",'" + TaxType + "','" + TaxAmount + "')";
            cmd.ExecuteNonQuery();
            conn.Close();


        }

        //purchase item
        public List<int> getPurchaseOrderIdForSupplier(string supplierName)
        {
            int supplierId= this.getSupplierId(supplierName);

            conn.Open();
            ds = new DataSet();
            cmd.CommandText = "SELECT PurchaseOrderId From PurchaseOrder where SupplierId='" + supplierId + "' and POCompleted='"+false+"'";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds, "PurchaseOrderSupplier");
            conn.Close();

            List<int> purchaseOrderIdList = new List<int>();
            foreach (DataRow i in ds.Tables["PurchaseOrderSupplier"].Rows)
            {
                purchaseOrderIdList.Add(Int32.Parse( i[0].ToString()));
            }

            return purchaseOrderIdList;
            
        }

        public List<int> getPurchaseIdForSupplier(string supplierName)
        {
            int supplierId = this.getSupplierId(supplierName);

            conn.Open();
            ds = new DataSet();
            cmd.CommandText = "SELECT PurchaseId From Purchase where SupplierId='" + supplierId + "' and PaymentArrived='" + false + "'";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds, "PurchaseSupplier");
            conn.Close();

            List<int> purchaseIdList = new List<int>();
            foreach (DataRow i in ds.Tables["PurchaseSupplier"].Rows)
            {
                purchaseIdList.Add(Int32.Parse(i[0].ToString()));
            }

            return purchaseIdList;

        }

        public void placePurchase_PurchaseTable(int PurchaeId,int PurchaseOrderId, DateTime PurchaseDate, int SupplierId, float AmountItems,float AmountTaxes,string Note)
        {
            //Purchase table
            conn.Open();
            cmd.CommandText = "Insert into Purchase (PurchaseId,PurchaseOrderId, PurchaseDate, SupplierId, AmountItems,AmountTaxes,Note,PaymentArrived) values (" + PurchaeId + "," + PurchaseOrderId + ",'" + PurchaseDate + "'," + SupplierId + "," + AmountItems + "," + AmountTaxes + ",'" + Note + "','"+false+"')";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void placePurchase_PurchaseItemsTable(int PurchseId, int ItemId, int Quantity, float PricePerUnit)
        {
            //PurchaseItems table
            conn.Open();
            cmd.CommandText = "Insert into PurchaseItems (PurchaseId, ItemId, Quantity, PricePerUnit) values (" + PurchseId + "," + ItemId + "," + Quantity + ",'" + PricePerUnit + "')";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void placePurchase_PurchaseTaxesTable(int PurchaseId, int TaxId, string TaxType, float TaxAmount)
        {
            //PurchaseTaxes table
            conn.Open();
            cmd.CommandText = "Insert into PurchaseTaxes (PurchaseId, TaxId, Type, Amount) values (" + PurchaseId + "," + TaxId + ",'" + TaxType + "','" + TaxAmount + "')";
            cmd.ExecuteNonQuery();
            conn.Close();


        }

        public int getPurchaseNo()
        {
            conn.Open();
            ds = new DataSet();
            cmd.CommandText = "SELECT Max(PurchaseId) From Purchase";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds, "Purchase");
            conn.Close();
            return Int32.Parse(ds.Tables["Purchase"].Rows[0][0].ToString()) + 1;

        }
            //payment code
        public int getPaymentId()
        {
            conn.Open();
            cmd.CommandText = "SELECT Max(PaymentId) From Payment";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds, "Payment");
            conn.Close();
            if (ds.Tables["Payment"].Rows[0][0].ToString() == "")
            {
                return 1;
            }
            else
            {
                return Int32.Parse(ds.Tables["Payment"].Rows[0][0].ToString()) + 1;
            }
        }

        public List<string> getPurchaseItemIdForPayment()
        {
            
            conn.Open();
            cmd.CommandText = "SELECT PurchaseId From Purchase where PaymentArrived='" + false+"'";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds, "PurchaseIdPurchase");
            conn.Close();
            List<string> purchseIdList = new List<string>();

            foreach (DataRow i in ds.Tables["PurchaseIdPurchase"].Rows)
            {
                purchseIdList.Add(i[0].ToString());
            }
            
            return purchseIdList;
        }

        public Dictionary<string,string> getPurchaseDetailsForPayment(int purchaseId)
        {
            
            Dictionary<string,string> pd=new Dictionary<string,string>();
            conn.Open();

            ds = new DataSet();
            cmd.CommandText = "Select AmountItems,AmountTaxes from Purchase where PurchaseId="+purchaseId;
            adpt.SelectCommand = cmd;
            adpt.Fill(ds, "AmountPurchase");
            conn.Close();

            pd.Add("AmountItems", ds.Tables["AmountPurchase"].Rows[0]["AmountItems"].ToString());
            pd.Add("AmountTaxes", ds.Tables["AmountPurchase"].Rows[0]["AmountTaxes"].ToString());

            return pd;
        }

        public List<string> getPaymentModeAccounts()
        {
            List<string> paymentModeAccounts = new List<string>();
            conn.Open();
            ds = new DataSet();                         //2 for Asset Accounts
            cmd.CommandText = "Select AccountName from Account where AccountGroupID=2";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds, "Account");
            conn.Close();
            foreach (DataRow i in ds.Tables["Account"].Rows)
            {
                paymentModeAccounts.Add(i[0].ToString());
            }

            return paymentModeAccounts;
        }

        public void makePayment(int PaymentId,int PurchaseId, string PaymentMode, DateTime PaymentDate, float TotalAmount,string Note)
        {
            //Get PaymentMode = Account , so Account Id
            conn.Open();
            ds = new DataSet();                        
            cmd.CommandText = "Select AccountID from Account where Accountname='"+PaymentMode+"'";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds, "Account");
            
            cmd.CommandText = "Insert into Payment (PaymentId,PurchaseId, PaymentDate, TotalAmount, Note,PaymentMode) values (" + PaymentId + "," + PurchaseId + ",'" +PaymentDate +"'," + TotalAmount + ",'" + Note + "'," + Int32.Parse(ds.Tables["Account"].Rows[0][0].ToString()) + ")";
            adpt.SelectCommand = cmd;
            cmd.ExecuteNonQuery();

            //Modify value in Purchase Table, Field PaymaentArrive=true
            cmd.CommandText="UPDATE Purchase SET PaymentArrived = '" + true + "' Where PurchaseId=" + PurchaseId + "";
            adpt.SelectCommand = cmd;
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Payment Made Successfully.","Succeed",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        //----
        
        public DataSet getItemTable()
        {
            conn.Open();
            cmd.CommandText = "Select * from Item";
            adpt.SelectCommand = cmd;

            ds.Clear();
            adpt.Fill(ds);
            conn.Close();

            return ds;
        }

        //if the item code exists in the item table
        public bool itemCodeExists(string itemcode)
        {
            bool itemcodethere = false;

            ds = this.getItemTable();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["ItemCode"].Equals(itemcode))
                {
                    itemcodethere = true;
                    goto A;
                }
            }

        A:
            return itemcodethere;
        }

        //if the item name exists int the table..
        public bool itemNameExists(string itemName)
        {
            bool itemNamether = false;

            ds = this.getItemTable();

            foreach (DataRow dr in ds.Tables[0].Rows)
    	    {
		       if(dr["ItemName"].Equals(itemName))
               {
                   itemNamether=true;
                   goto A;
               }
	        }

            A:
            return itemNamether;
        }
        //write code for getting itemgroupid for item group name n same for unit..


        public String AddItem(ItemObject item)//method ncommented just to build successfully..
        {
            string itemCode = item.ItemCode;
            string itemName = item.ItemName;

            //if (itemCodeExists(itemCode))
            //{
            //    string str = "Item With the same Code already exists, Cannot add another item with same code";
            //    return str;
            //}

            //if (itemNameExists(itemName))
            //{
            //    string str = "Another Item With the same name already exists, cannot add another item with same name";
            //    return str;
            //}

            cmd.CommandText = "Select ItemId from Item where ItemId=" + item.ItemID;
            adpt.SelectCommand = cmd;
            ds.Clear();
            conn.Open();
            adpt.Fill(ds);
            conn.Close();

            

            if (ds.Tables[0].Rows.Count == 0)
            {

                ds.Tables.Clear();
                cmd = conn.CreateCommand();
                string itemGroup = item.ItemGroup;
                adpt.SelectCommand = cmd;
                cmd.CommandText = "Select ItemGroupId from ItemGroup where ItemGroupName='" + itemGroup + "';";
                adpt.Fill(ds, "ItemGroup");

                int ItemGroupId = int.Parse(ds.Tables["ItemGroup"].Rows[0]["ItemGroupId"].ToString());

                ds.Tables.Clear();
                string unitName = item.Unit;
                cmd.CommandText = "Select UnitId from Unit where UnitName='" + unitName + "';";
                adpt.SelectCommand = cmd;
                adpt.Fill(ds, "Unit");

                int UnitId = int.Parse(ds.Tables["Unit"].Rows[0]["UnitId"].ToString());

                cmd.CommandText = @"Insert Into Item(ItemCode,ItemGroupId,ItemName,ItemDesc,UnitId,OpenDate,OpenStockQty,OpenStockValue,PurchasePrice,SalePrice,MRP,MinimumSalePrice,InsuranceAmount,HSNCode,IMCOClass,CASNo)values(@ItemCode,@ItemGroupId,@ItemName,@ItemDesc,@UnitId,@OpenDate,@OpenStockQty,@OpenStockValue,@PurchasePrice,@SalePrice,@MRP,@MinimumSalePrice,@InsuranceAmount,@HSNCode,@IMCOClass,@CASNo);";

                cmd.Parameters.Add("@ItemCode", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@ItemGroupId", SqlDbType.Int);
                cmd.Parameters.Add("@ItemName", SqlDbType.VarChar);
                cmd.Parameters.Add("@ItemDesc", SqlDbType.VarChar);
                cmd.Parameters.Add("@UnitId", SqlDbType.Int);
                cmd.Parameters.Add("@OpenDate", SqlDbType.DateTime);
                cmd.Parameters.Add("@OpenStockQty", SqlDbType.Int);
                cmd.Parameters.Add("@OpenStockValue", SqlDbType.Float);
                cmd.Parameters.Add("@PurchasePrice", SqlDbType.Float);
                cmd.Parameters.Add("@SalePrice", SqlDbType.Float);
                cmd.Parameters.Add("@MRP", SqlDbType.Float);
                cmd.Parameters.Add("@MinimumSalePrice", SqlDbType.Float);
                cmd.Parameters.Add("@InsuranceAmount", SqlDbType.Float);
                cmd.Parameters.Add("@HSNCode", SqlDbType.VarChar);
                cmd.Parameters.Add("@IMCOClass", SqlDbType.VarChar);
                cmd.Parameters.Add("@CASNo", SqlDbType.VarChar);

                cmd.Parameters["@ItemCode"].Value = item.ItemCode;
                cmd.Parameters["@ItemGroupId"].Value = ItemGroupId;
                cmd.Parameters["@ItemName"].Value = item.ItemName;
                cmd.Parameters["@ItemDesc"].Value = item.ItemDescription;
                cmd.Parameters["@UnitId"].Value = UnitId;
                cmd.Parameters["@OpenDate"].Value = item.OpenDate;
                cmd.Parameters["@OpenStockQty"].Value = item.OpenStockQuantity;
                cmd.Parameters["@OpenStockValue"].Value = item.OpenStockValue;
                cmd.Parameters["@PurchasePrice"].Value = item.PurchasePrice;
                cmd.Parameters["@SalePrice"].Value = item.SalePrice;
                cmd.Parameters["@MRP"].Value = item.Mrp;
                cmd.Parameters["@MinimumSalePrice"].Value = item.MinimumSalePrice;
                cmd.Parameters["@InsuranceAmount"].Value = item.InsuranceAmount;
                cmd.Parameters["@HSNCode"].Value = item.HsnCode;
                cmd.Parameters["@IMCOClass"].Value = item.IMCOClass;
                cmd.Parameters["@CASNo"].Value = item.CasNo;

                conn.Open();

                cmd.ExecuteNonQuery();
                conn.Close();

                string str1 = "Your Item : \"" + item.ItemName + "\" has been Saved to the database";
                return str1;
            }
            else
            {

                ds.Tables.Clear();
                cmd = conn.CreateCommand();
                string itemGroup = item.ItemGroup;
                adpt.SelectCommand = cmd;
                cmd.CommandText = "Select ItemGroupId from ItemGroup where ItemGroupName='" + itemGroup + "';";
                adpt.Fill(ds, "ItemGroup");

                int ItemGroupId = int.Parse(ds.Tables["ItemGroup"].Rows[0]["ItemGroupId"].ToString());

                ds.Tables.Clear();
                string unitName = item.Unit;
                cmd.CommandText = "Select UnitId from Unit where UnitName='" + unitName + "';";
                adpt.SelectCommand = cmd;
                adpt.Fill(ds, "Unit");

                int UnitId = int.Parse(ds.Tables["Unit"].Rows[0]["UnitId"].ToString());

                cmd.CommandText = "Update Item SET ItemCode=@ItemCode,ItemGroupId=@ItemGroupId,ItemName=@ItemName,ItemDesc=@ItemDesc,UnitId=@UnitId,OpenDate=@OpenDate,OpenStockQty=@OpenStockQty,OpenStockValue=@OpenStockQty,PurchasePrice=@PurchasePrice,SalePrice=@SalePrice,MRP=@MRP,MinimumSalePrice=@MinimumSalePrice,InsuranceAmount=@InsuranceAmount,HSNCode=@HSNCode,IMCOClass=@IMCOClass,CASNo=@CASNo where ItemId=" + item.ItemID;
                cmd.Parameters.Add("@ItemCode", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@ItemGroupId", SqlDbType.Int);
                cmd.Parameters.Add("@ItemName", SqlDbType.VarChar);
                cmd.Parameters.Add("@ItemDesc", SqlDbType.VarChar);
                cmd.Parameters.Add("@UnitId", SqlDbType.Int);
                cmd.Parameters.Add("@OpenDate", SqlDbType.DateTime);
                cmd.Parameters.Add("@OpenStockQty", SqlDbType.Int);
                cmd.Parameters.Add("@OpenStockValue", SqlDbType.Float);
                cmd.Parameters.Add("@PurchasePrice", SqlDbType.Float);
                cmd.Parameters.Add("@SalePrice", SqlDbType.Float);
                cmd.Parameters.Add("@MRP", SqlDbType.Float);
                cmd.Parameters.Add("@MinimumSalePrice", SqlDbType.Float);
                cmd.Parameters.Add("@InsuranceAmount", SqlDbType.Float);
                cmd.Parameters.Add("@HSNCode", SqlDbType.VarChar);
                cmd.Parameters.Add("@IMCOClass", SqlDbType.VarChar);
                cmd.Parameters.Add("@CASNo", SqlDbType.VarChar);

                cmd.Parameters["@ItemCode"].Value = item.ItemCode;
                cmd.Parameters["@ItemGroupId"].Value = ItemGroupId;
                cmd.Parameters["@ItemName"].Value = item.ItemName;
                cmd.Parameters["@ItemDesc"].Value = item.ItemDescription;
                cmd.Parameters["@UnitId"].Value = UnitId;
                cmd.Parameters["@OpenDate"].Value = item.OpenDate;
                cmd.Parameters["@OpenStockQty"].Value = item.OpenStockQuantity;
                cmd.Parameters["@OpenStockValue"].Value = item.OpenStockValue;
                cmd.Parameters["@PurchasePrice"].Value = item.PurchasePrice;
                cmd.Parameters["@SalePrice"].Value = item.SalePrice;
                cmd.Parameters["@MRP"].Value = item.Mrp;
                cmd.Parameters["@MinimumSalePrice"].Value = item.MinimumSalePrice;
                cmd.Parameters["@InsuranceAmount"].Value = item.InsuranceAmount;
                cmd.Parameters["@HSNCode"].Value = item.HsnCode;
                cmd.Parameters["@IMCOClass"].Value = item.IMCOClass;
                cmd.Parameters["@CASNo"].Value = item.CasNo;

                adpt.SelectCommand = cmd;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                string str1 = "Your Item : \"" + item.ItemName + "\" has been Updated to the database";
                return str1;
            }

        }

        public DataTable getItems()
        {
            ds.Clear();
            cmd.CommandText = "SELECT Item.ItemCode, Item.ItemName, Item.ItemDesc, ItemGroup.ItemGroupName FROM Item INNER JOIN ItemGroup ON Item.ItemGroupId = ItemGroup.ItemGroupId";
            conn.Open();
            adpt.SelectCommand = cmd;

            adpt.Fill(ds, "Items");
            conn.Close();
            return ds.Tables["Items"];
        }

        
        public ItemObject getDetailsofItemCode(string itemcode, string itemname)
        {
            io = new ItemObject();

            cmd.CommandText = "SELECT Item.ItemId, Item.ItemCode, Item.ItemName, Item.ItemDesc, Item.OpenDate, Item.OpenStockValue, Item.OpenStockQty, Item.PurchasePrice, Item.SalePrice, Item.MRP, Item.MinimumSalePrice, Item.InsuranceAmount, Item.HSNCode, Item.IMCOCLass, Item.CASNo, ItemGroup.ItemGroupName, Unit.UnitName FROM Item INNER JOIN ItemGroup ON Item.ItemGroupId = ItemGroup.ItemGroupId INNER JOIN Unit ON Item.UnitId = Unit.UnitId where Item.ItemCode='" + itemcode + "' and Item.ItemName='" + itemname + "'";
            adpt.SelectCommand = cmd;
            ds.Tables.Clear();

            conn.Open();
            adpt.Fill(ds);
            conn.Close();

            io.ItemID = int.Parse(ds.Tables[0].Rows[0]["ItemId"].ToString());
            io.ItemCode = ds.Tables[0].Rows[0]["ItemCode"].ToString();
            io.ItemGroup = ds.Tables[0].Rows[0]["ItemGroupName"].ToString();
            io.ItemName = ds.Tables[0].Rows[0]["ItemName"].ToString();
            io.ItemDescription = ds.Tables[0].Rows[0]["ItemDesc"].ToString();
            io.Unit = ds.Tables[0].Rows[0]["UnitName"].ToString();
            io.OpenDate = (DateTime)ds.Tables[0].Rows[0]["OpenDate"];
            io.OpenStockQuantity = int.Parse(ds.Tables[0].Rows[0]["OpenStockQty"].ToString());
            io.OpenStockValue = float.Parse(ds.Tables[0].Rows[0]["OpenStockValue"].ToString());
            io.PurchasePrice = float.Parse(ds.Tables[0].Rows[0]["PurchasePrice"].ToString());
            io.SalePrice = float.Parse(ds.Tables[0].Rows[0]["SalePrice"].ToString());
            io.Mrp = float.Parse(ds.Tables[0].Rows[0]["MRP"].ToString());
            io.MinimumSalePrice = float.Parse(ds.Tables[0].Rows[0]["MinimumSalePrice"].ToString());
            io.InsuranceAmount = float.Parse(ds.Tables[0].Rows[0]["InsuranceAmount"].ToString());
            io.HsnCode = ds.Tables[0].Rows[0]["HSNCode"].ToString();
            io.IMCOClass = ds.Tables[0].Rows[0]["IMCOCLass"].ToString();
            io.CasNo = ds.Tables[0].Rows[0]["CASNo"].ToString();

            return io;
            
        }

        public int getNextItemId()
        {
            ds.Clear();
            cmd.CommandText="Select * from Item";
            adpt.SelectCommand = cmd;
            conn.Open();
            adpt.Fill(ds);
            conn.Close();
           

            if (ds.Tables[0].Rows.Count == 0)
            {
                return 1;
            }

            else
            {
                ds.Clear();
                cmd.CommandText = "Select Max(ItemId) from Item";
                adpt.SelectCommand = cmd;
                conn.Open();
                int i = int.Parse(cmd.ExecuteScalar().ToString());
                conn.Close();

                return ++i;
                //try
                //{
                //    int itemId = 0;
                //    itemId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                //    return ++itemId;
                //}
                //catch (Exception e)
                //{
                //    return 1;
                //}
            }

            
        }

        public String DeleteItem(int ItemId)
        {
            cmd.CommandText = "Select ItemId from Item where ItemId=" + ItemId;
            adpt.SelectCommand = cmd;
            ds.Clear();
            conn.Open();
            adpt.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count == 0)
            {
                string str = "No such Item in the database";
                return str;
            }
            else
            {
                cmd.CommandText = "Select ItemName from Item where ItemId=" + ItemId;
                adpt.SelectCommand = cmd;
                ds.Tables.Clear();

                conn.Open();
                adpt.Fill(ds);
                conn.Close();

                string Itemname = ds.Tables[0].Rows[0][0].ToString();

                cmd.CommandText = "Delete From Item Where ItemId=" + ItemId;
                adpt.SelectCommand = cmd;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                string str = "Your Item : "+Itemname+" has beed deleted from the database";
                return str;            
            }
        }

        public bool checkFinancialyearSetup()
        {
            cmd.CommandText="Select FYStartDate from CompanyDetails where CompanyId=1";
            adpt.SelectCommand=cmd;

            ds.Tables.Clear();
            conn.Open();
            adpt.Fill(ds);
            conn.Close();

            if(ds.Tables[0].Rows.Count==0)
                return false;
                else return true;
        }

        public int getNextAccountId()
        {
            ds.Clear();
            cmd.CommandText = "Select * from Account";
            adpt.SelectCommand = cmd;
            conn.Open();
            adpt.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count == 0)
            {
                return 1;
            }

            else
            {
                ds.Clear();
                cmd.CommandText = "Select Max(AccountId) from Account";
                adpt.SelectCommand = cmd;
                conn.Open();
                int i = int.Parse(cmd.ExecuteScalar().ToString());
                conn.Close();

                return ++i;
                
            }
        }

        public string AddAccount(AccountObject account)
        {
            
            cmd.CommandText = "Select AccountId from Account where AccountId=" + account.AccountId;
            adpt.SelectCommand = cmd;
            ds.Clear();
            conn.Open();
            adpt.Fill(ds);
            conn.Close();

            

            if (ds.Tables[0].Rows.Count == 0)
            {

                cmd.CommandText = "Select * from Account where AccountName=@AccName";

                cmd.Parameters.Add("@AccName", SqlDbType.VarChar);
                cmd.Parameters["@AccName"].Value = account.AccountName;
                adpt.SelectCommand = cmd;

                ds.Clear();
                conn.Open();
                adpt.Fill(ds);
                conn.Close();

                if (ds.Tables[0].Rows.Count == 0)
                {
                    int CityId = 0; ;
                    int StateId = 0;

                    ds.Tables.Clear();
                    cmd = conn.CreateCommand();
                    string accGroup = account.AccountGroup;
                    adpt.SelectCommand = cmd;
                    cmd.CommandText = "Select AccountGroupId from AccountGroup where AccountGroupName='" + accGroup + "';";
                    adpt.Fill(ds, "AccountGroup");

                    int AccountGroupId = int.Parse(ds.Tables["AccountGroup"].Rows[0]["AccountGroupId"].ToString());

                    if (account.City != "")
                    {
                        ds.Tables.Clear();
                        cmd = conn.CreateCommand();
                        string cityName = account.City;
                        adpt.SelectCommand = cmd;
                        cmd.CommandText = "Select CityId from City where CityName='" + cityName + "';";
                        adpt.Fill(ds, "City");

                        CityId = int.Parse(ds.Tables["City"].Rows[0]["CityID"].ToString());
                    }




                    if (account.State != "")
                    {
                        ds.Tables.Clear();
                        cmd = conn.CreateCommand();
                        string stateName = account.State;
                        adpt.SelectCommand = cmd;
                        cmd.CommandText = "Select StateId from State where StateName='" + stateName + "';";
                        adpt.Fill(ds, "State");


                        StateId = int.Parse(ds.Tables["State"].Rows[0]["StateID"].ToString());

                    }
                    cmd.CommandText = "Insert into Account(AccountName,AccountPrintName,AccountGroupId,AddressLine1,AddressLine2,AddressLine3,CityId,StateId,Pincode,Email,ContactPerson,TelephoneNo,PANNo) values (@AccountName,@AccountPrintName,@AccountGroupId,@AddressLine1,@AddressLine2,@AddressLine3,@CityId,@StateId,@Pincode,@Email,@ContactPerson,@TelephoneNo,@PANNo)";


                    cmd.Parameters.Add("@AccountName", SqlDbType.VarChar);
                    cmd.Parameters.Add("@AccountPrintName", SqlDbType.VarChar);
                    cmd.Parameters.Add("@AccountGroupId", SqlDbType.Int);
                    cmd.Parameters.Add("@AddressLine1", SqlDbType.VarChar);
                    cmd.Parameters.Add("@AddressLine2", SqlDbType.VarChar);
                    cmd.Parameters.Add("@AddressLine3", SqlDbType.VarChar);
                    cmd.Parameters.Add("@CityId", SqlDbType.Int);
                    cmd.Parameters.Add("@StateId", SqlDbType.Int);
                    cmd.Parameters.Add("@Pincode", SqlDbType.VarChar);
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar);
                    cmd.Parameters.Add("@ContactPerson", SqlDbType.VarChar);
                    cmd.Parameters.Add("@TelephoneNo", SqlDbType.VarChar);
                    cmd.Parameters.Add("@PANNo", SqlDbType.VarChar);


                    cmd.Parameters["@AccountName"].Value = account.AccountName;
                    cmd.Parameters["@AccountPrintName"].Value = account.AccountPrintName;
                    cmd.Parameters["@AccountGroupId"].Value = AccountGroupId;
                    cmd.Parameters["@AddressLine1"].Value = account.AddLine1;
                    cmd.Parameters["@AddressLine2"].Value = account.AddLine2;
                    cmd.Parameters["@AddressLine3"].Value = account.AddLine3;
                    if (account.City == "")
                    {
                        cmd.Parameters["@CityId"].Value = -1;
                    }
                    else
                    {
                        cmd.Parameters["@CityId"].Value = CityId;
                    }

                    if (account.State == "")
                    {
                        cmd.Parameters["@StateId"].Value = -1;
                    }
                    else
                    {
                        cmd.Parameters["@StateId"].Value = StateId;
                    }
                    cmd.Parameters["@Pincode"].Value = account.Pin;
                    cmd.Parameters["@Email"].Value = account.Email;
                    cmd.Parameters["@ContactPerson"].Value = account.ContactPerson;
                    cmd.Parameters["@TelephoneNo"].Value = account.PhoneNo;
                    cmd.Parameters["@PANNo"].Value = account.ItPanNo;

                    adpt.SelectCommand = cmd;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    string str = "Your Account namely, \" " + account.AccountName + "\" has been Added to the database";
                    return str;
                }
                else
                {
                    string str = "Account with the same Name Already exists, cannot add the account";
                    return str;
                }

            }
            else
            {
                int CityId = 0;
                int StateId = 0;

                ds.Tables.Clear();
                cmd = conn.CreateCommand();
                string accGroup = account.AccountGroup;
                adpt.SelectCommand = cmd;
                cmd.CommandText = "Select AccountGroupId from AccountGroup where AccountGroupName='" + accGroup + "';";
                adpt.Fill(ds, "AccountGroup");

                int AccountGroupId = int.Parse(ds.Tables["AccountGroup"].Rows[0]["AccountGroupId"].ToString());

                if (account.City != "")
                {
                    ds.Tables.Clear();
                    cmd = conn.CreateCommand();
                    string cityName = account.City;
                    adpt.SelectCommand = cmd;
                    cmd.CommandText = "Select CityId from City where CityName='" + cityName + "';";
                    adpt.Fill(ds, "City");

                    CityId = int.Parse(ds.Tables["City"].Rows[0]["CityId"].ToString());

                }

                if (account.State != "")
                {
                    ds.Tables.Clear();
                    cmd = conn.CreateCommand();
                    string stateName = account.State;
                    adpt.SelectCommand = cmd;
                    cmd.CommandText = "Select StateId from State where StateName='" + stateName + "';";
                    adpt.Fill(ds, "State");

                    StateId = int.Parse(ds.Tables["State"].Rows[0]["StateId"].ToString());
                }
                cmd.CommandText = "Update Account SET AccountName=@AccountName, AccountPrintName=@AccountPrintName,AccountGroupId=@AccountGroupId, AddressLine1=@AddressLine1, AddressLine2=@AddressLine2, AddressLine3=@AddressLine3, CityId=@CityId, StateId=@StateId, Pincode=@Pincode, Email=@Email, ContactPerson=@ContactPerson, TelephoneNo=@TelephoneNo,PANNo=@PANNo where AccountId=" + account.AccountId;

                cmd.Parameters.Add("@AccountName", SqlDbType.VarChar);
                cmd.Parameters.Add("@AccountPrintName", SqlDbType.VarChar);
                cmd.Parameters.Add("@AccountGroupId", SqlDbType.Int);
                cmd.Parameters.Add("@AddressLine1", SqlDbType.VarChar);
                cmd.Parameters.Add("@AddressLine2", SqlDbType.VarChar);
                cmd.Parameters.Add("@AddressLine3", SqlDbType.VarChar);
                cmd.Parameters.Add("@CityId", SqlDbType.Int);
                cmd.Parameters.Add("@StateId", SqlDbType.Int);
                cmd.Parameters.Add("@Pincode", SqlDbType.Float);
                cmd.Parameters.Add("@Email", SqlDbType.VarChar);
                cmd.Parameters.Add("@ContactPerson", SqlDbType.VarChar);
                cmd.Parameters.Add("@TelephoneNo", SqlDbType.Float);
                cmd.Parameters.Add("@PANNo", SqlDbType.Float);

                cmd.Parameters["@AccountName"].Value = account.AccountName;
                cmd.Parameters["@AccountPrintName"].Value = account.AccountPrintName;
                cmd.Parameters["@AccountGroupId"].Value = AccountGroupId;
                cmd.Parameters["@AddressLine1"].Value = account.AddLine1;
                cmd.Parameters["@AddressLine2"].Value = account.AddLine2;
                cmd.Parameters["@AddressLine3"].Value = account.AddLine3;
                if (account.City == "")
                {
                    cmd.Parameters["@CityId"].Value = -1;
                }
                else
                {
                    cmd.Parameters["@CityId"].Value = CityId;
                }

                if (account.State == "")
                {
                    cmd.Parameters["@StateId"].Value = -1;
                }
                else
                {
                    cmd.Parameters["@StateId"].Value = StateId;
                }
                cmd.Parameters["@Pincode"].Value = account.Pin;
                cmd.Parameters["@Email"].Value = account.Email;
                cmd.Parameters["@ContactPerson"].Value = account.ContactPerson;
                cmd.Parameters["@TelephoneNo"].Value = account.PhoneNo;
                cmd.Parameters["@PANNo"].Value = account.ItPanNo;

                adpt.SelectCommand = cmd;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                string str = "Your Account namely, \" " + account.AccountName + "\" has been Updated to the database";
                return str;
            }
        }

        public DataTable getAccounts()
        {
            ds.Clear();
            cmd.CommandText = "SELECT  Account.AccountId, Account.AccountName, Account.AccountPrintName, AccountGroup.AccountGroupName FROM Account INNER JOIN AccountGroup ON Account.AccountGroupId = AccountGroup.AccountGroupID";
            conn.Open();
            adpt.SelectCommand = cmd;

            adpt.Fill(ds, "Accounts");
            conn.Close();
            return ds.Tables["Accounts"];
        }

        public AccountObject getDetailsOfAccountId(int accId)
        {
            ao = new AccountObject();

            //cmd.CommandText = "SELECT Account.AccountId, Account.AccountName, Account.AccountPrintName, AccountGroup.AccountGroupName, Account.AddressLine1, Account.AddressLine2, Account.AddressLine3, Account.CityId, City.CityName, Account.StateId, State.StateName, Account.Pincode, Account.Email, Account.ContactPerson, Account.TelephoneNo, Account.PANNo FROM Account INNER JOIN AccountGroup ON Account.AccountGroupId = AccountGroup.AccountGroupID INNER JOIN State ON Account.StateId = State.StateID INNER JOIN City ON Account.CityId = City.CityID WHERE AccountId="+accId;
            //cmd.CommandText = "SELECT AccountId, AccountName, AccountPrintName, AccountGroupId, AddressLine1, AddressLine2, AddressLine3, CityId, StateId, Pincode, Email, ContactPerson, TelephoneNo, PANNo FROM Account WHERE AccountId=" + accId;
            cmd.CommandText = "SELECT Account.AccountId, Account.AccountName, Account.AccountPrintName, Account.AddressLine1, Account.AddressLine2, Account.AddressLine3, Account.CityId, Account.StateId, Account.Pincode, Account.Email, Account.ContactPerson, Account.TelephoneNo, Account.PANNo, AccountGroup.AccountGroupName FROM Account INNER JOIN AccountGroup ON Account.AccountGroupId = AccountGroup.AccountGroupId WHERE AccountId=" + accId;
            adpt.SelectCommand = cmd;
            ds.Tables.Clear();

            conn.Open();
            adpt.Fill(ds);
            conn.Close();

            ao.AccountId = int.Parse(ds.Tables[0].Rows[0]["AccountId"].ToString());
            ao.AccountName = ds.Tables[0].Rows[0]["AccountName"].ToString();
            ao.AccountPrintName = ds.Tables[0].Rows[0]["AccountPrintName"].ToString();

            ao.AccountGroup=ds.Tables[0].Rows[0]["AccountGroupName"].ToString();
            
            ao.AddLine1=ds.Tables[0].Rows[0]["AddressLine1"].ToString();
            ao.AddLine2=ds.Tables[0].Rows[0]["AddressLine2"].ToString();
            ao.AddLine3=ds.Tables[0].Rows[0]["AddressLine3"].ToString();
            if (int.Parse(ds.Tables[0].Rows[0]["CityId"].ToString()) == -1)
            {
                ao.City = "";
            }
            else
            {
                int cityId = int.Parse(ds.Tables[0].Rows[0]["CityId"].ToString());
                cmd.CommandText = "Select CityName From City Where CityId=" + cityId;
                adpt.SelectCommand = cmd;
                ds1.Tables.Clear();

                conn.Open();
                adpt.Fill(ds1);
                conn.Close();

                ao.City = ds1.Tables[0].Rows[0]["CityName"].ToString();
            }

            if (int.Parse(ds.Tables[0].Rows[0]["StateId"].ToString()) == -1)
            {
                ao.State = "";
            }
            else
            {
                int stateId = int.Parse(ds.Tables[0].Rows[0]["StateId"].ToString());
                cmd.CommandText = "Select StateName From State Where StateId=" + stateId;
                adpt.SelectCommand = cmd;
                ds1.Tables.Clear();

                conn.Open();
                adpt.Fill(ds1);
                conn.Close();

                ao.State = ds1.Tables[0].Rows[0]["StateName"].ToString();
            }
            ao.Pin=ds.Tables[0].Rows[0]["Pincode"].ToString();
            ao.Email=ds.Tables[0].Rows[0]["Email"].ToString();
            ao.ContactPerson=ds.Tables[0].Rows[0]["ContactPerson"].ToString();
            ao.PhoneNo=ds.Tables[0].Rows[0]["TelephoneNo"].ToString();
            ao.ItPanNo=ds.Tables[0].Rows[0]["PANNo"].ToString();

            return ao;
        }

        

        #region Sales

        public List<string> getCustomerName()
        {
            conn.Open();
            ds = new DataSet();
            cmd.CommandText = "SELECT CustomerCompany From Customer";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds, "Customer");
            conn.Close();

            List<string> customerNameList = new List<string>();
            foreach (DataRow dr in ds.Tables["Customer"].Rows)
            {
                customerNameList.Add(dr[0].ToString());
            }

            return customerNameList;
        }

        public int getSaleNo()
        {
            try
            {
                conn.Open();
                ds.Clear();
                cmd.CommandText = "SELECT Max(SaleId) From Sale";
                adpt.SelectCommand = cmd;
                adpt.Fill(ds, "Sale");
                conn.Close();
                DataRow dr = ds.Tables["Sale"].Rows[0];
                return ((dr != null) ? (Int32.Parse(dr[0].ToString()) + 1) : 1);
            }
            catch (Exception ex)
            {
                return 1;
            }

        }

        public int getCustomerId(string CustomerName)
        {
            ds = new DataSet();
            cmd.CommandText = "SELECT CustomerId From Customer Where CustomerCompany='" + CustomerName + "'";
            adpt.SelectCommand = cmd;
            conn.Open();
            adpt.Fill(ds, "Customer");
            conn.Close();
            if (ds.Tables["Customer"].Rows.Count > 0)
                return Int32.Parse(ds.Tables["Customer"].Rows[0][0].ToString());
            else
                throw new Exception("No such Customer exists !!");
        }

        public void placeSale_SaleTable(int SaleId, int PurchaseOrderNo, DateTime SaleDate, int CustomerId, float AmountItems, float AmountTaxes, string Note)
        {
            //Purchase table
            conn.Open();
            cmd.CommandText = "Insert into Sale (SaleId, PurchaseOrderNumber, SaleDate, CustomerId, AmountItems, AmountTaxes, Note, ReceiptGenerated) values (" + SaleId + "," + PurchaseOrderNo + ",'" + SaleDate + "'," + CustomerId + "," + AmountItems + "," + AmountTaxes + ",'" + Note + "','" + false + "')";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void placeSale_SaleItemsTable(int SaleId, int ItemId, int Quantity, float PricePerUnit)
        {
            //SaleItems table
            cmd.CommandText = "Insert into SaleItems (SaleId, ItemId, Quantity, PricePerUnit) values (" + SaleId + "," + ItemId + "," + Quantity + ",'" + PricePerUnit + "')";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void placeSale_SaleTaxesTable(int PurchaseId, int TaxId, string TaxType, float TaxAmount)
        {
            //SaleTaxes table
            cmd.CommandText = "Insert into SaleTaxes (SaleId, TaxId, Type, Amount) values (" + PurchaseId + "," + TaxId + ",'" + TaxType + "','" + TaxAmount + "')";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();


        }

        public void placeSale_ChallanTable(int challanId, int saleId, DateTime challanDate, string paymentMode, int LRNo, string transporter, string destination)
        {
            cmd.CommandText = "Insert into Challan (ChallanId, SaleId, ChallanDate, PaymentMode, LorryReceiptNumber, Transporter, Destination) values("+challanId+","+saleId+",'"+challanDate+"','"+paymentMode+"',"+LRNo+",'"+transporter+"','"+destination+"')";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        #endregion


        #region Receipt

        public List<int> getSaleIdForCustomer(string customerName)
        {
            int customerId = this.getCustomerId(customerName);

            conn.Open();
            ds = new DataSet();
            cmd.CommandText = "SELECT SaleId From Sale where CustomerId='" + customerId + "' and ReceiptGenerated='" + false + "'";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds, "SaleCustomer");
            conn.Close();

            List<int> saleIdList = new List<int>();
            foreach (DataRow i in ds.Tables["SaleCustomer"].Rows)
            {
                saleIdList.Add(Int32.Parse(i[0].ToString()));
            }

            return saleIdList;

        }

        public int getReceiptId()
        {
            try
            {
                ds.Clear();
                cmd.CommandText = "SELECT Max(ReceiptId) From Receipt";
                adpt.SelectCommand = cmd;
                conn.Open();
                adpt.Fill(ds, "Receipt");
                conn.Close();
                DataRow dr = ds.Tables["Receipt"].Rows[0];
                return ((dr != null) ? (Int32.Parse(dr[0].ToString()) + 1) : 1);
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public List<string> getSaleItemIdForReceipt()
        {
            ds.Clear();
            
            cmd.CommandText = "SELECT SaleId From Sale where ReceiptGenerated='" + false + "'";
            adpt.SelectCommand = cmd;
            conn.Open();
            adpt.Fill(ds, "SaleId");
            conn.Close();
            List<string> saleIdList = new List<string>();

            foreach (DataRow i in ds.Tables["SaleId"].Rows)
            {
                saleIdList.Add(i[0].ToString());
            }

            return saleIdList;
        }

        public Dictionary<string, string> getSaleDetailsForReceipt(int saleId)
        {
            Dictionary<string, string> sd = new Dictionary<string, string>();
            ds = new DataSet();
            cmd.CommandText = "Select AmountItems, AmountTaxes from Sale where SaleId=" + saleId;
            adpt.SelectCommand = cmd;
            conn.Open();
            adpt.Fill(ds, "AmountSale");
            conn.Close();

            sd.Add("AmountItems", ds.Tables["AmountSale"].Rows[0]["AmountItems"].ToString());
            sd.Add("AmountTaxes", ds.Tables["AmountSale"].Rows[0]["AmountTaxes"].ToString());

            return sd;
        }

        public void makeReceipt(int ReceiptId, int SaleId, string PaymentMode, DateTime ReceiptDate, float TotalAmount, string Note)
        {
            //Get PaymentMode = Account , so Account Id
            conn.Open();
            ds = new DataSet();
            cmd.CommandText = "Select AccountID from Account where AccountName='" + PaymentMode + "'";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds, "Account");

            cmd.CommandText = "Insert into Receipt (ReceiptId, SaleId, ReceiptDate, TotalAmount, Note, PaymentMode) values (" + ReceiptId + "," + SaleId + ",'" + ReceiptDate + "'," + TotalAmount + ",'" + Note + "'," + Int32.Parse(ds.Tables["Account"].Rows[0][0].ToString()) + ")";
            adpt.SelectCommand = cmd;
            cmd.ExecuteNonQuery();

            //Modify value in Sale Table, Field ReceiptGenerated=true
            cmd.CommandText = "UPDATE Sale SET ReceiptGenerated = '" + true + "' Where SaleId=" + SaleId + "";
            adpt.SelectCommand = cmd;
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Receipt Entry made successfully.", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Supplier

        public int getNextSupplierId()
        {
            ds.Clear();
            cmd.CommandText = "Select * from Supplier";
            adpt.SelectCommand = cmd;
            conn.Open();
            adpt.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count == 0)
            {
                return 1;
            }

            else
            {
                ds.Clear();
                cmd.CommandText = "Select Max(SupplierId) from Supplier";
                adpt.SelectCommand = cmd;
                conn.Open();
                int i = int.Parse(cmd.ExecuteScalar().ToString());
                conn.Close();

                return ++i;

            }
        }

        #endregion

        public void truncateDatabase()
        {


        }
    }
}
