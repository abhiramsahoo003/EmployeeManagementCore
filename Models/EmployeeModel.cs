using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementCore.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        public required string EmployeeName { get; set; }
        public int Salary { get; set; }
        public int ManagerId { get; set; }
    }
}
