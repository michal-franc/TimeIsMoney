﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;
using TimeIsMoney.XMLLogic;

namespace TimeIsMoney
{
    /// <summary>
    /// Class representing Task
    /// </summary>
    public class Task
    {
        [NonSerialized]
        private TimeTodo _timeTodo;

        public TimeTodo TimeTodo { get { return _timeTodo; } set { _timeTodo = value;} }

        public string Title { get; set; }
        public int Id { get; set; }
        public int Pos { get; set; }
        public string LastMod { get; set; }
        public string LastModString { get; set; }
        public int Priority { get; set; }
        public int Risk { get; set; }
        public int PercentDone { get; set; }
        public string StartDate{ get; set; }
        public string StartDateString { get; set; }
        public string DueDate { get; set; }
        public string DueDateString { get; set; }

        public double TimeEstimate { get{return this.TimeTodo.TimeEstimate;}}
        public string TimeEstUnits {get{return this.TimeTodo.TimeEstUnits;}}

        public string CreationDate { get; set; }
        public string CreationDateString { get; set; }
        public string PriorityColor { get; set; }
        public string PriorityWebColor { get; set; }
        // komentarze tez na razie obczaic
        public string Comments { get; set; }

        //Right now without childrens
        public List<Task> children { get; set; }

        public Task()
        {

        }

        public Task(string title,int estTime,string estUnit,DateTime dueDate,int priority)
        {
            this.Title = title;
            this.TimeTodo = new TimeTodo(estTime,estUnit);
            this.DueDateString = dueDate.ToShortDateString();
            this.Priority = priority;
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
            CreationDateString = (string)element.Attribute("CREATIONDATESTRING") == null ? String.Empty : (string)element.Attribute("CREATIONDATESTRING");
            PriorityColor = (string)element.Attribute("PRIORITYCOLOR") == null ? String.Empty : (string)element.Attribute("PRIORITYCOLOR");
            PriorityWebColor = (string)element.Attribute("PRIORITYWEBCOLOR") == null ? String.Empty : (string)element.Attribute("PRIORITYWEBCOLOR");
            Comments = (string)element.Attribute("COMMENTS") == null ? String.Empty : (string)element.Attribute("COMMENTS");


            TimeTodo = new TimeTodo(
                ((element.Attribute("TIMEESTIMATE") == null) ? 0 : Double.Parse(((string)element.Attribute("TIMEESTIMATE")).Replace(".",","))),
                ((string)element.Attribute("TIMEESTUNITS") == null ? String.Empty : (string)element.Attribute("TIMEESTUNITS")));
        }

        /// <summary>
        /// Used to Create XML Object
        /// </summary>
        /// <param name="converter">Converter which defines the object , its attributes etc.</param>
        /// <returns></returns>
        public XElement CreateXmlElement(IXMLConverter converter)
        {
            return converter.CreateXML(this);
        }
    }
}
