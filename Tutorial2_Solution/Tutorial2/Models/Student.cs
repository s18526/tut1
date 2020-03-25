using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Tutorial2.Models
{

    public class Student
    {
        
        [XmlAttribute(attributeName:"indexNumber")]
        public string IndexNumber { get; set; }
        [XmlElement(elementName:"email")]
        public string Email { get; set; }
        [XmlElement(elementName: "fname")]
        public string FirstName { get; set; }
        
        private string _lastName;
        [XmlElement(elementName: "lname")]
        public string LastName { 
            get { return _lastName; } 
            set
            {
                _lastName = value ?? throw new ArgumentException();
            } 
        }
        [XmlElement(elementName: "birthdate")]
        public DateTime Birthdate { get; set; }
        [XmlElement(elementName: "mothersName")]
        public string MomsName { get; set; }
        [XmlElement(elementName: "fathersName")]
        public string DadsName { get; set; }

        [XmlElement(elementName: "studies")]
        public ActiveStudies ActiveStudies { get; set; }

    }
}
