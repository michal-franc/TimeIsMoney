using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace DekstopTodo
{
    [Serializable]
    public class Settings
    {

        public List<string> ProjectsPath { get; set; }

        public Settings()
        {
            ProjectsPath = new List<string>();
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            Stream stream = new FileStream("settings.xml", FileMode.Truncate);
            serializer.Serialize(stream, this);
            stream.Close();
        }

        public static Settings Load()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                Stream stream = new FileStream("settings.xml", FileMode.OpenOrCreate);
                Settings set = (Settings)serializer.Deserialize(stream);
                stream.Close();
                return set;
            }
            // If There was a problem loading settings ... load default options.
            catch(Exception ex)
            {
                return new Settings();
            }
        }
    }
}
