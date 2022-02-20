using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hrsystem.data
{[Table("Departments")]
    public class Department
    {
        [Display(Name ="Name")]
        public string name { set; get; }
        public int id { set; get; }
        public List<Employee> employees { set; get; }
    }
}
