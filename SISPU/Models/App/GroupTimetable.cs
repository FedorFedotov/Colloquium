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
        public string GroupName { get; set; }

        public string GroupDepartment { get; set; }

        public string GroupEmployment { get; set; }

        public int GroupTasks { get; set; }

        public int GroupAdvice { get; set; }


    }
}
