using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPU.Models
{
    public class GroupTimetableDay
    {
        public GroupTimetableDay()
        {
            IsDeleted = false;
        }

        public int GroupTimetableId { get; set; }

        public GroupTimetable GroupTimetable { get; set; }

        public int DayId { get; set; }

        public Day Day { get; set; }

        public bool IsDeleted { get; set; }
    }
}