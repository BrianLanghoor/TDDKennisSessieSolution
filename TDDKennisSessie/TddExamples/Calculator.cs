using System;

namespace TDDKennisSessie.TddExamples
{
    public class Calculator
    {
        public int Add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public int Subtract(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }

        public int Multiply(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }

        public double Divide(double firstNumber, double secondNumber)
        {
            if (secondNumber == 0)
            {
                throw new ArgumentOutOfRangeException("Cannot divide by zero");
            }
            return firstNumber / secondNumber;
        }
    }
}