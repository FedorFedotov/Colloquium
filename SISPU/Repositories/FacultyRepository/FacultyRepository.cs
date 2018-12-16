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

    public class FacultyRepository : IFacultyRepository
    {

        private Context context;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public FacultyRepository(Context ctx)
        {
            context = ctx;
        }


        public List<Faculty> GetAllFaculties()
        {
            var faculties = context.FacultySet.Include(v => v.Groups).
                                          Where(p => p.IsDeleted == false).ToList();

            return faculties;
        }



        public int? Create(FacultyVM[] GG)
        {

            int id = 0;

            foreach (FacultyVM G in GG)
            {


                var fac = context.FacultySet.SingleOrDefault(v => v.FacultyName == G.faculty_name && v.FacultyId == G.faculty_id);
                if (fac == null)
                {
                    fac = new Faculty();
                    fac.FacultyName = G.faculty_name;
                    fac.FacultyId = G.faculty_id;

                    foreach (GroupVM groupVM in G.groups)
                    {

                        var gro = context.GroupSet.SingleOrDefault(v => v.GroupName == groupVM.group_name && v.GroupId == groupVM.group_id);
                        if (gro == null)
                        {
                            gro = new Group();
                            gro.GroupName = groupVM.group_name;
                            gro.GroupId = groupVM.group_id;

                            context.GroupSet.Add(gro);
                            context.SaveChanges();
                            
                        }

                        fac.Groups.Add(gro);


                    }


                    context.FacultySet.Add(fac);
                    context.SaveChanges();
                    id++;
                }


            }
            return id;
        }


    }
}
