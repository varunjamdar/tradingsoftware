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
using System.Windows.Forms;

namespace tradingSoftware
{
    /// <summary>
    /// Interaction logic for Restore.xaml
    /// </summary>
    public partial class Restore : Window
    {
        public Restore()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            
            ofd.DefaultExt = ".mdf";
            ofd.Filter = "MSSQL Database File (*.mdf)|*.mdf";
            DialogResult dr = ofd.ShowDialog();

            textBoxBackupLocation.Text = ofd.FileName;

        }

        private void btnBackup_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxBackupLocation.Text != "")
            {
                string fileName = tradingSoftware.Properties.Settings.Default.DBFile;
                string sourcePath =textBoxBackupLocation.Text;
                

                //**********************************--------------------------
                string s = sourcePath;
                char[] c = s.ToCharArray();
                int count = 0;
                //--------------------------------------------------------------------------------------------           //check how many : exist 
                foreach (char ss in c)
                {
                    if (ss.ToString() == @"\")
                    {
                        count++;
                    }
                }
                //-------------------------------------------------------------------------------------------
                int i = 0;
                bool createString = false;
                string SFileName = "";
                foreach (char ss in c)
                {
                    if (createString == false)
                    {
                        if (ss.ToString() == @"\" )
                        {
                            i++;
                            if (i == count)
                            {
                                createString = true;
                            }
                        }
                    }
                    else
                    {
                        SFileName += ss.ToString();
                    }
                }

                //

                string targetPath = Environment.CurrentDirectory + @"\" + SFileName; //with .mdf

                // Use Path class to manipulate file and directory paths.
                string destFile = targetPath;
                string sourceFile = sourcePath;


                // To copy a file to another location and 
                // overwrite the destination file if it already exists.

                //Delete the database from the Programme file.
                System.Windows.MessageBox.Show("To Delete File : "+ Environment.CurrentDirectory + @"\" + fileName);
                System.IO.File.Delete(Environment.CurrentDirectory+@"\"+fileName);
                System.IO.File.Delete(Environment.CurrentDirectory + @"\" + fileName+"_log");
                System.Windows.MessageBox.Show("File Deleted Successfully");

                //Save database in the programme file.
                System.IO.File.Copy(sourceFile, destFile, true);
                System.Windows.MessageBox.Show("Restore done Successfully","Succeed",MessageBoxButton.OK,MessageBoxImage.Information);
                textBoxBackupLocation.Text = "";


                //Save to Settings.Settings File
                Properties.Settings.Default.DBFile = SFileName;
                Properties.Settings.Default.Save();

            }
            else
            {
                System.Windows.MessageBox.Show("Select Location","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
