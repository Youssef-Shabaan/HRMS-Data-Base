
namespace HRMS.Models
{
    public class Attendance
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public DateTime time_in { get; set; }
        public DateTime time_out { get; set; }

        public int employeeId { get; set; }
        public Employee employee { get; set; }
    }
}