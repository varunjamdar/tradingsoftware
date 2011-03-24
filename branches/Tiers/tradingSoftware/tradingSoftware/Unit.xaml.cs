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
    /// Interaction logic for Unit.xaml
    /// </summary>
    public partial class Unit : Window
    {
        DataLogic dl;
        TradeDataSet tds;
        public Unit()
        {
            InitializeComponent();
            txtUnitName.IsEnabled = false;
            txtPrintName.IsEnabled = false;
            this.showUnitData();
        }

        private void showUnitData()
        {
            tds = new TradeDataSet();
            TradeDataSetTableAdapters.UnitTableAdapter unitTableAdpt = new tradingSoftware.TradeDataSetTableAdapters.UnitTableAdapter();

            unitTableAdpt.Fill(tds.Unit);
            UnitDataGrid.DataContext = tds.Unit;
            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            txtUnitName.Text = "";
            txtPrintName.Text = "";

            txtUnitName.IsEnabled = true;
            txtPrintName.IsEnabled = true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtUnitName.Text == "" || txtPrintName.Text == "")
            {
                MessageBox.Show("You Must Enter Both Unit Name and Unit Print Name", "Warning..!!");
                return;
            }

            UnitObject unitobject = new UnitObject();
            dl = new DataLogic();

            unitobject.UnitName = txtUnitName.Text;
            unitobject.UnitPrintName = txtPrintName.Text;

            dl.addUnit(unitobject);

            this.showUnitData();

            txtUnitName.Text = "";
            txtPrintName.Text = "";

            txtUnitName.IsEnabled = false;
            txtPrintName.IsEnabled = false;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtUnitName.Text == "" || txtPrintName.Text == "")
            {
                MessageBox.Show("Select some Unit to Delete", "Warning..!!");
                return;
            }

            UnitObject unitobject = new UnitObject();
            dl = new DataLogic();

            unitobject.UnitName = txtUnitName.Text;
            unitobject.UnitPrintName = txtPrintName.Text;

            dl.deleteUnit(unitobject);

            this.showUnitData();
        }
    }
}
