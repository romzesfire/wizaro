using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magic.Domain;

[Table("users")]
public class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("login")]
    public string Login { get; set; }
    
    [Column("password_hash")]
    public string PasswordHash { get; set; }
    
    [Column("email")]
    public string Email { get; set; }
    
    [Column("personal_data_id")]
    public int PersonalDataId { get; set; }
    
    [Column("role_id")]
    public int RoleId { get; set; }
    
    [Column("cart_id")]
    public int CartId { get; set; }
    
    [ForeignKey("PersonalDataId")]
    public PersonalData PersonalData { get; set; }
    
    [ForeignKey("RoleId")]
    public Role Role { get; set; }

    [ForeignKey("CartId")]
    public Cart Cart { get; set; }
    
    public ICollection<Order> Orders { get; set; }
}

