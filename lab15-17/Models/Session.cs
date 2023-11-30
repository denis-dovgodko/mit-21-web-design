namespace lab15_17.Models
{
    public class Session
    {
        public int Id { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set;}
        public int HallId { get; set; }
        public Hall Hall { get; set;}
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
    }
}
