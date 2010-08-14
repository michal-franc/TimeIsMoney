
namespace TimeIsMoney.Notifiers
{
    public abstract class Notifier
    {
        protected readonly System.Windows.Forms.NotifyIcon _notifiedObject;


        public Notifier(System.Windows.Forms.NotifyIcon obj)
        {
            _notifiedObject = obj;
        }
    }
}
