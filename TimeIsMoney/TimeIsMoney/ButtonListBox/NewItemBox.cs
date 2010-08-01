using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeIsMoney.ButtonListBox
{
    public partial class NewItemBox : Form
    {
        OpenFileDialog dialog = new OpenFileDialog();
        
        private int y = 0;
        public NewItemBox()
        {
            InitializeComponent();
        }


        public void CreateTextBox(string name)
        {
            this.Controls.Add(new Label() { Text = name, Location = new Point(0, y) });
            this.Controls.Add(new TextBox() { Location = new Point(0, y + 20) });
            y += 40;
        }

        public void CreateFileDialogButton(string name, string filter)
        {
            this.Controls.Add(new Label() { Text = name, Location = new Point(0, y) });


            TextBox dialogText = new TextBox();
            dialogText.Click += new EventHandler(dialog_Click);
            dialogText.Location = Location = new Point(0, y + 20);
            this.Controls.Add(dialogText);
            y += 40;
        }

        private void dialog_Click(object sender, EventArgs e)
        {
            dialog.ShowDialog();
        }

        public string GenerateStringObject()
        {
            string returnString = String.Empty;

            foreach (Control c in Controls)
            {
                returnString += String.Format("{0};", c.Text);
            }

            return returnString;
        }
    }
}
