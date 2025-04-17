using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace razorweb.Models
{
    public class Article
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; } = "";

        [DataType(DataType.Date)]
        [Required]
        public DateTime CreateAt { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Content { get; set; } = "";
    }
}
