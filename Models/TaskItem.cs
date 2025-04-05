namespace TaskTracker.Models
{
    public class TaskItem
    {
        public string Title { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
