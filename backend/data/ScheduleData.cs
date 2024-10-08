using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("tb_schedule")]
    internal class ScheduleData
    {
        [Key]
        public int Id { get; set; }

        public List<TimeSlotData> TimeSlots { get; set; }

        public decimal MonthlyFee { get; set; }

        public List<MemberData> Members { get; set; }

        public List<CoachData> Coaches { get; set; }
    }
}