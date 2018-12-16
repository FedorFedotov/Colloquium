using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace SISPU.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System;
    using NLog;
    using ViewModel;

    public class GrouptimetableRepository : IGrouptimetableRepository
    {
        private Context context;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public GrouptimetableRepository(Context ctx)
        {
            context = ctx;
        }



        public int? DeleteGroup(string GroupName)
        {
            int id = 0;
            var ggggg = context.GroupTimetableSet.SingleOrDefault(v => v.GroupName == GroupName);
            if (ggggg.IsDeleted == false)
            {
                ggggg.IsDeleted = true;
                context.SaveChanges();
                id = 1;
            }

            return id;
        }




        public List<GroupTimetable> GetAllGroupTimetables()
        {
            var grouptimetables = context.GroupTimetableSet.
                                    Include(v => v.GTD).
                                      ThenInclude(v => v.Day).
                                        ThenInclude(z => z.DL).
                                          ThenInclude(z => z.Lesson).
                                            ThenInclude(f => f.LT).ThenInclude(f => f.Teacher).
                                    Include(v => v.GTD).
                                      ThenInclude(v => v.Day).
                                        ThenInclude(z => z.DL).
                                          ThenInclude(z => z.Lesson).
                                            ThenInclude(f => f.LA).ThenInclude(f => f.Auditory).
                                         Where(p => p.IsDeleted == false).ToList();

            return grouptimetables;
        }

        public GroupTimetable GetGroupTimetable(string group_name)
        {
            var grouptimetable = context.GroupTimetableSet.
                                    Include(v => v.GTD).
                                      ThenInclude(v => v.Day).
                                        ThenInclude(z => z.DL).
                                          ThenInclude(z=>z.Lesson).
                                            ThenInclude(f=>f.LT).ThenInclude(f => f.Teacher).
                                    Include(v => v.GTD).
                                      ThenInclude(v => v.Day).
                                        ThenInclude(z => z.DL).
                                          ThenInclude(z => z.Lesson).
                                            ThenInclude(f => f.LA).ThenInclude(f => f.Auditory).
                                  SingleOrDefault(p => p.GroupName == group_name && p.IsDeleted == false);
            return grouptimetable;
        }

        public int? Create(GroupTimetableVM[] GG)
        {

            int id = 0;

            foreach (GroupTimetableVM G in GG)
            {
                GroupTimetable grouptimetabe = new GroupTimetable();
                grouptimetabe.GroupName = G.group_name;

                var ggg = context.GroupTimetableSet.FirstOrDefault(v => v.GroupName == grouptimetabe.GroupName);
            if (ggg == null)
            {
                List<Day> days = new List<Day>();
                foreach (DayVM dayVM in G.days)
                {
                    var day = new Day();
                    day.Weekday = dayVM.weekday;

                    // ------ для каждого day из списка days в GroupTimetable

                    List<Lesson> lessons = new List<Lesson>();
                    foreach (LessonVM lessonVM in dayVM.lessons)
                    {
                        var lesson = new Lesson();
                        lesson.Subject = lessonVM.subject;
                        lesson.Type = lessonVM.type;
                        lesson.TimeStart = lessonVM.time_start;
                        lesson.TimeEnd = lessonVM.time_end;
                        lesson.Parity = lessonVM.parity;
                        lesson.DateStart = lessonVM.date_start;
                        lesson.DateEnd = lessonVM.date_end;
                        if (lessonVM.dates != null) lesson.Dates = lessonVM.dates;

                            // +----- для каждого lesson из списка lessons в day

                        

                        if (lessonVM.teachers.Count != 0)
                        {
                            var teachers = new List<String>();
                            foreach (TeacherVM teacherVM in lessonVM.teachers)
                            {
                                if (!teachers.Contains(teacherVM.teacher_name))
                                {
                                        var tea = context.TeacherSet.SingleOrDefault(v => v.TeacherName == teacherVM.teacher_name);
                                        if (tea == null)
                                        {
                                            tea = new Teacher();
                                            tea.TeacherName = teacherVM.teacher_name;
                                            context.TeacherSet.Add(tea);
                                            context.SaveChanges();
                                        }


                                        var lt = context.LessonTeacherSet.SingleOrDefault(v => v.Lesson == lesson && v.Teacher == tea);
                                        if (lt == null)
                                        {
                                            lesson.LT.Add(new LessonTeacher { Lesson = lesson, Teacher = tea });
                                            context.SaveChanges();
                                        }
                                        else
                                        {
                                            if (lt.IsDeleted == true)
                                            {
                                                lt.IsDeleted = false;
                                            }
                                        }
                                        teachers.Add(teacherVM.teacher_name);
                                 }
                             

                            }

                        }

                        if (lessonVM.auditories.Count != 0)
                        {    
                            var auditoriesn = new List<String>();
                            var auditoriesa = new List<String>();
                            foreach (AuditoryVM auditoryVM in lessonVM.auditories)
                            {
                              if (!(auditoriesn.Contains(auditoryVM.auditory_name)&& auditoriesa.Contains(auditoryVM.auditory_address)))
                              {
                                var aud = context.AuditorySet.SingleOrDefault(v => v.AuditoryName == auditoryVM.auditory_name && v.AuditoryAdress == auditoryVM.auditory_address);
                                if (aud == null)
                                {
                                    aud = new Auditory();
                                    aud.AuditoryName = auditoryVM.auditory_name;
                                    aud.AuditoryAdress = auditoryVM.auditory_address;
                                    context.AuditorySet.Add(aud);
                                    context.SaveChanges();
                                }

                                var la = context.LessonAuditorySet.SingleOrDefault(v => v.Lesson == lesson && v.Auditory == aud);
                                if (la == null)
                                {
                                    lesson.LA.Add(new LessonAuditory { Lesson = lesson, Auditory = aud });
                                    context.SaveChanges();
                                }
                                else
                                {
                                    if (la.IsDeleted == true)
                                    {
                                        la.IsDeleted = false;
                                    }
                                }
                                auditoriesn.Add(auditoryVM.auditory_name);
                                auditoriesa.Add(auditoryVM.auditory_address);
                              }

                            }

                        }

                        context.LessonSet.Add(lesson);
                        context.SaveChanges();


                        var dl = context.DayLessonSet.SingleOrDefault(v => v.Day == day && v.Lesson == lesson);
                        if (dl == null)
                        {
                            day.DL.Add(new DayLesson { Day = day, Lesson = lesson });
                            context.SaveChanges();
                        }
                        else
                        {
                            if (dl.IsDeleted == true)
                            {
                                dl.IsDeleted = false;
                            }
                        }


                    }



                    // ------


                    context.DaySet.Add(day);
                    context.SaveChanges();


                    var gtd = context.GroupTimetableDaySet.SingleOrDefault(v => v.GroupTimetable == grouptimetabe && v.Day == day);
                    if (gtd == null)
                    {
                        grouptimetabe.GTD.Add(new GroupTimetableDay { GroupTimetable = grouptimetabe, Day = day });
                        context.SaveChanges();
                    }
                    else
                    {
                        if (gtd.IsDeleted == true)
                        {
                            gtd.IsDeleted = false;
                        }
                    }

                }



                var a = context.GroupTimetableSet.Add(grouptimetabe);
                int check = context.SaveChanges();
               int? i = a.Entity.Id;

            }
            else
            {
                //return 0;
            }

        }
            return id;
        }

        

       
    }
}
