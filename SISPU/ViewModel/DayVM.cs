using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SISPU.ViewModel
{
    using System.Collections.Generic;
    using SISPU.Models;

    public class DayVM
    {

        public int weekday;

        public List<LessonVM> lessons= new List<LessonVM>();


        public DayVM(Day day)
        {

            this.weekday = day.Weekday;


            lessons = new List<LessonVM>();

            foreach (DayLesson item in day.DL)
            {
                if (item.IsDeleted == false)
                {
                    lessons.Add(new LessonVM(item.Lesson));
                }
            }

        }

        public DayVM()
        {
        }
    }
}


