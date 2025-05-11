using System.ComponentModel.DataAnnotations;

namespace MovieStoreMvcWeb.Models.Domain
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ReleaseYear { get; set; }
        [Required]
        public string MovieImage { get; set; }
        [Required]
        public string Cast { get; set; }
        [Required]
        public string Director { get; set; }

    }
}
