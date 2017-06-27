using System.Collections.Generic;
using FubuCoreDemo.MVC.Entities;

namespace FubuCoreDemo.MVC.ViewModels
{
    public class ListItemsViewModel
    {
        public ListItemsViewModel() { }

        public ListItemsViewModel(List<TodoItem> items)
        {
            Items = items;
        }

        public List<TodoItem> Items { get; set; }
    }
}