using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPU.Models
{
    public class DayLesson
    {
        public DayLesson()
        {
            IsDeleted = false;
        }

        public int DayId { get; set; }

        public Day Day { get; set; }

        public int LessonId { get; set; }

        public Lesson Lesson { get; set; }

        public bool IsDeleted { get; set; }
    }
}