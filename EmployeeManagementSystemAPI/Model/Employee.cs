using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystemAPI.Model
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
    }
}
