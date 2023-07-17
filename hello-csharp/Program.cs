using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hello_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.Read();
            Person  p = new Person();
            p.Name = "John";
            p.Age = 25;
        }
        
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        
    }
}
