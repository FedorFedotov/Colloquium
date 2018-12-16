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

    public class GroupTimetable
    {
        public int Id { get; set; }

        public string GroupName { get; set; }

        public List<GroupTimetableDay> GTD { get; set; }

        public bool IsDeleted { get; set; }

        public GroupTimetable()
        {
            GTD = new List<GroupTimetableDay>();
            IsDeleted = false;
        }

    }
}
