using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPU.Models
{
    using System.Collections.Generic;
    using ViewModel;

    public interface IFacultyRepository
    {

        int? Create(FacultyVM[] GG);

        List<Faculty> GetAllFaculties();

    }
}
