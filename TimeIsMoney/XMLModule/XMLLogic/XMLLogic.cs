using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XMLModule.XMLLogic
{
    public  static class XmlLogic
    {
        public static List<Task> ReadXml(string filePath)
        {

            XDocument document = XDocument.Load(filePath);

            var tasks = (from element in document.Descendants("TASK")
                            select new Task(element)).ToList();

            return tasks;
        }

        public  static void AddToXml(Task task, string filePath)
        {
            XDocument document = XDocument.Load(filePath);

            XContainer element=  document.Root;

            SetIdAndPos(filePath,task);


            element.Add(task.CreateXmlElement(new XMLToDoListConverter()));
            document.Save(filePath);
        }

        public static void AddToXml(List<Task> tasks, string filePath)
        {
            XDocument document = XDocument.Load(filePath);
            XContainer element = document.Root;

            document.Root.Descendants("TASK").Remove();
            
            foreach (Task t in tasks)
            {
                SetIdAndPos(filePath, t);

                element.Add(t.CreateXmlElement(new XMLToDoListConverter()));
            }

            document.Save(filePath);
        }

        /// <summary>
        /// Method used to set the ID and Position of the Task. Tasks in todo list need unique ID and correct Position
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="task"></param>
        private static void SetIdAndPos(string filePath,Task task)
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
                        id = t.Id+1;
                    if (t.Pos >= pos)
                        pos = t.Pos+1;
                }
                task.Pos = pos;
                task.Id = id;
            }
        }
    }
}
