using System;
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
            Settings settings = Settings.Load();
            if (settings != null)
          {
              settings.Save();
          }

          this.Hide();
        }
    }
}
