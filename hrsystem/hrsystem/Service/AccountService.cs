using hrsystem.data;
using hrsystem.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrsystem.Service
{
    public class AccountService : IAccountService
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        RoleManager<IdentityRole> roleManager;
        public AccountService(UserManager<ApplicationUser> _userManager,SignInManager<ApplicationUser> _signInManager,
            RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            signInManager = _signInManager;
        }
        public async Task<IdentityResult> create(SignUpModel signUpModel)
        {
            ApplicationUser applicationUser = new ApplicationUser();
            applicationUser.name= signUpModel.name;
            applicationUser.Email = signUpModel.email;
            applicationUser.UserName = signUpModel.email;
          var result=await  userManager.CreateAsync(applicationUser,signUpModel.password);
            if (result.Succeeded)
            {
              var role=await  roleManager.FindByIdAsync(signUpModel.RoleId);
                if (role != null) {
                   result=await userManager.AddToRoleAsync(applicationUser, role.Name);
                }

            }
            return result;
            
        }

        public async Task<SignInResult> LogIn(LoginModel loginModel)
        {
          var result=await  signInManager.PasswordSignInAsync(loginModel.Email,loginModel.Password,loginModel.RememberMe,false);
            return result;
        }

        public async Task SignOut()
        {
           await signInManager.SignOutAsync();
        }
        public async Task<IdentityResult> AddRole(RoleModel roleModel)
        {
            IdentityRole identityRole = new IdentityRole();
            identityRole.Name = roleModel.Name;
          var result=await  roleManager.CreateAsync(identityRole);
            return result;
        }
        public List<IdentityRole> GetRoles()
        {
            List<IdentityRole> identityRoles = roleManager.Roles.ToList();
            return identityRoles;
        }
    }
}
