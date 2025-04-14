using TaskTracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace TaskTracker.Services
{
    public static class TaskService
    {
        // This list will hold completed tasks, which are moved to history
        private static List<TaskItem> completedTasksHistory = new List<TaskItem>();

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
                    Console.WriteLine($"   Description: {task.Description ?? "No description"}");
                    Console.WriteLine($"   Priority: {task.Priority ?? "No priority"}");
                    Console.WriteLine($"   Client: {task.Client ?? "No client"}");

                    // Highlight overdue tasks in red
                    if (task.DueDate.Date < today)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("   OVERDUE");
                        Console.ResetColor();
                    }
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
            if (!DateTime.TryParse(Console.ReadLine(), out var dueDate))
            {
                Console.WriteLine("Invalid date format.");
                Console.WriteLine("Press enter to return to menu.");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter task description: ");
            var description = Console.ReadLine();

            Console.Write("Enter task priority: ");
            var priority = Console.ReadLine();

            Console.Write("Enter client name: ");
            var client = Console.ReadLine();

            tasks.Add(new TaskItem
            {
                Title = title,
                DueDate = dueDate,
                Description = description,
                Priority = priority,
                Client = client
            });

            Console.WriteLine("Task added successfully!");
            Console.WriteLine("Press enter to return to menu.");
            Console.ReadLine();
        }

        public static void CompleteTask(List<TaskItem> tasks)
        {
            Console.Clear();
            Console.WriteLine("Mark task as complete:");

            // Create a list of tasks that are not completed
            var incompleteTasks = tasks.Where(t => !t.IsCompleted).ToList();

            // Check if there are any incomplete tasks
            if (!incompleteTasks.Any())
            {
                Console.WriteLine("There are no incomplete tasks.");
                Console.WriteLine("Press enter to return to menu.");
                Console.ReadLine();
                return;
            }

            // Sort tasks by DueDate and highlight overdue tasks
            for (int i = 0; i < incompleteTasks.Count; i++)
            {
                var task = incompleteTasks[i];
                if (task.DueDate < DateTime.Today)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{i + 1}. {task.Title} - OVERDUE");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{i + 1}. {task.Title} (Due: {task.DueDate.ToShortDateString()})");
                }

                Console.WriteLine($"   Description: {task.Description ?? "No description"}");
                Console.WriteLine($"   Priority: {task.Priority ?? "No priority"}");
                Console.WriteLine($"   Client: {task.Client ?? "No client"}");
            }

            Console.Write("Enter task number to complete: ");
            if (int.TryParse(Console.ReadLine(), out int taskIndex) && taskIndex > 0 && taskIndex <= incompleteTasks.Count)
            {
                var task = incompleteTasks[taskIndex - 1];

                // Move completed task to history
                completedTasksHistory.Add(task);

                // Remove from active tasks
                tasks.Remove(task);

                Console.WriteLine("Task marked as complete and moved to history!");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }

            Console.WriteLine("Press enter to return to menu.");
            Console.ReadLine();
        }

        // New method to view all pending tasks sorted by due date
        public static void ViewAllTasksSortedByDeadline(List<TaskItem> tasks)
        {
            Console.Clear();
            Console.WriteLine("All Pending Tasks Sorted by Due Date:");

            // Filter out completed tasks and sort by due date
            var sortedTasks = tasks.Where(t => !t.IsCompleted)
                                   .OrderBy(t => t.DueDate)
                                   .ToList();

            if (!sortedTasks.Any())
            {
                Console.WriteLine("No pending tasks.");
                Console.WriteLine("Press enter to return to menu.");
                Console.ReadLine();
                return;
            }

            // Display the sorted tasks
            int i = 1;
            foreach (var task in sortedTasks)
            {
                Console.WriteLine($"{i++}. {task.Title} (Due: {task.DueDate.ToShortDateString()})");
                Console.WriteLine($"   Description: {task.Description ?? "No description"}");
                Console.WriteLine($"   Priority: {task.Priority ?? "No priority"}");
                Console.WriteLine($"   Client: {task.Client ?? "No client"}");

                // Highlight overdue tasks
                if (task.DueDate < DateTime.Today)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("   OVERDUE");
                    Console.ResetColor();
                }
            }

            Console.WriteLine("\nPress enter to return to menu.");
            Console.ReadLine();
        }

        // Method to view completed tasks
        public static void ViewCompletedTasks()
        {
            Console.Clear();
            Console.WriteLine("Completed Tasks (History):");

            if (!completedTasksHistory.Any())
            {
                Console.WriteLine("No tasks have been completed yet.");
            }

            foreach (var task in completedTasksHistory)
            {
                Console.WriteLine($"{task.Title} (Completed: {task.DueDate.ToShortDateString()})");
                Console.WriteLine($"   Description: {task.Description ?? "No description"}");
                Console.WriteLine($"   Priority: {task.Priority ?? "No priority"}");
                Console.WriteLine($"   Client: {task.Client ?? "No client"}");
            }

            Console.WriteLine("\nPress enter to return to menu.");
            Console.ReadLine();
        }
    }
}
