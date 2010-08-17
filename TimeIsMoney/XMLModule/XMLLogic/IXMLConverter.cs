using System;
using System.Xml.Linq;

namespace XMLModule.XMLLogic
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
        XElement CreateXml(Object obj);
    }
}
