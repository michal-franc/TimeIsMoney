using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ActivityTracker
{
    [Serializable]
    public class Settings
    {

        public List<string> Projects { get; set; }


        private Settings()
        {
            Projects = new List<string>();
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            Stream stream = new FileStream("settings.xml", FileMode.OpenOrCreate);
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
            catch
            {
                return new Settings();
            }
        }
    }
}
