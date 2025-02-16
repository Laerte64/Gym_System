using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

[Table("tb_user")]
public class User
{
    [Key]
    public int Id { get; set; } = 0;

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [Required]
    public required DateTime BirthDate { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Login { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Password { get; set; }
}