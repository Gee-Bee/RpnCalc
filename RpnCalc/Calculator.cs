using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RpnCalc
{
    class Calculator
    {
        public string Current { get; set; }
        private Stack<Operand> opdStack;
        private Display display;

        public Calculator(Label display, int displayWidth)
        {
            this.Current = "";
            this.opdStack = new Stack<Operand>();
            this.display = new Display(this, this.opdStack, display, displayWidth);
            this.display.Draw();
        }

        public void appendNumber(string number)
        {
            Current += number;
            display.Draw();
        }

        public void Push()
        {
            if (Current.Length > 0)
            {
                opdStack.Push(new Operand(Current));
                Current = "";
                display.Draw();
            }
        }

        public void Swap()
        {
            Push();
            if (opdStack.Count < 2) throw new ArgumentException("Too few arguments");
            Operand last = opdStack.Pop();
            Operand previous = opdStack.Pop();
            opdStack.Push(last);
            opdStack.Push(previous);
            display.Draw();
        }

        public void Drop()
        {
            if (Current.Length > 0)
            {
                Current = Current.Substring(0, Current.Length - 1);
            }
            else
            {
                if (opdStack.Count < 1) throw new ArgumentException("Too few arguments");
                opdStack.Pop();
            }
            display.Draw();
        }

    }
}
