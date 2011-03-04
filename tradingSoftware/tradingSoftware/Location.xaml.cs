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
        DataLogic dl;
        string state, city;
        public Location()
        {
            InitializeComponent();
            dl = new DataLogic();
            LocationSetupGrid.DataContext = dl.showState();
            comboBoxState.Text = "--add State--";
            txtCity.Text = "--add City--";
           //
            fillStateCityListBox();
        }
        public void fillStateCityListBox()
        {
            TradeDataSet ds = new TradeDataSet();
            TradeDataSetTableAdapters.StateTableAdapter stateAdpt = new TradeDataSetTableAdapters.StateTableAdapter();
            TradeDataSetTableAdapters.CityTableAdapter cityAdpt = new TradeDataSetTableAdapters.CityTableAdapter();
            stateAdpt.Fill(ds.State);
            cityAdpt.Fill(ds.City);
            EditGrid.DataContext = ds.State;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            state = comboBoxState.Text;
            city = txtCity.Text;
            string Msg= dl.addStateCity(state,txtCity.Text);
            
                MessageBox.Show(Msg);

                comboBoxState.Text = "--add State--";
                txtCity.Text = "--add City--";

            //refresh the state city list Box and textBoxes
                fillStateCityListBox();

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click_1(object sender, RoutedEventArgs e)
        {
            string StateID, CityID;
            StateID=labelStateID.Content.ToString();
            try
            {
                CityID = labelCityID.Content.ToString();
            }
            catch (NullReferenceException nre)
            {
                CityID = "";
            }
            
            string msg = dl.updateStateCity(StateID, textBoxState.Text, CityID, textBoxCity.Text);
            MessageBox.Show(msg);
            fillStateCityListBox();
        }

        private void btnDeleteCity_Click_1(object sender, RoutedEventArgs e)
        {
            //delete city
            dl.deleteCity(Int32.Parse(labelCityID.Content.ToString()));
            //refresh the state city list Box and textBoxes
            fillStateCityListBox();


        }

        private void btnDeleteState_Click(object sender, RoutedEventArgs e)
        {
            //delete state
            dl.deleteState(Int32.Parse(labelStateID.Content.ToString()));
            //refresh the state city list Box and textBoxes
            fillStateCityListBox();

        }

        private void textBoxCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxCity.Text == "")
            {
                btnDeleteCity.IsEnabled = false;
            }
            else
            {
                btnDeleteCity.IsEnabled = true;
            }
        }

        

    }
}
