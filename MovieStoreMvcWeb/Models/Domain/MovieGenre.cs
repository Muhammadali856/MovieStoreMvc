using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreMvcWeb.Models.Domain
{
    public class MovieGenre
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
    }
}
