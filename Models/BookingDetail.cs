using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commander.Models
{
    public class BookingDetail
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int? TableId { get; set; }
        [Key]
        public int BookingId { get; set; }

        [ForeignKey(nameof(BookingId))]
        [InverseProperty("BookingDetails")]
        public virtual Reservation Reservation { get; set; }
        [ForeignKey(nameof(TableId))]
        [InverseProperty("BookingDetails")]
        public virtual Table Table { get; set; }
    }
}
