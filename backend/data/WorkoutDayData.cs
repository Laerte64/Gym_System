using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("tb_workoutday")]
    internal class WorkoutDayData 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public List<ExerciseData> Exercises { get; set; }

        public bool Standart { get; set; }
    }
}