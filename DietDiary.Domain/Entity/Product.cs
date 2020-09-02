using DietDiary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DietDiary.Domain.Entity
{
    public class Product : BaseEntity
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Calorific")]
        public int Calorific { get; set; }
        [XmlElement("Proteins")]
        public double Proteins { get; set; }
        [XmlElement("Carbos")]
        public double Carbos { get; set; }
        [XmlElement("Fats")]
        public double Fats { get; set; }

        public Product()
        {

        }

        public Product(int id, int category, string name, int calorific, double proteins, double carbos, double fats)
        {
            Id = id;
            Category = category;
            Name = name;
            Calorific = calorific;
            Proteins = proteins;
            Carbos = carbos;
            Fats = fats;
        }

    }
}
