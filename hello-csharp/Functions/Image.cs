using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
namespace Functions
{
    public class ImageTest
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


    public static partial class Image
    {
        public static (bool isSuccess, byte[]? resultImage) AddImageOrderT()
        {
            try
            {
                // 在這裡放入添加圖像到訂單的邏輯
                // 這裡只是一個示例，你需要根據實際情況進行修改

                // 假設在這裡有一些處理圖像的邏輯
                // 在這裡放入處理圖像的邏輯
                // 假設你有一個原始圖像的 byte 陣列
                byte[] originalImage = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 };

                // 假設你在這裡對圖像進行了某種處理，這裡只是一個示例
                byte[] processedImage = originalImage; // 這裡只是示例，實際應用中你需要執行實際的圖像處理

                byte[] resultImage = processedImage;

                // 成功添加圖像，返回處理後的圖像
                return (true, resultImage);
            }
            catch (Exception)
            {
                // 在出現異常的情況下，返回失敗和一個空的結果圖像
                return (false, null);
            }
            // throw new NotImplementedException();
        }

        public static (bool isSuccess, byte[]? resultImage) AddImageOrder(this byte[] byteImage)
        {
            double fontScale = 1.0;
            int fontThickness = 1;
            string fontColor = "#0000FF";
            string backgroundColor = "#FFFFFF";
            string position = "bottomLeft";

            try
            {

                byte[] originalImage = byteImage;

                // Do something with the image by configuration
                byte[] processedImage = originalImage;

                byte[] resultImage = processedImage;

                // 成功添加圖像，返回處理後的圖像
                return (true, resultImage);
            }
            catch (Exception)
            {
                // 在出現異常的情況下，返回失敗和一個空的結果圖像
                return (false, null);
            }
        }

        public static (bool isSuccess, byte[]? resultImage) AddPlateNumberBoundingBox(this byte[] byteImage)
        {
            throw new NotImplementedException();
        }

        public static (bool isSuccess, byte[]? resultImage) EnlargePlateNumber(this byte[] byteImage)
        {
            throw new NotImplementedException();
        }
    }


    public class ImageProcessor
    {
        public static void AddTextToImage(string imagePath, string textToAdd)
        {
            // Load the image from the file path
            using (Image image = Image.FromFile(imagePath))
            {
                // Create a Graphics object from the image
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    // Set the font and brush for the text
                    Font font = new Font("Arial", 12, FontStyle.Bold);
                    Brush brush = Brushes.White;

                    // Calculate the size of the text
                    SizeF textSize = graphics.MeasureString(textToAdd, font);

                    // Calculate the position to add the text (bottom-left corner)
                    int x = 10; // You can adjust this value based on your desired position from the left edge
                    int y = image.Height - (int)textSize.Height - 10; // 10 pixels from the bottom edge

                    // Draw the text on the image
                    graphics.DrawString(textToAdd, font, brush, x, y);
                }

                // Save the modified image back to the file
                image.Save(imagePath, ImageFormat.Jpeg); // You can change the format as needed
            }
        }
    }
}