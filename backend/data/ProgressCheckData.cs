using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("tb_progresscheck")]
    internal class ProgressCheckData
    {
        [Key]
        public int Id { get; set; } = 0;

        public required MemberData Member { get; set; }

        public required CoachData Coach { get; set; }

        public required DateTime Date { get; set; }

        public required decimal Height { get; set; }

        public required decimal Mass { get; set; }

        public required decimal Fat { get; set; }
    }
}