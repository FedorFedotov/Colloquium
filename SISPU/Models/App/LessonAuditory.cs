using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPU.Models
{
    public class LessonAuditory
    {
        public LessonAuditory()
        {
            IsDeleted = false;
        }

        public int LessonId { get; set; }

        public Lesson Lesson { get; set; }

        public int AuditoryId { get; set; }

        public Auditory Auditory { get; set; }

        public bool IsDeleted { get; set; }
    }
}