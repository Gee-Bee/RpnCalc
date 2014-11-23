using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RpnCalc
{
    public partial class Form1 : Form
    {
        Calculator calc;

        public Form1()
        {
            InitializeComponent();
            calc = new Calculator(displayLabel, 20);
        }

        private void numbers_Click(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            calc.appendNumber(btn.Text);
        }

        private void enter_Click(object sender, EventArgs e)
        {
            calc.Push();
        }

        private void swap_Click(object sender, EventArgs e)
        {
            try { calc.Swap(); }
            catch (ArgumentException ex) { MessageBox.Show(ex.Message); }
        }

        private void drop_Click(object sender, EventArgs e)
        {
            try { calc.Drop(); }
            catch (ArgumentException ex) { MessageBox.Show(ex.Message); }
        }

    }
}
