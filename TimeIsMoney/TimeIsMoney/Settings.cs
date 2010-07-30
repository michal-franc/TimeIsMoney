using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;

namespace TimeIsMoney
{
    [Serializable]
    public class Settings
    {
        public string BinPath { get; set; }
        public string ToDoPath { get; set; }
        public bool ReminderOn { get; set; }
        public bool RemindWholeDay { get; set; }
        
        #region RemindTime
        private TimeSpan m_RemindTime;

        [XmlIgnore]
        public TimeSpan RemindTime
        {
            get { return m_RemindTime; }
            set { m_RemindTime = value; }
        }

        // Pretend property for serialization
        [XmlElement("RemindTime")]
        public long RemindTimetTicks
        {
            get { return m_RemindTime.Ticks; }
            set { m_RemindTime = new TimeSpan(value); }
        }

        #endregion
        
        public List<TaskBin> Lists { get; set; }
 
            
        private Settings()
        {
            // Default Values
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
            catch(Exception ex)
            {
                return new Settings();
            }
        }
}
}
