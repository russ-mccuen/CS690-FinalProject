using System.Text.Json;
using TaskTracker.Models;

namespace TaskTracker.Services;

public static class StorageService
{
    private static readonly string filePath = "tasks.json";

    public static List<TaskItem> LoadTasks()
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }
        return new List<TaskItem>();
    }

    public static void SaveTasks(List<TaskItem> tasks)
    {
        var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}
