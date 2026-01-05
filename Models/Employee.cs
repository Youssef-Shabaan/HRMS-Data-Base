
using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? position { get; set; }
        public DateTime? hire_date { get; set; }

        public int departmentId { get; set; }
        public Department department { get; set; }  

        public Payroll? payroll { get; set; }
        public List<Training>? training { get; set; }

        public List<Attendance>? attendance { get; set; }
        public List<Leave>? leaves { get; set; } 

    }
}