namespace TaskTracker.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }  // New field for payment method

        // Constructor now accepts payment method as well
        public Payment(int paymentId, int invoiceId, decimal amount, DateTime paymentDate, string paymentMethod)
        {
            PaymentId = paymentId;
            InvoiceId = invoiceId;
            Amount = amount;
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;  // Store payment method
        }
    }
}
