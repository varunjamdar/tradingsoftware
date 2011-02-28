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
    /// Interaction logic for Location.xaml
    /// </summary>
    public partial class Location : Window
    {
        public Location()
        {
            InitializeComponent();
            txtState.IsEnabled =false;
            txtCity.IsEnabled = false;

        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            txtState.IsEnabled = true;
            txtCity.IsEnabled = true;

        }

        

    }
}
