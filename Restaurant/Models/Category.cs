using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    public class Category
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Category Name")]
        public string? CategoryName { get; set; }

        public ICollection<Item>? Items { get; set; }

        [NotMapped]
        public IFormFile clientFile { get; set; }

        public byte[]? dbImage { get; set; }
    }
}
