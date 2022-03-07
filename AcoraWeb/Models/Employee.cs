using System.ComponentModel.DataAnnotations;

namespace AcoraWeb.Models
{
    public class Employee
    {
        [Key]
        [Display(Name = "Employee Number")]
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [MaxLength(50)]

        [Required]
        public string? LastName { get; set; }
        [MaxLength(100)]
        public string? Address { get; set; }
        [MaxLength(50)]
        public string? City { get; set; }

        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
