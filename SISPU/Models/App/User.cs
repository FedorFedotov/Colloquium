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

    public class User
    {
        public int Id { get; set; }

        public bool Status { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Year { get; set; }
        
        public Group Group { get; set; }

        public bool IsDeleted { get; set; }

        public User()
        {
            IsDeleted = false;
        }
    }
}