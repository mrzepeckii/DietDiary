using DietDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;

namespace DietDiary.App.Concrete
{
    public class BodyMeasurementsService
    {

        public BodyMeasurements Body { get; private set; }

        public BodyMeasurementsService()
        {
            Body = ReadMeasurementsFromXml();
        }

        public void SetBodyMeasuremnts(int calf, int thight, int waist, int chest, int biceps)
        {
            Body.Calf = calf;
            Body.Thight = thight;
            Body.Waist = waist;
            Body.Chest = chest;
            Body.Biceps = biceps;
        }

        public void SaveMeasurementsToXml()
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "BodyMeasurements";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BodyMeasurements), root);

            using (StreamWriter streamWriter = new StreamWriter(@"C:\Temp\body.xml"))
            {
                xmlSerializer.Serialize(streamWriter, Body);
            }
        }

        public BodyMeasurements ReadMeasurementsFromXml()
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "BodyMeasurements";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BodyMeasurements), root);
            if (!File.Exists(@"C:\Temp\body.xml"))
            {
                return new BodyMeasurements();
            }
            string xml = File.ReadAllText(@"C:\Temp\body.xml");
            StringReader stringReader = new StringReader(xml);
            var item = (BodyMeasurements)xmlSerializer.Deserialize(stringReader);
            return item;
        }
    }
}
