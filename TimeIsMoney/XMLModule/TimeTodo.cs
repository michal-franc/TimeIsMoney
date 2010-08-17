
namespace XMLModule
{
    public class TimeTodo
    {
        private double _value;
        private string _type;


        public double TimeEstimate { get { return _value; } }

        public string TimeEstUnits { get { return _type; } }

        public TimeTodo(double value, string type)
        {
            _value = value;
            _type = type;
        }

        public double Time {
            get { return ConvertTime(_value,_type); }
        }



        public static double ConvertTime(double value , string type)
        {
            int multiplier = 1;
            switch(type)
            {
                case "I": multiplier = 1;
                    break;
                case "H": multiplier = 60;
                    break;
            }

            return value * multiplier;
        }

    }
}
