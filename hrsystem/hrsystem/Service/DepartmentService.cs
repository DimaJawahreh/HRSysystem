using hrsystem.Context;
using hrsystem.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrsystem.Service
{
    public class DepartmentService: IDepartmentService
    {
        HRContext context;
        public DepartmentService(HRContext hRContext)
        {
            context = hRContext;
        }
        public void Insert(Department department)
        {
            context.departments.Add(department);
            context.SaveChanges();
        }
        public void DeleteById(int id)
        {
            Department department = context.departments.Find(id);
            context.departments.Remove(department);
            context.SaveChanges();

        }
        public List<Department> GetDepartments()
        {
            List<Department> departments = context.departments.ToList();
            return departments;
        }
        public Department Edit(int id)
        {
            Department department = context.departments.Find(id);
            return department;
        }
        public void Update(Department department)
        {
            context.departments.Attach(department);
            context.Entry(department).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

        }
    }
}
