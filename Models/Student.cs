using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace School.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string? FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string? LastName { get; set; }
        [DisplayName("Date Of Birth")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Phone Number")]
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public int batch { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }





    }
}
