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

    public class Faculty
    {
        public int Id { get; set; }

        public string FacultyName { get; set; }

        public string FacultyId { get; set; }

        public List<Group> Groups { get; set; }

        public bool IsDeleted { get; set; }

        public Faculty()
        {
            Groups = new List<Group>();
            IsDeleted = false;
        }
    }
}