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
    [Route("api/grouptimetable")]
    public class GrouptimetableController : Controller
    {

        private readonly IGrouptimetableRepository repository;

        public GrouptimetableController(IGrouptimetableRepository repository)
        {
            this.repository = repository;
        }


        [HttpGet]
        public JsonResult GetAllGroupTimetables()
        {
            var grouptimetables = repository.GetAllGroupTimetables();
            if (grouptimetables == null)
            {
                return Json(null);
            }

            List<GroupTimetableVM> view = new List<GroupTimetableVM>();
            foreach (GroupTimetable item in grouptimetables)
            {
                view.Add(new GroupTimetableVM(item));
            }

            return Json(view);
        }

        [HttpDelete("{GroupName}")]
        public JsonResult PostChat([FromRoute]string GroupName)
        {
            int? id = repository.DeleteGroup(GroupName);
            return Json(id);
        }


        [HttpGet("{group_name}")]
        public JsonResult GetPosition([FromRoute]string group_name)
        {
            var grouptimetable = repository.GetGroupTimetable(group_name);
            if (grouptimetable == null)
            {
                return Json(null);
            }

            GroupTimetableVM view = new GroupTimetableVM(grouptimetable);
            return Json(view);
        }

        [HttpPost]
        public JsonResult PostGrouptimetable([FromBody] GroupTimetableVM[] GG)
        {
            int? id = repository.Create(GG);
            return Json(id);
        }




    }
}

