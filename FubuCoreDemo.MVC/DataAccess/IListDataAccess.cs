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
        void RemoveItemFromList(string id);
        void StoreItem(TodoItem item);
        List<TodoItem> LoadItems();
        void UpdateItem(TodoItem item);
        TodoItem GetItem(string id);
        void ClearAll();
        void SaveChanges();
        void SaveItem(TodoItem item);
    }
}
