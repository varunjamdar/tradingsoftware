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
    /// Interaction logic for NewFinancialYear.xaml
    /// </summary>
    public partial class NewFinancialYear : Window
    {
        string dbFolderName;
        public NewFinancialYear()
        {
            InitializeComponent();
            int currentMonth = Int32.Parse(DateTime.Today.Month.ToString());
            int currentYear=Int32.Parse(DateTime.Today.Year.ToString());

            string FinancialYear = "";
            string NFinancialYear = "";
            
            
            if (currentMonth > 3)
            {
                //current
                FinancialYear = "April " + currentYear + "-" + " March " + ++currentYear;
                dbFolderName = --currentYear + "-" + ++currentYear;

                //Next
                NFinancialYear = "April " + currentYear + "-" + " March " + ++currentYear;
            }
            else
            {
                //current
                FinancialYear = "April " + --currentYear + "-" + " March " + currentYear;

                NFinancialYear = "April " + currentYear + "-" + " March " + ++currentYear;
            }
            lblCurrentFY.Content = FinancialYear;
            lblNewFY.Content = NFinancialYear;
            
        }

        private void btnNewFY_Click(object sender, RoutedEventArgs e)
        {


            MessageBoxResult result = MessageBox.Show("Are you sure you want to move to next Financial Year ?", "Warning !!", MessageBoxButton.YesNo,MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                //Move current db in FinancialYearDB Folder Name
                try
                {
                    //string fileName = Properties.Settings.Default.DBFile;
                    string sourcePath = Environment.CurrentDirectory + @"/Trade.mdf";
                    string targetPath = Environment.CurrentDirectory+@"/"+dbFolderName;


                    // Use Path class to manipulate file and directory paths.
                    string sourceFile = sourcePath;//System.IO.Path.Combine(sourcePath, fileName);
                    string destFile = targetPath + @"/Trade.mdf";

                    if (!System.IO.Directory.Exists(targetPath))
                    {
                        System.IO.Directory.CreateDirectory(targetPath);
                    }
                    // To copy a file to another location and 
                    // overwrite the destination file if it already exists.

                    System.IO.File.Copy(sourceFile, destFile, true);

                    //for log file
                    sourcePath = Environment.CurrentDirectory + @"/Trade_log.ldf";
                    destFile = targetPath + @"/Trade_log.ldf";
                    System.IO.File.Copy(sourceFile, destFile, true);
                    DataLogic dl = new DataLogic();
                    dl.truncateDatabase();
                    System.Windows.MessageBox.Show("Financial Year Changed Successfully", "Succeed", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message + "\n \n Restart the Application and then try.");
                }

                //Truncate the current database

            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
