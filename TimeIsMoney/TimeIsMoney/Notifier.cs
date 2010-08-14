using System.Windows.Forms;
using TimeIsMoney.Reminder;

namespace TimeIsMoney
{
    public class Notifier : Control ,INotified
    {
        private readonly System.Windows.Forms.NotifyIcon _notifiedObject;



        public  Notifier(System.Windows.Forms.NotifyIcon obj)
        {
            _notifiedObject = obj;
        }
        #region INotified Members


        public void Notify()
        {
            _notifiedObject.BalloonTipText = "Test";
            _notifiedObject.ShowBalloonTip(1000);
        }

        public bool IsNotified()
        {
            return true;
        }

        #endregion
    }
}
