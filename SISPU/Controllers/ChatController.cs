using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISPU.Models;
using SISPU.ViewModel;
using Microsoft.AspNetCore.Cors;
namespace SISPU.Controllers
{
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("api/chat")]
    public class ChatController : Controller
    {

        private readonly IChatRepository repository;

        public ChatController(IChatRepository repository)
        {
            this.repository = repository;
        }


        [HttpGet("{GroupChatName}")]
        public JsonResult GetMessages([FromRoute]string GroupChatName)
        {
            var messages = repository.GetChat(GroupChatName);
            if (messages == null)
            {
                return Json(null);
            }

            List<MessageVM> view = new List<MessageVM>();
            foreach (Message item in messages)
            {
                view.Add(new MessageVM(item));
            }

            return Json(view);
        }

        [HttpGet]
        public JsonResult GetAllGroupChats()
        {
            var grouptchats = repository.GetAllGroupChats();
            if (grouptchats == null)
            {
                return Json(null);
            }

            List<GroupChatVM> view = new List<GroupChatVM>();
            foreach (GroupChat item in grouptchats)
            {
                view.Add(new GroupChatVM(item));
            }

            return Json(view);
        }

        [HttpPost("message/")]
        public JsonResult PostMessage([FromBody] MessageVM GG)
        {
            int? id = repository.CreateMessage(GG);
            return Json(id);
        }

        [HttpPost]
        public JsonResult PostChats([FromBody] GroupChatVM[] GG)
        {
            int? id = repository.CreateChats(GG);
            return Json(id);
        }

        [HttpPost("groupchat/")]
        public JsonResult PostChat([FromBody] GroupChatVM G)
        {
            int? id = repository.CreateChat(G);
            return Json(id);
        }

        [HttpDelete("{GroupChatName}")]
        public JsonResult PostChat([FromRoute]string GroupChatName)
        {
            int? id = repository.DeleteGroupChat(GroupChatName);
            return Json(id);
        }


    }
}