using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace School.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
