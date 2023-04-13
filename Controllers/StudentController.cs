using Microsoft.AspNetCore.Mvc;
using School.Data;
using School.Models;

namespace School.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Student> students = _db.student.ToList();
            return View(students);
            
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student studentObj)
        {
            if(ModelState.IsValid)
            {
                _db.student.Add(studentObj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(studentObj);
            }
        }
        public IActionResult Delete(int id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var studentObj = _db.student.Find(id);
            if(studentObj==null)
            {
                return NotFound();
            }
            else
            {
                return View(studentObj);
            }
            
        }
        [HttpPost]
        public IActionResult DeletePOST(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var studentObj = _db.student.Find(id);
            if (studentObj == null)
            {
                return NotFound();
            }
            else
            {
                _db.student.Remove(studentObj);
                _db.SaveChanges(true);
                return RedirectToAction("Index");
            }

        }
    }
}
