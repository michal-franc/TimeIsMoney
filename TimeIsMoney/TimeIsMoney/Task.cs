using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using TimeIsMoney.XMLLogic;

namespace TimeIsMoney
{
    /// <summary>
    /// Class representing Task
    /// </summary>
    public class Task
    {
        public string Title { get; set; }
        public int ID { get; set; }
        public int Pos { get; set; }
        public string LastMod { get; set; }
        public string LastModString { get; set; }
        public int Priority { get; set; }
        public int Risk { get; set; }
        public int PercentDone { get; set; }
        public string StartDate{ get; set; }
        public string StartDateString { get; set; }
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


        /// <summary>
        /// Constructor which creates Task from the XElement
        /// </summary>
        /// <param name="element"></param>
        public Task(XElement element)
        {
            Title = (string)element.Attribute("TITLE") == null ? String.Empty : (string)element.Attribute("TITLE");
            ID = (int)element.Attribute("ID") == null ? -1 : (int)element.Attribute("ID");
            Pos = (int)element.Attribute("POS") == null ? -1 : (int)element.Attribute("POS");
            LastMod = (string)element.Attribute("LASTMOD") == null ? String.Empty : (string)element.Attribute("LASTMOD");
            LastModString = (string)element.Attribute("LASTMODSTRING") == null ? String.Empty : (string)element.Attribute("LASTMODSTRING");
            Priority = (int)element.Attribute("PRIORITY") == null ? -1 : (int)element.Attribute("PRIORITY");
            Risk = (int)element.Attribute("RISK") == null ? -1 : (int)element.Attribute("RISK");
            PercentDone = (int)element.Attribute("PERCENTDONE") == null ? -1 : (int)element.Attribute("PERCENTDONE");
            StartDate = (string)element.Attribute("STARTDATE") == null ? String.Empty : (string)element.Attribute("STARTDATE");
            StartDateString = (string)element.Attribute("STARTDATESTRING") == null ? String.Empty : (string)element.Attribute("STARTDATESTRING");
            CreationDate = (string)element.Attribute("CREATIONDATE") == null ? String.Empty : (string)element.Attribute("CREATIONDATE");
            CreationDateString = (string)element.Attribute("CREATIONDATESTRING") == null ? String.Empty : (string)element.Attribute("CREATIONDATESTRING");
            PriorityColor = (string)element.Attribute("PRIORITYCOLOR") == null ? String.Empty : (string)element.Attribute("PRIORITYCOLOR");
            PriorityWebColor = (string)element.Attribute("PRIORITYWEBCOLOR") == null ? String.Empty : (string)element.Attribute("PRIORITYWEBCOLOR");
            Comments = (string)element.Attribute("COMMENTS") == null ? String.Empty : (string)element.Attribute("COMMENTS");
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
