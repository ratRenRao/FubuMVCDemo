using FubuCoreDemo.MVC.Entities;

namespace FubuCoreDemo.MVC.ViewModels
{
    public class AddTodoItemResponse
    {
        public AddTodoItemResponse()
        {
            
        }

        public AddTodoItemResponse(TodoItem todoItem)
        {
            TodoItem = todoItem;
        }

        public TodoItem TodoItem { get; set; }
    }
}