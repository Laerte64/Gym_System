using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

[Table("tb_employee")]
internal class Employee : User
{
    public required List<Payment> Payments { get; set; }
    public required bool IsManager = false;
}