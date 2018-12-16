using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPU.Models
{
    using System.Collections.Generic;
    using ViewModel;

    public interface ITeacherRepository
    {

        List<GroupTimetable> GetGroupTimetable(string teacher_name);

        List<Teacher> GetAllTeachers();

    }




}




