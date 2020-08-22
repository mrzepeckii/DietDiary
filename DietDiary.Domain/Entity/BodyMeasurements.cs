using System;
using System.Collections.Generic;
using System.Text;

namespace DietDiary.Domain.Entity
{
    public class BodyMeasurements
    {
        public double Calf { get; set; }
        public double Thight { get; set; }
        public double Waist { get; set; }
        public double Chest { get; set; }
        public double Biceps { get; set; }

        public override string ToString()
        {
            return $"Łydka - {Calf} \nUdo - {Thight} \nTalia - {Waist} \nKlatka - {Chest} \nBiceps - {Biceps}";
        }
    }
}
