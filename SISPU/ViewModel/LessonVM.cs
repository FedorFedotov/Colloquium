using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPU.ViewModel
{
    using System.Collections.Generic;
    using SISPU.Models;

    public class LessonVM
    {

        public string subject;

        public int type;

        public string time_start;

        public string time_end;

        public int parity;

        public string date_start;

        public string date_end;

        public int dates;

        public List<TeacherVM> teachers = new List<TeacherVM>();

        public List<AuditoryVM> auditories = new List<AuditoryVM>();


        public LessonVM(Lesson lesson)
        {
            this.subject = lesson.Subject;
            this.type = lesson.Type;
            this.time_start = lesson.TimeStart;
            this.time_end = lesson.TimeEnd;
            this.parity = lesson.Parity;
            this.date_start = lesson.DateStart;
            this.date_end = lesson.DateEnd;
            this.dates = lesson.Dates;



            teachers = new List<TeacherVM>();

            foreach (LessonTeacher item in lesson.LT)
            {
                if (item.IsDeleted == false)
                {
                    teachers.Add(new TeacherVM(item.Teacher));
                }
            }

            auditories = new List<AuditoryVM>();

            foreach (LessonAuditory item in lesson.LA)
            {
                if (item.IsDeleted == false)
                {
                    auditories.Add(new AuditoryVM(item.Auditory));
                }
            }
       
    }

        public LessonVM()
        {
        }
    }
}


