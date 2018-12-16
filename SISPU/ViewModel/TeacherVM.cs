using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPU.ViewModel
{
    using System.Collections.Generic;
    using SISPU.Models;

    public class TeacherVM
    {

        public string teacher_name;

        public TeacherVM(Teacher tec)
        {
            this.teacher_name = tec.TeacherName;
        }

        public TeacherVM()
        {
        }

    }
}


