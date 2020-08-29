using DietDiary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietDiary.Domain.Entity
{
    public class Day : BaseEntity
    {
        public DateTime Date { get; set; }
        public IEnumerable<Meal> MealsInDay { get; set; }
        public BodyMeasurements bodyMeasurements { get; set; }
        public UserData userData { get; set; }

        public Day()
        {
            Date = DateTime.Now;
        }

        public Day(DateTime dateTime)
        {
            Date = dateTime;
        }
    }
}
