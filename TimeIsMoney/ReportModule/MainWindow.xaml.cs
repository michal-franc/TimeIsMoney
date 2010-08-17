using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
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
            List<Task> tasks=  XMLModule.XMLLogic.XmlLogic.ReadXml("Koszyk.tdl");
            MainList.ItemsSource = tasks;
        }
    }
}
