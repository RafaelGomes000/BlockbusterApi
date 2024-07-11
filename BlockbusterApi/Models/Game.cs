using System.ComponentModel.DataAnnotations;

namespace BlockbusterApi.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name of the game must be filled")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The genre of the game must be filled")]
        [StringLength(20)]
        public string Genre { get; set; }

        [Required(ErrorMessage = "The age restrict must be filled")]
        [Range(5, 18, ErrorMessage = "The age restrict must be between 5 and 18")]
        public int AgeRestriction { get; set; }
    }
}
