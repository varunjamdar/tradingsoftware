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
using System.IO;
using Microsoft.Win32;

namespace tradingSoftware
{
    public class Validations
    {
        public static void PhoneNoValidator(string phoneno)
        {
            float phno;
            int phnolength;

            try
            {
                phno = float.Parse(phoneno);
            }
            catch (FormatException fe)
            {
                throw new PhoneNoErrorException("Enter only numbers");
                return;
            }

            phnolength = phoneno.Length;
           // MessageBox.Show("phone lenght " + phnolength);

            if (phnolength.Equals(10) || phnolength.Equals(11))
            {

            }
            else
            {
                throw new PhoneNoErrorException("Phone/Fax No not of Proper Length");
            }
                
        }

        public static void NumberValidator(string number)
        {
            if (number.Length == 0)
                return;
            float no;

            try
            {
                no = float.Parse(number);
            }
            catch (FormatException fe)
            {
                throw new FormatException("Enter Only Numbers");
            }
        }

        public static void NullValidator(string str)
        {
            if (str == null)
                throw new NullValueException("Value is Null");
        }

        //public static void DateValidator(DateTime date)
        //{
        //    DateTime dt;

        //    try
        //    {
        //        dt = DateTime.Parse(date);
        //    }
        //    catch (FormatException fe)
        //    {
        //        throw new FormatException("Enter Correct Date");
        //    }
        //}
    }
}
