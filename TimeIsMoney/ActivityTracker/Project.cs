using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XMLModule;

namespace ActivityTracker
{
    public class Project
    {
        #region Fields

        private List<Task> _tasks;

        #endregion

        #region Properties

        public string Title { get; set; }
        public string Path { get; set; }
        public List<TaskWpf> Content { get; set; }

        #endregion

        #region Ctor

        public Project(List<Task> tasks, string title, string path)
        {
            _tasks = tasks;
            this.Content = ConvertTaskList(tasks);
            this.Title = title;
            this.Path = path;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Saves the project on project Path
        /// </summary>
        public void SaveProject()
        {
            XMLModule.XMLLogic.XmlLogic.AddToXml(_tasks, Path);
        }

        public void DeleteTask(TaskWpf task)
        {
            if (this.Content.Contains(task))
            {
                this.Content.Remove(task);
            }
            else
            {
                foreach (TaskWpf t in Content)
                {
                    t.Delete(task);
                }
            }

        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Method which Converts Task to TaskWpf
        /// </summary>
        /// <param name="tasks">List of tasks to be Converted</param>
        /// <returns></returns>
        private static List<TaskWpf> ConvertTaskList(List<Task> tasks)
        {
            List<TaskWpf> wpfTasks = new List<TaskWpf>();
            foreach (var task in tasks)
            {
                wpfTasks.Add(new TaskWpf(task, null));
            }

            return wpfTasks;
        }
        #endregion

    }

}
