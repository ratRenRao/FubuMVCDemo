using System.Collections.Generic;
using FubuCoreDemo.MVC.DataAccess;
using FubuCoreDemo.MVC.Entities;
using FubuMVC.Core;
using FubuMVC.Core.Continuations;
using Raven.Client;

namespace FubuCoreDemo.MVC.Endpoints
{
    public class HomeEndpoint
    {
        private readonly TodoItemsDataAccess _todoItemsDataAccess;
        private readonly IDocumentSession _documentSession;
        private ItemList _itemList;
        private HomeViewModel _homeViewModel;

        public HomeEndpoint(TodoItemsDataAccess todoItemsDataAccess, IDocumentSession documentSession)
        {
            _todoItemsDataAccess = todoItemsDataAccess;
            _documentSession = documentSession;
            _itemList = new ItemList(_todoItemsDataAccess);

            _homeViewModel = new HomeViewModel
            {
                Text = "Hello Fubu 3!!",
                Items = _itemList.TodoItems
            };
        }

        [UrlPattern("")] //overides the default translation of the action to a url (in this case, the get_index() with a default url pattern of "/index" will now have a blank url pattern, effectively turning it into the home page)
        public HomeViewModel get_index()
        {
            return _homeViewModel;
        }

        public FubuContinuation post_Home_Todo(TodoItem item)
        {
            _todoItemsDataAccess.AddItemToList(item);

            _documentSession.SaveChanges();

            return FubuContinuation.RedirectTo("~");
        }

        public FubuContinuation post_Home_Todo_Clear()
        {
            _todoItemsDataAccess.ClearAll();

            _documentSession.SaveChanges();

            return FubuContinuation.RedirectTo("~");
        }
    }

    public class HomeViewModel
    {
        public string Text { get; set; }

        public List<TodoItem> Items { get; set; }
    }
}