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

    public class Lesson
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public int Type { get; set; }

        public string TimeStart { get; set; } // спросить 

        public string TimeEnd { get; set; } // спросить 

        public int Parity { get; set; } // спросить 

        public string DateStart { get; set; } // спросить 

        public string DateEnd { get; set; } // спросить 

        public int Dates { get; set; } // спросить 

        public virtual List<DayLesson> DL { get; set; }

        public List<LessonTeacher> LT { get; set; }

        public List<LessonAuditory> LA { get; set; }

        public bool IsDeleted { get; set; }

        public Lesson()
        {
            LT = new List<LessonTeacher>();
            LA = new List<LessonAuditory>();
            IsDeleted = false;
        }
    }
}
