using System;
using System.Collections.Generic;
using NUnit.Framework;
using TimeIsMoney;
using TimeIsMoney.Notification;
using XMLModule;

namespace Tests
{
    [TestFixture]
    public class XmlAnalyserTests
    {
        private static readonly List<Task> TestData = new List<Task>()
                                                  {
                                                      new Task("test",3,"H",new DateTime(2010,1,1),5,""),
                                                      new Task("test",0,"H",new DateTime(2010,1,1),5,""),
                                                      new Task("test",30,"I",new DateTime(2010,8,14),5,""),
                                                      new Task("test",15,"I",new DateTime(2010,8,13),5,""),
                                                      new Task("test",10,"I",new DateTime(2010,8,16),5,""),
                                                  };
        
         [Test]
        public void LowEstimatedTimeCheckMinutes()
        {
            var results = XmlAnalyser.GetItemsWithLowEstTime(TestData, 30, "I");
            if (results != null) 
                Assert.IsTrue(results.Count == 4);
        }

        [Test]
        public void LowEstimatedTimeCheckHours()
        {
            var results = XmlAnalyser.GetItemsWithLowEstTime(TestData, 2, "H");
            if (results != null) 
                Assert.IsTrue(results.Count == 4);
        }

        [Test]
        public void NoEstimatedTimeCheckHours()
        {
            var results = XmlAnalyser.GetItemsWithLowEstTime(TestData, 0, "I");
            if (results != null) 
                Assert.IsTrue(results.Count==1);
        }

        [Test]
        public void LowDueDateTest()
        {
            var results = XmlAnalyser.GetItemsWithLowDueDate(TestData, new DateTime(2010, 8, 13), TimeSpan.FromDays(1));
            if (results != null) 
                Assert.IsTrue(results.Count ==4);
        }

        [Test]
        public void NoDueDateTest()
        {
            var results = XmlAnalyser.GetItemsWithNoDueDate(TestData);
            if (results != null) 
                Assert.IsTrue(results.Count == 0);
        }

        public static void Main()
        {

        }
    }
}
