using System.Collections.Generic;
using FubuMVCTODO.Domain;

namespace FubuMVCTODO
{
    public class ListTodoItemsViewModel
    {
        public ListTodoItemsViewModel() { }

        public ListTodoItemsViewModel(List<TodoItem> items)
        {
            Items = items;
        }

        public List<TodoItem> Items { get; set; }
    }
}