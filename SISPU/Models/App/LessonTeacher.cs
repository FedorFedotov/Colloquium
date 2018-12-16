using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPU.Models
{
    public class LessonTeacher
    {
        public LessonTeacher()
        {
            IsDeleted = false;
        }

        public int LessonId { get; set; }

        public Lesson Lesson { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public bool IsDeleted { get; set; }
    }
}
