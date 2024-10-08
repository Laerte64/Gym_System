using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("tb_schedule")]
    internal class ScheduleData
    {
        [Key]
        public int Id { get; set; } = 0;

        public required List<TimeSlotData> TimeSlots { get; set; }

        public required decimal MonthlyFee { get; set; }

        public required List<MemberData> Members { get; set; }

        public required List<CoachData> Coaches { get; set; }
    }
}