namespace CoreBackend.API.Models
{
    public class Actress : BaseProperties
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public string? PlaceOfBirth { get; set; }
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
