using System;
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
        public void EstimatedTimeCheckMinutes()
        {
            List<Task> results = XMLAnalyser.CheckItemsWithLowTime("tests.tdl", 30,"I");
            Assert.IsTrue(results.Count == 1);
        }

        [Test]
        public void EstimatedTimeCheckHours()
        {
            List<Task> results = XMLAnalyser.CheckItemsWithLowTime("tests.tdl", 2, "H");
            Console.WriteLine(results.Count);
            Assert.IsTrue(results.Count == 4);
        }
    

        public static void Main()
        {
        }
    }
}
