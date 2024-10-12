using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

[Table("tb_coach")]
internal class Coach : User
{
    public required List<ProgressCheck> ProgressChecks { get; set; }
}
