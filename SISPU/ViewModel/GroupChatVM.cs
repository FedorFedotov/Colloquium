using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPU.ViewModel
{
    using System.Collections.Generic;
    using SISPU.Models;

    public class GroupChatVM
    {

        public string groupchat_name;
        public int id;

        public GroupChatVM(GroupChat gro)
        {
            this.groupchat_name = gro.Name;
            this.id = gro.Id;
        }

        public GroupChatVM()
        {
        }

    }
}
