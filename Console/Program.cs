using System;
using System.Drawing;

namespace Models
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var bmp = new Bitmap(1,1);

            Console.WriteLine("{0}", bmp.Size);
        }
    }
}
