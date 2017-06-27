using System.Collections.Generic;
using System.Linq;
using FubuCoreDemo.MVC.Entities;
using Raven.Abstractions.Data;
using Raven.Client;

namespace FubuCoreDemo.MVC.DataAccess
{
    public class ItemListDataAccess : ITodoItemsDataAccess
    {
        private readonly IDocumentSession _documentSession;

        public ItemListDataAccess(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        private List<TodoItem> _items = new List<TodoItem>();

        public void RemoveItemFromList(TodoItem item)
        {
            _documentSession.Delete(item);
        }

        public void AddItemToList(TodoItem item)
        {
            _items.Add(item);

            _documentSession.Store(item);
        }

        public List<TodoItem> LoadItems()
        {
            return _documentSession.Query<TodoItem>().ToList();
        }

        public void SaveItem(TodoItem item)
        {
            var toSave = _documentSession.Load<TodoItem>(item.Id);

            toSave.Text = item.Text;
            toSave.IsComplete = item.IsComplete;
        }

        public TodoItem GetTodoItem(string id)
        {
            return _documentSession.Load<TodoItem>(id);
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