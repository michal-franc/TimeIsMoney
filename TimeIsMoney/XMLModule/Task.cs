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

        private XElement _base;

        private double _timeEstimate;
        private double _timeSpent;

        private string _timeSpentUnit;
        private string _timeEstUnit;

        private string _timeSpentString;
        private string _timeEstimateString;

        #endregion

        #region Properties

        public int Id
        {
            get
            {
                return (_base.Attribute("ID") == null) ? -1 : (int)_base.Attribute("ID");
            }
            set
            {
                _base.SetAttributeValue("ID", value);
            }
        }
        public int Position
        {
            get
            {
                return (_base.Attribute("POS") == null) ? -1 : (int)_base.Attribute("POS");
            }
            set
            {
                _base.SetAttributeValue("POS", value);
            }
        }
        public string Title
        {
            get
            {
                return (string)_base.Attribute("TITLE") ?? String.Empty;
            }
            set
            {
                _base.SetAttributeValue("TITLE", value);
            }
        }
        public string LastMod
        {
            get
            {
                return (string)_base.Attribute("LASTMOD") ?? String.Empty;
            }
            set
            {
                _base.SetAttributeValue("LASTMOD", value);
            }
        }
        public string LastModString
        {
            get
            {
                return (string)_base.Attribute("LASTMODSTRING") ?? String.Empty;
            }
            set
            {
                _base.SetAttributeValue("LASTMODSTRING", value);
            }
        }
        public int Priority
        {
            get
            {
                return (_base.Attribute("PRIORITY") == null) ? -1 : (int)_base.Attribute("PRIORITY");
            }
            set
            {
                _base.SetAttributeValue("PRIORITY", value);
            }
        }
        public int Risk
        {
            get
            {
                return (_base.Attribute("RISK") == null) ? -1 : (int)_base.Attribute("RISK");
            }
            set
            {
                _base.SetAttributeValue("RISK", value);
            }
        }
        public int PercentDone
        {
            get
            {
                return (_base.Attribute("PERCENTDONE") == null) ? -1 : (int)_base.Attribute("PERCENTDONE");
            }
            set
            {
                _base.SetAttributeValue("PERCENTDONE", value);
            }
        }

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

        public string CreationDate
        {
            get
            {
                return (string)_base.Attribute("CREATIONDATE") ?? String.Empty;
            }
            set
            {
                _base.SetAttributeValue("CREATIONDATE", value);
            }
        }
        public string CreationDateString
        {
            get
            {
                return (string)_base.Attribute("CREATIONDATESTRING") ?? String.Empty;

            }
            set
            {
                _base.SetAttributeValue("CREATIONDATESTRING", value);
            }
        }

        public string CompletedDate { get; set; }
        public string CompletedDateString
        {
            get
            {
                return (string)_base.Attribute("DONEDATESTRING") ?? String.Empty;
            }

            set
            {
                _base.SetAttributeValue("DONEDATESTRING", value);
            }
        }

        public string PriorityColor
        {
            get
            {
                return (string)_base.Attribute("PRIORITYCOLOR") ?? String.Empty;
            }
            set
            {
                _base.SetAttributeValue("PRIORITYCOLOR", value);
            }
        }
        public string PriorityWebColor
        {
            get
            {
                return (string)_base.Attribute("PRIORITYWEBCOLOR") ?? String.Empty;
            }
            set
            {
                _base.SetAttributeValue("PRIORITYWEBCOLOR", value);
            }
        }
        public string Comments
        {
            get
            {
                return (string)_base.Attribute("COMMENTS") ?? String.Empty;
            }
            set
            {
                _base.SetAttributeValue("COMMENTS", value);
            }
        }

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

            _base = element;
            StartDate = (string)element.Attribute("STARTDATE") ?? String.Empty;
            StartDateString = (string)element.Attribute("STARTDATESTRING") ?? String.Empty;
            DueDate = (string)element.Attribute("DUEDATE") ?? String.Empty;
            DueDateString = (string)element.Attribute("DUEDATESTRING") ?? String.Empty;

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
                    child.Position = posCounter;
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
