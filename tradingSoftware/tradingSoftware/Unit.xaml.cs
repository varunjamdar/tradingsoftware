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
        private DataLogic dl = null;
        private TradeDataSet tds = null;
        private TradeDataSetTableAdapters.UnitTableAdapter unitTableAdpt = null;

        private UnitObject unitobject = null;

        public Unit()
        {
            InitializeComponent();
            txtUnitName.IsEnabled = false;
            txtPrintName.IsEnabled = false;

            dl = new DataLogic();
            tds = new TradeDataSet();
            unitTableAdpt = new tradingSoftware.TradeDataSetTableAdapters.UnitTableAdapter();

            this.showUnitData();
        }

        private void showUnitData()
        {
            //for better performance made these changes.
            //author=VJ, timestamp=27/3/2011 1:00 pm
            tds.Clear();
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

//            UnitObject unitobject = new UnitObject();
            unitobject = new UnitObject();
//            dl = new DataLogic();

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

//            UnitObject unitobject = new UnitObject();
            unitobject = new UnitObject();
//            dl = new DataLogic();

            unitobject.UnitName = txtUnitName.Text;
            unitobject.UnitPrintName = txtPrintName.Text;

            dl.deleteUnit(unitobject);

            this.showUnitData();
        }
    }
}
