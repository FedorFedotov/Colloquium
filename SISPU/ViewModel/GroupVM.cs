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

        public string group_name;
        public string group_id;

        public GroupVM(Group gro)
        {
            this.group_name = gro.GroupName;
            this.group_id = gro.GroupId;
        }

        public GroupVM()
        {
        }

    }
}
