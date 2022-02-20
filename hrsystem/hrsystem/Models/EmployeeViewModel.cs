using hrsystem.data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrsystem.Models
{
    public class EmployeeViewModel
    {
        public List<Department> departments { set; get; }
        public Employee employee { set; get; }
        public IFormFile imgpath { set; get; }
    }
}
