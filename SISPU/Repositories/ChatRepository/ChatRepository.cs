using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace  SISPU.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System;
    using NLog;
    using ViewModel;

    public class ChatRepository : IChatRepository
    {

        private Context context;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ChatRepository(Context ctx)
        {
            context = ctx;
        }


        public List<Message> GetChat(string GroupChatName)
        {
            var messages = context.MessageSet.Where(p => p.IsDeleted == false && p.Chat.Name == GroupChatName).ToList();

            return messages;
        }

        public int? DeleteGroupChat(string GroupChatName)
        {
            int id=0;
            var ggggg = context.GroupChatSet.SingleOrDefault(v => v.Name == GroupChatName);
            if (ggggg.IsDeleted == false)
            {
                ggggg.IsDeleted = true;
                context.SaveChanges();
                id =1;
            }

            return id;
        }

        public List<GroupChat> GetAllGroupChats()
        {
            var groupchats = context.GroupChatSet.Where(p => p.IsDeleted == false).ToList();    

            return groupchats;
        }

        public int? CreateMessage(MessageVM G)
        {


                    var mes = new Message();
                    mes.Id = G.id;
                    mes.Text = G.message_text;
                    mes.Date = G.date;

                    var gc = context.GroupChatSet.SingleOrDefault(v => v.Name == G.groupchat.groupchat_name && v.Id == G.groupchat.id);
                        //if (gc == null)
                        //{
                        //    gc = new GroupChat();
                        //    gc.Name = G.groupchat.groupchat_name;
                        //    gc.Id = G.groupchat.id;

                        //    context.GroupChatSet.Add(gc);
                        //    context.SaveChanges();

                        //}

                    mes.Chat = gc;

                       var us = context.UserSet.SingleOrDefault(v => v.Id == G.user.id);
                       mes.User = us;




                    var a = context.MessageSet.Add(mes);
                    context.SaveChanges();
                    int check = context.SaveChanges();
                    int? id = a.Entity.Id;
                    return id;
        }

        public int? CreateChats(GroupChatVM[] GG)
        {
            int id = 0;
            foreach(GroupChatVM G in GG)
            {

                var ggggg = context.GroupChatSet.FirstOrDefault(v => v.Name == G.groupchat_name);
                if (ggggg == null)
                {
                    GroupChat groupchat = new GroupChat();
                    groupchat.Name = G.groupchat_name;
                    var a = context.GroupChatSet.Add(groupchat);
                    context.SaveChanges();
                    int check = context.SaveChanges();
                    int? i = a.Entity.Id;
                    if (i > -1) id++;

                }
                else
                {
                    if (ggggg.IsDeleted == true)
                    {
                        ggggg.IsDeleted = false;
                        context.SaveChanges();
                        id++;
                    }
                }
            }
            return id;
            
        }

        public int? CreateChat(GroupChatVM G)
        {

                var ggggg = context.GroupChatSet.FirstOrDefault(v => v.Name == G.groupchat_name);
            if (ggggg == null)
            {
                GroupChat groupchat = new GroupChat();
                groupchat.Name = G.groupchat_name;
                var a = context.GroupChatSet.Add(groupchat);
                context.SaveChanges();
                int check = context.SaveChanges();
                int? id = a.Entity.Id;
                return id;

            }
            else
            {
                if (ggggg.IsDeleted == true)
                {
                    ggggg.IsDeleted = false;
                    context.SaveChanges();
                    return ggggg.Id;
                }
                else
                {
                    return null;
                }
            }
        }



    }
}
