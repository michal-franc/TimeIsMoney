using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeIsMoney
{
    public static class Extension
    {
        public static void eReloadDataSource(this ListBox listbox)
        {
            string s = listbox.DisplayMember;
            Object obj = listbox.DataSource;
            listbox.DataSource = null;
            listbox.DataSource = obj;
            listbox.DisplayMember=s;       
        }
    }
}
