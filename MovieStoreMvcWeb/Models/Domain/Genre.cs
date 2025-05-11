using System.ComponentModel.DataAnnotations;

namespace MovieStoreMvcWeb.Models.Domain
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string GenreName { get; set; }
    }
}
