using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DietDiary.Domain.Entity
{
    public class UserData
    {
        //dodac dzien pomiarow -- TO DO 
        //lista pomairów -- TO DO 
        [XmlElement("Age")]
        public int Age { get; set; }
        [XmlElement("Weight")]
        public double Weight { get; set; }
        [XmlElement("Height")]
        public int Height { get; set; }
        public UserData()
        {

        }
        public override string ToString()
        {
            return "Wiek - " + Age + "\r\nWzrost - " + Height + "\r\nWaga - " + Weight;
        }
    }
}
