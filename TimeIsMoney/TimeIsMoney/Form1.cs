using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
            listSelector.MouseClick += new MouseEventHandler(listSelector_MouseClick);
            listSelector.Hide();

            listBoxTasks.DisplayMember = "Title";
            this.complexListBox.SetData(set.Lists,typeof(TaskBin),"Name");

            foreach(Task task in XMLLogic.XMLLogic.ReadXML(set.BinPath))
            {
                unsortedTasks.Add(task);
            }

            listBoxTasks.DataSource = unsortedTasks;
            this.listBoxTasks.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBoxTasks_MouseClick);

            box.Deactivate += new EventHandler(EditMessageBoxClosed);

            gkh.HookedKeys.Add(Keys.B);
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);

            Reminder.Run(this, set.RemindTime);
            Reminder.RemindWholeDay = set.RemindWholeDay;
        }

        private void listSelector_MouseClick(object sender, MouseEventArgs e)
        {
            if (listSelector.SelectedItem != null)
            {
                if (listSelector.SelectedIndex == listSelector.IndexFromPoint(e.X, e.Y))
                {
                    AddToBin((Task)listBoxTasks.SelectedItem, ((TaskBin)listSelector.SelectedItem).Address);
                    listSelector.Hide();
                }

            }
        }

        private void AddToBin(Task task, string filePath)
        {
            if (task != null)
            {
                XMLLogic.XMLLogic.AddToXml(task, filePath);
                unsortedTasks.RemoveAt(listBoxTasks.SelectedIndex);
                listBoxTasks.eReloadDataSource();
                XMLLogic.XMLLogic.AddToXml(unsortedTasks,set.BinPath);

            }
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

        private void listBoxTasks_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBoxTasks.SelectedIndex >= 0)
            {
                if (listBoxTasks.SelectedIndex == listBoxTasks.IndexFromPoint(e.X, e.Y))
                {
                    Rectangle rect = listBoxTasks.GetItemRectangle(listBoxTasks.SelectedIndex);

                    listSelector.Location = new Point(rect.X + listBoxTasks.Location.X, rect.Y + listBoxTasks.Location.Y);
                    listSelector.eReloadDataSource();
                    listSelector.BringToFront();
                    listSelector.Show();
                    listSelector.Focus();
                }
            }
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            set.Save();
        }
    }
}
