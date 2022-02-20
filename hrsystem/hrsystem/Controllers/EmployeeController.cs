using ClosedXML.Excel;
using hrsystem.Context;
using hrsystem.data;
using hrsystem.Models;
using hrsystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace hrsystem.Controllers
{
    [Authorize(Roles ="Sales,Admin")]
    public class EmployeeController : Controller
    {
        IEmployeeService employeeService;
        IDepartmentService departmentService;
        IConfiguration configuration;
        HRContext context;
        public EmployeeController(IEmployeeService _employeeService,IDepartmentService _departmentService,
           IConfiguration  _configuration, HRContext _context)
        {
            employeeService = _employeeService;
            departmentService = _departmentService;
            configuration = _configuration;
            context = _context;
        }
        public IActionResult Index()
        {
            List<Employee> employees = employeeService.GetEmployees();
            return View("EmpList",employees);
        }
        public IActionResult NewEmp()
        {
            ViewData["Edit"] = false;

            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.departments = departmentService.GetDepartments();
            return View(employeeViewModel);
        }
        public IActionResult Insert(EmployeeViewModel employeeViewModel)
        {
            employeeViewModel.departments = departmentService.GetDepartments();
            if (ModelState.IsValid == true)
            {
                string filepath = Path.Combine(Directory.GetCurrentDirectory(),configuration["FilePath"], employeeViewModel.imgpath.FileName);
                employeeViewModel.imgpath.CopyTo(new FileStream(filepath, FileMode.Create));
                employeeViewModel.employee.photopath= "http://localhost/hrsystem/" + "img" + "/" + employeeViewModel.imgpath.FileName;
                employeeService.Insert(employeeViewModel.employee);
            }

            return View("NewEmp",employeeViewModel);
        }


        public IActionResult Edit(int id)
        {
            ViewData["Edit"] = true;
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.employee = employeeService.Edit(id);

            employeeViewModel.departments = departmentService.GetDepartments();
            return View("NewEmp", employeeViewModel);
        }
        public IActionResult Update(EmployeeViewModel employeeViewModel)
        {
            employeeService.Update(employeeViewModel.employee);
            List<Employee> employees = employeeService.GetEmployees();

            return View("EmpList",employees);
        }
        public IActionResult Delete(int id)
        {
            employeeService.DeleteById(id);
            List<Employee> employees = employeeService.GetEmployees();

            return View("EmpList", employees);
        }
        public FileResult ExportToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[3] { 
            new DataColumn("name"),new DataColumn("phone"),new DataColumn("email")});
            var emps = context.employees.ToList();
            foreach(var emp in emps)
            {
                dt.Rows.Add(emp.name, emp.phone, emp.email);
            }
            using(XLWorkbook wb=new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream=new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
            }
        }
    }
}
