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

    public class Auditory
    {
        public int Id { get; set; }

        public string AuditoryName { get; set; }

        public virtual List<LessonAuditory> LA { get; set; }

        public string AuditoryAdress { get; set; }

        public bool IsDeleted { get; set; }

        public Auditory()
        {
            IsDeleted = false;
        }
    }
}