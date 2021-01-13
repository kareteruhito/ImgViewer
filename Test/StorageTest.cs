using System.Xml.Linq;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Security.AccessControl;
using System.IO.IsolatedStorage;
using System.Data.SqlTypes;
using System;
using Microsoft.VisualBasic;
using Xunit;
using Xunit.Abstractions;
using System.Collections.Generic;
using System.Linq;
using Models;


namespace Test
{
    public class StorageTest
    {
        private readonly ITestOutputHelper output;
        public StorageTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void EmptyDir()
        {
            var path = @"H:\csharp\dotnet5\ImgViewer\data\empy";
            var files = Storage.GetEntriesFromDir(path);

            Assert.False(files.Any());
        }
        [Fact]
        public void DirType()
        {
            var path = @"H:\csharp\dotnet5\ImgViewer\data";
            var files = Storage.GetEntriesFromDir(path);

            Assert.True(files.Any());
            Assert.True(files.Count == 1);

            var str = "";
            foreach(var x in files)
            {
                str = str + x;
            }
            output.WriteLine("{0}", str);
            Assert.True(str == @"H:\csharp\dotnet5\ImgViewer\data\1.png");
        }
        [Fact]
        public void DirType2()
        {
            var path = @"H:\csharp\dotnet5\ImgViewer\data\data";
            var files = Storage.GetEntriesFromDir(path);

            Assert.True(files.Any());
            Assert.True(files.Count == 2);

            var str = "";
            foreach(var x in files)
            {
                str = str + x;
            }
            output.WriteLine("{0}", str);
            Assert.True(str == @"H:\csharp\dotnet5\ImgViewer\data\data\2.pngH:\csharp\dotnet5\ImgViewer\data\data\3.png");
        }
        [Fact]
        public void ZipType()
        {
            var path = @"H:\csharp\dotnet5\ImgViewer\data\data2.zip";
            var files = Storage.GetEntriesFromZip(path);

            Assert.True(files.Any());
            Assert.True(files.Count == 3);

            var str = "";
            foreach(var x in files)
            {
                str = str + x;
            }
            output.WriteLine("{0}", str);
            Assert.True(str == @"4.png5.png6.png");
        }
        [Fact]
        public void GetBookEntriesTest()
        {
            var path = @"H:\csharp\dotnet5\ImgViewer\data";
            var files = Storage.GetBookEntries(path);

            Assert.True(files.Any());
            Assert.True(files.Count == 3);

            var str = "";
            foreach(var x in files)
            {
                str = str + x;
            }
            output.WriteLine("{0}", str);
            Assert.True(str == @"H:\csharp\dotnet5\ImgViewer\dataH:\csharp\dotnet5\ImgViewer\data\dataH:\csharp\dotnet5\ImgViewer\data\data2.zip");
        }
    }
}
