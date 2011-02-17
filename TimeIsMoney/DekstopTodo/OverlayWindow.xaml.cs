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

namespace DekstopTodo
{
    /// <summary>
    /// Interaction logic for OverlayWindow.xaml
    /// </summary>
    public partial class OverlayWindow : Window
    {
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
            this.Close();
        }
    }
}
