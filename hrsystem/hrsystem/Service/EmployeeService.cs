using hrsystem.Context;
using hrsystem.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrsystem.Service
{
    public class EmployeeService: IEmployeeService
    {
        HRContext context;
        public EmployeeService(HRContext hRContext)
        {
            context = hRContext;
        }

        public void Insert(Employee employee)
        {
            context.employees.Add(employee);
            context.SaveChanges();
        }
        public Employee Edit(int id)
        {
            Employee employee = context.employees.Find(id);
            return employee;

        }
        public void Update(Employee employee)
        {
            context.employees.Attach(employee);
            context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteById(int id)
        {
            Employee emp = context.employees.Find(id);
            context.employees.Remove(emp);
            context.SaveChanges();
        }
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = context.employees.Include("department").ToList();
            return employees;
        }
    }
}
