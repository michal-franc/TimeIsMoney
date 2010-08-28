using System;
using System.Collections.ObjectModel;
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
        #region Private

        [NonSerialized]
        private TimeTodo _timeTodo;

        private double _timeEstimate;
        private double _timeSpent;
        private string _timeSpentString;
        private string _timeEstimateString;
        #endregion


        public TimeTodo TimeTodo { get { return _timeTodo; } set { _timeTodo = value; } }


        private string title;
        public string Title { get { return title; } set { title = value; } }
        public int Id { get; set; }
        public int Pos { get; set; }
        public string LastMod { get; set; }
        public string LastModString { get; set; }
        public int Priority { get; set; }
        public int Risk { get; set; }
        public int PercentDone { get; set; }
        public string StartDate { get; set; }
        public string StartDateString { get; set; }
        public string DueDate { get; set; }
        public string DueDateString { get; set; }
        public double TimeSpent { get { return TimeTodo.ConvertTime(_timeSpent, "I"); } set { _timeSpent = value; OnPropertyChanged("TimeSpentString"); } }

        public double TimeEstimate { get { return this.TimeTodo.TimeValue; } set { _timeEstimate = value; } }
        public string TimeEstUnits { get { return this.TimeTodo.TimeType; } }

        public string TimeEstimateString { get { return TimeTodo.GetString((int)TimeEstimate); } set { _timeEstimateString = value; } }
        public string TimeSpentString { get { return TimeTodo.GetString((int)TimeSpent); } set { _timeSpentString = value; } }

        public string CreationDate { get; set; }
        public string CreationDateString { get; set; }

        public string CompletedDate { get; set; }
        public string CompletedDateString { get; set; }

        public string PriorityColor { get; set; }
        public string PriorityWebColor { get; set; }
        // komentarze tez na razie obczaic
        public string Comments { get; set; }

        //Right now without childrens
        public List<Task> Childrens { get; set; }

        public Task()
        {

        }

        public Task(string title, int estTime, string estUnit, DateTime dueDate, int priority, string comment)
        {
            this.Title = title;
            this.TimeTodo = new TimeTodo(estTime, estUnit);
            this.DueDateString = dueDate.ToShortDateString();
            this.Priority = priority;
            this.Comments = comment;
            Childrens = new List<Task>();
        }

        public Task(string title, int estTime, string estUnit, DateTime dueDate, int priority, string comment, List<Task> children)
        {
            this.Title = title;
            this.TimeTodo = new TimeTodo(estTime, estUnit);
            this.DueDateString = dueDate.ToShortDateString();
            this.Priority = priority;
            this.Comments = comment;
            Childrens = children;
        }

        /// <summary>
        /// Constructor which creates Task from the XElement    
        /// </summary>
        /// <param name="element"></param>
        public Task(XElement element)
        {
            Title = (string)element.Attribute("TITLE") == null ? String.Empty : (string)element.Attribute("TITLE");
            Id = (element.Attribute("ID") == null) ? -1 : (int)element.Attribute("ID");
            Pos = (element.Attribute("POS") == null) ? -1 : (int)element.Attribute("POS");
            LastMod = (string)element.Attribute("LASTMOD") == null ? String.Empty : (string)element.Attribute("LASTMOD");
            LastModString = (string)element.Attribute("LASTMODSTRING") == null ? String.Empty : (string)element.Attribute("LASTMODSTRING");
            Priority = (element.Attribute("PRIORITY") == null) ? -1 : (int)element.Attribute("PRIORITY");
            Risk = (element.Attribute("RISK") == null) ? -1 : (int)element.Attribute("RISK");
            PercentDone = (element.Attribute("PERCENTDONE") == null) ? -1 : (int)element.Attribute("PERCENTDONE");
            StartDate = (string)element.Attribute("STARTDATE") == null ? String.Empty : (string)element.Attribute("STARTDATE");
            StartDateString = (string)element.Attribute("STARTDATESTRING") == null ? String.Empty : (string)element.Attribute("STARTDATESTRING");
            DueDate = (string)element.Attribute("DUEDATE") == null ? String.Empty : (string)element.Attribute("DUEDATE");
            DueDateString = (string)element.Attribute("DUEDATESTRING") == null ? String.Empty : (string)element.Attribute("DUEDATESTRING");
            CreationDate = (string)element.Attribute("CREATIONDATE") == null ? String.Empty : (string)element.Attribute("CREATIONDATE");
            CompletedDateString = (string)element.Attribute("DONEDATESTRING") == null ? String.Empty : (string)element.Attribute("DONEDATESTRING");
            CreationDateString = (string)element.Attribute("CREATIONDATESTRING") == null ? String.Empty : (string)element.Attribute("CREATIONDATESTRING");
            PriorityColor = (string)element.Attribute("PRIORITYCOLOR") == null ? String.Empty : (string)element.Attribute("PRIORITYCOLOR");
            PriorityWebColor = (string)element.Attribute("PRIORITYWEBCOLOR") == null ? String.Empty : (string)element.Attribute("PRIORITYWEBCOLOR");
            Comments = (string)element.Attribute("COMMENTS") == null ? String.Empty : (string)element.Attribute("COMMENTS");


            TimeTodo = new TimeTodo(
                ((element.Attribute("TIMEESTIMATE") == null) ? 0 : long.Parse(((string)element.Attribute("TIMEESTIMATE")).Replace(".", ","))),
                ((string)element.Attribute("TIMEESTUNITS") == null ? String.Empty : (string)element.Attribute("TIMEESTUNITS")));
        }

        /// <summary>
        /// Used to Create XML Object
        /// </summary>
        /// <param name="converter">Converter which defines the object , its attributes etc.</param>
        /// <returns></returns>
        public XElement CreateXmlElement(IXMLConverter converter)
        {
            return converter.CreateXml(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event   
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
