using hrsystem.helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hrsystem.data
{[Table("Employees")]
    public class Employee
    {
        public int id { set; get; }
        public string name { set; get; }
        [RegularExpression(@"07(7|8|9)\d{7}")]
        public string phone { set; get; }
        [EmailAddress]
        public string email { set; get; }

        public string gender { set; get; }
        [datevalidation]
        public DateTime birtodate { set; get; }
        public string photopath { set; get; }
        [datevalidation]
        public DateTime dateofjoining { set; get; }
        [ForeignKey("department")]
        public int dept_id { set; get; }
        public Department department { set; get; }
    }
}
