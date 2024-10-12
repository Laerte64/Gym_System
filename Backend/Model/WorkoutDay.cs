using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

[Table("tb_workoutday")]
internal class WorkoutDay
{
    [Key]
    public int Id { get; set; } = 0;

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    public required List<Exercise> Exercises { get; set; }

    public required bool Standart { get; set; }
}