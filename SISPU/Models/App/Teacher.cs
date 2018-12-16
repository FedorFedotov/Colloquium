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

    public class Teacher
    {
        public int Id { get; set; }

        public string TeacherName { get; set; }

        public virtual List<LessonTeacher> LT { get; set; }

        public bool IsDeleted { get; set; }

        public Teacher()
        {
            IsDeleted = false;
        }
    }
}