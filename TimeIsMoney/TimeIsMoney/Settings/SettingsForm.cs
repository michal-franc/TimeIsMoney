using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeIsMoney.Settings
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
          Form1 parent =  this.FindForm() as Form1;
          if (parent != null)
          {
              parent.set.Save();
          }

          this.Hide();
        }
    }
}
