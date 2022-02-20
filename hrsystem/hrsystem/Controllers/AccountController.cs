using hrsystem.Models;
using hrsystem.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrsystem.Controllers
{
    public class AccountController : Controller
    {
        IAccountService  accountservice;

        public AccountController(IAccountService _accountservice)
        {
            accountservice = _accountservice;
        }
        public IActionResult Index()
        {
            SignUpViewModel signUpViewModel = new SignUpViewModel();
            signUpViewModel.roles= accountservice.GetRoles();
            return View(signUpViewModel);
        }
        public async Task<IActionResult> CreateAccount(SignUpViewModel signUpViewModel)
        {
          var result= await accountservice.create(signUpViewModel.signUpModel);
            signUpViewModel.roles = accountservice.GetRoles();

            return View("Index",signUpViewModel);
        }

        public IActionResult SignIn()
        {
            return View();
        }
        public async Task< IActionResult> LogIn(LoginModel loginModel)
        {
            var result = await accountservice.LogIn(loginModel);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                ViewData["ErrorMessage"] = "Invalid UserName or Password";
                return View("SignIn");

            }
        }
        public async Task<IActionResult> SignOut()
        {
            await accountservice.SignOut();
            return View("SignIn");
        }
        public IActionResult NewRole()
        {
            return View();
        }
        public async Task<IActionResult>CreateRole( RoleModel roleModel)
        {
          var result=await  accountservice.AddRole(roleModel);
            return View("NewRole");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
