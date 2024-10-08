using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("tb_timeslot")]
    internal class TimeSlotData
    {
        [Key]
        public int Id { get; set; } = 0;

        public required DayOfWeek Day { get; set; }

        public required TimeSpan Start { get; set; }

        public required TimeSpan End { get; set; }
    }
}