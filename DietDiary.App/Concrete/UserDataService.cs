using DietDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace DietDiary.App.Concrete
{
    public class UserDataService
    {
        public UserData userData { get; private set; }

        public UserDataService()
        {
            userData = ReadUserDataFromXml();
        }

        public void SetUserData(int age, double weight, int height)
        {
            userData.Age = age;
            userData.Weight = weight;
            userData.Height = height;
        }

        public void SaveUserDataToXml()
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "UserData";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserData), root);

            using (StreamWriter streamWriter = new StreamWriter(@"C:\Temp\userData.xml"))
            {
                xmlSerializer.Serialize(streamWriter, userData);
            }
        }

        public UserData ReadUserDataFromXml()
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "UserData";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserData), root);
            if (!File.Exists(@"C:\Temp\userData.xml"))
            {
                return new UserData();
            }
            string xml = File.ReadAllText(@"C:\Temp\userData.xml");
            StringReader stringReader = new StringReader(xml);
            var item = (UserData)xmlSerializer.Deserialize(stringReader);
            return item;
        }
    }
}
