using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using NUnit.Framework;

namespace LegalServiceTest
{
    [TestFixture]
    public class MyTests
    {
        [Test, TestCaseSource(typeof(MyDataClass), "TestCases1")]
        public int DivideTest(int n, int d)
        {
            return n / d;
        }
    }

    public class MyDataClass
    {
        public static IEnumerable TestCases1
        {
            get
            {
                yield return new TestCaseData(12, 3).Returns(4);
                yield return new TestCaseData(12, 2).Returns(3);
                yield return new TestCaseData(12, 4).Returns(3);
            }
        }
    }
}
