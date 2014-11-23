﻿using System;
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
            safely(calc.Swap);
        }

        private void drop_Click(object sender, EventArgs e)
        {
            safely(calc.Drop);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == Convert.ToChar(decimalSeparator))
                calc.appendNumber(e.KeyChar.ToString());
            else
            {
                switch (e.KeyChar)
                {
                    case '+':
                        safely(calc.Sum);
                        break;
                    case '-':
                        safely(calc.Difference);
                        break;
                    case '*':
                        safely(calc.Product);
                        break;
                    case '/':
                        safely(calc.Quotient);
                        break;
                }
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
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

        private void reset_Click(object sender, EventArgs e)
        {
            calc.Reset();
        }

        private void sum_Click(object sender, EventArgs e)
        {
            safely(calc.Sum);
        }

        private void difference_Click(object sender, EventArgs e)
        {
            safely(calc.Difference);
        }

        private void product_Click(object sender, EventArgs e)
        {
            safely(calc.Product);
        }

        private void quotient_Click(object sender, EventArgs e)
        {
            safely(calc.Quotient);
        }

        private void negate_Click(object sender, EventArgs e)
        {
            safely(calc.Negate);
        }

        private void invert_Click(object sender, EventArgs e)
        {
            safely(calc.Invert);
        }

    }
}
