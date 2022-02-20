using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrsystem.Models
{
    public class SignUpViewModel
    {
        public SignUpModel signUpModel { set; get; }
        public List<IdentityRole> roles { set; get; }
    }
}
