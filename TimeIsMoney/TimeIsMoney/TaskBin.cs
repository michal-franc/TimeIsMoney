using System;
using TimeIsMoney.ButtonListBox;

namespace TimeIsMoney
{
    [Serializable]
    public class TaskBin : IEditable<TaskBin>
    {
        [EditableDialogBox]
        public string Address { get; set; }
        [EditableTextBox]
        public string Name { get; set; }

        public string DisplayMember
        {
            get
            {
                return "Name";
            }
        }

        #region IEditable<TaskBin> Members

        public  TaskBin CreateFromString(string stringObject)
        {
            string[] datas = stringObject.Split(';');

            return new TaskBin() { Address = datas[1], Name = datas[3] };
        }

        #endregion
    }
}