using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication8.Data
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string WorkEmail { get; set; }
        public string Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarUrl { get; set; }
        public int employeeType { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public string JoinDate { get; set; }

        public int status { get; set; }
    }
}
