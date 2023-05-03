using Microsoft.AspNetCore.Mvc;
using School.Data;
using School.Models;
using System.Diagnostics;

namespace School.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        [ActivatorUtilitiesConstructor]
        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            ViewData["numOfStudents"] = _db.student.ToList().Count;
            ViewData["numOfTeachers"] = _db.teacher.ToList().Count;
            ViewData["numOfSubjects"] = _db.subject.ToList().Count;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}