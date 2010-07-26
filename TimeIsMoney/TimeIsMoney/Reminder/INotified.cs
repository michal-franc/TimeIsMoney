using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeIsMoney
{
    public interface INotified
    {
        void Notify();
        bool IsNotified();
    }
}
