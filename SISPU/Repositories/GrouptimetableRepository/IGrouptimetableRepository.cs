using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPU.Models
{
    using System.Collections.Generic;
    using ViewModel;

    public interface IGrouptimetableRepository
    {

        int? Create(GroupTimetableVM[] GG);

        GroupTimetable GetGroupTimetable(string group_name);

        List<GroupTimetable> GetAllGroupTimetables();

        int? DeleteGroup(string GroupName);


    }

    

 
}
