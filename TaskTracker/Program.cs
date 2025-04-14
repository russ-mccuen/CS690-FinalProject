using TaskTracker.Models;
using TaskTracker.Services;

class Program
{
    static void Main()
    {
        List<TaskItem> tasks = StorageService.LoadTasks();
        List<Invoice> invoices = StorageService.LoadInvoices();
        List<Payment> payments = StorageService.LoadPayments();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Task Manager v2.0.0\n");
            Console.WriteLine("1. View today's tasks");
            Console.WriteLine("2. Add new task");
            Console.WriteLine("3. Complete task");
            Console.WriteLine("4. View completed tasks");
            Console.WriteLine("5. Create invoice");
            Console.WriteLine("6. View unpaid invoices");
            Console.WriteLine("7. Record a payment");
            Console.WriteLine("8. View all tasks sorted by due date");  // Added new option
            Console.WriteLine("9. Exit");
            Console.Write("Select an option: ");

            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    TaskService.ViewTodaysTasks(tasks);
                    break;
                case "2":
                    TaskService.AddTask(tasks);
                    break;
                case "3":
                    TaskService.CompleteTask(tasks);
                    break;
                case "4":
                    TaskService.ViewCompletedTasks();
                    break;
                case "5":
                    InvoiceService.CreateInvoice(invoices);
                    break;
                case "6":
                    InvoiceService.ViewUnpaidInvoices(invoices);
                    break;
                case "7":
                    PaymentService.RecordPayment(invoices, payments);
                    break;
                case "8":
                    TaskService.ViewAllTasksSortedByDeadline(tasks); // Calling the new method
                    break;
                case "9":
                    StorageService.SaveTasks(tasks);
                    StorageService.SaveInvoices(invoices);
                    StorageService.SavePayments(payments);
                    return;
                default:
                    Console.WriteLine("Invalid input. Press enter to continue.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
