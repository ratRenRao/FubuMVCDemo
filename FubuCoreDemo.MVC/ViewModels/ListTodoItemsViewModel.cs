using System.Collections.Generic;
using FubuCoreDemo.MVC.Entities;

namespace FubuCoreDemo.MVC.ViewModels
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