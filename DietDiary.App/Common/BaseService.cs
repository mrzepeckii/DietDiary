using DietDiary.App.Abstract;
using DietDiary.Domain.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DietDiary.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }

        public BaseService()
        {
            Items = new List<T>();
        }

        public int AddItem(T item)
        {
            Items.Add(item);
            return item.Id;
        }

        public List<T> GetAllItems()
        {
            return Items;
        }

        public T GetItemById(int id)
        {
            var tempItem = Items.FirstOrDefault(p => p.Id == id);
            return tempItem;
        }

        public void RemoveItem(T item)
        {
            Items.Remove(item);
        }

        public int UpdateItem(T item)
        {
            var entity = GetItemById(item.Id);
            if (entity != null)
            {
                entity = item;
            }
            return entity.Id;
        }

        public int GetLastId()
        {
            int lastId;
            if (Items.Any())
            {
                lastId = Items.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
        }

        public void SaveItemsToXml(string elementName, string path)
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = elementName;
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>), root);

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                xmlSerializer.Serialize(streamWriter, Items);
            }
        }

        public IEnumerable<T> ReadItemsFromXml(string elementName, string path)
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = elementName;
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>), root);
            string xml = File.ReadAllText(path);
            StringReader stringReader = new StringReader(xml);
            var items = (IEnumerable<T>)xmlSerializer.Deserialize(stringReader);
            return items;
        }
    }
}
