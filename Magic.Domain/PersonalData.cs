using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magic.Domain;

[Table("personal_data")]
public class PersonalData
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("first_name")]
    public int FirstName { get; set; }
    
    [Column("second_name")]
    public int? SecondName { get; set; }
    
    [Column("third_name")]
    public int? ThirdName { get; set; }
    
    [Column("date_of_birth")]
    public DateTime? DateOfBirth { get; set; }

    private ICollection<Address>? Addresses { get; set; }
    
    [Column("phone_number")]
    public string? PhoneNumber { get; set; }
}