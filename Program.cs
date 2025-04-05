using TaskTracker.Models;
using TaskTracker.Services;

class Program
{
    static void Main()
    {
        List<TaskItem> tasks = StorageService.LoadTasks();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Task Manager v1.0.0\n");
            Console.WriteLine("1. View today's tasks");
            Console.WriteLine("2. Add new task");
            Console.WriteLine("3. Complete task");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            var input = Console.ReadLine();
            switch (input)
            {
                case "1": TaskService.ViewTodaysTasks(tasks); break;
                case "2": TaskService.AddTask(tasks); break;
                case "3": TaskService.CompleteTask(tasks); break;
                case "4": StorageService.SaveTasks(tasks); return;
                default:
                    Console.WriteLine("Invalid input. Press enter to continue.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
