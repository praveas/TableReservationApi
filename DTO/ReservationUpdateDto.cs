using System;
using System.ComponentModel.DataAnnotations;

namespace Commander.DTO
{
    public class ReservationUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string BookingName { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        [Phone]
        public string Mobile { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(300)]
        public string AddComments { get; set; }


        public TimeSpan ReservedTime { get; set; }
    }
}
