using TimeIsMoney.Reminder;
using XMLModule;
using XMLModule.XMLLogic;

namespace TimeIsMoney.Notifiers
{
    public class NotifierLowEstImatedTime : Notifier, INotified
    {
        private readonly string _filePath;

        public NotifierLowEstImatedTime(System.Windows.Forms.NotifyIcon obj , string filePath) : base(obj)
        {
            _filePath = filePath;
        }

        #region INotified Members

        public void Notify()
        {
            base._notifiedObject.BalloonTipText = "There are items with Low Estimated Time! ";
            base._notifiedObject.ShowBalloonTip(1000);
        }

        public bool IsNotified()
        {
            if (XmlAnalyser.GetItemsWithLowEstTime(XmlLogic.ReadXml(_filePath), 30, "I").Count > 0)
                return true;
            return false;
        }

        #endregion
    }
}
