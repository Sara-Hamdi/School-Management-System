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

            var users = from userObj in _db.userAccount select userObj;
                var userExist = users.Where(u => u.Email == user.Email);
                if (userExist != null)
                {
                    ViewData["result"] = "this email aleardy exist";

                    return View(user);

                }
                if (ModelState.IsValid)
                {
                    _db.userAccount.Add(user);
                    _db.SaveChanges(true);
                    ModelState.Clear();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(user);
                }
            
            


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
                var users = from user in _db.userAccount select user;
              var Loggedinuser=  users.Where(u => u.Username ==username && u.Password == password);
                if (Loggedinuser == null)
                {

                    ViewData["error"] = "Invalid username or password";
                    return View();
                 
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                return View();
            }
        }
    }
}
