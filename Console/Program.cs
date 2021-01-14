using System;
using System.Drawing;

namespace Models
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var bookShelf = new BookShelf(@"H:\csharp\dotnet5\ImgViewer\data\data2.zip");

            if (bookShelf.Any())
            {
                Console.WriteLine("current:{0}", bookShelf.Value);
                Console.WriteLine("----");
                foreach(var v in bookShelf.Entries)
                {
                    Console.WriteLine("{0}", v);
                }
            }
        }
    }
}
