using System;
using System.Collections.Generic;
using System.Text;

namespace DietDiary.App.Abstract
{
    public interface IService<T>
    {
        List<T> Items { get; set; }

        int AddItem(T item);
        int UpdateItem(T item);
        void RemoveItem(T item);
        //void ShowDetails(T item);
        List<T> GetAllItems();
        T GetItemById(int id);
        //T GetItemByName(string name);
        int GetLastId();

    }
}
