using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TimeIsMoney.Notifiers;
using TimeIsMoney.Settings;
using XMLModule;
using XMLModule.XMLLogic;

namespace TimeIsMoney
{
    public partial class Form1 : Form
    {
        private ListBox listSelector = new ListBox()
        {
            Size = new System.Drawing.Size(100, 100),
        };

        globalKeyboardHook gkh = new globalKeyboardHook();
        EditMessageBox box = new EditMessageBox();
        SettingsForm settingsForm = new SettingsForm();
        public List<Task> unsortedTasks = new List<Task>();
        public Settings.Settings set;

        public Form1()
        {
            InitializeComponent();

            set = Settings.Settings.Load();
            this.Menu = new MainMenu();
            this.Menu.MenuItems.Add(new MenuItem("Settings", new EventHandler(settings_OnClick)));


            //
            //NotifyIcon
            //
            notifyIcon.ContextMenu = new System.Windows.Forms.ContextMenu();
            notifyIcon.ContextMenu.MenuItems.Add(new MenuItem("Close", new EventHandler(Close_MouseClick)));

            //
            //listSelector
            //
            this.Controls.Add(listSelector);
            listSelector.DataSource = set.Lists;
            listSelector.DisplayMember = "Name";
            listSelector.MouseClick += new MouseEventHandler(listSelector_MouseClick);
            listSelector.Hide();

            listBoxTasks.DisplayMember = "Title";
            settingsForm.complexListBox.SetData(set.Lists, typeof(TaskBin), "Name");

            foreach (Task task in XmlLogic.ReadXml(set.BinPath))
            {
                unsortedTasks.Add(task);
            }

            listBoxTasks.DataSource = unsortedTasks;
            this.listBoxTasks.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBoxTasks_MouseClick);

            box.Deactivate += new EventHandler(EditMessageBoxClosed);

            gkh.HookedKeys.Add(Keys.B);
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);

            Reminder.Reminder.AddObjectToNotify(new NotifierLowEstImatedTime(notifyIcon,set.RemindListPath));
            Reminder.Reminder.AddObjectToNotify(new NotifierUnsortedItems(notifyIcon));

            Reminder.Reminder.Run(set.RemindTime, set.RemindDelay);
            Reminder.Reminder.RemindWholeDay = set.RemindWholeDay;
        }

        protected override CreateParams CreateParams
        {

            get
            {

                CreateParams param = base.CreateParams;

                param.ClassStyle = param.ClassStyle | 0x200;

                return param;

            }

        }

        protected void settings_OnClick(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();
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
                XmlLogic.AddToXml(task, filePath);
                unsortedTasks.RemoveAt(listBoxTasks.SelectedIndex);
                listBoxTasks.eReloadDataSource();
                XmlLogic.AddToXml(unsortedTasks, set.BinPath);

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
                unsortedTasks.Add(new Task(box.textBoxData.Text,
                    Int32.Parse(box.textBoxEstTime.Text),
                    "I",
                    box.dateTimePicker.Value,
                    Convert.ToInt32(box.comboBoxPriority.SelectedItem),box.textBoxComment.Text));

                XmlLogic.AddToXml(unsortedTasks, set.BinPath);
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

        private void Close_MouseClick(object sender, EventArgs e)
        {
            box.Close();
            Application.ExitThread();
            Application.Exit();
            Reminder.Reminder.Stop();
        }
    }
}
