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

            var book = new PathList();

            Assert.True(false);
        }
    }
}
