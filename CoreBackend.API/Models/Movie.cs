namespace CoreBackend.API.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PhotoPath { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Actress> Actresses { get; set; } = new List<Actress>();
    }
}
