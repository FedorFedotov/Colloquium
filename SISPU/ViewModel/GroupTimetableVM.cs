using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPU.ViewModel
{
    using System.Collections.Generic;
    using SISPU.Models;

    public class GroupTimetableVM
    {

        public string group_name;

        public List<DayVM> days = new List<DayVM>();


        public GroupTimetableVM(GroupTimetable groupTimetable)
        {

            this.group_name = groupTimetable.GroupName;


            days = new List<DayVM>();

            foreach (GroupTimetableDay item in groupTimetable.GTD)
            {
                if (item.IsDeleted == false)
                {
                    days.Add(new DayVM(item.Day));
                }
            }

        }

        public GroupTimetableVM()
        {
        }
    }
}


