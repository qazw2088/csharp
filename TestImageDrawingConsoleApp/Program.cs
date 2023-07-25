using SkiaSharp;
using IVAS.Domain.Extension;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;
using System.Drawing;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

static bool ByteArrayToFile(string fileName, byte[] byteArray)
{
    try
    {
        using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
        {
            fs.Write(byteArray, 0, byteArray.Length);
            return true;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Exception caught in process: {0}", ex);
        return false;
    }
}

string firstText = "時間：2022年06月21日 09時25分19秒 地點：template2測試路口1234567890abcdefghijklmnopqrstuvwxyz1234567890abcdefghijklmnopqrstuvwxyz1234567890abcdefghijklmnopqrstuvwxyz";
string secondText = "車牌：889-JEP";

string imageFilePath_input = @"C:\Users\user\Desktop\input1.png";
string imageFilePath_output = @"C:\Users\user\Desktop\output1.png";

//string imageFilePath_input = @"C:\Users\Tony\Postman\files\exampleInput2.jpg";
//string imageFilePath_output = @"C:\Users\Tony\Desktop\output2.png";

//string imageFilePath_input = @"C:\Users\Tony\Postman\files\exampleInput3.png";
//string imageFilePath_output = @"C:\Users\Tony\Desktop\output3.png";

//string imageFilePath_input = @"C:\Users\Tony\Postman\files\exampleInput4.jpg";
//string imageFilePath_output = @"C:\Users\Tony\Desktop\output4.png";

byte[] byteImage  = File.ReadAllBytes(@"D:\Github\csharp\hello-csharp\cht_logo.jpg");
//byte[] byteImage1 = File.ReadAllBytes(@"C:\Users\user\Desktop\input\input1.png");
//byte[] byteImage2 = File.ReadAllBytes(@"C:\Users\user\Desktop\input\input2.png");
//byte[] byteImage3 = File.ReadAllBytes(@"C:\Users\user\Desktop\input\input3.png");
//byte[] byteImage4 = File.ReadAllBytes(@"C:\Users\user\Desktop\input\input4.png");
//byte[] byteImage5 = File.ReadAllBytes(@"C:\Users\user\Desktop\input\input5.png");
//byte[] byteImage6 = File.ReadAllBytes(@"C:\Users\user\Desktop\input\input6.png");
//byte[] byteImage7 = File.ReadAllBytes(@"C:\Users\user\Desktop\input\input7.png");
//byte[] byteImage8 = File.ReadAllBytes(@"C:\Users\user\Desktop\input\input8.png");
//byte[] byteImage9 = File.ReadAllBytes(@"C:\Users\user\Desktop\input\input9.png");


IEnumerable<string> list = new List<string>();

list = list.Append(firstText);
list = list.Append(secondText);

//(var _, var outputImage) = AddTextOnEventImage(byteImage, list);
// (var _, var outputImage) = ImageExtension.AddTextOnEventImage(byteImage, list);
// (var _, var outputImage) = byteImage.AddTextOnEventImage(list);

//var aBunchOfArr = new[] { byteImage, byteImage, byteImage, byteImage, byteImage, byteImage, byteImage, byteImage, byteImage, byteImage };
//var aBunchOfArr = new[] { byteImage, byteImage, byteImage, byteImage, byteImage };
//Dictionary<string, byte[]> myDictionary = new ()
//{
//    { "i0", byteImage },
//    { "i1", byteImage1 },
//    { "i2", byteImage2 },
//    { "i3", byteImage3 },
//    { "i4", byteImage4 },
//    { "i5", byteImage5 },
//    { "i6", byteImage6 },
//    { "i7", byteImage7 },
//    { "i8", byteImage8 },
//    { "i9", byteImage9 }
//};
//IEnumerable<IEnumerable<string>> orderarray = new List<List<string>>
//{
//    new List<string> { "i2", "i1", "i4" },
//    new List<string> { "i4", "i0", "i5" },
//    new List<string> { "i7", "i9"},
//};

//(var _, var outputImage) = ImageExtension.Combine(aBunchOfArr, "i1,i2,i3;i4,i5,i6", 2048, 1024);
//(var _, var outputImage) = ImageExtension.Combine(myDictionary, orderarray);
//(var _, var outputImage) = ImageExtension.Resize(byteImage, 2048, 2048);

//(var _, var outputImage) = ImageExtension.AddImageOrder(byteImage);

var text = new List<string> { "my test text 2" };
(var _, var outputImage) = ImageExtension.AddTextOnEventImage(byteImage, text);

ByteArrayToFile(imageFilePath_output, outputImage);
