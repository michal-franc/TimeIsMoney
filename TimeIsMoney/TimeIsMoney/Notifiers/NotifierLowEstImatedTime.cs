using TimeIsMoney.Notification;
using TimeIsMoney.Reminder;

namespace TimeIsMoney.Notifiers
{
    public class NotifierLowEstImatedTime : Notifier, INotified
    {


        public NotifierLowEstImatedTime(System.Windows.Forms.NotifyIcon obj) : base(obj)
        {}

        #region INotified Members

        public void Notify()
        {
            base._notifiedObject.BalloonTipText = "There are items with Low Estimated Time! ";
            base._notifiedObject.ShowBalloonTip(1000);
        }

        public bool IsNotified()
        {
            if (XmlAnalyser.GetItemsWithLowEstTime("Koszyk.tdl", 30, "I").Count > 0)
                return true;
            return false;
        }

        #endregion
    }
}
