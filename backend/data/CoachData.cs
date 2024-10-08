using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("tb_coach")]
    internal class CoachData : UserData
    {
        public required List<MemberData> Members { get; set; }

        public required ScheduleData Schedule { get; set; }

        public required List<ProgressCheckData> ProgressChecks { get; set; }
    }
}