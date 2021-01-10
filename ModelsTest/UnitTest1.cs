using System;
using Xunit;
using Xunit.Abstractions;

using ImgViewer.Models;

namespace ImgViewer.ModelsTest
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test1()
        {
            const string path = @".\data\data.zip";
            
            IBook book = BookMaker.Create(path);
            output.WriteLine("{0} Page:{1}", book.GetParent(), book.Count());

            Assert.True(true);
        }
        [Fact]
        public void Test2()
        {
            const string path = @"C:\Users\asagao\Documents\vm\新しいフォルダー (11)\02マネージャ.zip";
            
            IBook book = new BookShelf(path);
            output.WriteLine("Parent:{0} Page:{1} Name:{2}", book.GetParent(), book.Count(), book.GetName());
            foreach(var x in book.GetEntries())
            {
                output.WriteLine("{0}", x);
            }
            Assert.True(false);
        }
        [Fact]
        public void Test3()
        {
            //const string path = @"H:\Pictures\inzip\202009181047.zip";
            const string path = @"H:\Pictures\202004301613.PNG";

            IBook book = BookMaker.Create(path);
            output.WriteLine("Parent:{0} Page:{1} Name:{2}", book.GetParent(), book.Count(), book.GetName());
            book = new BookShelf(path);
            output.WriteLine("Parent:{0} Page:{1} Name:{2}", book.GetParent(), book.Count(), book.GetName());


            Assert.True(false);

        }
    }
}
