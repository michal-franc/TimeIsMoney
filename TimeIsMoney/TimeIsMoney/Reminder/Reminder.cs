using System;
using System.Collections.Generic;
using System.Threading;

namespace TimeIsMoney.Reminder
{
    public static class Reminder
    {

        /// <summary>
        /// Parameter used to
        /// </summary>
        public static bool RemindWholeDay;
        private static Thread _backgroundWorker;
        private static List<INotified> _notifiedObjects = new List<INotified>();



        public static void AddObjectToNotify(INotified obj)
        {
            _notifiedObjects.Add(obj);
        }

        /// <summary>
        /// Starts the thread of the reminder.
        /// </summary>
        /// <param name="notifiedObject">Object which is being notified about evvent.</param>
        /// <param name="remindTime"></param>
        /// <param name="remindDelay"></param>
        /// <returns></returns>
        public static void Run(TimeSpan remindTime,int remindDelay)
        {
            _backgroundWorker = new Thread(delegate()
            {
                while (true)
                {
                    if (DateTime.Now.TimeOfDay.CompareTo(remindTime) >=1 || RemindWholeDay)
                    {
                        foreach (INotified notified in _notifiedObjects)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(1));

                            if (notified.IsNotified())
                                notified.Notify();
                        }
                    }
                    Thread.Sleep(TimeSpan.FromSeconds(remindDelay));
                    
                }
            });

            _backgroundWorker.Start();
            return;

        }

        public static void Stop()
        {
            _backgroundWorker.Abort();
        }
    }
}
