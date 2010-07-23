using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace TimeIsMoney.XMLLogic
{
    public  static class XMLLogic
    {
        public static List<Task> ReadXML(string filePath)
        {
            XDocument document = XDocument.Load(filePath);

            var tasks   =  (from element in document.Descendants("TASK")
                            select new Task(element)).ToList();

            return tasks;
        }

        internal static void AddToXml(Task task, string filePath)
        {
            XDocument document = XDocument.Load(filePath);

            XContainer element=  document.Root;

            SetIdAndPos(filePath,task);


            element.Add(task.CreateXmlElement(new XMLToDoListConverter()));
            document.Save(filePath);
        }

        private static void SetIdAndPos(string filePath,Task task)
        {
            List<Task> tasks = ReadXML(filePath);
            if (tasks.Count <= 0)
            {
                task.ID = 1;
                task.Pos = 1;
            }
            else
            {
                int id = 0;
                int pos = 0;
                foreach (Task t in tasks)
                {
                    if (t.ID > id)
                        id = t.ID;
                    if (t.Pos > pos)
                        pos = t.Pos;
                }
            }

        }
    }
}
