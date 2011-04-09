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
    /// Interaction logic for ItemsFind.xaml
    /// </summary>
    public partial class ItemsFind : Window
    {
        private DataLogic dl = null;
        private int itemCode;

        public ItemsFind()
        {
            InitializeComponent();

            //TradeDataSet tds = new TradeDataSet();
            //TradeDataSetTableAdapters.ItemTableAdapter itemadpt = new tradingSoftware.TradeDataSetTableAdapters.ItemTableAdapter();
            //itemadpt.Fill(tds.Item);

            //TradeDataSetTableAdapters.ItemGroupTableAdapter itemgroupadpt = new tradingSoftware.TradeDataSetTableAdapters.ItemGroupTableAdapter();
            //itemgroupadpt.Fill(tds.ItemGroup);

            //this.ItemListingGrid.DataContext = tds.Item;

            dl = new DataLogic();
            this.ItemGrid.ItemsSource = dl.getItems().DefaultView;
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ItemGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Helper helperClass = new Helper();
                helperClass.HelperDataGrid = this.ItemGrid;

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
                    MessageBox.Show(valueToShow.ToString());
                    itemCode = int.Parse(valueToShow.ToString());
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
