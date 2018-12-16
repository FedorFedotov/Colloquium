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
        public string group_department;
        public string group_employment;
        public int group_tasks;
        public int group_advice;
        public string[] group_tasks2;
        public string[] group_advice2;
        public string[] group_answers;
        public string[] group_recs;



        public GroupTimetableVM(GroupTimetable groupTimetable)
        {

            this.group_name = groupTimetable.GroupName;

            this.group_department = groupTimetable.GroupDepartment;

            this.group_employment = groupTimetable.GroupEmployment;

            this.group_tasks = groupTimetable.GroupTasks;

            this.group_advice = groupTimetable.GroupAdvice;

            this.group_tasks2 = groupTimetable.GroupTasks2;

            this.group_advice2 = groupTimetable.GroupAdvice2;

            this.group_answers = groupTimetable.Answers;

            this.group_recs = groupTimetable.Recs;


        }

        public GroupTimetableVM()
        {
        }
    }
}


