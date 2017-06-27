using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FubuCoreDemo.MVC.Entities;

namespace FubuCoreDemo.MVC.DataAccess
{
    public interface ITodoItemsDataAccess
    {
        void RemoveItemFromList(TodoItem item);
        void AddItemToList(TodoItem item);
        List<TodoItem> LoadItems();
        void SaveItem(TodoItem item);
        TodoItem GetTodoItem(string id);
        void ClearAll();
    }
}
