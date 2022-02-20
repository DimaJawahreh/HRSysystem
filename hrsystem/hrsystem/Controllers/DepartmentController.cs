using hrsystem.data;
using hrsystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrsystem.Controllers
{
    [Authorize(Roles ="Admin")]
    public class DepartmentController : Controller
    {
        IDepartmentService departmentService;
        public DepartmentController(IDepartmentService _departmentService)
        {
            departmentService = _departmentService;
        }
        public IActionResult Index()
        {
            List<Department> departments = departmentService.GetDepartments();
            return View("DepartmentList",departments);
        }
        public IActionResult Create(Department department)
        {
            ViewData["Edit"] = false;

            departmentService.Insert(department);
            return View("NewDepartment");
        }
        public IActionResult NewDept()
        {
            ViewData["Edit"] = false;

            return View("NewDepartment");
        }
        public IActionResult Delete(int id)
        {
            departmentService.DeleteById(id);
            List<Department> departments = departmentService.GetDepartments();

            return View("DepartmentList", departments);
        }
        public IActionResult Edit(int id)
        {
            Department department= departmentService.Edit(id);
            ViewData["Edit"] = true;


            return View("NewDepartment",department);


        }
        public IActionResult Update(Department department)
        {
            departmentService.Update(department);
            List<Department> departments = departmentService.GetDepartments();
            return View("DepartmentList", departments);
        }


    }
}
