using System;

namespace Functions
{
    public class Image
    {
        public static int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        public static int Subtract(int a, int b, int c)
        {
            return a - b - c;
        }

        public static int Multiply(int a, int b, int c)
        {
            return a * b * c;
        }

        public static int Divide(int a, int b, int c)
        {
            if (b == 0 || c == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }
            return a / b / c;
        }
    }
}