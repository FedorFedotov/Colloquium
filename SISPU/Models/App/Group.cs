using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPU.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class Group
    {

        public string GroupName { get; set; }

        public string GroupDesc { get; set; }


    }
}