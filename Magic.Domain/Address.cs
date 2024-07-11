using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magic.Domain;

[Table("address")]
public class Address
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("string_address")]
    public string StringAddress { get; set; }
    
    [Column("personal_data_id")]
    public int PersonalDataId { get; set; }
    
    [ForeignKey("PersonalDataId")]
    public PersonalData PersonalData { get; set; }
}