
using System;
namespace XMLModule
{
    public class TimeTodo
    {
        private long _value;
        private string _type;


        public long TimeValue { get { return _value; } }

        public string TimeType { get { return _type; } }

        public void AddSecond(int i)
        {
            _value += i;
        }

        public void AddMinute(int i)
        {
            AddSecond(i * 60);
        }

        public void AddHour(int i)
        {
            AddMinute(i * 60);
        }

        public void AddDay(int i)
        {
            AddHour(i * 24);
        }

        public TimeTodo(long value, string type)
        {
            _value = value;
            _type = type;
        }

        public double Time
        {
            get { return ConvertTime(_value, _type); }
        }



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

        public override string ToString()
        {
            return TimeTodo.GetString((int)_value);
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
