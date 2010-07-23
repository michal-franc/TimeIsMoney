using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace TimeIsMoney.XMLLogic
{
    public class XMLToDoListConverter : IXMLConverter
    {
        #region IXMLConverter Members

        public XElement CreateXML(object obj)
        {
            Type type = obj.GetType();
            System.Reflection.PropertyInfo[] properties = type.GetProperties();

            List<XAttribute> attributes = new List<XAttribute>();

            foreach (System.Reflection.PropertyInfo prop in properties)
            {
                if (prop.GetValue(obj, null) != null)
                {
                    XAttribute attr = new XAttribute(prop.Name.ToUpper(), prop.GetValue(obj, null));
                    attributes.Add(attr);
                }
            }

            XElement element = new XElement("Task", attributes.ToArray());

            return element;
        }

        #endregion
    }
}
