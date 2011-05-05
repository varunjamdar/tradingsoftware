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

using System.Collections;
using System.Data;
using Microsoft.Windows.Controls.Primitives;
using Microsoft.Windows.Controls;

namespace tradingSoftware
{
    /// <summary>
    /// Interaction logic for AccountsFind.xaml
    /// </summary>
    public partial class AccountsFind : Window
    {
        private DataLogic dl =null;
        private AccountSetup Parent;
        private int AccountId;

        public AccountsFind(AccountSetup Account)
        {
            InitializeComponent();

            Parent = Account;
            dl = new DataLogic();
            this.AccountGrid.DataContext = dl.getAccounts().DefaultView;
        }

        private void AccountGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Helper helperClass = new Helper();
                helperClass.HelperDataGrid = this.AccountGrid;

                DependencyObject dep = (DependencyObject)e.OriginalSource;

                while ((dep != null) && !(dep is DataGridCell) && !(dep is DataGridColumnHeader))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }

                if (dep == null)
                    return;

                if (dep is DataGridColumnHeader)
                {
                    return;
                }

                if (dep is DataGridCell)
                {
                    DataGridCell cell = dep as DataGridCell;

                    // navigate further up the tree
                    while ((dep != null) && !(dep is DataGridRow))
                    {
                        dep = VisualTreeHelper.GetParent(dep);
                    }

                    if (dep == null)
                        return;

                    DataGridRow row = dep as DataGridRow;

                    //object value = ExtractBoundValue(row, cell);

                    //int columnIndex = cell.Column.DisplayIndex;
                    int rowIndex = helperClass.FindRowIndex(row);

                    //ClickedItemDisplay.Text = string.Format("Cell clicked [{0}, {1}] = {2}", rowIndex, columnIndex, value.ToString());

                    DataGridCell dgc = helperClass.GetCell(rowIndex, 0);
                    object valueToShow = helperClass.ExtractBoundValue(row, dgc);
                    //MessageBox.Show(valueToShow.ToString());
                    // ItemCode = int.Parse(valueToShow.ToString());
                    AccountId = int.Parse(valueToShow.ToString());

                    //DataGridCell dgc1 = helperClass.GetCell(rowIndex, 1);
                    //object valueToShow1 = helperClass.ExtractBoundValue(row, dgc1);
                    //ItemName = valueToShow1.ToString();

                    Parent.populate(AccountId);
                    this.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
