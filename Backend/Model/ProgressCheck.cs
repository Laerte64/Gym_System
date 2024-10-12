using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

[Table("tb_progresscheck")]
internal class ProgressCheck
{
    [Key]
    public int Id { get; set; } = 0;

    public required Member Member { get; set; }

    public required Coach Coach { get; set; }

    public required DateTime Date { get; set; }

    public required decimal Height { get; set; }

    public required decimal Mass { get; set; }

    public required decimal Fat { get; set; }
}