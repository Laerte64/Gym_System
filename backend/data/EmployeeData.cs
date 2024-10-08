using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("tb_employee")]
    internal class EmployeeData : UserData
    {
        public List<TimeSlotData> WorkDays { get; set; }

        public List<PaymentData> Payments { get; set; }
    }
}