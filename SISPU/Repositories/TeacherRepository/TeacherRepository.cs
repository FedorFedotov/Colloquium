using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace SISPU.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System;
    using NLog;
    using ViewModel;

    public class TeacherRepository : ITeacherRepository
    {
        private Context context;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public TeacherRepository(Context ctx)
        {
            context = ctx;
        }


        public List<Teacher> GetAllTeachers()
        {
            var teachers = context.TeacherSet.Where(p => p.IsDeleted == false).ToList();

            return teachers;
        }

        public List<GroupTimetable> GetGroupTimetable(string teacher_name)
        {
            // var timetables = context.GroupTimetableSet.
            //                         Include(v => v.GTD).
            //                           ThenInclude(v => v.Day).
            //                             ThenInclude(z => z.DL).
            //                               ThenInclude(z => z.Lesson).
            //                                 ThenInclude(f => f.LT).ThenInclude(f => f.Teacher).
            //                         Include(v => v.GTD).
            //                           ThenInclude(v => v.Day).
            //                             ThenInclude(z => z.DL).
            //                               ThenInclude(z => z.Lesson).
            //                                 ThenInclude(f => f.LA).ThenInclude(f => f.Auditory).
            //                              Where(p => p.IsDeleted == false).ToList();

            return null;
        }






    }
}
