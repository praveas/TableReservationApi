using System;
using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class ReservationReadDto
    {
       
        public int Id { get; set; }
        public string BookingName { get; set; }

        
        public DateTime BookingDate { get; set; }

        
        public string Mobile { get; set; }

        
        public string Email { get; set; }

        
        public string AddComments { get; set; }

        public int TableId { get; set; }

        public TimeSpan ReservedTime { get; set; }


    }

}


