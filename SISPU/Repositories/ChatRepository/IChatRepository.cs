using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  SISPU.Models
{
    using System.Collections.Generic;
    using ViewModel;

    public interface IChatRepository
    {

        int? CreateMessage(MessageVM G);

        int? CreateChats(GroupChatVM[] G);

        int? CreateChat(GroupChatVM G);

        int? DeleteGroupChat(string GroupChatName);

        List<Message> GetChat(string GroupChatName);

        List<GroupChat> GetAllGroupChats();

    }
    
}
