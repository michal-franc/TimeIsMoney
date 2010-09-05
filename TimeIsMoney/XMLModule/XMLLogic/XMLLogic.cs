using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;

namespace XMLModule.XMLLogic
{
    public static class XmlLogic
    {
        public static List<Task> ReadXml(string filePath)
        {

            XDocument document = XDocument.Load(filePath);

            var tasks = (from element in document.Descendants("TASK")
                         where element.Parent == document.Root
                         select new Task(element, element.Descendants("TASK").Where(t => t.Parent == element).ToList())).ToList();

            return tasks;
        }

        public static void AddToXml(Task task, string filePath)
        {
            throw new NotImplementedException();
            //XDocument document = XDocument.Load(filePath);

            //XContainer element = document.Root;

            //SetIdAndPos(filePath, task);


            //element.Add(task.CreateXmlElement(0, new XMLToDoListConverter()));
            //document.Save(filePath);
        }

        public static void AddToXml(List<Task> tasks, string filePath)
        {
            XDocument document;
            if (File.Exists(filePath))
            {
                document = XDocument.Load(filePath);
                document.Root.Descendants("TASK").Remove();
            }
            else
            {
                document = new XDocument();
                XElement root = new XElement("TODOLIST");
                root.SetAttributeValue("FILENAME", filePath);
                root.SetAttributeValue("FILEFORMAT", 9);
                root.SetAttributeValue("FILEVERSION", 6);
                root.SetAttributeValue("PROJECTNAME", "");
                document.Add(root);
                throw new NotImplementedException();
            }
            XContainer element = document.Root;

            int idCounter = 1;
            int posCounter = 1;

            foreach (Task t in tasks)
            {
                t.Id = idCounter;
                t.Pos = posCounter;
                element.Add(t.CreateXmlElement(ref idCounter, new XMLToDoListConverter()));

                idCounter++;
            }

            document.Save(filePath);
        }

        /// <summary>
        /// Method used to set the ID and Position of the Task. Tasks in todo list need unique ID and correct Position
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="task"></param>
        private static void SetIdAndPos(string filePath, Task task)
        {
            List<Task> tasks = ReadXml(filePath);
            if (tasks.Count <= 0)
            {
                task.Id = 1;
                task.Pos = 1;
            }
            else
            {
                int id = 0;
                int pos = 0;
                foreach (Task t in tasks)
                {
                    if (t.Id >= id)
                        id = t.Id + 1;
                    if (t.Pos >= pos)
                        pos = t.Pos + 1;
                }
                task.Pos = pos;
                task.Id = id;
            }
        }
    }
}
