using System.Collections.Generic;
using System.Linq;
using FubuCoreDemo.MVC.Entities;
using Raven.Abstractions.Data;
using Raven.Client;

namespace FubuCoreDemo.MVC.DataAccess
{
    public class ListDataAccess : IListDataAccess
    {
        private readonly IDocumentSession _documentSession;
        private List<TodoItem> _items = new List<TodoItem>();

        public ListDataAccess(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public void RemoveItemFromList(string item)
        {
            //_documentSession.Delete(item);
            _items.Remove(_items.SingleOrDefault(x => x.Id == item));
        }

        public void StoreItem(TodoItem item)
        {
            _documentSession.Store(item);
        }

        public List<TodoItem> LoadItems()
        {
            //return _documentSession.Query().ToList();
            return _items;
        }

        public void SaveChanges()
        {
            _documentSession.SaveChanges();
        }

        public void SaveItem(TodoItem item)
        {
            //_documentSession.Store(item);
            //_documentSession.SaveChanges();
            _items.Add(item);
        }

        public void UpdateItem(TodoItem item)
        {
            //var dbItem = _documentSession.Load<TodoItem>(new[] {item.Id});

            //_documentSession.Delete(dbItem);
            //_documentSession.SaveChanges();
            //SaveItem(item);
            _items.Single(x => x.Id == item.Id).IsComplete = item.IsComplete;
            _items.Single(x => x.Id == item.Id).Text = item.Text;
        }

        public TodoItem GetItem(string id)
        {
            //return _documentSession.Load<TodoItem>(new[] {id}).First();
            return _items.SingleOrDefault(x => x.Id == id);
        }

        public void ClearAll()
        {
            var indexDefinitions = _documentSession.Advanced.DocumentStore.DatabaseCommands.GetIndexes(0, 10);
            foreach (var indexDefinition in indexDefinitions)
            {
                _documentSession.Advanced.DocumentStore.DatabaseCommands.DeleteByIndex(indexDefinition.Name, new IndexQuery());
            }
        }
    }
}