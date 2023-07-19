// See https://aka.ms/new-console-template for more information

using SkiaSharp;

Console.WriteLine("Hello, World!");

/// code 中 有 用到 ILogger? log = null
/// public static (bool isSuccess, byte[]? resultImage) AddTextOnEventImage(this byte[] byteImage, IEnumerable<string> lines, ILogger? log = null, float fontRatio = 40f, string fontBrush = "ffff00", string font = "mingliu", string backgroundColor = "000000")

(bool isSuccess, byte[]? resultImage) AddTextOnEventImage(byte[] byteImage, IEnumerable<string> lines, float fontRatio = 40f, string fontBrush = "ffff00", string font = "mingliu", string backgroundColor = "000000")
{
    try
    {
        SKBitmap input = SKBitmap.Decode(byteImage);

        /// 取得原始圖片長寬
        var height = input.Height;
        var width = input.Width;


        /// font size 40F 配上  寬 1917 X 高 1083 image  為 之前 POC 案的   字體 跟圖片的比例
        /// 這邊讓 之後進來的每張圖片 字體站圖片比例 跟 POC 案一樣
        /// 如果 lines 中每一行文字，都不會超出圖片寬度，就會使用 tmpFontSize 作為字體大小
        /// 如果超出圖片寬度，會自動縮小
        /// 
        /// 選 height 的原因是，想讓 海苔條高度 跟 整張圖高度的比例固定
        float tmpFontSize = fontRatio * (height / 1083.0F);




        /// 選字體(要去 C://Windows/Fonts 找 可用字體)
        /// 設定需不需要粗體斜體底線
        var typeFace = SKTypeface.FromFamilyName(font, SKFontStyle.Normal);

        // Create an SKPaint object to display the text
        SKPaint textPaint = new(new SKFont(typeFace))
        {
            // Color = SKColors.Yellow,
            Color = SKColor.Parse(fontBrush),
            TextSize = tmpFontSize,
        };


        /// 判斷是否要再縮小字體
        bool needShrink = false;
        float shrinkRaitio = 1.0F;

        /// 這邊座自動縮小字體
        foreach (string tmp in lines)
        {
            SKRect textBound = new();
            textPaint.MeasureText(tmp, ref textBound);

            //Console.WriteLine(textBound.Width);
            //Console.WriteLine(textBound.Height);

            if (textBound.Width > width)
            {
                needShrink = true;
                // 0.9 的目的不要 縮太剛好，到時候有可能 會切到字 或是 觸發自動換行
                shrinkRaitio = Math.Min(shrinkRaitio, width / textBound.Width * 0.99F);
            }
        }

        if (needShrink)
        {
            //Console.WriteLine(shrinkRaitio);
            textPaint.TextSize = tmpFontSize * shrinkRaitio;
        }

        /// 避免縮太小 看不見，文字看不見
        if (textPaint.TextSize <= 10)
        {
            textPaint.TextSize = 10;
        }

        List<string> str_output = new() { };

        /// offset 為 海苔條 的高度
        int offset = 0;
        List<int> offsetArr = new();




        /// 以防萬一還是留 原本 自動換行的 code，不過理論上因為上面有做自動縮小字體，理論上不會觸發自動換行
        /// 如果有文字才   印海苔條
        if (lines.Any())
        {

            SKRect textBounds = new();


            for (int i = 0; i < lines.Count(); i++)
            {

                string str_input = lines.ElementAt(i);
                string str_tmp = str_input;

                // 取得該行 字變成圖片時的  行高 行寬
                textPaint.MeasureText(str_tmp, ref textBounds);
                int idx = (int)textPaint.BreakText(str_tmp, width);

                // 如果 文字超出圖片寬度 就會進 while 迴圈，觸發自動換行
                while (idx < str_tmp.Length && str_tmp.Length > 0)
                {
                    /// 剪下跟圖片寬度一樣長的 文字
                    str_output = str_output.Append(str_tmp[..idx]).ToList();


                    /// 紀錄這次剪下的文字  使 海苔條變高完後的高度  及 y 座標圖片寬度一樣長的 文字
                    offset += (int)(textBounds.Height);
                    offsetArr.Add(offset);



                    /// 剩下的文字
                    str_tmp = str_tmp[(idx)..];
                    /// 計算剩下文字的圖片  高度 以及 寬度
                    textPaint.MeasureText(str_tmp, ref textBounds);
                    idx = (int)textPaint.BreakText(str_tmp, width);
                }

                str_output = str_output.Append(str_tmp[..idx]).ToList();
                offset += (int)(textBounds.Height);
                offsetArr.Add(offset);

                /// 讓海苔條可以多一點點，如果少會有自跑到圖片的可能性，不可以少
                offset += (int)Math.Ceiling(textBounds.Height * 0.333);
            }

        }


        SKBitmap black_bg = new(width, height + offset);
        SKCanvas canvas = new(black_bg);

        SKColor bgColor = SKColor.Parse(backgroundColor);
        canvas.Clear(bgColor);
        canvas.DrawBitmap(input, 0.0F, offset);


        /// xText  每行字的圖片左下角的點  在  canvas 的 X 座標  (右為 正方向)
        /// yText  每行字的圖片左下角的點  在  canvas 的 Y 座標  (下為 正方向)
        float xText = 0;
        //float yText = 0;

        // And draw the text
        for (int i = 0; i < str_output.Count; i++)
        {
            //Console.WriteLine(str_output[i]);
            //// 座標定位在 text 左下角座標
            canvas.DrawText(str_output[i], xText, offsetArr.ElementAt(i), textPaint);
        }

        /// 寫檔案
        int quality = 128;

        /// 取得 byte array data
        byte[] dataOutput = black_bg.Encode(SKEncodedImageFormat.Png, quality).ToArray();

        return (true, dataOutput);

    }
    catch (Exception ex)
    {
        /// return null
        return (false, null);
    }
}


bool ByteArrayToFile(string fileName, byte[] byteArray)
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


byte[] byteImage = File.ReadAllBytes(imageFilePath_input);


IEnumerable<string> list = new List<string>();

list = list.Append(firstText);
list = list.Append(secondText);

//(var _, var outputImage) = AddTextOnEventImage(byteImage, list);
(var _, var outputImage) = AddTextOnEventImage(byteImage, list);

ByteArrayToFile(imageFilePath_output, outputImage);