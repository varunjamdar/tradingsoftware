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

namespace tradingSoftware
{
    /// <summary>
    /// Interaction logic for AccountSetup.xaml
    /// </summary>
    public partial class AccountSetup : Window
    {
        DataLogic dl;
        AccountObject account ;
        AccountsFind accountsFind;


        public AccountSetup()
        {
            InitializeComponent();

            TradeDataSet tds = new TradeDataSet();

            TradeDataSetTableAdapters.AccountGroupTableAdapter accountGroupTableAdpt = new tradingSoftware.TradeDataSetTableAdapters.AccountGroupTableAdapter();
            accountGroupTableAdpt.Fill(tds.AccountGroup);

            this.cmbAccountGroup.DataContext = tds.AccountGroup;

            TradeDataSetTableAdapters.StateTableAdapter stateadpt = new tradingSoftware.TradeDataSetTableAdapters.StateTableAdapter();
            stateadpt.Fill(tds.State);

            TradeDataSetTableAdapters.CityTableAdapter cityadpt = new tradingSoftware.TradeDataSetTableAdapters.CityTableAdapter();
            cityadpt.Fill(tds.City);

            this.AccountSetupGrid.DataContext = tds.State;

        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
            txtPrintName.Text = "";
            cmbAccountGroup.SelectedIndex = -1;
            txtAddline1.Text = "";
            txtAddline2.Text = "";
            txtAddline3.Text = "";
            cmbState.SelectedIndex = -1;
            cmbCity.SelectedIndex = -1;
            txtPin.Text = "";
            txtContactPerson.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtItPan.Text = "";

            txtName.IsEnabled = true;

            dl = new DataLogic();

            int accountId = dl.getNextAccountId();

            txtAccountId.Text = accountId.ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtAccountId.Text == "")
            {
                MessageBox.Show("Click NEW to add NEW value", "WARNING");
                return;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("Enter/Select Account Name, cant proceed further", "WARNING");
                return;
            }

            if (txtPrintName.Text == "")
            {
                MessageBox.Show("Enter/Select Account Print Name, cant proceed further", "WARNING");
                return;
            }

            if (cmbAccountGroup.SelectedIndex == -1)
            {
                MessageBox.Show("Select the Account Group type", "WARNING");
                return;
            }

            account = new AccountObject();

            account.AccountId = int.Parse(txtAccountId.Text.ToString());
            account.AccountName = txtName.Text.ToString();
            account.AccountPrintName = txtPrintName.Text.ToString();
            account.AccountGroup = cmbAccountGroup.Text.ToString();
            account.AddLine1 = txtAddline1.Text.ToString();
            account.AddLine2 = txtAddline2.Text.ToString();
            account.AddLine3 = txtAddline3.Text.ToString();
            account.City = cmbCity.Text.ToString();
            account.State = cmbState.Text.ToString();
            account.Pin = txtPin.Text.ToString();
            account.ContactPerson = txtContactPerson.Text.ToString();
            account.Email = txtEmail.Text.ToString();
            account.PhoneNo = txtPhone.Text.ToString();
            account.ItPanNo = txtItPan.Text.ToString();

            dl = new DataLogic();

            string reply = dl.AddAccount(account);

            MessageBox.Show("" + reply);

            txtAccountId.Text = "";
            txtName.Text = "";
            txtPrintName.Text = "";
            cmbAccountGroup.SelectedIndex = -1;
            txtAddline1.Text = "";
            txtAddline2.Text = "";
            txtAddline3.Text = "";
            cmbCity.SelectedIndex = -1;
            cmbState.SelectedIndex = -1;
            txtPin.Text = "";
            txtContactPerson.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtItPan.Text = "";

        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtPrintName.Text = txtName.Text;

        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            accountsFind = new AccountsFind(this);
            accountsFind.ShowDialog();
        }

        public void populate(int accoId)
        {
            dl = new DataLogic();
            account = new AccountObject();

            account = dl.getDetailsOfAccountId(accoId);

            txtAccountId.Text = account.AccountId.ToString();
            txtName.Text = account.AccountName.ToString();
            txtPrintName.Text = account.AccountPrintName.ToString();
            cmbAccountGroup.Text = account.AccountGroup.ToString();
            txtAddline1.Text = account.AddLine1.ToString();
            txtAddline2.Text = account.AddLine2.ToString();
            txtAddline3.Text = account.AddLine3.ToString();
            cmbState.Text = account.State.ToString();
            cmbCity.Text = account.City.ToString();
            txtPin.Text = account.Pin.ToString();
            txtContactPerson.Text = account.ContactPerson.ToString();
            txtEmail.Text = account.Email.ToString();
            txtPhone.Text = account.PhoneNo.ToString();
            txtItPan.Text = account.ItPanNo.ToString();

            txtName.IsEnabled = false;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
