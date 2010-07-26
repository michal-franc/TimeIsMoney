using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TimeIsMoney
{
    public class BinSelector : Control
    {
        public ListBox list;
        public BinSelector(List<TaskBin> Bins)
        {
            list = new ListBox();
            list.Size = new System.Drawing.Size(100, 100);

            foreach (TaskBin bin in Bins)
            {
                list.Items.Add(bin.Name);
            }

            list.SelectedIndexChanged += new EventHandler(list_SelectedIndexChanged);
            list.Hide();

        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form parent =this.Parent.FindForm();
            if (parent != null)
            {
                ListBox listBoxTasks = parent.Controls.Find("listBoxTasks", true)[0] as ListBox;
                if (listBoxTasks != null)
                {
                    AddToBin((Task)listBoxTasks.SelectedItem, list.SelectedItem.ToString());
                    list.Hide();
                }
            }
        }

        private void AddToBin(Task task, string binName)
        {
            string filePath = String.Format("{0}.tdl", binName);
            XMLLogic.XMLLogic.AddToXml(task, filePath);
        }



        public void ShowList(Point point)
        {
            list.Location = point;
            Form parent =  this.Parent.FindForm();

            // If parent form has already this list control dont create new one.
            if (!parent.Controls.Contains(list))
            {
                this.Parent.FindForm().Controls.Add(list);
            }

            list.BringToFront();
            list.Show();
            list.Focus();
        }
    }
}
