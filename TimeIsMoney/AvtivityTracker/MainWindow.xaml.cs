using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Win32;
using XMLModule;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Threading;
using System.ComponentModel;
using System.Linq;

namespace ActivityTracker
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields

        private Thread _backgroundWorker;
        private TaskWpf _currentTask;
        private List<Project> projects = new List<Project>();

        #endregion

        #region Ctor

        public MainWindow()
        {
            InitializeComponent();

            //Todo logic to load saved projects
            //MainTabControl.ItemsSource = projects;
        }

        #endregion

        #region Events
        protected void btnStartClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                var template = btn.TemplatedParent as ContentPresenter;
                TaskWpf task = template.Content as TaskWpf;

                if (task.State == TaskState.Stoped)
                {

                    if (_backgroundWorker != null)
                    {
                        _backgroundWorker.Abort();
                        if (_currentTask.State == TaskState.Started)
                        {
                            _currentTask.ToogleState();
                        }
                    }

                    _currentTask = task;
                    task.ToogleState();

                    _backgroundWorker = new Thread(delegate()
                    {
                        while (true)
                        {
                            task.Increment();
                            Thread.Sleep(TimeSpan.FromSeconds(1));

                        }
                    });
                    _backgroundWorker.Start();
                }
                else
                {
                    task.ToogleState();
                    _backgroundWorker.Abort();
                }
            }
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
        }

        protected void AddProjectClick(object sender, EventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();

            if (dialog.FileName.Contains(".tdl"))
            {
                List<Task> tasks = XMLModule.XMLLogic.XmlLogic.ReadXml(dialog.FileName);
                string projectTitle = dialog.FileName.Remove(dialog.FileName.IndexOf(".")).Substring(dialog.FileName.LastIndexOf("\\")).Replace('\\', ' ');
                Project newProject = new Project(tasks, projectTitle, dialog.FileName);

                projects.Add(newProject);

                MainTabControl.ItemsSource = null;
                MainTabControl.ItemsSource = projects;

            }
        }

        protected void RemoveProjectClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                var tabItem = btn.TemplatedParent as TabItem;
                if (tabItem != null)
                {
                    Project project = tabItem.Content as Project;
                    if (project != null)
                    {
                        project.SaveProject();
                        projects.Remove(project);
                        MainTabControl.ItemsSource = null;
                        MainTabControl.ItemsSource = projects;
                    }
                }
            }
        }
        #endregion


    }
}
