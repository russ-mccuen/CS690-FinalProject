using TaskTracker.Models;

namespace TaskTracker.Services
{
    public static class InvoiceService
    {
        public static void CreateInvoice(List<Invoice> invoices)
        {
            Console.Clear();
            string? clientName = null;
            while (string.IsNullOrWhiteSpace(clientName))
            {
                Console.WriteLine("Enter client name:");
                clientName = Console.ReadLine();
            }


            Console.WriteLine("Enter amount due:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amountDue))
            {
                Console.WriteLine("Invalid amount. Press enter to return to menu.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Enter due date (yyyy-mm-dd):");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
            {
                Console.WriteLine("Invalid date. Press enter to return to menu.");
                Console.ReadLine();
                return;
            }

            int id = invoices.Count > 0 ? invoices.Max(i => i.Id) + 1 : 1;
            DateTime issueDate = DateTime.Now;

            Invoice newInvoice = new Invoice(id, clientName, amountDue, issueDate, dueDate);
            invoices.Add(newInvoice);

            Console.WriteLine("Invoice created successfully. Press enter to return to menu.");
            Console.ReadLine();
        }

        public static void ViewUnpaidInvoices(List<Invoice> invoices)
        {
            Console.Clear();
            Console.WriteLine("Unpaid Invoices:\n");

            var unpaid = invoices.Where(i => !i.IsPaid).ToList();
            if (unpaid.Count == 0)
            {
                Console.WriteLine("No unpaid invoices.");
            }
            else
            {
                foreach (var invoice in unpaid)
                {
                    Console.WriteLine($"ID: {invoice.Id} | Client: {invoice.ClientName} | Amount: {invoice.AmountDue:C} | Due: {invoice.DueDate:yyyy-MM-dd} | Status: {invoice.Status}");
                }
            }

            Console.WriteLine("\nPress enter to return to menu.");
            Console.ReadLine();
        }
    }
}
