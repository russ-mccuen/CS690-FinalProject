namespace TaskTracker.Models
{
    public class TaskItem
    {
        public required string Title { get; set; }
        public required DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;
        public string? Description { get; set; }
        public string? Priority { get; set; }
        public string? Client { get; set; }
    }
}
