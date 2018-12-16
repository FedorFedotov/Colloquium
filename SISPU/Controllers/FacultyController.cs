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
    [Route("api/faculty")]
    public class FacultyController : Controller
    {


        private readonly IFacultyRepository repository;

        public FacultyController(IFacultyRepository repository)
        {
            this.repository = repository;
        }


        [HttpGet]
        public JsonResult GetAllFaculties()
        {
            var faculties = repository.GetAllFaculties();
            if (faculties == null)
            {
                return Json(null);
            }

            List<FacultyVM> view = new List<FacultyVM>();
            foreach (Faculty item in faculties)
            {
                view.Add(new FacultyVM(item));
            }

            return Json(view);
        }


        [HttpPost]
        public JsonResult PostFaculties([FromBody] FacultyVM[] GG)
        {
            int? id = repository.Create(GG);
            return Json(id);
        }

    }
}