using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("tb_checkinday")]
    internal class CheckInDayData
    {
        [Key]
        public int Id { get; set; }

        public MemberData Member { get; set; }

        public WorkoutDayData WorkoutDay { get; set; }
    }
}