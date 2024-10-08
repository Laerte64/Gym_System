using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("tb_employee")]
    internal class EmployeeData : UserData
    {
        public required List<TimeSlotData> WorkDays { get; set; }

        public required List<PaymentData> Payments { get; set; }

        public required List<CheckInDayData> CheckInDays{ get; set; }
    }
}