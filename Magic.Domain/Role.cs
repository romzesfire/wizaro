using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magic.Domain;

[Table("role")]
public class Role
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("role_name")]
    public int RoleName { get; set; }
}