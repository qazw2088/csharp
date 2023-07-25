using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;

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
            // ExtensionMethods.UseCalculator();
            // ExtensionMethods.UseImage();
            ExtensionMethods.UseAddImageOrderT();
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
            Console.WriteLine("a + b + c = {0}", ImageTest.Add(a, b, c));
            Console.WriteLine("a - b - c = {0}", ImageTest.Subtract(a, b, c));
            Console.WriteLine("a * b * c = {0}", ImageTest.Multiply(a, b, c));
            Console.WriteLine("a / b / c = {0}", ImageTest.Divide(a, b, c));
        }

        public static void UseAddImageOrderT()
        {
            // Cht Logo Byte
            byte[] chtImage = File.ReadAllBytes(@"D:\Github\csharp\hello-csharp\cht_logo.jpg");

            // 使用函數
            (bool isSuccess, byte[]? resultImage) = Image.AddImageOrder(chtImage);

            // 現在可以根據 isSuccess 的值來判斷是否成功添加了圖像
            if (isSuccess)
            {
                // 成功添加圖像，這裡可以使用 resultImage 來處理處理後的圖像
                Console.WriteLine("圖像添加成功！");
                if (resultImage != null)
                {
                    // 這裡假設你要將處理後的圖像保存到檔案
                    File.WriteAllBytes("processed_image.jpg", chtImage);
                }
            }
            else
            {
                // 圖像添加失敗，你可以根據需要進行錯誤處理
                Console.WriteLine("圖像添加失敗。");
            }
        }
    }
}
