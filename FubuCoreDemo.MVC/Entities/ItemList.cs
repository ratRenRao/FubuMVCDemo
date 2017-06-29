using System.Collections.Generic;
using FubuCoreDemo.MVC.DataAccess;

namespace FubuCoreDemo.MVC.Entities
{
    public class ItemList
    {
        private readonly IListDataAccess _listDataAccess;

        public ItemList(IListDataAccess listDataAccess)
        {
            _listDataAccess = listDataAccess;
        }

        public List<TodoItem> TodoItems
        {
            get
            {
                var items = _listDataAccess.LoadItems();
                return items;
            }
        }

        public void AddItem(TodoItem item)
        {
            _listDataAccess.StoreItem(item);
        }

        public void RemoveItem(string id)
        {
            _listDataAccess.RemoveItemFromList(id);
        }

        //public void MarkItemComplete(string itemId)
        //{
        //    var item = TodoItems.Find(i => i.Id == itemId);
        //    item.IsComplete = true;
        //    _listDataAccess.SaveItem(item);
        //}
    }
}