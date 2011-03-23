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
        public Unit()
        {
            InitializeComponent();
            txtUnitName.IsEnabled = false;
            txtPrintName.IsEnabled = false;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
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
            DataLogic dl = new DataLogic();

            unitobject.UnitName = txtUnitName.Text;
            unitobject.UnitPrintName = txtPrintName.Text;

            dl.addUnit(unitobject);


        }

        

        

    }
}
