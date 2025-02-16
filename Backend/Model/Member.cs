using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

[Table("tb_member")]
internal class Member : User
{
    public int SplitId { get; set; } = 0;
    public required Split Split { get; set; }
    public int DayOfSplit { get; set; } = 0;
}