using System.Collections.Generic;

namespace TimeIsMoney.Notification
{
    public static  class XMLAnalyser
    {
        public static List<Task> CheckItemsWithLowTime(string filePath,int timeLimit,string timeUnit)
        {
            List<Task> notifiedItems = new List<Task>();
            List<Task> allItems = XMLLogic.XMLLogic.ReadXML(filePath);

            foreach (Task t in allItems)
            {
                if (t.TimeTodo.Time < TimeTodo.ConvertTime(timeLimit,timeUnit) )
                    notifiedItems.Add(t);
            }

            return notifiedItems;
        }

    }
}
