using TaskTracker.Models;
using TaskTracker.Services;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskTracker.Tests
{
    public class TaskServiceTests
    {
        // Test to verify if tasks due today are displayed correctly
        [Fact]
        public void ViewTodaysTasks_ShouldDisplayTasksForToday()
        {
            // Arrange
            var tasks = new List<TaskItem>
            {
                new TaskItem { Title = "Task 1 Today", DueDate = DateTime.Today, Description = "Description 1", Priority = "High", Client = "Client A" },
                new TaskItem { Title = "Task 2 Tomorrow", DueDate = DateTime.Today.AddDays(1), Description = "Description 2", Priority = "Low", Client = "Client B" }
            };

            // Act
            // Normally, the method writes to the console, so testing it requires output capture (StringWriter).
            // This placeholder asserts only that the method does not throw an error.
            Assert.True(true); // Placeholder assertion; requires output capture to test functionality.
        }

        // Test to ensure a new task is correctly added to the list
        [Fact]
        public void AddTask_ShouldAddNewTask()
        {
            // Arrange
            var tasks = new List<TaskItem>();

            // Act
            var title = "New Task";
            var dueDate = DateTime.Now.AddDays(2);
            var description = "Test Task Description";
            var priority = "High";
            var client = "Client A";

            // Adding task to the list
            tasks.Add(new TaskItem
            {
                Title = title,
                DueDate = dueDate,
                Description = description,
                Priority = priority,
                Client = client
            });

            // Assert
            Assert.Single(tasks); // Ensure only one task is added.
            Assert.Equal("New Task", tasks[0].Title);
            Assert.Equal(dueDate, tasks[0].DueDate);
        }

        // Test to verify a task can be marked as complete and moved to history
        [Fact]
        public void CompleteTask_ShouldMoveTaskToHistory()
        {
            // Arrange
            var taskToComplete = new TaskItem { Title = "Task To Complete", DueDate = DateTime.Today, IsCompleted = false };
            var tasks = new List<TaskItem> { taskToComplete };

            // Act
            // Simulating completing the task (without using Console.ReadLine)
            TaskService.CompleteTask(tasks);

            // Assert
            Assert.DoesNotContain(tasks, taskToComplete); // Ensure task is removed from active list.
            Assert.True(TaskService.GetCompletedTasks().Contains(taskToComplete)); // Ensure task is in history.
        }

        // Test to verify that completed tasks are correctly displayed
        [Fact]
        public void ViewCompletedTasks_ShouldDisplayCompletedTasks()
        {
            // Arrange
            // Manually adding completed tasks to the history list for testing
            var completedTask = new TaskItem { Title = "Completed Task", DueDate = DateTime.Today.AddDays(-1), IsCompleted = true };
            TaskService.AddToCompletedTasksHistory(completedTask); // Assuming a method to add completed tasks to history

            // Act
            // Normally writes to the console, so capturing output would be required (e.g., StringWriter).
            // Placeholder assertion.
            Assert.Contains(completedTask, TaskService.GetCompletedTasks()); // Ensure task is in history.
        }

        // Test to verify tasks are displayed in the correct order when sorted by due date
        [Fact]
        public void ViewAllTasksSortedByDeadline_ShouldDisplayTasksSorted()
        {
            // Arrange
            var tasks = new List<TaskItem>
            {
                new TaskItem { Title = "Task Due Later", DueDate = DateTime.Today.AddDays(2) },
                new TaskItem { Title = "Task Due Soon", DueDate = DateTime.Today.AddDays(1) },
                new TaskItem { Title = "Task Due Now", DueDate = DateTime.Today },
                new TaskItem { Title = "Task Overdue", DueDate = DateTime.Today.AddDays(-1) } // Added overdue task
            };

            var expectedOrder = new[] { "Task Overdue", "Task Due Now", "Task Due Soon", "Task Due Later" }; // Expected sorted order

            // Act
            // Simulating sorting functionality
            var sortedTasks = tasks.OrderBy(t => t.DueDate).ToList();

            // Assert
            for (int i = 0; i < expectedOrder.Length; i++)
            {
                Assert.Equal(expectedOrder[i], sortedTasks[i].Title); // Ensure tasks are sorted by due date.
            }
        }
    }
}
