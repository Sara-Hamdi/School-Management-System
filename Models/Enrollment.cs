using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{

    public class Enrollment
    {
   
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public double MidtermExam { get; set; }
        public double Practical { get; set; }
        public double FinalGrade { get; set; }
        public double FinalExam { get; set; }
    



    }
}
