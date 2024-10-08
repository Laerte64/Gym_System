using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("tb_progresscheck")]
    internal class ProgressCheckData
    {
        [Key]
        public int Id { get; set; }

        public MemberData Member { get; set; }

        public CoachData Coach { get; set; }

        public DateTime Date { get; set; }

        public decimal Height { get; set; }

        public decimal Mass { get; set; }

        public decimal Fat { get; set; }
    }
}