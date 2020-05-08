using System;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;

namespace ImageProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = ImageExample.GetImagesWords();
            foreach (var s in x)
            Console.Write(s);
                
        }
    }
}
