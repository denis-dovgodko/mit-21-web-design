namespace lab13.Models
{
    public class Purchase
    {
        // ID покупки
        public int PurchaseId { get; set; }
        // ім'я й прізвище покупця
        public string Person { get; set; }
        // телефон покупця
        public string Phone { get; set; }
        // ID квитка
        public int TicketId { get; set; }
        // дата покупки
        public DateTime Date { get; set; }
    }
}
