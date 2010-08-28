using System;
using System.Collections.Generic;
using NUnit.Framework;
using XMLModule;

namespace Tests
{
    [TestFixture]
    public class XmlAnalyserTests
    {
        private static readonly List<Task> TestData = new List<Task>()
                                                  {
                                                      new Task("test",3,"H",new DateTime(2010,1,1),5,"")
                                                          {
                                                              Comments="",
                                                              CreationDateString = new DateTime(2010,8,14).ToShortDateString(),
                                                              LastModString = new DateTime(2010,8,14).ToShortDateString(),
                                                              PercentDone = 100,Risk = 1,Priority = 1,
                                                              CompletedDateString = new DateTime(2010,8,12).ToShortDateString()
                                                          },
                                                      new Task("test",0,"H",new DateTime(2010,1,1),5,"")
                                                      {
                                                          Comments="Tak",
                                                          CreationDateString = new DateTime(2010,8,14).ToShortDateString(),
                                                              LastModString = new DateTime(2010,8,14).ToShortDateString(),
                                                              PercentDone = 0,Risk = 3,Priority = 5,
                                                              CompletedDateString = new DateTime(2010,8,8).ToShortDateString()
                                                      },
                                                      new Task("test",30,"I",new DateTime(2010,8,14),5,"")
                                                          {
                                                              Comments="Bardzoodasodsoadosad dlugi komentarz",
                                                              CreationDateString = new DateTime(2010,8,14).ToShortDateString(),
                                                              LastModString = new DateTime(2010,8,10).ToShortDateString(),
                                                              PercentDone = 30,Risk = 6,Priority = 9,
                                                              CompletedDateString = new DateTime(2010,8,11).ToShortDateString()
                                                          },
                                                      new Task("test",15,"I",new DateTime(2010,8,13),5,"")
                                                          {
                                                              Comments="jakis tam testowy komentarz",
                                                              CreationDateString = new DateTime(2010,8,10).ToShortDateString(),
                                                              LastModString = new DateTime(2010,8,10).ToShortDateString(),
                                                              PercentDone = 50,Risk = 2,Priority = 4,
                                                              CompletedDateString = new DateTime(2010,8,10).ToShortDateString()
                                                          },
                                                      new Task("test",10,"I",new DateTime(2010,8,16),5,"")
                                                          {
                                                              Comments="",
                                                              CreationDateString = new DateTime(2010,8,10).ToShortDateString(),
                                                              LastModString = new DateTime(2010,8,10).ToShortDateString(),
                                                              PercentDone = 60,Risk = 4,Priority = 3,
                                                              CompletedDateString = new DateTime(2010,8,10).ToShortDateString()
                                                          },
                                                  };
        [Test]
        public void TestGetCompletedByDay()
        {
            var results = ReportModule.ReportEngine.GetCompletedTasksPerDay(TestData);
            Assert.IsTrue((results.Count == 5));
            Assert.That(results, Contains.Item(new KeyValuePair<DateTime, int>(new DateTime(2010, 8, 8), 1)));
            Assert.That(results, Contains.Item(new KeyValuePair<DateTime, int>(new DateTime(2010, 8, 9), 0)));
            Assert.That(results, Contains.Item(new KeyValuePair<DateTime, int>(new DateTime(2010, 8, 10), 2)));
            Assert.That(results, Contains.Item(new KeyValuePair<DateTime, int>(new DateTime(2010, 8, 11), 1)));
            Assert.That(results, Contains.Item(new KeyValuePair<DateTime, int>(new DateTime(2010, 8, 12), 1)));

        }



        [Test]
        public void TestPriority()
        {
            var results = XmlAnalyser.GetItemsWithPrioryty(TestData, new Func<Task , bool >(t => t.Priority > 5));
            if(results !=null)
                Assert.IsTrue((results.Count==1));

            results = XmlAnalyser.GetItemsWithPrioryty(TestData, new Func<Task, bool>(t => t.Priority >=9));
            if (results != null)
                Assert.IsTrue((results.Count == 1));

            results = XmlAnalyser.GetItemsWithPrioryty(TestData, new Func<Task, bool>(t => t.Priority <3));
            if (results != null)
                Assert.IsTrue((results.Count == 1));
        }

        [Test]
        public void NoComments()
        {
            var results = XmlAnalyser.GetItemsWithNoComments(TestData);
            if(results !=null)
                Assert.IsTrue(results.Count==2);
        }

        [Test]
        public void HasComments()
        {
            var results = XmlAnalyser.GetItemsWithComments(TestData);
            if (results != null)
                Assert.IsTrue(results.Count == 3);
        }
        
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
