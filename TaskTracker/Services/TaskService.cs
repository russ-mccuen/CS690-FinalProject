using TaskTracker.Models;

namespace TaskTracker.Services;

public static class TaskService
{
    public static void ViewTodaysTasks(List<TaskItem> tasks)
    {
        Console.Clear();
        Console.WriteLine("Today's Tasks:");
        var today = DateTime.Today;
        int i = 1;
        foreach (var task in tasks)
        {
            if (!task.IsCompleted && task.DueDate.Date == today)
            {
                Console.WriteLine($"{i++}. {task.Title} (Due: {task.DueDate.ToShortDateString()})");
            }
        }
        Console.WriteLine("\nPress enter to return to menu.");
        Console.ReadLine();
    }

    public static void AddTask(List<TaskItem> tasks)
{
    Console.Clear();
    Console.Write("Enter task title: ");
    var title = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(title))
    {
        Console.WriteLine("Title cannot be empty.");
        Console.WriteLine("Press enter to return to menu.");
        Console.ReadLine();
        return;
    }

    Console.Write("Enter due date (yyyy-mm-dd): ");
    if (DateTime.TryParse(Console.ReadLine(), out var dueDate))
    {
        tasks.Add(new TaskItem { Title = title, DueDate = dueDate });
        Console.WriteLine("Task added successfully!");
    }
    else
    {
        Console.WriteLine("Invalid date format.");
    }

    Console.WriteLine("Press enter to return to menu.");
    Console.ReadLine();
}

    public static void CompleteTask(List<TaskItem> tasks)
    {
        Console.Clear();
        Console.WriteLine("Mark task as complete:");
        for (int i = 0; i < tasks.Count; i++)
        {
            if (!tasks[i].IsCompleted)
            {
                Console.WriteLine($"{i + 1}. {tasks[i].Title} (Due: {tasks[i].DueDate.ToShortDateString()})");
            }
        }
        Console.Write("Enter task number to complete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
        {
            if (!tasks[index - 1].IsCompleted)
            {
                tasks[index - 1].IsCompleted = true;
                Console.WriteLine("Task marked as complete!");
            }
            else
            {
                Console.WriteLine("Task is already completed.");
            }
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
        Console.WriteLine("Press enter to return to menu.");
        Console.ReadLine();
    }
}
