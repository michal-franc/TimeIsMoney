
using System;
using System.Collections.Generic;
using System.Linq;
using XMLModule;
namespace ReportModule
{
    public static class ReportEngine
    {
        public static Dictionary<DateTime,int> GetCompletedTasksPerDay(List<Task> tasks)
        {
            Dictionary<DateTime,int> data = new Dictionary<DateTime, int>();

            var sortedTasks = tasks.Where(t => t.CompletedDateString != String.Empty).OrderBy(t => t.CompletedDateString);

            bool first = true;
            int counter = 0;
            DateTime current = new DateTime();

            foreach (var task in sortedTasks)
            {
                if (first)
                {
                    current = Convert.ToDateTime(task.CompletedDateString);
                    first = false;
                }

                if (Convert.ToDateTime(task.CompletedDateString) != current)
                {
                    data.Add(current, counter);
                    current = current + TimeSpan.FromDays(1);
                    counter = 0;
                }

                if (Convert.ToDateTime(task.CompletedDateString) == current)
                {
                    counter++;
                }
            }

            data.Add(current, counter);

            return data;
        }
    }
}
