using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("tb_payment")]
    internal class PaymentData
    {
        [Key]
        public int Id { get; set; }

        public MemberData Member { get; set; }

        public EmployeeData Employee { get; set; }

        public ScheduleData Schedule { get; set; }
        
        public decimal Value { get; set; }

        public DateTime Date { get; set; }
    }
}