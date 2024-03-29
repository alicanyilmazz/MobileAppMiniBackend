﻿namespace CoreBackend.API.Models
{
    public class Movie : BaseProperties
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string? ReleaseDate { get; set; }
        public string? PhotoPath { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Actress> Actresses { get; set; } = new List<Actress>();
    }
}
