using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using XMLModule;

namespace DekstopTodo
{
    /// <summary>
    /// Interaction logic for OverlayWindow.xaml
    /// </summary>
    public partial class OverlayWindow : Window
    {

        private List<Task> _tasks = new List<Task>();

        public string Path { get; set; }

        public Object ParentWindow { get; set; }
        public List<Task> Tasks 
        {
            get
            {
                return _tasks;
            }
            set
            {
                _tasks = value;
            }
        }

        public OverlayWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void txtBlockProjectName_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (mainGrid.IsVisible)
                mainGrid.Visibility = System.Windows.Visibility.Hidden;
            else
                mainGrid.Visibility = System.Windows.Visibility.Visible;
        }

        private void txtClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow parent = this.ParentWindow as MainWindow;
            if (parent != null)
            {
                parent.Projects.Remove(parent.Projects.Where(x => x.Path == Path).First());
            }
            this.Close();
        }

        private void txtWeek_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.mainTree.ItemsSource = null;
            this.mainTree.ItemsSource = Tasks.Where(
                x => !String.IsNullOrWhiteSpace(x.DueDateString)
                    && DateTime.Parse(x.DueDateString).Date <= DateTime.Now.Date.AddDays(7)
                    ).Select(x => x);
        }

        private void txtDay_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.mainTree.ItemsSource = null;
            this.mainTree.ItemsSource = Tasks.Where(
                x => !String.IsNullOrWhiteSpace(x.DueDateString) 
                    && DateTime.Parse(x.DueDateString).Date <= DateTime.Now.Date
                    ).Select(x => x);
        }

        private void txtAll_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.mainTree.ItemsSource = null;
            this.mainTree.ItemsSource = Tasks;
        }
    }
}
