using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("tb_payment")]
    internal class PaymentData
    {
        [Key]
        public int Id { get; set; } = 0;

        public required MemberData Member { get; set; }

        public required EmployeeData Employee { get; set; }

        public required ScheduleData Schedule { get; set; }
        
        public required decimal Value { get; set; }

        public required DateTime Date { get; set; }
    }
}