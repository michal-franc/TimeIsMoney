using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using XMLModule;

namespace Tests
{
    [TestFixture]
    public class TimeTodoTests
    {
        [Test]
        public void TestTimeTodoToString()
        {
            var testData = new TimeTodo(100, "I");
            Assert.That(testData.ToString(), Is.EqualTo("1m 40s"));
            testData.AddSecond(1);
            Assert.That(testData.ToString(), Is.EqualTo("1m 41s"));
            testData.AddMinute(1);
            Assert.That(testData.ToString(), Is.EqualTo("2m 41s"));
            testData.AddHour(1);
            Assert.That(testData.ToString(), Is.EqualTo("1h 2m 41s"));
            testData.AddDay(1);
            Assert.That(testData.ToString(), Is.EqualTo("1d 1h 2m 41s"));

            var testData1 = new TimeTodo(0, "I");
            Assert.That(testData1.ToString(), Is.EqualTo("0s"));
            testData1.AddDay(2);
            Assert.That(testData1.ToString(), Is.EqualTo("2d 0s"));
            testData1.AddMinute(10);
            Assert.That(testData1.ToString(), Is.EqualTo("2d 10m 0s"));
        }

    }
}
