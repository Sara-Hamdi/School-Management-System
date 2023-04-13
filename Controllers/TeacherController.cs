using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Index()
        {
            List<Teacher> teachers = _db.teacher.ToList();

            return View(teachers);
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
