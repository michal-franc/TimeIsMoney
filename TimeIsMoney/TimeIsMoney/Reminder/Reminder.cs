using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TimeIsMoney
{
    public static class Reminder
    {
        //TODO :  Atm we re just using simple logic

        /// <summary>
        /// Parameter used to
        /// </summary>
        public static bool remind = false;

        /// <summary>
        /// Starts the thread of the reminder.
        /// </summary>
        /// <param name="conditionVariable">Parameter used to specify if the reminding condition is true</param>
        /// <param name="notifiedObject">Object which is being notified about evvent.</param>
        /// <returns></returns>
        public static void Run(INotified notifiedObject)
        {
            Thread backgroundWorker = new Thread(delegate()
            {

                while (true)
                {
                    if (DateTime.Now.Hour >= 20)
                    {
                        if (notifiedObject.IsNotified())
                            notifiedObject.Notify();
                    }
                    Thread.Sleep(TimeSpan.FromMinutes(10));
                }

            });

            backgroundWorker.Start();

        }

        public static void Stop()
        {

        }
    }
}
