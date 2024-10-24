namespace Movies.Api.Docker.Dtos
{   
    public class MovieDto
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public decimal Rating { get; set; }
        public string Synopsis { get; set; }
    }

}
