using System;
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

        public MainWindow()
        {

            //XMLModule.XMLLogic.XmlLogic.ReadXml();

            List<TaskWPF> tasks = new List<TaskWPF>()
                                   {
                                       new TaskWPF(new Task(("test1"),10,"I",DateTime.Now,1,"komentarz"){TimeSpent = 0},null),
                                       new TaskWPF(new Task(("test2"),10,"I",DateTime.Now,2,"komentarz"){TimeSpent = 0},null),
                                       new TaskWPF(new Task(("test3"),10,"I",DateTime.Now,3,"komentarz"){TimeSpent = 0},null),
                                       new TaskWPF(new Task(("test4"),10,"I",DateTime.Now,4,"komentarz"){TimeSpent = 0},null)
                                   }.OrderByDescending(x => x.Priority).ToList();


            InitializeComponent();
            tasks[0].Childrens = new List<TaskWPF>()
                                     {
                                             new TaskWPF(new Task("test8",10,"I",DateTime.Now,8,"komentarz"){TimeSpent = 0},tasks[0]),
                                             new TaskWPF(new Task("test1",10,"I",DateTime.Now,1,"komentarz"){TimeSpent = 0},tasks[0])
                                     }.OrderByDescending(x => x.Priority).ToList();

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
