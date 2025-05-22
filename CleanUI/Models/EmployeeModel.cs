using System.ComponentModel.DataAnnotations;

namespace CleanUI.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Role { get; set; } = null!;
        [Required]
        public int Salary { get; set; }
    }
}
