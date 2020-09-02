using DietDiary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DietDiary.Domain.Entity
{
    public class Meal : BaseEntity
    {
        [XmlElement("ProductsInMeal")]
        public List<Product> products;
        [XmlElement("Name")]
        public string Name { get; set; }
        public Meal()
        {

        }

    }
    
}
