using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace TimeIsMoney.XMLLogic
{
    /// <summary>
    /// Interface used to create XmlConvert classes
    /// </summary>
    public interface IXMLConverter
    {
        /// <summary>
        /// Method used to Create Xml from the object
        /// </summary>
        /// <param name="obj">Object used to create Xml</param>
        /// <returns></returns>
        XElement CreateXML(Object obj);
    }
}
