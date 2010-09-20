
using System;
namespace XMLModule
{
    public class TimeTodo
    {
        #region Properties

        public string Type { get; set; }
        public double Value { get; set; }

        #endregion

        #region Static Methods

        public static TimeTodo ConvertTime(double value)
        {
            TimeTodo returnvalue = new TimeTodo();
            if (value <= 60)
            {
                returnvalue.Type = "I";
                returnvalue.Value = value / 60.0;
            }
            else
            {
                returnvalue.Type = "H";
                returnvalue.Value = value / 3600.0;
            }

            return returnvalue;
        }

        public static int ConvertToSeconds(TimeTodo timeTodo)
        {
            int returnValue = 0;

            switch (timeTodo.Type)
            {
                case "I":
                    returnValue = Convert.ToInt32(Math.Floor(timeTodo.Value * 60));
                    break;
                case "H":
                    returnValue = Convert.ToInt32(Math.Floor(timeTodo.Value * 60 * 60));
                    break;
            }

            return returnValue;
        }

        public static int ConvertToSeconds(double value, string type)
        {
            int returnValue = 0;

            switch (type)
            {
                case "I":
                    returnValue = Convert.ToInt32(Math.Floor(value * 60));
                    break;
                case "H":
                    returnValue = Convert.ToInt32(Math.Floor(value * 60 * 60));
                    break;
            }

            return returnValue;
        }

        public static string GetString(int value)
        {
            TimeSpan time = new TimeSpan(0, 0, 0, value);
            string returnString = String.Format("{0}s", time.Seconds);
            if (time.Minutes > 0)
                returnString = String.Format("{0}m {1}", time.Minutes, returnString);
            if (time.Hours > 0)
                returnString = String.Format("{0}h {1}", time.Hours, returnString);
            if (time.Days > 0)
                returnString = String.Format("{0}d {1}", time.Days, returnString);

            return returnString;
        }
        #endregion
    }
}
