using AcoraWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AcoraWeb.ModelView
{
    public class EmployeeModelView
    {


        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }

        [MaxLength(50)]
        public string? FirstName { get; set; }
        [MaxLength(50)]
        public string? LastName { get; set; }
        [MaxLength(100)]
        public string? Address { get; set; }
        [MaxLength(50)]
        public string? City { get; set; }

        [Required]
        [Display(Name = "Select Department")]
        public int? SelectedDepartment { get; set; }
        public IEnumerable<SelectListItem>? Departments { get; set; }

        public int DepartmentId { get; set; }
    }
}
