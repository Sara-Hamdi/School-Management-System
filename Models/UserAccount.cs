using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace School.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Email is required")]
     
        public string Email { get; set; }
        [Required(ErrorMessage="Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Please confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }

    }
}
