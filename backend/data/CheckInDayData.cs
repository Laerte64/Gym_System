using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("tb_checkinday")]
    internal class CheckInDayData
    {
        [Key]
        public int Id { get; set; } = 0;

        public required MemberData Member { get; set; }

        public required EmployeeData Employee { get; set; }

        public required WorkoutDayData WorkoutDay { get; set; }

        public required DateTime Date { get; set; }
    }
}