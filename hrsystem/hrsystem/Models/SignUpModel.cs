using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hrsystem.Models
{
    public class SignUpModel
    {
        [Required]
        public string name { set; get; }
        [Required]
        [EmailAddress]
        public string email { set; get; }
         //[DataType(DataType.Password)]
        [Required]
        [Compare("confirmpassword")]
        public string password { set; get; }
       // [DataType(DataType.Password)]

        [Required]
        [Display(Name ="Confirm Password")]

        public string confirmpassword { set; get; }
        [Required]
        [Display(Name ="Role")]
        public string RoleId { set; get; }
    }
}
