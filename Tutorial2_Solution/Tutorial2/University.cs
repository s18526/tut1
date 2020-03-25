using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Tutorial2.Models;

namespace Tutorial2
{
    [Serializable]
    public class University
    {
       
            [XmlAttribute(AttributeName = "createdAt")]
            public DateTime CreatedAt { get; set; }

            [XmlAttribute(AttributeName = "author")]
            public string Author { get; set; }

            [XmlElement(ElementName = "students")]
            public HashSet<Student> Students { get; set; }

        public HashSet<ActiveStudies> ActiveStudies { get; set; }
        
    }
}

