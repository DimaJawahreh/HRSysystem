using hrsystem.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrsystem.Service
{
  public  interface IAccountService
    {
        Task<IdentityResult> create(SignUpModel signUpModel);
        Task<SignInResult> LogIn(LoginModel loginModel);
        Task SignOut();
        Task<IdentityResult> AddRole(RoleModel roleModel);
        List<IdentityRole> GetRoles();


    }
}
