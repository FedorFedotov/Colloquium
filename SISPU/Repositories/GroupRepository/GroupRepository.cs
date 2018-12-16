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
                // var groups = context.GroupSet.Where(p => p.IsDeleted == false).ToList();
                List<Group> groups = new List<Group>();
                Group a = new Group();
                a.GroupName = "Akvelon, Inc.";
                a.GroupDesc = "Основная цель компании — это промышленая разработка заказного программного обеспечения для известных технологических и телекоммуникационных компаний, а также фирм, работающих в области юриспруденции, образования, масмедиа, туризма, медицины и пр. Akvelon работает только с американскими и европейскими компаниями. Уже не первый год является золотым партнером Microsoft (Microsoft Gold Certified Partner) и сотрудничает с командами Microsoft в области разработки Microsoft Sharepoint и Microsoft Dynamics CRM. Головной офис компании находится в городе Белвью (штат Вашингтон, США). Филиалы компании открыты в Иванове, Ярославле, Казани и Харькове. Во всех офисах Аквелон в настоящее время работает более 350 сотрудников. 1 июня 2011 года журнал «Puget Sound Business Journal» внес компанию Аквелон в список 50 самых быстрорастущих компаний штата Вашингтон в 4-й раз с 2008 года.";
                Group i = new Group();
                i.GroupName = "Involta.";
                i.GroupDesc = "Компания Involta со своим опытом и наработками в области запуска интернет-проектов поможет Вам реализовать бизнес-мечту. Мы будем рады иметь дело с людьми, которые хотят воплотить в жизнь свою идею и верят в исключительные возможности сети интернет. Кроме финансовой поддержки и консалтинга, мы готовы взять на себя организационные вопросы (от офиса, до подбора персонала), чтобы помочь сфокусироваться на важном.";
                groups.Add(a);
                groups.Add(i);
                return groups;
            }

            public int? Create(GroupVM[] GG)
            {

            //     int id = 0;

            //     foreach (GroupVM G in GG)
            //     {


            //     var gro = context.GroupSet.SingleOrDefault(v => v.GroupName == G.group_name && v.GroupId == G.group_id);
            //     if (gro == null)
            //     {
            //         gro = new Group();
            //         gro.GroupName = G.group_name;
            //         gro.GroupId = G.group_id;
            //         context.GroupSet.Add(gro);
            //         context.SaveChanges();
            //         id++;
            //     }


            // }
            //     return id;
            return null;
            }

        }
    }
