using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XMLModule;
using System.Windows.Media;
using System.ComponentModel;

namespace AvtivityTracker
{
    public enum TaskState
    {
        Started,
        Stoped
    }

    public class TaskWPF : INotifyPropertyChanged
    {
        private Task _task;
        private string _color;
        private TaskState _state;

        public List<TaskWPF> Childrens { get; set; }

        public string Title
        {
            get { return _task.Title; }
        }

        public TaskState state
        {
            get { return _state; }
        }

        public string ButtonText
        {
            get
            {
                if (_state == TaskState.Started)
                {
                    return "Stop";
                }
                else if (_state == TaskState.Stoped)
                {
                    return "Start";
                }
                else
                {
                    return "Error";
                }
            }
        }

        public string TaskColor
        {
            get { return _color; }
            set { _color = value; }
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
            IsOverEstimatedTime();
            OnPropertyChanged("ButtonText");
        }

        public void ChangeState()
        {
            if (_state == TaskState.Started)
                _state = TaskState.Stoped;
            else if (_state == TaskState.Stoped)
                _state = TaskState.Started;

            OnPropertyChanged("TimeSpentString");
        }

        public void IsOverEstimatedTime()
        {
            if (_task.TimeSpent > _task.TimeEstimate)
            {
                TaskColor = "Red";
                OnPropertyChanged("TaskColor");
            }
        }

        public TaskWPF(Task task)
        {
            _task = task;
            TaskColor = "DarkOrange";
            _state = TaskState.Stoped;
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
