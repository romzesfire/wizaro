using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magic.Domain;

[Table("counted_product")]
public class CountedProduct
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("product_id")]
    public int ProductId { get; set; }
    
    [Column("count")]
    public int Count { get; set; }
    
    [ForeignKey("ProductId")]
    public Product Product { get; set; }
    
    [Column("cart_id")]
    public int? CartId { get; set; }
    
    [ForeignKey("CartId")]
    public Cart? Cart { get; set; }
    
    [Column("order_id")]
    public int? OrderId { get; set; }
    
    [ForeignKey("OrderId")]
    public Order? Order { get; set; }
}