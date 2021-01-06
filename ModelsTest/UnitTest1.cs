using System;
using Xunit;
using Xunit.Abstractions;

using Models;

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
    }
}
