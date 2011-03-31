using System;
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











        //if the item code exists in the item table
        
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

        //--get SupplierId
        public int getSupplierId(string SupplierName)
        {
            conn.Open();
            cmd.CommandText = "SELECT SupplierId From Supplier Where SupplierName='" + SupplierName + "'";
            adpt.SelectCommand = cmd;
            adpt.Fill(ds, "Supplier");
            conn.Close();

            return Int32.Parse(ds.Tables["Supplier"].Rows[0][0].ToString());
        }

        public void placePurchaseOrder_PurchaseOrderTable(int PurchaseOrderId,DateTime PurchaseOrderDate,int SupplierId,float AmountItems,float AmountTaxes)
        {
            //PurchaseOrder table
            conn.Open();
            cmd.CommandText = "Insert into PurchaseOrder (PurchaseOrderId, PurchaseOrderDate, SupplierId, AmountItems, AmountTaxes, GoodsRecieved) values ("+PurchaseOrderId+",'"+PurchaseOrderDate+"',"+SupplierId+","+AmountItems+","+AmountTaxes+",'"+false+"')";     
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

        //if the item code exists in the item table
        public bool itemCodeExists(string itemcode)
        {
            bool itemcodethere = false;

            conn.Open();

            cmd.CommandText = "Select * from Item";
            adpt.SelectCommand = cmd;

            adpt.Fill(ds, "Itemsrc");

            foreach (DataRow dr in ds.Tables["Itemsrc"].Rows)
            {
                if (dr["ItemSrc"].Equals(itemcode))
                {
                    itemcodethere = true;
                    goto A;
                }
            }

        A:
            conn.Close();
            return itemcodethere;
        }

        //if the item name exists int the table..
        public bool itemNameExists(string itemName)
        {

            conn.Open();

            bool itemNamether=false;

            cmd.CommandText="Select * from Item";
            adpt.SelectCommand=cmd;

            adpt.Fill(ds,"itemSrc");

            foreach (DataRow dr in ds.Tables["itemSrc"].Rows)
    	    {
		       if(dr["itemSrc"].Equals(itemName))
               {
                   itemNamether=true;
                   goto A;
               }
	        }

            A:
            conn.Close();
            return itemNamether;
        }
        //write code for getting itemgroupid for item group name n same for unit..


        public String AddItem(ItemObject item)//method ncommented just to build successfully..
        {
            //    String itemCode = item.ItemCode;
            //    String itemName = item.ItemName;

            //    if (itemCodeExists(itemCode))
            //    {
            //        String str = "Item With the same Code already exists, Cannot add another item with same code";
            //        return str;
            //    }

            //    if (itemNameExists(itemName))
            //    {
            //        String str = "Another Item With the same name already exists, cannot add another item with same name";
            //        return str;
            //    }

            //    cmd = conn.CreateCommand();
            //    cmd.CommandText = @"Insert Into Item(ItemCode,ItemGroupId,ItemName,ItemDesc,UnitId,OpenDate,OpenStockQty,OpenStockValue,PurchasePrice,SalePrice,MRP,MinimumSalePrice,InsuranceAmount,HSNCode,IMCOClass,CASNo)values(@ItemCode,@ItemGroupId,@ItemName,@ItemDesc,@UnitId,@OpenDate,@OpenStockQty,@OpenStockValue,@PurchasePrice,@SalePrice,@MRP,@MinimumSalePrice,@InsuranceAmount,@HSNCode,@IMCOClass,@CASNo);";

            //    cmd.Parameters.Add("@ItemCode", SqlDbType.VarChar, 50);
            //    cmd.Parameters.Add("@ItemGroupId", SqlDbType.Int);
            return "";
        }

        public int getItemId(string s)//code remaining to write
        {
            return 1;
        }
    }
}
