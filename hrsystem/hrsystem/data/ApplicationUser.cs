using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrsystem.data
{
    public class ApplicationUser:IdentityUser
    {
        public string name { set; get; }
    }

}
