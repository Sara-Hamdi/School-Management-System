using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using School.Data;
using School.Models;

namespace School.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TeacherController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: TeacherController
        public ActionResult Index(string searchString,string subject)
        {
            var teachers = from t in _db.teacher select t;
            if(!string.IsNullOrEmpty(subject))
            {
                teachers = teachers.Where(t => t.subject == subject);
            }
            if(!string.IsNullOrEmpty(searchString))
            {
                teachers = teachers.Where(t => t.FirstName == searchString || t.LastName == searchString);
            }

            return View(teachers.ToList());
        }


        // GET: TeacherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher teacher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.teacher.Add(teacher);
                    _db.SaveChanges();
                  
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
           
          
        }
        public IActionResult Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var teacherObj = _db.teacher.Find(id);
            if(teacherObj==null)
            {
                return View();
            }
            return View(teacherObj);
        }
        public IActionResult EditPOST(Teacher teacher)
        {
            if(ModelState.IsValid)
            {
                _db.Update(teacher);
                _db.SaveChanges(true);
                return RedirectToAction("Index");
            }
            return View();

        }
       public IActionResult Delete(int? Id)
        {
            if(Id==0 || Id==null)
            {
                return NotFound();


            }
            var TeacherObj = _db.teacher.Find(Id);
            if(TeacherObj==null)
            {
                return NotFound();
            }
            return View(TeacherObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int Id)
       {
            var TeacherObj = _db.teacher.Find(Id);
            if (TeacherObj== null)
            {
                return NotFound();
            }
            else
            {
                _db.teacher.Remove(TeacherObj);
                _db.SaveChanges(true);
                return RedirectToAction("Index");
            }
         
        }

        
    }
}
