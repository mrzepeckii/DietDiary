using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DietDiary.Domain.Entity
{
    public class BodyMeasurements
    {
        //dodac dzien pomiarow -- TO DO 
        //lista pomiarów -- TO DO 
        [XmlElement("Calf")]
        public double Calf { get; set; }
        [XmlElement("Thight")]
        public double Thight { get; set; }
        [XmlElement("Waist")]
        public double Waist { get; set; }
        [XmlElement("Chest")]
        public double Chest { get; set; }
        [XmlElement("Biceps")]
        public double Biceps { get; set; }

        public override string ToString()
        {
            return $"Łydka - {Calf} \nUdo - {Thight} \nTalia - {Waist} \nKlatka - {Chest} \nBiceps - {Biceps}";
        }
    }
}
