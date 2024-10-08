using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data 
{
    [Table("tb_member")]
    internal class MemberData : UserData
    {
        public List<CoachData> Coaches { get; set; }

        public List<PaymentData> Payments { get; set; }

        public ScheduleData Schedule { get; set; }

        public List<CheckInDayData> CheckInDays { get; set; }

        public List<ProgressCheckData> ProgressChecks { get; set; }

        public int SplitId { get; set; }
        public SplitData Split { get; set; }
        public int DayOfSplit { get; set; }
    }
}