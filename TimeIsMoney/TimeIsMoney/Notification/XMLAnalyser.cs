using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeIsMoney.Notification
{
    public static  class XmlAnalyser
    {
        private static List<Task> _allItems;

        public static void Load(string filepath,bool reload = false)
        {
                _allItems = XMLLogic.XMLLogic.ReadXML(filepath);
        }

        public static List<Task> GetItemsWithLowEstTime(string filePath,int timeLimit,string timeUnit)
        {
            Load(filePath);
            return _allItems.Where(t => t.TimeTodo.Time <= TimeTodo.ConvertTime(timeLimit, timeUnit)).ToList();
        }

        public static List<Task> GetItemsWithNoEstTime(string filePath, int timeLimit, string timeUnit)
        {
            Load(filePath);
            return _allItems.Where(t => t.TimeTodo.Time == 0).ToList();
        }

        public static List<Task> GetItemsWithNoDueDate(string filePath)
        {
            Load(filePath);
            return _allItems.Where(t => t.DueDate == String.Empty).ToList();
        }

        public static List<Task> GetItemsWithLowDueDate(string filePath,DateTime dateTimeLimit, TimeSpan timeSpan)
        {
            Load(filePath);
            DateTime dateTime;
            List<Task> returnList =new List<Task>();
            foreach (Task t in _allItems)
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

        public static int GetItemsCount(string filePath)
        {
            Load(filePath);
            return _allItems.Count;
        }
    }
}
