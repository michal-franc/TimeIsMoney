using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XMLModule;

namespace DekstopTodo
{
    public class Project
    {
        #region Properties

        public string Title { get; set; }
        public string Path { get; set; }
        public List<Task> Tasks { get; set; }

        #endregion


        #region Ctor

        public Project(List<Task> tasks, string title, string path)
        {
            Tasks = tasks;
            this.Title = title;
            this.Path = path;
        }

        #endregion


        /// <summary>
        /// Saves the project on project Path
        /// </summary>
        public void SaveProject()
        {
            XMLModule.XMLLogic.XmlLogic.AddToXml(Tasks, Path);
        }
    }
}
