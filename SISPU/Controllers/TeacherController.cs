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
    [Route("api/teacher")]
    public class TeacherController : Controller
    {


        private readonly ITeacherRepository repository;

        public TeacherController(ITeacherRepository repository)
        {
            this.repository = repository;
        }


        [HttpGet]
        public JsonResult GetAllTeachers()
        {
            var teachers = repository.GetAllTeachers();
            if (teachers == null)
            {
                return Json(null);
            }

            List<TeacherVM> view = new List<TeacherVM>();
            foreach (Teacher item in teachers)
            {
                view.Add(new TeacherVM(item));
            }

            return Json(view);
        }

        [HttpGet("{teacher_name}")]
        public JsonResult GetGroupTimetable([FromRoute] string teacher_name)
        {
            var teatimetables = repository.GetGroupTimetable(teacher_name);
            if (teatimetables == null)
            {
                return Json(null);
            }

            List<GroupTimetableVM> view = new List<GroupTimetableVM>();
            Boolean flag = false;
            foreach (GroupTimetable item in teatimetables)
            { foreach (GroupTimetableDay ite in item.GTD)
                {
                    foreach (DayLesson it in ite.Day.DL)
                    {
                        foreach (LessonTeacher i in it.Lesson.LT)
                        {
                            if (i.Teacher.TeacherName == teacher_name) flag = true;
                        }
                    }
                     
                }
                    

               if (flag==true) view.Add(new GroupTimetableVM(item));
                flag = false;
            }

            return Json(view);
        }



    }
}