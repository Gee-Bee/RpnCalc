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
        string decimalSeparator;

        public Form1()
        {
            InitializeComponent();
            decimalSeparatorBtn.Text = decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            calc = new Calculator(displayLabel, 20);
        }

        private void safely(Action func){
            try { func(); }
            catch (ArgumentException ex) { MessageBox.Show(ex.Message); }
            catch (FormatException) { MessageBox.Show("Invalid operand format."); }
        }

        private void numbers_MouseClick(object sender, MouseEventArgs e)
        {
            Button btn = (Button) sender;
            calc.appendNumber(btn.Text);
        }

        private void enter_MouseClick(object sender, MouseEventArgs e)
        {
            calc.Push();
        }

        private void swap_MouseClick(object sender, MouseEventArgs e)
        {
            safely(calc.Swap);
        }

        private void drop_MouseClick(object sender, MouseEventArgs e)
        {
            safely(calc.Drop);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == Convert.ToChar(decimalSeparator) || e.KeyChar == '.')
                calc.appendNumber(e.KeyChar.ToString());
            else
            {
                switch (e.KeyChar)
                {
                    case '+':
                        safely(calc.Add);
                        break;
                    case '-':
                        safely(calc.Subtract);
                        break;
                    case '*':
                        safely(calc.Multiply);
                        break;
                    case '/':
                        safely(calc.Divide);
                        break;
                }
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {   
                case Keys.Enter:
                    calc.Push();
                    break;
                case Keys.Back:
                    safely(calc.Drop);
                    break;
                case Keys.Delete:
                    calc.Reset();
                    break;
            }
        }

        private void reset_MouseClick(object sender, MouseEventArgs e)
        {
            calc.Reset();
        }

        private void add_MouseClick(object sender, MouseEventArgs e)
        {
            safely(calc.Add);
        }

        private void subtract_MouseClick(object sender, MouseEventArgs e)
        {
            safely(calc.Subtract);
        }

        private void multiply_MouseClick(object sender, MouseEventArgs e)
        {
            safely(calc.Multiply);
        }

        private void divide_MouseClick(object sender, MouseEventArgs e)
        {
            safely(calc.Divide);
        }

        private void negate_MouseClick(object sender, MouseEventArgs e)
        {
            safely(calc.Negate);
        }

        private void invert_MouseClick(object sender, MouseEventArgs e)
        {
            safely(calc.Invert);
        }

        private void dateAdd_MouseClick(object sender, MouseEventArgs e)
        {
            safely(calc.DateAdd);
        }

        private void dateSubtract_MouseClick(object sender, MouseEventArgs e)
        {
            safely(calc.DateSubtract);
        }

    }
}
