using hrsystem.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrsystem.Service
{
  public  interface IDepartmentService
    {
        void Insert(Department department);
        void DeleteById(int id);
        List<Department> GetDepartments();
        Department Edit(int id);
        void Update(Department department);
    }
}
