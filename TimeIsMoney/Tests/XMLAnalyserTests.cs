using System;
using NUnit.Framework;
using TimeIsMoney.Notification;

namespace Tests
{
    [TestFixture]
    public class XmlAnalyserTests
    {   

        [Test]
        public void LowEstimatedTimeCheckMinutes()
        {
            var results = XmlAnalyser.GetItemsWithLowEstTime("tests.tdl", 30, "I");
            Assert.IsTrue(results.Count == 4);
        }

        [Test]
        public void LowEstimatedTimeCheckHours()
        {
            var results = XmlAnalyser.GetItemsWithLowEstTime("tests.tdl", 2, "H");
            Console.WriteLine(results.Count);
            Assert.IsTrue(results.Count == 7);
        }
        [Test]
        public void NoEstimatedTimeCheckHours()
        {
            var results = XmlAnalyser.GetItemsWithLowEstTime("tests.tdl", 0, "I");
            Assert.IsTrue(results.Count==3);
        }

        [Test]
        public void LowDueDateTest()
        {
            var results = XmlAnalyser.GetItemsWithLowDueDate("tests.tdl", new DateTime(2010, 8, 13), TimeSpan.FromDays(1));
                  
            Assert.IsTrue(results.Count ==1);
        }
        [Test]
        public void NoDueDateTest()
        {
            var results = XmlAnalyser.GetItemsWithNoDueDate("tests.tdl");

            Assert.IsTrue(results.Count == 1);
        
        }


        public static void Main()
        {

        }
    }
}
