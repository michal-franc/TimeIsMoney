using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XMLModule;
using System.Windows.Media;
using System.ComponentModel;

namespace AvtivityTracker
{
    public class TaskWPF : INotifyPropertyChanged
    {
        private Task _task;

        public List<TaskWPF> Childrens { get; set; }

        public string Title
        {
            get { return _task.Title; }
        }

        public string TimeSpentString
        {
            get { return _task.TimeSpentString; }
        }

        public string TimeEstimateString
        {
            get { return _task.TimeEstimateString; }
        }

        public void Increment()
        {
            AddSecond(1);
            OnPropertyChanged("TimeSpentString");
        }

        public bool IsOverEstimatedTime
        {
            get;
            set;
        }

        public TaskWPF(Task task)
        {
            _task = task;
        }

        private void AddSecond(int i)
        {
            _task.TimeSpent += i;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}
