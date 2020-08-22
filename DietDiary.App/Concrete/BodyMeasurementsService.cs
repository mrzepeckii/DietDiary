using DietDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietDiary.App.Concrete
{
    public class BodyMeasurementsService
    {

        public BodyMeasurements body { get; private set; }

        public BodyMeasurementsService()
        {
            body = new BodyMeasurements();
        }

        public void SetBodyMeasuremnts(int calf, int thight, int waist, int chest, int biceps)
        {
            body.Calf = calf;
            body.Thight = thight;
            body.Waist = waist;
            body.Chest = chest;
            body.Biceps = biceps;
        }
    }
}
