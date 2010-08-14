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
              settings.RemindListPath = textBoxRemindList.Text;
              settings.Save();
          }

          this.Hide();
        }

        private void textBoxRemindList_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.ShowDialog();

            if (DialogResult.OK == filedialog.ShowDialog())
            {
                textBoxRemindList.Text = filedialog.FileName;              
            }


        }
    }
}
