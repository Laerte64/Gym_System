using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("tb_timeslot")]
    internal class TimeSlotData
    {
        [Key]
        public int Id { get; set; }

        public DayOfWeek Day { get; set; }

        public TimeSpan Start { get; set; }

        public TimeSpan End { get; set; }
    }
}