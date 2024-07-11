using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magic.Domain;

[Table("product")]
public class Product
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("description")]
    public string Description { get; set; }
    
    [Column("image_sources")]
    public string[] ImageSources { get; set; }
    
    [Column("price_id")]
    public int PriceId { get; set; }
    
    [ForeignKey("PriceId")]
    public Price Price { get; set; }
    
    [Column("time_to_complete")]
    public int? TimeToComplete { get; set; }
    
    [Column("product_type")]
    public ProductType ProductType { get; set; }
}
