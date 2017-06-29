using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using FubuCoreDemo.MVC.DataAccess;
using FubuCoreDemo.MVC.Entities;
using FubuCoreDemo.MVC.ViewModels;
using Raven.Client;

namespace FubuCoreDemo.MVC.Endpoints
{
    public class TodoItemEndpoint
    {
        private readonly IListDataAccess _taskListDataAccess;
        private readonly IDocumentSession _documentSession;
        private ItemList _itemList;

        public TodoItemEndpoint(IListDataAccess taskListDataAccess, IDocumentSession documentSession)
        {
            _taskListDataAccess = taskListDataAccess;
            _documentSession = documentSession;

            _itemList = new ItemList(_taskListDataAccess);
        }
        
        public List<TodoItem> get_Todo_List()
        {
            _taskListDataAccess.ClearAll();

            post_Todo(new TodoItem
            {
                Text = "First Task",
                IsComplete = false
            });

            post_Todo(new TodoItem
            {
                Text = "Second Task",
                IsComplete = false
            });

            var items = _taskListDataAccess.LoadItems<TodoItem>();
            return items;
        }

        public TodoItem get_Todo(TodoGetRequest todo)
        {
            var item = _taskListDataAccess.GetItemById<TodoItem>(todo.Id);
            return item;
        }
        
        public AddItemResponse post_Todo(TodoItem item)
        {
            _taskListDataAccess.SaveItem(item);

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
            var todoItem = _taskListDataAccess.GetItemById<TodoItem>(todo.Id);
            if (todoItem == null)
                return new DeleteItemResponse {HttpStatusCode = HttpStatusCode.NotFound};
            _taskListDataAccess.RemoveItemFromList(todoItem);
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