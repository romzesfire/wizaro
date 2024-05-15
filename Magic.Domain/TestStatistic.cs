using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magic.Domain
{
    [Table("questions")]
    public class Question
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("type")]
        public string Type { get; set; }
        
        [Column("text")]
        public string? Text { get; set; }
        
        [Column("answer")]
        public string Answer { get; set; }
        
        [Column("answer_options")]
        public string[]? AnswerOptions { get; set; }
        
        [Column("image_url")]
        public string? ImageUrl { get; set; }
    }
}
