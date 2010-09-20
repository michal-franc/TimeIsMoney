using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class XMLLogicTests
    {
        private static XElement testElement;
        [TestFixtureSetUp]
        public void SetUp()
        {
            testElement = new XElement("TASK");
            testElement.SetAttributeValue("ID", 1);
            testElement.SetAttributeValue("POS", 1);
            testElement.SetAttributeValue("TITLE", "test");
            testElement.SetAttributeValue("TIMEESTIMATE", 10);
            testElement.SetAttributeValue("TIMESPENT", 10);
        }

        [Test]
        public void TestReading1Element()
        {
            XMLModule.Task task = new XMLModule.Task(testElement, null);
            Assert.That(task.Id, Is.EqualTo(1));
            Assert.That(task.Position, Is.EqualTo(1));
            Assert.That(task.Title, Is.EqualTo("test"));
            Assert.That(task.TimeEstimate, Is.EqualTo(10));
            Assert.That(task.TimeSpent, Is.EqualTo(10));
        }
        //Test Ladowania
        //TEst Zapisywania
        //Testy ugenerycznione by pozniej moc wladowac inny converter
        //Testy dla convertera Todo list
        // Rozne testy symulujace uszkodzone dane i zle formatyq
    }
}
