using System.Net;
using FubuCoreDemo.MVC.DataAccess;
using FubuCoreDemo.MVC.Entities;
using FubuCoreDemo.MVC.ViewModels;
using Raven.Client;

namespace FubuCoreDemo.MVC.Endpoints
{
    public class TodoItemEndpoint
    {
        private readonly ITodoItemsDataAccess _todoItemsDataAccess;
        private readonly IDocumentSession _documentSession;
        private ItemList _itemList;

        public TodoItemEndpoint(ITodoItemsDataAccess todoItemsDataAccess, IDocumentSession documentSession)
        {
            _todoItemsDataAccess = todoItemsDataAccess;
            _documentSession = documentSession;

            _itemList = new ItemList(_todoItemsDataAccess);
        }
        
        public ListItemsViewModel get_Todo_List()
        {
            var items = _todoItemsDataAccess.LoadItems();

            return new ListItemsViewModel(items);
        }

        
        public TodoItem get_Todo(TodoGetRequest todo)
        {
            var item = _todoItemsDataAccess.GetTodoItem(todo.Id);

            return item;
        }
        
        public AddItemResponse post_Todo(TodoItem item)
        {
            _todoItemsDataAccess.AddItemToList(item);
            _documentSession.SaveChanges();

            return new AddItemResponse(item);
        }

        public UpdateItemResponse post_Todo_MarkComplete(UpdateTodoItemRequest item)
        {
            _itemList.MarkItemComplete(item.Item.Id);
            _documentSession.SaveChanges();

            return new UpdateItemResponse {HttpStatusCode = HttpStatusCode.OK};
        }

        public DeleteItemResponse post_Todo_Delete(TodoDeleteRequest todo)
        {
            var todoItem = _todoItemsDataAccess.GetTodoItem(todo.Id);
            if (todoItem == null)
                return new DeleteItemResponse {HttpStatusCode = HttpStatusCode.NotFound};
            _todoItemsDataAccess.RemoveItemFromList(todoItem);
            _documentSession.SaveChanges();

            return new DeleteItemResponse { HttpStatusCode = HttpStatusCode.OK };
        }
    }

    public class UpdateTodoItemRequest
    {
        public TodoItem Item { get; set; }
    }

    public class TodoGetRequest
    {
        public string Id { get; set; }
    }

    public class TodoDeleteRequest
    {
        public string Id { get; set; }
    }
}