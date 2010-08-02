using System;
using System.Drawing;
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
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
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

            dialog.Filter = filter;
            TextBox dialogText = new TextBox();
            dialogText.Click += new EventHandler(dialog_Click);
            dialogText.Location = Location = new Point(0, y + 20);
            this.Controls.Add(dialogText);
            y += 40;
        }

        private void dialog_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == dialog.ShowDialog())
            {
                TextBox txtBox = sender as TextBox;
                if (txtBox != null)
                {
                    txtBox.Text = dialog.FileName;
                }
            }


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
