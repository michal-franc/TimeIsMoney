using System;
using TimeIsMoney.Reminder;

namespace TimeIsMoney.Notifiers
{
    public class NotifierUnsortedItems : Notifier, INotified
    {
        private int count = 0;

        public NotifierUnsortedItems(System.Windows.Forms.NotifyIcon obj)
            : base(obj)
        {}

        #region INotified Members

        public void Notify()
        {
            if (count <= 1)
                base._notifiedObject.BalloonTipText = "There is still 1 unsorted item";
            else
                base._notifiedObject.BalloonTipText = String.Format(
                     "There are still {0} unsorted items", count);

            base._notifiedObject.ShowBalloonTip(1000);

        }

        public bool IsNotified()
        {
            count = XMLLogic.XmlLogic.ReadXml("Koszyk.tdl").Count;

            if (count > 0)
                return true;
            else
                return false;
        }

        #endregion
    }
}
