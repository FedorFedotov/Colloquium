using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPU.ViewModel
{
    using System.Collections.Generic;
    using SISPU.Models;

    public class GroupVM
    {

        public string c_name;
        public string c_desc;

        public GroupVM(Group gro)
        {
            this.c_name = gro.GroupName;
            this.c_desc = gro.GroupDesc;
        }

        public GroupVM()
        {
        }

    }
}
