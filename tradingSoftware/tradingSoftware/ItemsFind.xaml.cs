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
    /// Interaction logic for ItemsFind.xaml
    /// </summary>
    public partial class ItemsFind : Window
    {
        public ItemsFind()
        {
            InitializeComponent();

            TradeDataSet tds = new TradeDataSet();
            TradeDataSetTableAdapters.ItemTableAdapter itemadpt = new tradingSoftware.TradeDataSetTableAdapters.ItemTableAdapter();
            itemadpt.Fill(tds.Item);

            TradeDataSetTableAdapters.ItemGroupTableAdapter itemgroupadpt = new tradingSoftware.TradeDataSetTableAdapters.ItemGroupTableAdapter();
            itemgroupadpt.Fill(tds.ItemGroup);

            this.ItemListingGrid.DataContext = tds.Item;
            //this.ItemListingGrid.DataContext = tds.ItemGroup;
        }
    }
}
