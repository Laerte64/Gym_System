using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("tb_split")]
    internal class SplitData
    {
        [Key]
        public int Id { get; set; } = 0;

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        public required List<WorkoutDayData> Days { get; set; }

        public required bool Standart { get; set; }
    }
}