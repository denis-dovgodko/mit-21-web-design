namespace lab15_17.Models
{
    public class Hall
    {
        public int Id { get; set; }
        public string HallName { get; set; }
        public string Technology { get; set; }
        public int RowsCount { get; set; }
        public int SeatsCount { get; set; }
        public int MinPrice { get; set; }
        public bool VIP { get; set; }
        public IEnumerable<Session> Sessions { get; set; }
    }
}
