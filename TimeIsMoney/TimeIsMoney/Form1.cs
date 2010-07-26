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

        globalKeyboardHook gkh = new globalKeyboardHook();
        EditMessageBox box = new EditMessageBox();
        BinSelector binSelector;

        public Form1()
        {
            InitializeComponent();

            Settings set = Settings.Load();

            Reminder.Run(this);

            listBoxTasks.DisplayMember = "Title";

            //TODO : Atm empty list , need to to a list from the bins list
            binSelector = new BinSelector(set.Lists);
            this.Controls.Add(binSelector);

            foreach(Task task in XMLLogic.XMLLogic.ReadXML(set.BinPath))
            {
                listBoxTasks.Items.Add( task );
            }

            box.Deactivate += new EventHandler(EditMessageBoxClosed);

            gkh.HookedKeys.Add(Keys.B);
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);
		
        }

        void gkh_KeyUp(object sender, KeyEventArgs e)
        {

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
            listBoxTasks.Items.Add(box.textBoxData.Text);
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
           Rectangle rect =  listBoxTasks.GetItemRectangle(listBoxTasks.SelectedIndex);
           binSelector.ShowList(new Point(rect.X + listBoxTasks.Location.X, rect.Y + listBoxTasks.Location.Y)); 
        }

        #region INotified Members

        public void Notify()
        {
            MessageBox.Show("There are still unsorted items");
        }

        #endregion

        #region INotified Members


        public bool IsNotified()
        {
            if (this.listBoxTasks.Items.Count > 0)
                return true;
            else
                return false;
        }

        #endregion
    }
}
