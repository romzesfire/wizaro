using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magic.Domain;

[Table("price")]
public class Price
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("main_price")]
    public decimal MainPrice { get; set; }
    
    [Column("sale_price")]
    public decimal SalePrice { get; set; }
}