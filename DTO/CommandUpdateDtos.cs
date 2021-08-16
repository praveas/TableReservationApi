using System.ComponentModel.DataAnnotations;

namespace Commander.DTO
{
    public class CommandUpdateDtos
    {
        // public int Id { get; set; } // Created by database

        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}


