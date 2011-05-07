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
    /// Interaction logic for ChangeFinancialYear.xaml
    /// </summary>
    public partial class ChangeFinancialYear : Window
    {
        public ChangeFinancialYear()
        {
            InitializeComponent();
        }

        private void rBtnPrevious_Checked(object sender, RoutedEventArgs e)
        {
            cBYears.IsEnabled = true;
        }

        private void rBtnLatest_Checked(object sender, RoutedEventArgs e)
        {
            cBYears.SelectedIndex = -1;
            cBYears.IsEnabled = false;
        }

        private void btnChangeFinancialYear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
