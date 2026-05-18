namespace Todo_Managment_System.Entities
{
    public class TodoItem : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
    }
}
