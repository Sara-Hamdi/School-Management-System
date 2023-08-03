using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School.Data;
using School.Models;

namespace School.Controllers
{
    [Authorize]
    public class SubjectController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SubjectController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            List<Subject>subjects=_db.subject.ToList();
       
            return View(subjects);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Subject subject)
        {
            if (ModelState.IsValid)
            {
                _db.subject.Add(subject);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(subject);
            }
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var subjectObj = _db.subject.Find(id);
            if (subjectObj == null)
            {
                return View();
            }
         
            return View(subjectObj);
        }
        [HttpPost]
        public IActionResult Edit(Subject subject)
        {
            try
            {
                
                 _db.subject.Update(subject);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(subject);

            }
        }
            public IActionResult Delete(int? Id)
            {
                if (Id == 0 || Id == null)
                {
                    return NotFound();


                }
                var subjectObj = _db.subject.Find(Id);

                if (subjectObj == null)
                {
                    return NotFound();
                }
                return View(subjectObj);
            }
            [HttpPost]
            public IActionResult DeletePost(int Id)
            {
                var subjectObj = _db.subject.Find(Id);
                if (subjectObj == null)
                {
                    return NotFound();
                }
                else
                {
                    _db.subject.Remove(subjectObj);
                    _db.SaveChanges(true);
                    return RedirectToAction("Index");
                }

            }


        }
    
}
