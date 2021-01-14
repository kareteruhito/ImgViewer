using Xunit;
using Xunit.Abstractions;
using Models;
using System.Collections.Generic;

namespace Test
{
    public class IndexListTest
    {
        private readonly ITestOutputHelper output;
        public IndexListTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void SimpleConstructTest()
        {
            var indexList = new IndexList();

            output.WriteLine("{0}", nameof(indexList));
            Assert.True(indexList != null);
            Assert.True(indexList is IndexList);
        }

        [Fact]
        public void IteratorTest()
        {
            var indexList = new IndexList();

            indexList.Add("A");

            var t = new List<string>();
            t.Add("B");
            t.Add("C");
            indexList.AddRange(t);

            var str1 = "";
            foreach(var x in indexList.Entries)
            {
                str1 = str1 + x;
            }

            var str2 = "";
            if (indexList.Any())
            {
                indexList.MoveFirst();
                do {
                    str2 = str2 + indexList.Value;
                } while (indexList.MoveNext());
            }

            output.WriteLine("str1:{0} str2:{1}", str1, str2);
            Assert.True(str1 == str2);
        }
    }
}
