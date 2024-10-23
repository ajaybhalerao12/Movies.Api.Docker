namespace Movies.Api.Docker.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public decimal Rating { get; set; }
        public string Synopsis { get; set; }
    }

}
