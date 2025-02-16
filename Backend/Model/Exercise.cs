using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

[Table("tb_exercise")]
public class Exercise
{
    [Key]
    public int Id { get; set; } = 0;

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Equipment { get; set; }
}