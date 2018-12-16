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
    [Route("api/group")]
    public class GroupController : Controller
    {

        private readonly IGroupRepository repository;

        public GroupController(IGroupRepository repository)
        {
            this.repository = repository;
        }


        [HttpGet]
        public JsonResult GetAllGroups()
        {
            var groups = repository.GetAllGroups();
            if (groups == null)
            {
                return Json(null);
            }

            List<GroupVM> view = new List<GroupVM>();
            foreach (Group item in groups)
            {
                view.Add(new GroupVM(item));
            }

            return Json(view);
        }


        [HttpPost]
        public JsonResult PostGroups([FromBody] GroupVM[] GG)
        {
            // int? id = repository.Create(GG);
            // return Json(id);
            return Json(null);
        }




    }
}