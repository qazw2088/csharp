using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 引用Functions資料夾內的函數
using Functions;

namespace hello_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Person p = new Person();
            p.Name = "John";
            p.Age = 25;
            Console.WriteLine("Name: {0}, Age: {1}", p.Name, p.Age);
            string foo = "123";
            int i = foo.ToInt();
            Console.WriteLine(i);
            ExtensionMethods.UseCalculator();
            ExtensionMethods.UseImage();
            Console.ReadKey();
        }

    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }

    public static class ExtensionMethods
    {
        public static int ToInt(this string value)
        {
            Console.WriteLine("This is value i: {0}", value);
            return Convert.ToInt32(value);
        }

        // Generate a function could merge two lists
        public static List<T> MergeTwoList<T>(this List<T> list1, List<T> list2)
        {
            List<T> result = new List<T>();
            result.AddRange(list1);
            result.AddRange(list2);
            return result;
        }

        public static void UseCalculator()
        {
            int a = 10;
            int b = 20;
            Console.WriteLine("a + b = {0}", Calculator.Add(a, b));
            Console.WriteLine("a - b = {0}", Calculator.Subtract(a, b));
            Console.WriteLine("a * b = {0}", Calculator.Multiply(a, b));
            Console.WriteLine("a / b = {0}", Calculator.Divide(a, b));
        }

        public static void UseImage()
        {
            int a = 100;
            int b = 2;
            int c = 5;
            Console.WriteLine("a + b + c = {0}", Image.Add(a, b, c));
            Console.WriteLine("a - b - c = {0}", Image.Subtract(a, b, c));
            Console.WriteLine("a * b * c = {0}", Image.Multiply(a, b, c));
            Console.WriteLine("a / b / c = {0}", Image.Divide(a, b, c));
        }
    }
}
