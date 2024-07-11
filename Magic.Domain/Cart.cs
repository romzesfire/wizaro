using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magic.Domain;

[Table("cart")]
public class Cart
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("user_id")]
    public int UserId { get; set; }
    
    [ForeignKey("UserId")]
    public User User { get; set; }
    
    public ICollection<CountedProduct> Products { get; set; }
}