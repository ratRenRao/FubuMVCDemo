using FubuCoreDemo.MVC.Entities;

namespace FubuCoreDemo.MVC.ViewModels
{
    public class AddItemResponse
    {
        public AddItemResponse()
        {
            
        }

        public AddItemResponse(TodoItem todoItem)
        {
            TodoItem = todoItem;
        }

        public TodoItem TodoItem { get; set; }
    }
}