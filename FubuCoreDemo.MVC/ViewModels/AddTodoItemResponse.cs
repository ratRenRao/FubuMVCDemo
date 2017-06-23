using FubuMVCTODO.Domain;

namespace FubuMVCTODO.Todo
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