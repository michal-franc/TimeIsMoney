using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;

namespace XMLModule.XMLLogic
{
    /// <summary>
    /// Static class used for Xml Operations
    /// </summary>
    public static class XmlLogic
    {
        /// <summary>
        /// Return the List of Task read from the Xml list
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<Task> ReadXml(string filePath)
        {
            XDocument document = XDocument.Load(filePath);

            var tasks = (from element in document.Descendants("TASK")
                         where element.Parent == document.Root
                         select new Task(element, element.Descendants("TASK").Where(t => t.Parent == element).ToList())).ToList();

            return tasks;
        }

        /// <summary>
        /// Adds single Task to the Xml File
        /// </summary>
        /// <param name="task"></param>
        /// <param name="filePath"></param>
        public static void AddToXml(Task task, string filePath)
        {
            throw new NotImplementedException();
            //XDocument document = XDocument.Load(filePath);

            //XContainer element = document.Root;

            //SetIdAndPos(filePath, task);


            //element.Add(task.CreateXmlElement(0, new XMLToDoListConverter()));
            //document.Save(filePath);
        }

        /// <summary>
        /// Creates new Todo List file with specified tasks
        /// </summary>
        /// <param name="tasks"></param>
        /// <param name="filePath"></param>
        public static void AddToXml(List<Task> tasks, string filePath)
        {
            XDocument document;
            if (File.Exists(filePath))
            {
                document = XDocument.Load(filePath);
                //Clear Xml File
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

                throw new NotImplementedException();
            }

            if (document != null)
            {
                XContainer element = document.Root;

                int idCounter = 0;
                int posCounter = 0;

                foreach (Task t in tasks)
                {
                    t.Id = ++idCounter;
                    t.Position = ++posCounter;
                    element.Add(t.CreateXmlElement(ref idCounter, new XMLToDoListConverter()));
                }

                document.Save(filePath);
            }
            else
            {
                //Todo Loger  
                throw new NotImplementedException();
            }
        }
    }
}
