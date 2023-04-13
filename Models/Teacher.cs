using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace School.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        [Required]
        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }
        [Required]
        [DisplayName("Email")]
        public string? Email { get; set; }
        [Required]
        [DisplayName("Subject")]
        public string? subject { get; set; }


    }
}
