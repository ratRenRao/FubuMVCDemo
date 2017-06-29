using System.Collections.Generic;
using System.Linq;
using FubuCoreDemo.MVC.Entities;
using Raven.Abstractions.Data;
using Raven.Client;

namespace FubuCoreDemo.MVC.DataAccess
{
    public class ListDataAccess<T> : IListDataAccess
    {
        private readonly IDocumentSession _documentSession;
        private List<T> _list = new List<T>();

        public ListDataAccess(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public void RemoveItemFromList<T>(T item)
        {
            _documentSession.Delete(item);
        }

        public void StoreItem<T>(T item)
        {
            _documentSession.Store(item);
        }

        public List<T> LoadItems<T>()
        {
            return _documentSession.Query<T>().ToList();
        }

        public void SaveChanges()
        {
            _documentSession.SaveChanges();
        }

        public void SaveItem<T>(T item)
        {
            _documentSession.Store(item);
            _documentSession.SaveChanges();
        }

        public void UpdateItem<T>(string id, T item)
        {
            var dbItem = _documentSession.Load<T>(id);

            _documentSession.Delete(dbItem);
            _documentSession.SaveChanges();
            SaveItem(item);
        }

        public T GetItemById<T>(string id)
        {
            return _documentSession.Load<T>(id);
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