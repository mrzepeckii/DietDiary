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

        public BodyMeasurements body { get; private set; }

        public BodyMeasurementsService()
        {
            body = ReadItemsFromXml();
        }

        public void SetBodyMeasuremnts(int calf, int thight, int waist, int chest, int biceps)
        {
            body.Calf = calf;
            body.Thight = thight;
            body.Waist = waist;
            body.Chest = chest;
            body.Biceps = biceps;
        }

        public void SaveMeasurementsToXml()
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "BodyMeasurements";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BodyMeasurements), root);

            using (StreamWriter streamWriter = new StreamWriter(@"C:\Temp\body.xml"))
            {
                xmlSerializer.Serialize(streamWriter, body);
            }
        }

        public BodyMeasurements ReadItemsFromXml()
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
