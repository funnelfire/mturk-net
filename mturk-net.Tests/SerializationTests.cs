using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MTurk.Tests
{
    public class SerializationTests
    {
        [Fact]
        public void Scalar()
        {
            var obj = 5;
            var col = TurkSerializer.Internals.Collect(obj);
            Assert.Equal(col[""], "5");
        }

        [Fact]
        public void Null()
        {
            var col = TurkSerializer.Internals.Collect(null);
            Assert.Equal(0, col.Count);
        }

        [Fact]
        public void Vanilla_Object()
        {
            var obj = new { A = 1, B = "2", C = 3.5 };
            var col = TurkSerializer.Internals.Collect(obj);
            Assert.Equal(col["A"], "1");
            Assert.Equal(col["B"], "2");
            Assert.Equal(col["C"], "3.5");
        }

        [Fact]
        public void Object_With_Null()
        {
            var obj = new { A = 1, B = (string)null, C = 3.5 };
            var col = TurkSerializer.Internals.Collect(obj);
            Assert.Equal(col["A"], "1");
            Assert.False(col.AllKeys.Contains("B"));
            Assert.Equal(col["C"], "3.5");
        }

        [Fact]
        public void Object_With_Array()
        {
            var obj = new { A = 1, B = new[] { "2", "4", "6" }, C = 3.5 };
            var col = TurkSerializer.Internals.Collect(obj);
            Assert.Equal(col["A"], "1");
            Assert.Equal(col["B.1"], "2");
            Assert.Equal(col["B.2"], "4");
            Assert.Equal(col["B.3"], "6");
            Assert.Equal(col["C"], "3.5");
        }

        [Fact]
        public void Object_With_Collection()
        {
            var obj = new { A = 1, B = new List<string> { "2", "4", "6" }, C = 3.5 };
            var col = TurkSerializer.Internals.Collect(obj);
            Assert.Equal(col["A"], "1");
            Assert.Equal(col["B.1"], "2");
            Assert.Equal(col["B.2"], "4");
            Assert.Equal(col["B.3"], "6");
            Assert.Equal(col["C"], "3.5");
        }

        [Fact]
        public void Object_With_Array_Of_Object()
        {
            var obj = new { A = 1, B = new[] { new { X = 10 } } };
            var col = TurkSerializer.Internals.Collect(obj);
            Assert.Equal(col["A"], "1");
            Assert.Equal(col["B.1.X"], "10");
        }
    }
}
