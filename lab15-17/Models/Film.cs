
namespace lab15_17.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public IEnumerable<Session> Sessions { get; set; }
    }
}
