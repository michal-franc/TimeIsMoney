using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XMLModule;
using System.Windows.Media;
using System.ComponentModel;

namespace ActivityTracker
{
    public class TaskWpf : INotifyPropertyChanged
    {
        #region Private Fields

        private Task _task;
        private string _color;
        private TaskState _state;
        private TaskWpf _parent;

        #endregion

        #region Properties

        public List<TaskWpf> Childrens { get; set; }

        public string Title
        {
            get { return _task.Title; }
        }

        public TaskState State
        {
            get { return _state; }
        }

        public int Priority
        {
            get { return _task.Priority; }
        }

        /// <summary>
        /// Return Button Text according to State
        /// </summary>
        public string ButtonText
        {
            get
            {
                if (_state == TaskState.Started)
                    return "Stop";
                else if (_state == TaskState.Stoped)
                    return "Start";
                else
                    return "Error";
            }
        }

        public string TaskColor
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged("TaskColor");
            }
        }

        /// <summary>
        /// Return Time Spent formated as {0}d {0}m {0} s
        /// </summary>
        public string TimeSpentString
        {
            get { return _task.TimeSpentString; }
        }

        /// <summary>
        /// Return Time Estimated formated as {0}d {0}m {0} s
        /// </summary>
        public string TimeEstimateString
        {
            get { return _task.TimeEstimateString; }
        }

        #endregion

        #region Ctor

        public TaskWpf(Task task, TaskWpf parent)
        {
            _task = task;
            _parent = parent;
            TaskColor = "DarkOrange";
            _state = TaskState.Stoped;

            List<TaskWpf> tasks = new List<TaskWpf>();
            if (task.Childrens != null)
            {
                foreach (var t in task.Childrens)
                {
                    tasks.Add(new TaskWpf(t, this));
                }
            }
            this.Childrens = tasks;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds one second to SpentTime of this Task and its Parent and notifies the TextBlock to redraw itself
        /// </summary>
        public void Increment()
        {
            AddSecond(1);

            if (IsOverEstimatedTime())
                TaskColor = "Red";
            //else
            //TaskColor = "DarkOrange";

            OnPropertyChanged("TimeSpentString");

            if (_parent != null)
                _parent.Increment();
        }

        /// <summary>
        /// Toogles State and notifies the Button to redraw its Text
        /// </summary>
        public void ToogleState()
        {
            if (_state == TaskState.Started)
                _state = TaskState.Stoped;
            else if (_state == TaskState.Stoped)
                _state = TaskState.Started;

            OnPropertyChanged("ButtonText");
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Checks if TimeSpent is greater than TimeEstimate
        /// </summary>
        private bool IsOverEstimatedTime()
        {
            return (_task.TimeSpent > _task.TimeEstimate) ? true : false;
        }

        private void AddSecond(int i)
        {
            _task.IncrementSpent(i);
        }

        #endregion

        #region Interfaces

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

        #endregion
    }
}
