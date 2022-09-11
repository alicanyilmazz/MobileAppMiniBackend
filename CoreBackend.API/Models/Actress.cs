namespace CoreBackend.API.Models
{
    public class Actress
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Movie> Movies { get; set; } = new();
    }
}
