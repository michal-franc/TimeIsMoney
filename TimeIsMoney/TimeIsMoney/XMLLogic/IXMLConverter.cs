using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace TimeIsMoney.XMLLogic
{
    public interface IXMLConverter
    {
        XElement CreateXML(Object obj);
    }
}
