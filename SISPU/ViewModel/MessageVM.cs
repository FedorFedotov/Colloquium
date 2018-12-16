using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPU.ViewModel
{
    using System.Collections.Generic;
    using SISPU.Models;

    public class MessageVM
    {
        public int id;
        public string message_text;
        public GroupChatVM groupchat;
        public UserVM user;
        public DateTime date;

        public MessageVM(Message mes)
        {

            this.id = mes.Id;
            this.message_text = mes.Text;
            this.date = mes.Date;

            groupchat = new GroupChatVM();
                if (mes.Chat.IsDeleted == false)
                {
                groupchat = new GroupChatVM(mes.Chat);
                }

            user = new UserVM();
            if (mes.User.IsDeleted == false)
            {
                user = new UserVM(mes.User);
            }
        }

        public MessageVM()
        {
        }

    }
}
