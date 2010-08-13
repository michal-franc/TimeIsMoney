using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeIsMoney.Notification
{
    public static  class XmlAnalyser
    {
        private static List<Task> _allItems;

        public static List<Task> Load(string filepath,bool reload = false)
        {
            if (_allItems == null || reload)
            {
                _allItems = XMLLogic.XMLLogic.ReadXML(filepath);
            }
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
            return _allItems.Where(t => Convert.ToDateTime(t.DueDate) == DateTime.MinValue).ToList();
        }

        public static List<Task>  GetItemsWithLowDueDate(string filePath,DateTime dateTime, TimeSpan timeSpan)
        {
            Load(filePath);
            return _allItems.Where(t => Convert.ToDateTime(t.DueDate) - dateTime <= timeSpan).ToList();
        }
    }
}
