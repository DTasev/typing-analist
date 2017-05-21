using System;
using System.Collections.Generic;
using Analysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnalystTest
{
    [TestClass]
    public class AnalystTest
    {
        private Analyst analyst;

        [TestInitialize]
        public void SetUp()
        {
            analyst = new Analyst(new List<string> { "Test ", "Test3" });
        }

        [TestMethod]
        public void TestInitialise()
        {
            // we expect to be word length - 1
            Assert.AreEqual(new Tuple<int, int>(0, 4), analyst.WordLocation());
        }
    }
}
