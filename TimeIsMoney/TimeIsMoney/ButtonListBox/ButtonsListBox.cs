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

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            if (textBoxTodoTitle.Text.Length > 0 && textBoxTodoPath.Text.Length > 0)
            {
                listBoxMain.Items.Add(new TaskBin(){ Address=textBoxTodoPath.Text,  Name=textBoxTodoTitle.Text});
            }
        }

        private void buttonEleteItem_Click(object sender, EventArgs e)
        {

        }
    }
}
