using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using XMLModule.XMLLogic;
using System.Collections.Generic;
using System.ComponentModel;

namespace XMLModule
{
    /// <summary>
    /// Class representing Task
    /// </summary>
    public class Task
    {
        #region Fields


        private double _timeEstimate;
        private double _timeSpent;

        private string _timeSpentUnit;
        private string _timeEstUnit;

        private string _timeSpentString;
        private string _timeEstimateString;

        #endregion

        #region Properties

        public int Id { get; set; }
        public int Pos { get; set; }
        public string Title { get; set; }
        public string LastMod { get; set; }
        public string LastModString { get; set; }
        public int Priority { get; set; }
        public int Risk { get; set; }
        public int PercentDone { get; set; }

        public string StartDate { get; set; }
        public string StartDateString { get; set; }

        public string DueDate { get; set; }
        public string DueDateString { get; set; }

        public double TimeSpent { get { return TimeTodo.ConvertTime((int)_timeSpent).Value; } set { _timeSpent = value; } }
        public string TimeSpentUnits { get { return TimeTodo.ConvertTime((int)_timeSpent).Type; } set { _timeSpentUnit = value; } }

        public double TimeEstimate { get { return TimeTodo.ConvertTime((int)_timeEstimate).Value; } set { _timeEstimate = value; } }
        public string TimeEstUnits { get { return TimeTodo.ConvertTime((int)_timeEstimate).Type; } set { _timeEstUnit = value; } }

        [NotConverted]
        public string TimeEstimateString
        {
            get
            {
                return TimeTodo.GetString((int)_timeEstimate);
            }
            set { _timeEstimateString = value; }
        }

        [NotConverted]
        public string TimeSpentString
        {
            get
            {
                return TimeTodo.GetString((int)_timeSpent);
            }
            set { _timeSpentString = value; }
        }

        public string CreationDate { get; set; }
        public string CreationDateString { get; set; }

        public string CompletedDate { get; set; }
        public string CompletedDateString { get; set; }

        public string PriorityColor { get; set; }
        public string PriorityWebColor { get; set; }
        public string Comments { get; set; }

        [NotConverted]
        public List<Task> Childrens { get; set; }
        #endregion

        #region Ctor

        public Task(string title, int estTime, string estUnit, DateTime dueDate, int priority, string comment)
        {
            this.Title = title;
            this.TimeEstimate = estTime;
            this.TimeEstUnits = estUnit;
            this.DueDateString = dueDate.ToShortDateString();
            this.Priority = priority;
            this.Comments = comment;
            Childrens = new List<Task>();
        }

        /// <summary>
        /// Constructor which creates Task from the XElement    
        /// </summary>
        /// <param name="element"></param>
        public Task(XElement element, List<XElement> children)
        {
            Title = (string)element.Attribute("TITLE") ?? String.Empty;
            Id = (element.Attribute("ID") == null) ? -1 : (int)element.Attribute("ID");
            Pos = (element.Attribute("POS") == null) ? -1 : (int)element.Attribute("POS");
            LastMod = (string)element.Attribute("LASTMOD") ?? String.Empty;
            LastModString = (string)element.Attribute("LASTMODSTRING") ?? String.Empty;
            Priority = (element.Attribute("PRIORITY") == null) ? -1 : (int)element.Attribute("PRIORITY");
            Risk = (element.Attribute("RISK") == null) ? -1 : (int)element.Attribute("RISK");
            PercentDone = (element.Attribute("PERCENTDONE") == null) ? -1 : (int)element.Attribute("PERCENTDONE");
            StartDate = (string)element.Attribute("STARTDATE") ?? String.Empty;
            StartDateString = (string)element.Attribute("STARTDATESTRING") ?? String.Empty;
            DueDate = (string)element.Attribute("DUEDATE") ?? String.Empty;
            DueDateString = (string)element.Attribute("DUEDATESTRING") ?? String.Empty;
            CreationDate = (string)element.Attribute("CREATIONDATE") ?? String.Empty;
            CompletedDateString = (string)element.Attribute("DONEDATESTRING") ?? String.Empty;
            CreationDateString = (string)element.Attribute("CREATIONDATESTRING") ?? String.Empty;
            PriorityColor = (string)element.Attribute("PRIORITYCOLOR") ?? String.Empty;
            PriorityWebColor = (string)element.Attribute("PRIORITYWEBCOLOR") ?? String.Empty;
            Comments = (string)element.Attribute("COMMENTS") ?? String.Empty;

            TimeEstimate = TimeTodo.ConvertToSeconds((element.Attribute("TIMEESTIMATE") == null)
                                ? 0
                                : double.Parse(((string)element.Attribute("TIMEESTIMATE")).Replace(".", ",")),
                                (string)element.Attribute("TIMEESTUNITS") ?? "I");

            TimeSpent = TimeTodo.ConvertToSeconds((element.Attribute("TIMESPENT") == null)
                                ? 0
                                : double.Parse(((string)element.Attribute("TIMESPENT")).Replace(".", ",")),
                                (string)element.Attribute("TIMESPENTUNITS") ?? "I");

            if (children.Count > 0)
            {
                List<Task> childrens = new List<Task>();
                foreach (var xElement in children)
                {
                    childrens.Add(new Task(xElement, xElement.Descendants("TASK").Where(t => t.Parent == xElement).ToList()));
                }
                this.Childrens = childrens;
            }
        }
        #endregion

        /// <summary>
        /// Used to Create XML Object
        /// </summary>
        /// <param name="converter">Converter which defines the object , its attributes etc.</param>
        /// <returns></returns>
        public XElement CreateXmlElement(ref int currentID, IXMLConverter converter)
        {
            XElement xmlElement = converter.CreateXml(this);

            int posCounter = 0;

            if (Childrens != null)
            {
                foreach (var child in Childrens)
                {
                    currentID++;
                    posCounter++;
                    child.Id = currentID;
                    child.Pos = posCounter;
                    xmlElement.Add(child.CreateXmlElement(ref currentID, converter));
                }
            }

            return xmlElement;
        }

        public void IncrementSpent(int i)
        {
            _timeSpent += i;
        }
    }
}
