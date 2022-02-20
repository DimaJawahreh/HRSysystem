using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hrsystem.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { set; get; }
        [Required]
        public string Password { set; get; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { set; get; }
    }
}
