using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int x = 1;
            int y = 1;

            Assert.AreEqual(x, y);
        }


        [TestMethod]
        public void TestMethod2()
        {
            int x = 1;
            int y = 2;

            Assert.AreEqual(x, y);
        }

    }
}
