using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

[Table("tb_payment")]
internal class Payment
{
    [Key]
    public int Id { get; set; } = 0;

    public required Member Member { get; set; }

    public required Employee Employee { get; set; }
    
    public required decimal Value { get; set; }

    public required DateTime Date { get; set; }
}