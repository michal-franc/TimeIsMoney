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

        private TaskWPF _parent;
        public List<TaskWPF> Childrens { get; set; }

        public string Title
        {
            get { return _task.Title; }
        }

        public TaskState state
        {
            get { return _state; }
        }

        public int Priority
        {
            get { return _task.Priority; }
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
            get
            {
                return _task.TimeSpentString;
            }
        }

        public string TimeEstimateString
        {
            get { return _task.TimeEstimateString; }
        }

        public void Increment()
        {
            AddSecond(1);
            IsOverEstimatedTime();
            OnPropertyChanged("TimeSpentString");

            if (_parent != null)
                _parent.Increment();
        }

        public void ChangeState()
        {
            if (_state == TaskState.Started)
                _state = TaskState.Stoped;
            else if (_state == TaskState.Stoped)
                _state = TaskState.Started;

            OnPropertyChanged("ButtonText");
        }

        public void IsOverEstimatedTime()
        {
            if (_task.TimeSpent > _task.TimeEstimate)
            {
                TaskColor = "Red";
                OnPropertyChanged("TaskColor");
            }
        }

        public TaskWPF(Task task, TaskWPF parent)
        {
            _task = task;
            _parent = parent;
            TaskColor = "DarkOrange";
            _state = TaskState.Stoped;

            List<TaskWPF> tasks = new List<TaskWPF>();
            if (task.Childrens != null)
            {
                foreach (var t in task.Childrens)
                {
                    tasks.Add(new TaskWPF(t, this));
                }
            }
            this.Childrens = tasks;
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
