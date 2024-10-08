using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data 
{
    [Table("tb_member")]
    internal class MemberData : UserData
    {
        public required List<CoachData> Coaches { get; set; }

        public required List<PaymentData> Payments { get; set; }

        public required ScheduleData Schedule { get; set; }

        public required List<CheckInDayData> CheckInDays { get; set; }

        public required List<ProgressCheckData> ProgressChecks { get; set; }

        public int SplitId { get; set; } = 0;
        public required SplitData Split { get; set; }
        public int DayOfSplit { get; set; } = 0;
    }
}