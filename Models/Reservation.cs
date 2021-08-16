using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commander.Models
{
    public class Reservation
    {
        public Reservation()
        {
            this.ReservedTime = new TimeSpan(17, 0, 0);
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string BookingName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BookingDate { get; set; }

        [Required]
        [Phone]
        public string Mobile { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(300)]
        public string AddComments { get; set; }

        [Range(1, 11)]
        public Nullable<int> TableId { get; set; }


        [Required, DataType(DataType.Time),
        Display(Name = "Schedule Time", Description = "Number of Hours and Minutes after Midnight Central Timezone"),
        DisplayFormat(DataFormatString = @"{0:hh\\:mm}", ApplyFormatInEditMode = true),
        Range(typeof(TimeSpan), "16:00", "23:00")]
        public TimeSpan ReservedTime { get; set; }

        public TimeSpan BookingEnds { get; set; }




    }

}



// Notes:
// Fields can be decorated with data annotations
// Ref: https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/models-data/validation-with-the-data-annotation-validators-cs