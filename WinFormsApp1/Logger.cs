using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    static internal class Logger
    {
        internal static void Write(string name, string v)
        {
            //throw new NotImplementedException();
        }
        public static string GetCurrentMonth()
        {
            DateTime dateTime = DateTime.Now;
            string monthYear = dateTime.ToString("Y");
            if (Environment.Is64BitOperatingSystem)
            {
                monthYear = monthYear.Substring(0, monthYear.Length - 3);
            }
            monthYear = monthYear.Substring(0, 1).ToUpper() + monthYear.Substring(1);
            return monthYear;
        }
    }
}
