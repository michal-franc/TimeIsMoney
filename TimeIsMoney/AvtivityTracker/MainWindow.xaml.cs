using System;
using System.Collections.Generic;
using System.Windows;
using XMLModule;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Threading;

namespace AvtivityTracker
{
    public class Project
    {
        public string Title { get; set; }
        public List<Task> Content { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TextBlock globalTimeSpent;
        Timer timer = new Timer();

        public MainWindow()
        {


            List<Task> tasks = new List<Task>()
                                   {
                                       new Task("test",10,"I",DateTime.Now,8,"komentarz"){TimeSpent = "0"},
                                       new Task("test",10,"I",DateTime.Now,8,"komentarz"){TimeSpent = "0"},
                                       new Task("test",10,"I",DateTime.Now,8,"komentarz"){TimeSpent = "0"},
                                       new Task("test",10,"I",DateTime.Now,8,"komentarz"){TimeSpent = "0"}
                                   };


            InitializeComponent();
            tasks[0].Childrens = new List<Task>()
                                     {
                                            new Task("test",10,"I",DateTime.Now,8,"komentarz"){TimeSpent = "0"}
                                     };

            List<Project> projects = new List<Project>() { new Project() { Content = tasks, Title = "Projekt1" }, new Project() { Title = "Projekt2" } };
            MainTabControl.ItemsSource = projects;

        }

        protected void btnStartClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                Grid grid = btn.Parent as Grid;
                if (grid != null)
                {
                    globalTimeSpent = grid.FindName("TimeSpent") as TextBlock;
                }

                if (btn.Content.ToString() == "Start")
                {
                    btn.Content = "Stop";
                    timer.Interval = 1000;
                    timer.Elapsed += TimerElapsed;
                    timer.Start();
                }
                else
                {
                    btn.Content = "Start";
                    timer.Stop();
                    //Save i logika zapisywania
                }
            }
        }

        protected void TimerElapsed(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
            {
                int i = Int32.Parse(globalTimeSpent.Text);
                globalTimeSpent.Text = (++i).ToString();
            }));
        }
    }
}
