using System.ComponentModel.DataAnnotations;

namespace Movies.Api.Docker.Entities
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="This is required field")]
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage ="This is required field")]
        [StringLength(100)]
        public string Director { get; set; }
        public decimal Rating { get; set; }
        public string Synopsis { get; set; }
    }

}
