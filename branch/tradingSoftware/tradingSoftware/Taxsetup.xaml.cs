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
    /// Interaction logic for Taxsetup.xaml
    /// </summary>
    public partial class Taxsetup : Window
    {
        public Taxsetup()
        {
            InitializeComponent();
            DataLogic dl = new DataLogic();
            dl.addTax();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
