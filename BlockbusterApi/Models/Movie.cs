using System.ComponentModel.DataAnnotations;

namespace BlockbusterApi.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name of the movie must be filled")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The genre of the movie must be filled")]
        [StringLength(20)]
        public string Genre { get; set; }

        [Required(ErrorMessage = "The duration of the movie must be filled")]
        [Range(50, 300, ErrorMessage = "The duration of the movie must be between 50 and 300")]
        public int Duration { get; set; }
    }
}
