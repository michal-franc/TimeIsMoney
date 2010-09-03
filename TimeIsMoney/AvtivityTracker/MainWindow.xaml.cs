﻿using System;
using System.Collections.Generic;
using System.Windows;
using XMLModule;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Threading;
using System.ComponentModel;
using System.Linq;

namespace AvtivityTracker
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread _backgroundWorker;
        public List<TaskWPF> ConvertTaskList(List<Task> tasks)
        {
            List<TaskWPF> wpfTasks = new List<TaskWPF>();
            foreach (var task in tasks)
            {
                wpfTasks.Add(new TaskWPF(task, null));
            }
                
            return wpfTasks;
        }

        public MainWindow()
        {

            List<TaskWPF> tasks = ConvertTaskList(XMLModule.XMLLogic.XmlLogic.ReadXml(@"C:\Users\LaM\Desktop\Praca Dyplomowa\TODO.tdl"));

            InitializeComponent();

            List<Project> projects = new List<Project>() { new Project() { Content = tasks, Title = "Projekt1" }, new Project() { Title = "Projekt2" } };
            MainTabControl.ItemsSource = projects;

        }

        protected void btnStartClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                var template = btn.TemplatedParent as ContentPresenter;
                TaskWPF task = template.Content as TaskWPF;

                if (task.state == TaskState.Stoped)
                {
                    task.ChangeState();
                    if (_backgroundWorker != null)
                        _backgroundWorker.Abort();

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
                    task.ChangeState();
                    _backgroundWorker.Abort();
                }
            }
        }
    }
}
