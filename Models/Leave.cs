
namespace HRMS.Models
{
    public class Leave
    {
        public int id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }

        public int employeeId { get; set; }
        public Employee employee { get; set; }
    }
}