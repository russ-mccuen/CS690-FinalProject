using TaskTracker.Models;
using System.Text.Json;

namespace TaskTracker.Services
{
    public static class StorageService
    {
        private static string taskFile = "tasks.json";
        private static string invoiceFile = "invoices.json";
        private static string paymentFile = "payments.json";

        public static List<TaskItem> LoadTasks()
        {
            if (!File.Exists(taskFile)) return new List<TaskItem>();
            var json = File.ReadAllText(taskFile);
            return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }

        public static void SaveTasks(List<TaskItem> tasks)
        {
            var json = JsonSerializer.Serialize(tasks);
            File.WriteAllText(taskFile, json);
        }

        public static List<Invoice> LoadInvoices()
        {
            if (!File.Exists(invoiceFile)) return new List<Invoice>();
            var json = File.ReadAllText(invoiceFile);
            return JsonSerializer.Deserialize<List<Invoice>>(json) ?? new List<Invoice>();
        }

        public static void SaveInvoices(List<Invoice> invoices)
        {
            var json = JsonSerializer.Serialize(invoices);
            File.WriteAllText(invoiceFile, json);
        }

        public static List<Payment> LoadPayments()
        {
            if (!File.Exists(paymentFile)) return new List<Payment>();
            var json = File.ReadAllText(paymentFile);
            return JsonSerializer.Deserialize<List<Payment>>(json) ?? new List<Payment>();
        }

        public static void SavePayments(List<Payment> payments)
        {
            var json = JsonSerializer.Serialize(payments);
            File.WriteAllText(paymentFile, json);
        }
    }
}