using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPU.Models
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class Day
    {
        public int Id { get; set; }

        public int Weekday { get; set; }

        public List<DayLesson> DL { get; set; }

        public virtual List<GroupTimetableDay> GTD { get; set; }

        public bool IsDeleted { get; set; }

        public Day()
        {
            DL = new List<DayLesson>();
            IsDeleted = false;
        }

    }
}
