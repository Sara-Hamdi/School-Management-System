using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Index(string searchString,int batch)
        {
           
            var students = from s in _db.student select s;
          
            if (batch!=0)
            {
                students = students.Where(s => s.batch == batch);

            }

            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LastName == searchString || s.FirstName == searchString);
               
            }
            return View(students.ToList());
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
                TempData["ConfirmationMessage"] = "Customer succesfully created";
                return RedirectToAction("Index");
            }
            else
            {
                return View(studentObj);
            }
        }
        public IActionResult Edit(int id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var studentObj = _db.student.Find(id);
            return View(studentObj);
        }
        [HttpPost]
        public IActionResult EditPOST(Student student)
        {
           if(ModelState.IsValid)
            {
                _db.student.Update(student);
                _db.SaveChanges(true);
                return RedirectToAction("Index");
            }

            return View("Edit");
        }
        public IActionResult Delete(int? id)
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
            if (id == null)
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
