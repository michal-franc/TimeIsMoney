using System;
using System.Windows.Forms;

namespace TimeIsMoney
{
    /// <summary>
    /// Ipnut Dialog Box Form
    /// </summary>
    public partial class EditMessageBox : Form
    {
        private bool resized = false;
        private System.Drawing.Size size;

        public EditMessageBox()
        {
            InitializeComponent();
            size = new System.Drawing.Size(450, 50);
            this.Size = size;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyDown += new KeyEventHandler(EditMessageBox_KeyDown);
            this.comboBoxPriority.Items.AddRange(new object[] { "0", "1","2","3","4","5","6","7","8","9","10"});
            this.comboBoxPriority.SelectedIndex = 6;
        }

        private void EditMessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Hide();
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!resized)
            {
                this.Size = new System.Drawing.Size(this.Size.Width, 200);
                resized = true;
            }
            else
            {
                this.Size = size;
                resized = false;
            }
        }
    }
}
