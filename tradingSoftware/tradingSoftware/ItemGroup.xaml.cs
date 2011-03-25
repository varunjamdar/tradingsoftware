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
    /// Interaction logic for ItemGroup.xaml
    /// </summary>
    public partial class ItemGroup : Window
    {
        public ItemGroup()
        {
            InitializeComponent();
        }

        ItemGroupObject igo;
        DataLogic dl;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtGroupName.Text == "")
            {
                MessageBox.Show("Enter the Group Name", "Warning..!!");
                return;
            }

            igo = new ItemGroupObject();

            igo.ItemGroupName = txtGroupName.Text;
            igo.ItemGroupDesc = txtGroupDesc.Text;

            dl = new DataLogic();

            String reply = dl.AddItemGroup(igo);
                       

            MessageBox.Show(reply, "Message");

            txtGroupName.Text = "";
            txtGroupDesc.Text = "";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

             
    }
}
