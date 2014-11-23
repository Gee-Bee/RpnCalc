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

        public Operand(string s)
        {
            this.Text = s;
        }

        public decimal ToNumber()
        {
           return decimal.Parse(Text);
        }
    }
}
