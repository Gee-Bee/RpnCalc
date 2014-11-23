using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RpnCalc
{
    class Operand
    {
        public string Text { get; set; }

        public Operand(object obj)
        {
            Type t = obj.GetType();
            if (obj is String)
                this.Text = (string)obj;
            else if (obj is double)
                this.Text = String.Format("{0:0.#####}", (double)obj);
            else if (obj is TimeSpan)
                this.Text = ((TimeSpan)obj).Days.ToString();
            else if (obj is DateTime)
            {
                DateTime dt = (DateTime)obj;
                this.Text = String.Format("{0}.{1}.{2}", dt.Year, dt.Month, dt.Day);
            }
        }

        public double ToNumber()
        {
            return double.Parse(Text);
        }

        public DateTime ToDateTime()
        {
            return DateTime.ParseExact(Text, "yyyy.M.d", CultureInfo.CurrentCulture);
        }
    }
}
