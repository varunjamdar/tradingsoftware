using System;
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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Microsoft.VisualBasic;

namespace tradingSoftware
{
    /// <summary>
    /// Interaction logic for VersionInfromation.xaml
    /// </summary>
    public partial class VersionInfromation : Window
    {
        FileStream IfsTimeStamp = null;
        FileStream OfsTimeStamp = null;
        BinaryFormatter bf = new BinaryFormatter();
        string timeStamp=string.Empty;
        long TrialDay;

        EncryptionDecryption edClass = new EncryptionDecryption();

        public VersionInfromation()
        {
            InitializeComponent();
            //Read user Settings
            bool RunFirstTime = Properties.Settings.Default.RunFirstTime;
            //
            //change the property Name with true, and delete File
            //
            if (RunFirstTime == true)
            {
                IfsTimeStamp = new FileStream("ETimeStamp.Kalsariya", FileMode.OpenOrCreate);
                //timeStamp = edClass.Decrypt(bf.Deserialize(IfsTimeStamp).ToString());
                 
                Properties.Settings.Default.RunFirstTime = false;
                //Save
                Properties.Settings.Default.Save();
            }
            else
            {
                IfsTimeStamp = new FileStream("ETimeStamp.Kalsariya", FileMode.Open, FileAccess.Read);
                timeStamp = edClass.Decrypt(bf.Deserialize(IfsTimeStamp).ToString());

            }
            
            IfsTimeStamp.Close();
            //Display The Remaining Trail Day
            
            if (RunFirstTime==true)
            {
                timeStamp = DateTime.Today.ToShortDateString() + "/30";
                lblRemainingDays.Content = "Your Trial Period is Strartd, 30 days Remains";
                TrialDay = 30;
                MessageBox.Show("Welcome :  Enjoy Trial 30 Days");
            }
            else
            {
                string firstDate = timeStamp;
                BusinessLogic bl = new BusinessLogic();
                TrialDay = bl.remainingTrialDay(firstDate);
                lblRemainingDays.Content = "You have "+TrialDay+" Trial Days.";
                timeStamp = DateTime.Today.ToShortDateString() + "/" + TrialDay;
            }
            
            OfsTimeStamp = new FileStream("ETimeStamp.Kalsariya", FileMode.Open, FileAccess.Write);
            bf.Serialize(OfsTimeStamp, edClass.Encrypt(timeStamp));
            OfsTimeStamp.Close();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (radioButtonTrailVersion.IsChecked == true)
            {
                if (TrialDay >= 1)
                {
                    Window2 mainForm=new Window2();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Trial Version has been expired", "Trial Expired Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
