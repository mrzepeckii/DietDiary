using DietDiary.App.Abstract;
using DietDiary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        /* public T GetItemByName(string name)
         {
             var tempItem = Items.FirstOrDefault(p => p.Name == name);
             return tempItem;
         }*/

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


        /*public void ShowDetails(T item)
        {
            throw new NotImplementedException();
        }*/


    }
}
