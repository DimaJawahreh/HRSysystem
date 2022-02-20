using hrsystem.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrsystem.Service
{
  public  interface IEmployeeService
    {
        void Insert(Employee employee);
        Employee Edit(int id);
        void Update(Employee employee);
        void DeleteById(int id);
        List<Employee> GetEmployees();
    }
}
