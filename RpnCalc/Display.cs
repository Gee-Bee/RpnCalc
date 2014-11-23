using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RpnCalc
{
    class Display
    {
        private Calculator calc;
        private Stack<Operand> opdStack;
        private Label displayLabel;
        private readonly int width;
        private readonly int displayStackEl;

        public Display(Calculator calc, Stack<Operand> opdStack, Label displayLabel, int width)
        {
            this.calc = calc;
            this.opdStack = opdStack;
            this.displayLabel = displayLabel;
            this.width = width;
            this.displayStackEl = 4;
        }

        public void Draw()
        {
            bool currentElEmpty = calc.Current == "";
            string text = "";
            for (int i = displayStackEl; i > 0; i--)
            {
                if (i == 1)
                    text += currentElEmpty ? line("L1:", getFromStack(1)) : line("E:", calc.Current);
                else
                    text += line("L" + i + ":", getFromStack(currentElEmpty ? i : i - 1)); 
            }
            displayLabel.Text = text;
        }

        private string line(string caption, string content, bool last = false)
        {
            int totalLength = caption.Length + content.Length;
            if (totalLength > width)
                content = "..." + content.Substring(totalLength - width + "...".Length);
            return caption + content.PadLeft(width - caption.Length, ' ') + "\r\n";
        }

        private string getFromStack(int n)
        {
            return opdStack.Count >= n ? opdStack.ElementAt(n-1).Text : "";
        }
    }
}
