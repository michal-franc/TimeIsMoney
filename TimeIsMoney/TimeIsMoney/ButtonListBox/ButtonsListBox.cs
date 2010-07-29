using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeIsMoney
{
    public partial class ButtonsListBox : UserControl
    {
        public ButtonsListBox()
        {
            InitializeComponent();

            listBoxMain.DisplayMember = "Name";
        }
        public void SetData(List<TaskBin> data)
        {
                listBoxMain.DataSource = data;
        }


        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            if (textBoxTodoTitle.Text.Length > 0 && textBoxTodoPath.Text.Length > 0)
            {
                 ((List<TaskBin>)listBoxMain.DataSource).Add(new TaskBin(){ Address=textBoxTodoPath.Text,  Name=textBoxTodoTitle.Text});
                 listBoxMain.eReloadDataSource();
            }
        }

        private void buttonEleteItem_Click(object sender, EventArgs e)
        {
            if (listBoxMain.SelectedItem != null)
            {
                listBoxMain.Items.Remove(listBoxMain.SelectedItem);
            }
        }
    }
}
