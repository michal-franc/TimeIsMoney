using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace TimeIsMoney
{
    public partial class Form1 : Form , INotified
    {
        private ListBox listSelector = new ListBox()
        {
            Size = new System.Drawing.Size(100, 100),
        };

        globalKeyboardHook gkh = new globalKeyboardHook();
        EditMessageBox box = new EditMessageBox();
        public List<Task> unsortedTasks = new List<Task>();
        public Settings set;

        public Form1()
        {
            InitializeComponent();

            set = Settings.Load();

            //
            //listSelector
            //
            this.Controls.Add(listSelector);
            listSelector.DataSource = set.Lists;
            listSelector.DisplayMember = "Name";
            listSelector.SelectedIndexChanged += new EventHandler(list_SelectedIndexChanged);

            listBoxTasks.DisplayMember = "Title";

            this.buttonListBox.SetData(set.Lists);

            foreach(Task task in XMLLogic.XMLLogic.ReadXML(set.BinPath))
            {
                unsortedTasks.Add(task);
            }

            listBoxTasks.DataSource = unsortedTasks;
            listBoxTasks.SelectedIndexChanged += new System.EventHandler(this.listBoxTasks_SelectedIndexChanged);


            box.Deactivate += new EventHandler(EditMessageBoxClosed);

            gkh.HookedKeys.Add(Keys.B);
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);

            Reminder.Run(this, set.RemindTime);
            Reminder.RemindWholeDay = set.RemindWholeDay;
        }

        void gkh_KeyUp(object sender, KeyEventArgs e)
        {

        }



        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddToBin((Task)listBoxTasks.SelectedItem, ((TaskBin)listSelector.SelectedItem).Address);
            listSelector.Hide();
        }

        private void AddToBin(Task task, string filePath)
        {
            XMLLogic.XMLLogic.AddToXml(task, filePath);
            unsortedTasks.RemoveAt(listBoxTasks.SelectedIndex);
            listBoxTasks.eReloadDataSource();
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        void EditMessageBoxClosed(object sender, EventArgs e)
        {
            if (box.textBoxData.Text.Length > 0)
            {
                unsortedTasks.Add(new Task(box.textBoxData.Text));
                XMLLogic.XMLLogic.AddToXml(unsortedTasks, set.BinPath);
                listBoxTasks.eReloadDataSource();
            }
        }

        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            CustomKeyEventArgs custom = e as CustomKeyEventArgs;
            if (custom.isCtrl && custom.isAlt)
            {
                box.textBoxData.Clear();
                box.Show();
                box.Focus();
            }
        }

        private void listBoxTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTasks.SelectedIndex >= 0)
            {
                Rectangle rect = listBoxTasks.GetItemRectangle(listBoxTasks.SelectedIndex);

                listSelector.Location = new Point(rect.X + listBoxTasks.Location.X, rect.Y + listBoxTasks.Location.Y);
                listSelector.BringToFront();
                listSelector.Show();
                listSelector.Focus();
            }
        }

        #region INotified Members

        public void Notify()
        {
            if (listBoxTasks.Items.Count <= 1)
                notifyIcon1.BalloonTipText = "There is still 1 unsorted item";
            else
                notifyIcon1.BalloonTipText = String.Format("There are still {0} unsorted items", listBoxTasks.Items.Count);

            notifyIcon1.ShowBalloonTip(3000);
        }

        #endregion

        #region INotified Members


        public bool IsNotified()
        {
            if (!set.ReminderOn)
                return false;

            if (this.listBoxTasks.Items.Count > 0)
                return true;
            else
                return false;
        }

        #endregion
    }
}
