using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeIsMoney.ButtonListBox
{
    interface IEditable<T>
    {
        T CreateFromString(string stringObject);
    }
}
