using System.Collections.Generic;
using FubuCoreDemo.MVC.DataAccess;

namespace FubuCoreDemo.MVC.Entities
{
    public class ItemList
    {
        private readonly ITodoItemsDataAccess _todoItemsDataAccess;

        public ItemList(ITodoItemsDataAccess todoItemsDataAccess)
        {
            _todoItemsDataAccess = todoItemsDataAccess;
        }

        public List<TodoItem> TodoItems
        {
            get
            {
                var items = _todoItemsDataAccess.LoadItems();
                return items;
            }
        }

        public void AddItem(TodoItem item)
        {
            _todoItemsDataAccess.AddItemToList(item);
        }

        public void RemoveItem(TodoItem item)
        {
            _todoItemsDataAccess.RemoveItemFromList(item);
        }

        public void MarkItemComplete(string itemId)
        {
            var item = TodoItems.Find(i => i.Id == itemId);
            item.IsComplete = true;
            _todoItemsDataAccess.SaveItem(item);
        }
    }
}