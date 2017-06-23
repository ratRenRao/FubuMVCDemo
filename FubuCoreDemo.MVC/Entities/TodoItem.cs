namespace FubuCoreDemo.MVC.Entities
{
    public class TodoItem
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public bool IsComplete { get; set; }

        public void MarkCompleted()
        {
            IsComplete = true;
        }
    }
}