using System.Collections.Generic;
using NUnit.Framework;
using TimeIsMoney;
using TimeIsMoney.Notification;

namespace XMLModule
{
    [TestFixture]
    public class XMLAnalyserTests
    {   

        [Test]
        public void EstimatedTimeCheck()
        {
            List<Task> results = XMLAnalyser.CheckItemsWithLowTime("tests.tdl", 30);
            Assert.IsTrue(results.Count == 1);
        }
    

        public static void Main()
        {
        }
    }
}
