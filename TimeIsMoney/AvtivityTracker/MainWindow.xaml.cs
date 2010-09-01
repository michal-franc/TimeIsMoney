using System;
using System.Collections.Generic;
using System.Windows;
using XMLModule;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Threading;
using System.ComponentModel;

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


            List<TaskWPF> tasks = new List<TaskWPF>()
                                   {
                                       new TaskWPF(new Task(("test"),10,"I",DateTime.Now,8,"komentarz"){TimeSpent = 0}),
                                       new TaskWPF(new Task(("test"),10,"I",DateTime.Now,8,"komentarz"){TimeSpent = 0}),
                                       new TaskWPF(new Task(("test"),10,"I",DateTime.Now,8,"komentarz"){TimeSpent = 0}),
                                       new TaskWPF(new Task(("test"),10,"I",DateTime.Now,8,"komentarz"){TimeSpent = 0})
                                   };


            InitializeComponent();
            tasks[0].Childrens = new List<TaskWPF>()
                                     {
                                             new TaskWPF(new Task("test",10,"I",DateTime.Now,8,"komentarz"){TimeSpent = 0})
                                     };

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

                if (btn.Content.ToString() == "Start")
                {
                    btn.Content = "Stop";

                    if (_backgroundWorker != null)
                        _backgroundWorker.Abort();

                    _backgroundWorker = new Thread(delegate()
                    {
                        while (true)
                        {
                            task.Increment();
                            if (task.IsOverEstimatedTime)
                            { }

                            Thread.Sleep(TimeSpan.FromSeconds(1));

                        }
                    });
                    _backgroundWorker.Start();
                }
                else
                {
                    btn.Content = "Start";
                    _backgroundWorker.Abort();
                }
            }
        }
    }
}
