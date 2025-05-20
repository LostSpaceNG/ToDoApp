namespace ToDoApp.Models
{
    internal class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public override string ToString() => Name;
    }
}
