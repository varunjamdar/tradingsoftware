﻿using System;
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
    /// Interaction logic for NewFinancialYear.xaml
    /// </summary>
    public partial class NewFinancialYear : Window
    {
        public NewFinancialYear()
        {
            InitializeComponent();
        }

        private void btnNewFY_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBoxResult result= MessageBox.Show("Are you sure you want to move to next Financial Year ?","Warning !!",MessageBoxButton.YesNo);
            //if(result==MessageBoxResult.Yes)
            //    MessageBox.Show("Yes");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}