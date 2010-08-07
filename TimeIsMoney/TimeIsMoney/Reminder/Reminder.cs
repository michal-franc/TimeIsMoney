using System;
using System.Threading;

namespace TimeIsMoney
{
    public static class Reminder
    {

        /// <summary>
        /// Parameter used to
        /// </summary>
        public static bool RemindWholeDay = false;
        private static Thread backgroundWorker;

        /// <summary>
        /// Starts the thread of the reminder.
        /// </summary>
        /// <param name="conditionVariable">Parameter used to specify if the reminding condition is true</param>
        /// <param name="notifiedObject">Object which is being notified about evvent.</param>
        /// <returns></returns>
        public static void Run(INotified notifiedObject,TimeSpan remindTime,int remindDelay)
        {
            backgroundWorker = new Thread(delegate()
            {
                while (true)
                {
                    if (DateTime.Now.TimeOfDay.CompareTo(remindTime) >=1 || RemindWholeDay)
                    {
                        if (notifiedObject.IsNotified())
                            notifiedObject.Notify();
                    }
                    Thread.Sleep(TimeSpan.FromMinutes(remindDelay));
                }

            });

            backgroundWorker.Start();

        }

        public static void Stop()
        {
            backgroundWorker.Abort();
        }
    }
}
