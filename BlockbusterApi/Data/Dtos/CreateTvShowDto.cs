using System.ComponentModel.DataAnnotations;

namespace BlockbusterApi.Data.Dtos
{
    public class CreateTvShowDto
    {
        [Required(ErrorMessage = "The name of the TV Show must be filled")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The genre of the TV Show must be filled")]
        [StringLength(20)]
        public string Genre { get; set; }

        [Required(ErrorMessage = "The number of seasons must be filled")]
        [Range(1, 10, ErrorMessage = "The number of seasons must be between 1 and 10")]
        public int NumberOfSeason { get; set; }
    }
}
