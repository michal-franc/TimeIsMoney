using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using Visifire.Charts;
using XMLModule;

namespace ReportModule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Task> tasks=  XMLModule.XMLLogic.XmlLogic.ReadXml(@"C:\Users\LaM\Desktop\TimeIsMoney\todoTimeIsMoney.tdl");
            MainList.ItemsSource = tasks;

            DataSeries serie = new DataSeries();
            serie.RenderAs = RenderAs.Column;


            Dictionary<DateTime, int> days = ReportEngine.GetCompletedTasksPerDay(tasks);


            foreach (KeyValuePair<DateTime, int> day in days)
            {
                serie.DataPoints.Add(new DataPoint() { XValue = day.Key, YValue = day.Value });
            }

            PlotChart.Series.Add(serie);
        }
    }
}
