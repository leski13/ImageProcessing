using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessing
{
    public class ImageExample
    {
        public static string[] GetImagesWords()
        {
            List<string> w = new List<string>();

            using(ImageParser ip = new ImageParser(@"C:\emgu\bin\testdata", "eng"))
            {
                if (ip.OcrImage(@"D:\ФОТКИ\телега\235137262_188332.jpg") != string.Empty)
                    w.AddRange(ip?.Words.ToList<string>());
            }
            return w.ToArray();
        }
    }
}
