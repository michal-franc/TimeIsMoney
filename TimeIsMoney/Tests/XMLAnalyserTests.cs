using System;
using System.Collections.Generic;
using NUnit.Framework;
using TimeIsMoney;
using TimeIsMoney.Notification;

namespace Tests
{
    [TestFixture]
    public class XmlAnalyserTests
    {
        private static List<Task> _testData = new List<Task>();
        
         [Test]
        public void LowEstimatedTimeCheckMinutes()
        {
            var results = XmlAnalyser.GetItemsWithLowEstTime("tests.tdl", 30, "I");
            if (results != null) 
                Assert.IsTrue(results.Count == 4);
        }

        [Test]
        public void LowEstimatedTimeCheckHours()
        {
            var results = XmlAnalyser.GetItemsWithLowEstTime("tests.tdl", 2, "H");
            if (results != null) 
                Assert.IsTrue(results.Count == 7);
        }

        [Test]
        public void NoEstimatedTimeCheckHours()
        {
            var results = XmlAnalyser.GetItemsWithLowEstTime("tests.tdl", 0, "I");
            if (results != null) 
                Assert.IsTrue(results.Count==3);
        }

        [Test]
        public void LowDueDateTest()
        {
            var results = XmlAnalyser.GetItemsWithLowDueDate("tests.tdl", new DateTime(2010, 8, 13), TimeSpan.FromDays(1));
            if (results != null) 
                Assert.IsTrue(results.Count ==1);
        }

        [Test]
        public void NoDueDateTest()
        {
            var results = XmlAnalyser.GetItemsWithNoDueDate("tests.tdl");
            if (results != null) 
                Assert.IsTrue(results.Count == 7);
        }

        [Test]
        public void GetItemsCount()
        {
            var result = XmlAnalyser.GetItemsCount("tests.tdl");
            Assert.IsTrue(result==8);
        }
        public static void Main()
        {

        }
    }
}
