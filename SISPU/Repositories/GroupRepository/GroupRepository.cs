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

    public class GroupRepository : IGroupRepository
    {
            private Context context;
            private static Logger logger = LogManager.GetCurrentClassLogger();

            public GroupRepository(Context ctx)
            {
                context = ctx;
            }


            public List<Group> GetAllGroups()
            {
                var groups = context.GroupSet.Where(p => p.IsDeleted == false).ToList();

                return groups;
            }

            public int? Create(GroupVM[] GG)
            {

                int id = 0;

                foreach (GroupVM G in GG)
                {


                var gro = context.GroupSet.SingleOrDefault(v => v.GroupName == G.group_name && v.GroupId == G.group_id);
                if (gro == null)
                {
                    gro = new Group();
                    gro.GroupName = G.group_name;
                    gro.GroupId = G.group_id;
                    context.GroupSet.Add(gro);
                    context.SaveChanges();
                    id++;
                }


            }
                return id;
            }

        }
    }
