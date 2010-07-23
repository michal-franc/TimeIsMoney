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
    public partial class Form1 : Form
    {

        globalKeyboardHook gkh = new globalKeyboardHook();
        EditMessageBox box = new EditMessageBox();
        ListBox list = new ListBox();


        public Form1()
        {
            InitializeComponent();
			//test

            listBoxTasks.DisplayMember = "Title";

            list.Size = new System.Drawing.Size(100, 100);
            
            
            //Fill with Bins
            list.Items.Add("Koszyk");
            list.SelectedIndexChanged += new EventHandler(list_SelectedIndexChanged);
            list.Hide();


            foreach(Task task in XMLLogic.XMLLogic.ReadXML("Koszyk.tdl"))
            {
                listBoxTasks.Items.Add( task );
            }

            box.Deactivate += new EventHandler(EditMessageBoxClosed);

            gkh.HookedKeys.Add(Keys.B);
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);

            //Thread backgroundWorker = new Thread(delegate() {

            //    while(true)
            //    {
            //        if (DateTime.Now.Hour >= 20)
            //        {
            //            if (listBoxTasks.Items.Count > 0)
            //            {
            //                MessageBox.Show("Masz zadania do przydzielenia !!");
            //            }
            //        }
            //        Thread.Sleep(TimeSpan.FromMinutes(10));
            //    }
                
            //});

            //backgroundWorker.Start();
		
        }

        void gkh_KeyUp(object sender, KeyEventArgs e)
        {

        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
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

           list.Location = new Point(rect.X + listBoxTasks.Location.X, rect.Y+listBoxTasks.Location.Y);

           this.Controls.Add(list);
           list.BringToFront();
           list.Show();
           list.Focus();
        }

        void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddToBin((Task)listBoxTasks.SelectedItem,list.SelectedItem.ToString());
            list.Hide();
        }

        private void AddToBin(Task task, string binName)
        {
            string filePath = String.Format("{0}.tdl", binName);
            XMLLogic.XMLLogic.AddToXml(task, filePath);
        }

    }
}
