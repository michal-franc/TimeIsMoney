using System;
using System.Windows.Forms;

namespace TimeIsMoney
{
    /// <summary>
    /// Ipnut Dialog Box Form
    /// </summary>
    public partial class EditMessageBox : Form
    {
        public EditMessageBox()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyDown += new KeyEventHandler(EditMessageBox_KeyDown);
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
    }
}
