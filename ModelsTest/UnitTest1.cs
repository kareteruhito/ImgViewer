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
            string path = @".\dummy.txt";
            var sw = ViewModeSwitcher.Create(path);

            var mode = sw.CurrentMode();
            var modeName = "SingleView";

            output.WriteLine("{0}", mode.GetClassName());
            Assert.True(mode.GetClassName() == modeName);

            output.WriteLine("{0}", mode.GetPath());
            Assert.True(mode.GetPath() == path);

            path = @".\Foobar.txt";
            mode.SetPath(path);

            modeName = "DualView";
            mode = sw.ChangeMode(modeName);

            output.WriteLine("{0}", mode.GetClassName());
            Assert.True(mode.GetClassName() == modeName);

            output.WriteLine("{0}", mode.GetPath());
            Assert.True(mode.GetPath() == path);            

        }
        [Fact]
        public void Test2()
        {
            output.WriteLine("{0}", typeof(SingleView).Name);
            Assert.True(typeof(SingleView).Name == nameof(SingleView));

        }
        [Fact]
        public void Test3()
        {
            const string path = @".\dummy.txt";
            var sw = ViewModeSwitcher.Create(path);
            foreach (var className in sw.GetClassName())
            {
                output.WriteLine("{0}:{1}", className, sw.GetLabel(className));
            }
            Assert.True(true);
        }
        [Fact]
        public void Test4()
        {
            const string path = @"C:\Users\PC01114\Pictures";

            var book = new Book();
            book.Path = path;
            output.WriteLine("{0}", book.Path);

            Assert.True(book.Path == path);

            Assert.False(book.Any());

            Assert.True(book.Count == 0);

            Assert.False(book.IsLast());
            Assert.False(book.IsFirst());
            Assert.False(book.MoveNext());
            Assert.False(book.MovePrevious());
            Assert.True(book.FileName == "");
        }
    }
}
