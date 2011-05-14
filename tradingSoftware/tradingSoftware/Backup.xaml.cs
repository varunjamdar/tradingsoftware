﻿using System;
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
    /// Interaction logic for Backup.xaml
    /// </summary>
    public partial class Backup : Window
    {
        public Backup()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult dr= sfd.ShowDialog();
           
            
            // Get the selected file name and display in a TextBox
            
            textBoxBackupLocation.Text = sfd.FileName;

        }

        private void btnBackup_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxBackupLocation.Text != "")
            {

                string fileName = Properties.Settings.Default.DBFile;
                string sourcePath = Environment.CurrentDirectory;
                string targetPath = textBoxBackupLocation.Text;


                // Use Path class to manipulate file and directory paths.
                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = targetPath+@".mdf";


                // To copy a file to another location and 
                // overwrite the destination file if it already exists.
                System.IO.File.Copy(sourceFile, destFile, true);
                System.Windows.MessageBox.Show("Backup done Successfully","Succeed",MessageBoxButton.OK,MessageBoxImage.Information);
                textBoxBackupLocation.Text = "";
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
