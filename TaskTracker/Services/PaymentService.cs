using TaskTracker.Models;

namespace TaskTracker.Services
{
    public static class PaymentService
    {
        public static void RecordPayment(List<Invoice> invoices, List<Payment> payments)
        {
            Console.Clear();
            Console.WriteLine("Enter the invoice ID to apply a payment:");
            if (!int.TryParse(Console.ReadLine(), out int invoiceId))
            {
                Console.WriteLine("Invalid invoice ID. Press enter to return to menu.");
                Console.ReadLine();
                return;
            }

            var target = invoices.FirstOrDefault(i => i.Id == invoiceId);
            if (target == null)
            {
                Console.WriteLine("Invoice not found. Press enter to return to menu.");
                Console.ReadLine();
                return;
            }

            if (target.IsPaid)
            {
                Console.WriteLine("This invoice is already marked as paid. Press enter to return to menu.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Invoice found. Client: {target.ClientName}, Amount Due: {target.AmountDue}");
            Console.WriteLine("Enter the payment amount:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Invalid amount. Press enter to return to menu.");
                Console.ReadLine();
                return;
            }

            if (amount != target.AmountDue)
            {
                Console.WriteLine("Payment must match amount due exactly. Press enter to return to menu.");
                Console.ReadLine();
                return;
            }

            // Prompt for payment method
            Console.WriteLine("Enter the payment method (e.g., Credit Card, PayPal, etc.):");
            var paymentMethod = Console.ReadLine();

            // Check if paymentMethod is null or empty
            if (string.IsNullOrWhiteSpace(paymentMethod))
            {
                Console.WriteLine("Payment method cannot be empty. Press enter to return to menu.");
                Console.ReadLine();
                return;
            }

            int paymentId = payments.Count > 0 ? payments.Max(p => p.PaymentId) + 1 : 1;

            // Create a new payment and add it to the payments list
            var newPayment = new Payment(paymentId, invoiceId, amount, DateTime.Now, paymentMethod);
            payments.Add(newPayment);

            // Mark the invoice as paid and update the status
            target.IsPaid = true;
            target.Status = "Paid"; // Update the invoice status to "Paid"

            Console.WriteLine("Payment recorded successfully. Press enter to return to menu.");
            Console.ReadLine();
        }
    }
}
