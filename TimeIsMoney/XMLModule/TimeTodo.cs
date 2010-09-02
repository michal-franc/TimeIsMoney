
using System;
namespace XMLModule
{
    public static class TimeTodo
    {
        public static double ConvertTime(double value, string type)
        {
            int multiplier = 1;
            switch (type)
            {
                case "I": multiplier = 1;
                    break;
                case "H": multiplier = 60;
                    break;
            }

            return value * multiplier;
        }

        public static string GetString(int value)
        {
            TimeSpan time = new TimeSpan(0, 0, 0, (int)value);
            string returnString = String.Format("{0}s", time.Seconds);
            if (time.Minutes > 0)
                returnString = String.Format("{0}m {1}", time.Minutes, returnString);
            if (time.Hours > 0)
                returnString = String.Format("{0}h {1}", time.Hours, returnString);
            if (time.Days > 0)
                returnString = String.Format("{0}d {1}", time.Days, returnString);

            return returnString;
        }
    }
}
