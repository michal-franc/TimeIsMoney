﻿using System;
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
    public class Task : INotifyPropertyChanged
    {
        #region Fields

        private const int TaskMaxLength = 18;
        private XElement _base;

        private TimeTodo _timeSpent;

        private string _timeSpentString;
        private string _timeEstimateString;

        #endregion

        #region Properties

        private bool IsButtonHidden = false;
        [NotConverted]
        public string HiddenButton
        {
            get
            {
                if (IsButtonHidden)
                    return "Hidden";
                else
                    return "Visible";
            }
        }

        private string _taskDecoration="";
        [NotConverted]
        public string TaskDecoration
        {
            get
            {
                return _taskDecoration;
            }
            set
            {
                _taskDecoration = value;
                IsButtonHidden = true;
                OnPropertyChanged("TaskDecoration");
                OnPropertyChanged("HiddenButton");
            }
        }

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
                string s = (string)_base.Attribute("TITLE") ?? String.Empty;
                if (s.Length > TaskMaxLength)
                {
                    string newS = s.Substring(0, TaskMaxLength);
                    return newS.Insert(TaskMaxLength-1, "...");
                }
                else
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

        public double DoneDate
        {
            get
            {
                return (_base.Attribute("DONEDATE") == null) ? -1 : (double)_base.Attribute("DONEDATE");
            }
            set
            {
                _base.SetAttributeValue("DONEDATE", value);
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
        public string StartDate
        {
            get
            {
                return (string)_base.Attribute("STARTDATE") ?? String.Empty;
            }
            set
            {
                _base.SetAttributeValue("STARTDATE", value);
            }

        }
        public string StartDateString
        {
            get
            {
                return (string)_base.Attribute("STARTDATESTRING") ?? String.Empty;
            }
            set
            {
                _base.SetAttributeValue("STARTDATESTRING", value);
            }
        }
        public string DueDate
        {
            get
            {
                return (string)_base.Attribute("DUEDATE") ?? String.Empty;
            }
            set
            {
                _base.SetAttributeValue("DUEDATE", value);
            }
        }
        public string DueDateString
        {
            get
            {
                return (string)_base.Attribute("DUEDATESTRING") ?? String.Empty;
            }
            set
            {
                _base.SetAttributeValue("DUEDATESTRING", value);
            }
        }

        public double TimeSpent
        {
            get
            {
                if (TimeSpentInternal == null)
                    return 0;
                else
                {
                    double timeSpent = TimeSpentInternal;

                    _timeSpent = TimeTodo.ConvertTime(timeSpent);
                    TimeSpentUnits = _timeSpent.Type;

                    return _timeSpent.Value;
                }
            }
            set
            {
                TimeSpentInternal = value;
            }
        }
        public string TimeSpentUnits
        {
            get
            {
                return (string)_base.Attribute("TIMESPENTUNITS") ?? String.Empty;

            }
            set
            {
                _base.SetAttributeValue("TIMESPENTUNITS", value);
            }
        }

        public double TimeEstimate
        {
            get
            {
                return (_base.Attribute("TIMEESTIMATE") == null)
                                ? 0
                                : double.Parse(((string)_base.Attribute("TIMEESTIMATE")).Replace(".", ","));
            }
            set
            {
                _base.SetAttributeValue("TIMEESTIMATE", value);
            }
        }
        public string TimeEstUnits
        {
            get
            {
                
                return (string)_base.Attribute("TIMEESTUNITS") ?? String.Empty;
            }
            set
            {
                _base.SetAttributeValue("TIMEESTUNITS", value);
            }
        }

        [NotConverted]
        public string TimeEstimateString
        {
            get
            {
                return TimeTodo.GetString((int)TimeEstimate);
            }
            set { _timeEstimateString = value; }
        }

        public double TimeSpentInternal
        {
            get;
            set;
        }


        [NotConverted]
        public string TimeSpentString
        {
            get
            {
                double timeSpent = 0;
                if (Childrens != null)
                {
                    foreach (Task t in Childrens)
                    {
                        timeSpent += t.TimeSpentInternal;
                    }
                }
                timeSpent += this.TimeSpentInternal;

                return TimeTodo.GetString((int)timeSpent);
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
        public string DoneDateString
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
            TimeSpentInternal = TimeTodo.ConvertToSeconds((_base.Attribute("TIMESPENT") == null)
                                ? 0
                                : double.Parse(((string)_base.Attribute("TIMESPENT"))),TimeSpentUnits);

            if (children != null)
            {
                if (children.Count > 0)
                {
                    List<Task> childrens = new List<Task>();
                    foreach (var xElement in children)
                    {
                        childrens.Add(new Task(xElement, xElement.Descendants("TASK").Where(t => t.Parent == xElement).ToList()));
                    }

                    this.Childrens = childrens.OrderByDescending(x => x.Priority).ToList();
                }
            }
        }
        #endregion


        public override string ToString()
        {
            return this.Title.ToString();
        }

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
            TimeSpentInternal += i;
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}
