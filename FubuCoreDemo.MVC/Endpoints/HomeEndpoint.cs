using System.Collections.Generic;
using FubuCoreDemo.MVC.DataAccess;
using FubuCoreDemo.MVC.Entities;
using FubuMVC.Core;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.ServiceBus.Runtime.Serializers;
using Raven.Client;

namespace FubuCoreDemo.MVC.Endpoints
{
    public class HomeEndpoint
    {
        private readonly IDocumentSession _documentSession;
        private readonly DataAccess.ListDataAccess _listDataAccess;
        private readonly HomeViewModel _homeViewModel;

        public HomeEndpoint(DataAccess.ListDataAccess listDataAccess, IDocumentSession documentSession)
        {
            _listDataAccess = listDataAccess;
            _documentSession = documentSession;

            _homeViewModel = new HomeViewModel
            {
                Text = "All Your Base",
                Items = new ItemList(_listDataAccess).TodoItems
            };
        }

        [UrlPattern("")] //overides the default translation of the action to a url (in this case, the get_index() with a default url pattern of "/index" will now have a blank url pattern, effectively turning it into the home page)
        public HomeViewModel get_index()
        {
            return _homeViewModel;
        }

        public FubuContinuation post_Home_Todo(TodoItem item)
        {
            _listDataAccess.StoreItem(item);
            _documentSession.SaveChanges();
            return FubuContinuation.RedirectTo("~");
        }

        public FubuContinuation post_Home_Todo_Clear()
        {
            _listDataAccess.ClearAll();
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