using DietDiary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DietDiary.Domain.Entity
{
    public class Day : BaseEntity
    {
        [XmlElement("Date")]
        public DateTime Date { get; set; }
        [XmlElement("MealsInDay")]
        public List<Meal> MealsInDay { get; set; }
        [XmlElement("BodyMeasurements")]
        public BodyMeasurements BodyMeasurements { get; set; }
        [XmlElement("UserData")]
        public UserData UserData { get; set; }

        public Day()
        {
         
        }

        public Day(int dayId, DateTime dateTime)
        {
            Id = dayId;
            Date = dateTime;
            Category = dateTime.Month;
            MealsInDay = new List<Meal>();
        }
    }
}
