using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.Util;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ImageProcessing
{
    class ImageParser : IDisposable
    {
        public Tesseract OcrEngine { get; set; }
        public string[] Words { get; set; }
        
        public void Dispose() { }

        public ImageParser(string dataPath, string lang)
        {
            OcrEngine = new Tesseract(dataPath, lang, OcrEngineMode.TesseractCubeCombined);
        }

        public string OcrImage(string img)
        {
            string res = string.Empty;
            List<string> wrds = new List<string>();

            if (File.Exists(img))
            {
                using(Image<Bgr, byte> s = new Image<Bgr, byte>(img))
                {
                    if (OcrEngine != null)
                    {
                        OcrEngine.Recognize(s);
                        res = OcrEngine.GetText().TrimEnd();

                        wrds.AddRange(res.Split(new string[] { " ", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList());
                        this.Words = wrds?.ToArray();
                    }
                }
            }
            return res;
        }
    }
}
