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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void CompanyConfig_Click(object sender, RoutedEventArgs e)
        {
            CompanyDetails cd = new CompanyDetails();
            cd.ShowDialog();
        }

        private void Unit_Click(object sender, RoutedEventArgs e)
        {
            //open unit form
            Unit unitForm = new Unit();
            unitForm.ShowDialog();
        }

        private void CustomerDetails_Click(object sender, RoutedEventArgs e)
        {
            CustomerDetails custdet = new CustomerDetails();
            custdet.ShowDialog();
        }

        private void Location_Click(object sender, RoutedEventArgs e)
        {
            Location locationForm = new Location();
            locationForm.ShowDialog();
        }

        private void Accounts_Click(object sender, RoutedEventArgs e)
        {
            AccountSetup accountsetupform = new AccountSetup();
            accountsetupform.ShowDialog();
        }

        private void Journal_Click(object sender, RoutedEventArgs e)
        {
            Journal journalForm = new Journal();
            journalForm.ShowDialog();
        }
    }
}
