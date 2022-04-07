using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project_API_2021.Model
{
    public class Role
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        //public string RoleDescription { get; set; }

        //public ICollection<Champion> Champions { get; set; }
    }
}
