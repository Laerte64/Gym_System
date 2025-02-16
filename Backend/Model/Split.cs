using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

[Table("tb_split")]
internal class Split
{
    [Key]
    public int Id { get; set; } = 0;

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    public required List<WorkoutDay> Days { get; set; }
}