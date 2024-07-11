using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magic.Domain;

[Table("order")]
public class Order
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("user_id")]
    public int UserId { get; set; }
    
    [Column("address_id")]
    public int AddressId { get; set; }
    
    [ForeignKey("UserId")]
    public User User { get; set; }
    
    public ICollection<CountedProduct> Products { get; set; }
    
    [ForeignKey("AddressId")]
    public Address Address { get; set; }
    
    [Column("general_price")]
    public decimal GeneralPrice { get; set; }
    
    [Column("phone_number")]
    public string? PhoneNumber { get; set; }
    
    [Column("comment")]
    public string? Comment { get; set; }
}