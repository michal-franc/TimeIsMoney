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
        public ListBox m_list;
        public List<TaskBin> m_bins;
        public BinSelector(List<TaskBin> Bins)
        {
            m_bins = Bins;

            m_list = new ListBox();
            m_list.Size = new System.Drawing.Size(100, 100);

            foreach (TaskBin bin in m_bins)
            {
                m_list.Items.Add(bin.Name);
            }

            m_list.SelectedIndexChanged += new EventHandler(list_SelectedIndexChanged);
            m_list.Hide();

        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form parent =this.Parent.FindForm();
            if (parent != null)
            {
                ListBox listBoxTasks = parent.Controls.Find("listBoxTasks", true)[0] as ListBox;
                if (listBoxTasks != null)
                {
                    if (m_list.SelectedItem != null)
                    {
                        AddToBin((Task)listBoxTasks.SelectedItem, m_list.SelectedItem.ToString());
                        m_list.Hide();
                    }
                }
            }
        }

        private void AddToBin(Task task, string binName)
        {
            string filePath = String.Empty;

            foreach (TaskBin bin in m_bins)
            {
                if (bin.Name == binName)
                {
                    filePath = bin.Address;
                    break;
                }
            }
            

            XMLLogic.XMLLogic.AddToXml(task, filePath);
            

            Form parent =this.Parent.FindForm();
            if (parent != null)
            {
                ListBox listBoxTasks = parent.Controls.Find("listBoxTasks", true)[0] as ListBox;
                if (listBoxTasks != null)
                {
                    listBoxTasks.Items.RemoveAt(listBoxTasks.SelectedIndex);
                }
            }

        }



        public void ShowList(Point point)
        {
            m_list.Location = point;
            Form parent =  this.Parent.FindForm();

            // If parent form has already this list control dont create new one.
            if (!parent.Controls.Contains(m_list))
            {
                this.Parent.FindForm().Controls.Add(m_list);
            }

            m_list.BringToFront();
            m_list.Show();
            m_list.Focus();
        }
    }
}
