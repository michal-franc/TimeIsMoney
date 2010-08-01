using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using TimeIsMoney.ButtonListBox;

namespace TimeIsMoney
{
    public partial class ComplexListBox : UserControl
    {
        private NewItemBox newBox = new NewItemBox();
        string newObj;
        public ComplexListBox()
        {
            InitializeComponent();

            newBox.FormClosing += new FormClosingEventHandler(newBox_FormClosing);
        }

        void newBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            newObj = newBox.GenerateStringObject();
        }

        public List<PropertyInfo> propsToEdit = new List<PropertyInfo>();

        public void SetData(List<TaskBin> data,Type type,string displayMember)
        {
            listBoxMain.DataSource = data;
            if(data.Count>0)
                listBoxMain.DisplayMember = displayMember;


            int y = 0;
            foreach (PropertyInfo prop in type.GetProperties())
            {
                //Checking if property is decorated with EditableProperty Attribute
                if (prop.IsDefined(typeof(EditableTextBox), false))
                {
                    newBox.CreateTextBox(prop.Name);
                }
                else if(prop.IsDefined(typeof(EditableDialogBox),false))
                {
                    newBox.CreateFileDialogButton(prop.Name,"TODO list file (*.tdl)|*.tdl|All files (*.*)|*.*");
                }

            }
        }


        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            newBox.ShowDialog();
            ((List<TaskBin>)listBoxMain.DataSource).Add(new TaskBin().CreateFromString(newObj));
            listBoxMain.eReloadDataSource();
        }



        private void buttonDeleteItem_Click(object sender, EventArgs e)
        {
            if (listBoxMain.SelectedItem != null)
            {
                listBoxMain.Items.Remove(listBoxMain.SelectedItem);
            }
        }
    }
}
