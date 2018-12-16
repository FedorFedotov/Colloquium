using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPU.ViewModel
{
    using System.Collections.Generic;
    using SISPU.Models;

    public class FacultyVM
    {

        public string faculty_name;
        public string faculty_id;
        public List<GroupVM> groups = new List<GroupVM>();

        public FacultyVM(Faculty fac)
        {

            this.faculty_name = fac.FacultyName;
            this.faculty_id = fac.FacultyId;

            groups = new List<GroupVM>();
            foreach (Group item in fac.Groups)
            {
                if (item.IsDeleted == false)
                {
                    groups.Add(new GroupVM(item));
                }
            }
        }

        public FacultyVM()
        {
        }

    }
}
