using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Restaurant.Models
{
    public class Item
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required]
        public string? ItemName { get; set; }

        [Required]
        [DisplayName("The price")]
        [Range(0.25, 100, ErrorMessage = "The value must between {1} and {2}.")]
        public decimal Price { get; set; }

        public string? ImagePath { get; set; }

        [NotMapped]
        public IFormFile clientFile { get; set; }
    }
}
