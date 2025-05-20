namespace ToDoApp.Models
{
    internal class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsDone { get; set; }
        public int GroupId { get; set; }
        public override string ToString() => Title;
    }
}
