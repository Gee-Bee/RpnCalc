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
            requireArguments(2);
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
                requireArguments(1, false);
                opdStack.Pop();
            }
            display.Draw();
        }

        public void Reset()
        {
            opdStack.Clear();
            Current = "";
            display.Draw();
        }

        public void Sum()
        {
            requireArguments(2);
            decimal sum = opdStack.Pop().ToNumber() + opdStack.Pop().ToNumber();
            opdStack.Push(new Operand(sum.ToString()));
            display.Draw();
        }

        public void Difference()
        {
            requireArguments(2);
            decimal last = opdStack.Pop().ToNumber();
            decimal previous = opdStack.Pop().ToNumber();
            decimal difference = previous - last;
            opdStack.Push(new Operand(difference.ToString()));
            display.Draw();
        }

        public void Product()
        {
            requireArguments(2);
            decimal product = opdStack.Pop().ToNumber() * opdStack.Pop().ToNumber();
            opdStack.Push(new Operand(product.ToString()));
            display.Draw();
        }

        public void Quotient()
        {
            requireArguments(2);
            decimal last = opdStack.Pop().ToNumber();
            decimal previous = opdStack.Pop().ToNumber();
            decimal quotient = previous / last;
            opdStack.Push(new Operand(quotient.ToString()));
            display.Draw();
        }

        private void requireArguments(int n, bool push = true) {
            if(push) Push();
            if(opdStack.Count < n) throw new ArgumentException("Too few arguments");
        }

    }
}
