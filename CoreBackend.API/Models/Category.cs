namespace CoreBackend.API.Models
{
    public class Category : BaseProperties
    {
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
