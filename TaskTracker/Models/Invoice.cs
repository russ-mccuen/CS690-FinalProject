namespace TaskTracker.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public decimal AmountDue { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = "Pending";
        public bool IsPaid { get; set; } = false;

        public Invoice(int id, string clientName, decimal amountDue, DateTime issueDate, DateTime dueDate)
        {
            Id = id;
            ClientName = clientName;
            AmountDue = amountDue;
            IssueDate = issueDate;
            DueDate = dueDate;
            Status = "Pending";
            IsPaid = false;
        }

    }
}
