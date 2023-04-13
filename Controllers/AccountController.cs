using Microsoft.AspNetCore.Mvc;
using School.Data;
using School.Models;

namespace School.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AccountController(ApplicationDbContext db) 
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserAccount user)
        {
            if(ModelState.IsValid)
            {
                _db.userAccount.Add(user);
                _db.SaveChanges(true);
                ModelState.Clear();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            if(ModelState.IsValid)
            {
              var Loggedinuser=  _db.userAccount.Single(u => u.Username ==username && u.Password == password);
                if (Loggedinuser != null)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return View();
                }

            }
            else
            {
                return View();
            }
        }
    }
}
