using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("tb_coach")]
    internal class CoachData : UserData
    {
        public List<MemberData> Members { get; set; }

        public ScheduleData Schedule { get; set; }

        public List<ProgressCheckData> ProgressChecks { get; set; }
    }
}