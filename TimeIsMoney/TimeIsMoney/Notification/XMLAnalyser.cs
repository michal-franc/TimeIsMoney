﻿using System;
using System.Collections.Generic;
using System.Linq;
using XMLModule;

namespace TimeIsMoney.Notification
{
    public static  class XmlAnalyser
    {
        public static List<Task> GetItemsWithLowEstTime(List<Task> allitems ,int timeLimit,string timeUnit)
        {
            return allitems.Where(t => t.TimeTodo.Time <= TimeTodo.ConvertTime(timeLimit, timeUnit)).ToList();
        }

        public static List<Task> GetItemsWithNoEstTime(List<Task> allitems , int timeLimit, string timeUnit)
        {
            return allitems.Where(t => t.TimeTodo.Time == 0).ToList();
        }

        public static List<Task> GetItemsWithNoDueDate(List<Task> allitems)
        {
            return allitems.Where(t => t.DueDate == String.Empty).ToList();
        }

        public static List<Task> GetItemsWithLowDueDate(List<Task> allitems,DateTime dateTimeLimit, TimeSpan timeSpan)
        {
            DateTime dateTime;
            List<Task> returnList =new List<Task>();
            foreach (Task t in allitems)
            {
                if (DateTime.TryParse(t.DueDateString, out dateTime))
                {
                    if (dateTime - dateTimeLimit <= timeSpan)
                    {
                        returnList.Add(t);
                    }
                }
            }
            return returnList;
        }
    }
}
