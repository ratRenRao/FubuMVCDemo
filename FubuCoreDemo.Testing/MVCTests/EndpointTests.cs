using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FubuCoreDemo.MVC.DataAccess;
using FubuCoreDemo.MVC.Endpoints;
using FubuCoreDemo.MVC.Entities;
using FubuCoreDemo.MVC.ViewModels;
using FubuMVC.RavenDb.RavenDb;
using FubuMVC.RavenDb.RavenDb.Multiple;
using Xunit;
using Shouldly;
using Moq;
using Raven.Client;

namespace FubuCoreDemo.Testing.MVCTests
{
    public class EndpointTests
    {
        public MockRepository MockRepository = new MockRepository(MockBehavior.Default);

        [Fact]
        public void get_Todo_List_should_call_DataAccess_LoadItems()
        {
            var mockTodoItemsDataAccess = MockRepository.Create<IListDataAccess>();
            var mockDocumentSession = MockRepository.Create<IDocumentSession<RavenDbSettings>>();
            var itemsToReturn = new List<TodoItem> { new TodoItem { Text = "item1 " }, new TodoItem() };

            mockTodoItemsDataAccess.Verify(x => x.LoadItems());
            mockTodoItemsDataAccess.Object.LoadItems().ShouldBe(itemsToReturn);

            var endpoint = new TodoItemEndpoint(mockTodoItemsDataAccess.Object, mockDocumentSession.Object);

            var result = endpoint.get_Todo_List();

            mockTodoItemsDataAccess.Verify(x => x.LoadItems());
            result.ShouldBeOfType(typeof(ListItemsViewModel));
            result.Items.Count.ShouldBe(2);
        }

        [Fact]
        public void get_Todo_should_call_GetTodoItem_from_dataAccess_with_correct_params()
        {
            var mockTodoItemsDataAccess = MockRepository.Create<IListDataAccess>();
            mockTodoItemsDataAccess.SetupAllProperties();

            var mockDocumentSession = MockRepository.Create<IDocumentSession>();
            mockDocumentSession.SetupAllProperties();

            var todoGetReqeust = new TodoGetRequest { Id = "item1" };

            var endpoint = new TodoItemEndpoint(mockTodoItemsDataAccess.Object,
                                                mockDocumentSession.Object);

            endpoint.get_Todo(todoGetReqeust);

            mockTodoItemsDataAccess.Verify(
                todoItemDataAccess => todoItemDataAccess.GetItemById(todoGetReqeust.Id));
        }

        [Fact]
        public void post_Todo_should_add_item_and_save_changes()
        {
            var mockTodoItemsDataAccess = MockRepository.Create<IListDataAccess>();
            mockTodoItemsDataAccess.SetupAllProperties();

            var mockDocumentSession = MockRepository.Create<IDocumentSession>();
            mockDocumentSession.SetupAllProperties();

            var endpoint = new TodoItemEndpoint(mockTodoItemsDataAccess.Object,
                                                mockDocumentSession.Object);
            var todo = new TodoItem { Id = "1", Text = "do some stuff" };

            var result = endpoint.post_Todo(todo);

            mockTodoItemsDataAccess.Verify(da => da.StoreItem(todo));
            mockDocumentSession.Verify(ds => ds.SaveChanges());
        }
    }
}
