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
        public int Id { get; set; }

        public string GroupName { get; set; }

        public string GroupId { get; set; }

        public bool IsDeleted { get; set; }

        public Group()
        {
            IsDeleted = false;
        }
    }
}