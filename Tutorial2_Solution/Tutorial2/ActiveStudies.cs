using System;
using System.Xml.Serialization;

namespace Tutorial2
{
    [Serializable]

 
    public class ActiveStudies
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "mode")]
        public string StudyMode { get; set; }
        
    }
}