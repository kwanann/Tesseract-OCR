using System;
using Tesseract;
using System.IO;

namespace TesseractCaptcha
{
    class Program
    {
        static void Main(string[] args)
        {
            var theImage = "index.png";
            using (var engine = new TesseractEngine(@"./tessdata", "eng_best", EngineMode.Default, "./tessdata/config.txt"))
            {
                using (var img = Pix.LoadFromFile(theImage))
                {
                    using (var page = engine.Process(img))
                    {
                        var text = page.GetText();
                        var conf = page.GetMeanConfidence();

                        Console.WriteLine($"Tesseract is {conf * 100.0:0.00}% confident the text is: {text}");
                    }
                }
            }
        }
    }
}