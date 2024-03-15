using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    public class Employee
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? EmployeeEmail { get; set; }

        [Required]
        public string? EmployeePhone { get; set; }

        [Required]
        public DateTime? Birthday { get; set; }

        [Required]
        public decimal? Salary { get; set; }
    }
}
