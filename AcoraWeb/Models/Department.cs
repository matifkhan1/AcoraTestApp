using System.ComponentModel.DataAnnotations;

namespace AcoraWeb.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string? Name { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
