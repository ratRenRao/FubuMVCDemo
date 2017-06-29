using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FubuCoreDemo.MVC.Entities;

namespace FubuCoreDemo.MVC.DataAccess
{
    public interface IListDataAccess
    {
        void RemoveItemFromList<T>(T item);
        void StoreItem<T>(T item);
        List<T> LoadItems<T>();
        void UpdateItem<T>(string id, T item);
        T GetItemById<T>(string id);
        void ClearAll();
        void SaveChanges();
        void SaveItem<T>(T item);
    }
}
