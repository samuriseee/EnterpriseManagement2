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
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string Birthday { get; set; }
        [RegularExpression(@"^(090|098|091|031|035|038)\d{7}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }
        public string AvatarUrl { get; set; }
        public int employeeType { get; set; }
        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string JoinDate { get; set; }

        public int status { get; set; }
    }
}
