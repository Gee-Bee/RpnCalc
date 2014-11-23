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

        public void Add()
        {
            requireArguments(2);
            double sum = opdStack.Pop().ToNumber() + opdStack.Pop().ToNumber();
            opdStack.Push(new Operand(sum));
            display.Draw();
        }

        public void Subtract()
        {
            requireArguments(2);
            double last = opdStack.Pop().ToNumber();
            double previous = opdStack.Pop().ToNumber();
            double difference = previous - last;
            opdStack.Push(new Operand(difference));
            display.Draw();
        }

        public void Multiply()
        {
            requireArguments(2);
            double product = opdStack.Pop().ToNumber() * opdStack.Pop().ToNumber();
            opdStack.Push(new Operand(product));
            display.Draw();
        }

        public void Divide()
        {
            requireArguments(2);
            double last = opdStack.Pop().ToNumber();
            double previous = opdStack.Pop().ToNumber();
            double quotient = previous / last;
            opdStack.Push(new Operand(quotient));
            display.Draw();
        }

        public void Negate()
        {
            requireArguments(1);
            double negated = 0 - opdStack.Pop().ToNumber();
            opdStack.Push(new Operand(negated));
            display.Draw();
        }

        public void Invert()
        {
            requireArguments(1);
            double inverted = 1 / opdStack.Pop().ToNumber();
            opdStack.Push(new Operand(inverted));
            display.Draw();
        }

        public void DateAdd()
        {
            requireArguments(2);
            double days = opdStack.Pop().ToNumber();
            DateTime dateTime = opdStack.Pop().ToDateTime();
            dateTime = dateTime.AddDays(days);
            opdStack.Push(new Operand(dateTime));
            display.Draw();
        }

        public void DateSubtract()
        {
            requireArguments(2);
            DateTime last = opdStack.Pop().ToDateTime();
            DateTime previous = opdStack.Pop().ToDateTime();
            opdStack.Push(new Operand(previous.Subtract(last)));
            display.Draw();
        }

        private void requireArguments(int n, bool push = true) {
            if(push) Push();
            if(opdStack.Count < n) throw new ArgumentException("Too few arguments");
        }

    }
}
