using System;
using System.ComponentModel.DataAnnotations;

namespace Commander.DTO
{
    public class CommandCreateDtos
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

// Notes
/*
If we do not add DataAnnotations,
throw 500 internal server error if we miss one variable,

using Data Annotations, will throw 400 Bad Request, JSON error and easier to fix error

*/