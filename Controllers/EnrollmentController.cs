using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.Data;
using School.Models;
using System.Diagnostics;


namespace School.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EnrollmentController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index(int? id)
        {
          if (id == null) return NotFound();
          ViewData["studentid"] = id;
          var studentContext = _db.enrollment.Include(s => s.Student).Include(s => s.Subject).Where(s=>s.StudentId==id);
          return View(studentContext.ToList());
     
            
        }
     
        public IActionResult Create(int? id)
        {
            if (id == null) return NotFound();
          
            ViewData["StudentID"] = id;
            var enrollments = from e in _db.enrollment.Include(e => e.Student).Include(e => e.Subject).Where(e => e.StudentId == id)
                                     select e.Subject ;
            var subjects = _db.subject.Except(enrollments);
          

            ViewData["SubjectID"] = new SelectList(subjects, "Id", "Name");
           
            return View();
        }

        // POST: StudentTeachers/Create
        [HttpPost]
        public IActionResult Create(int id, float practical, float midtermExam, float finalExam, int SubjectID)
        {

            Enrollment enrollmentObj = new Enrollment
            {
                StudentId = id,
                SubjectId = SubjectID,
                MidtermExam = midtermExam,
                Practical = practical,
                FinalExam = finalExam,
                FinalGrade = practical + midtermExam + finalExam
            };

            _db.enrollment.Add(enrollmentObj);
                _db.SaveChanges();
          
                return RedirectToAction("Index", "Enrollment", new { Id = id });
         
           

        }

    }
}
