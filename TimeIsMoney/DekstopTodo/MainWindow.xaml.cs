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
using System.Windows.Navigation;
using System.Windows.Shapes;
using XMLModule;

namespace DekstopTodo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Project> _projects = new List<Project>();
        List<OverlayWindow> _spawnedWindows = new List<OverlayWindow>();

        public List<Project>  Projects
        {
            get
            {
                return _projects;
            }
        }

        public MainWindow()
        {
            InitializeComponent();




            foreach (string path in Settings.Load().ProjectsPath)
            {
                CreateNewProjectWindow(path);
            }
            this.Hide();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            //clean up notifyicon (would otherwise stay open until application finishes)
            NotifyIcon.Dispose();
            Settings set = new Settings();

            foreach (Project proj in _projects)
            {
                set.ProjectsPath.Add(proj.Path);
            }

            set.Save();
            base.OnClosing(e);
        }

        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "TODO List files (*.tdl)|*.tdl";
            dialog.ShowDialog();

            if (dialog.FileName.Contains(".tdl"))
            {

                foreach (Project p in _projects)
                {
                    if (dialog.FileName == p.Path)
                    {
                        MessageBox.Show("Project already added");
                        return;
                    }
                }


                CreateNewProjectWindow(dialog.FileName);
            }

        }

        private void CreateNewProjectWindow(string path)
        {
            if (System.IO.File.Exists(path))
            {
                List<Task> tasks = XMLModule.XMLLogic.XmlLogic.ReadXml(path);
                string projectTitle = path.Remove(path.IndexOf(".")).Substring(path.LastIndexOf("\\")).Replace('\\', ' ');
                Project newProject = new Project(tasks, projectTitle, path);
                _projects.Add(newProject);

                OverlayWindow overlay = new OverlayWindow(newProject,this);

                _spawnedWindows.Add(overlay);
                overlay.Show();
            }
        }

        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            foreach (OverlayWindow win in _spawnedWindows)
            {
                win.Close();
            }
            NotifyIcon.Dispose();
            this.Close();
        }
    }
}
