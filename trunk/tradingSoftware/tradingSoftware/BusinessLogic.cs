using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualBasic;

namespace tradingSoftware
{
    class BusinessLogic
    {
        public long remainingTrialDay(string input)
        {
            string DateString = input+"/"; //last / for return again to if(ss=seprator) to store in YMDD array

            char[] c = DateString.ToCharArray();

            StringBuilder sb = new StringBuilder();
            int[] MDYTd = new int[4];
            int i = 0;
            char seprator = Convert.ToChar("/");
            foreach (char ss in c)
            {

                if (ss == seprator)
                {

                    MDYTd[i++] = Int32.Parse(sb.ToString());
                    sb = new StringBuilder();
                }
                else
                {
                    sb.Append(ss);
                }
            }
            //
            //concept difference between date
            DateTime dt = new DateTime(MDYTd[2], MDYTd[0],MDYTd[1]); //yy/mm/dd
            Console.WriteLine(DateTime.Now.Date);
            Console.WriteLine(dt.ToString());
            long diffday = DateAndTime.DateDiff(DateInterval.Day, dt, DateTime.Now.Date, FirstDayOfWeek.Saturday, FirstWeekOfYear.FirstFullWeek);

            //Calculate Remaining Trail Days
            if (diffday < 0)
            {//check consistancy if systemDate modified any set privios date then also Trail day will reduce 
                //here diffday is negative(-)
                long TrailDays = MDYTd[3] + diffday;
                return TrailDays;
            }
            else
            {
                long TrailDays = MDYTd[3] - diffday;
                return TrailDays;
            }
            
            
        }
    }
}
