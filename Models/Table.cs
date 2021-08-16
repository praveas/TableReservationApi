using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commander.Models
{
    public class Table
    {
        [Key]
        public int Id { get; set; }

        [Range(1,11)]
        public int TableNumber { get; set; }

        public int TimeStatusId { get; set; }

        [ForeignKey("TimeStatusId")]
        public TimeStatus TimeStatus { get; set; }

    }

    public class TimeStatus
    {
        
        public int TimeStatusId { get; set; }
        public string StandardName { get; set; }
        
        public ICollection<Table> Tables { get; set; }
    }


    public class AllAvailableTimes
    {
        public int Id { get; set; }
        public TimeSpan AllAvailableTime { get; set; }

        public int TableId { get; set; }
        public int vacancy { get; set; }
     
    }

}

