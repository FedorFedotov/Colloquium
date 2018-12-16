using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SISPU.Models
{
    using Microsoft.EntityFrameworkCore;

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {

        }

        public DbSet<Faculty> FacultySet { get; set; }

        public DbSet<Group> GroupSet { get; set; }

        public DbSet<Auditory> AuditorySet { get; set; }

        public DbSet<Day> DaySet { get; set; }

        public DbSet<User> UserSet { get; set; }

        public DbSet<GroupChat> GroupChatSet { get; set; }

        public DbSet<Teacher> TeacherSet { get; set; }

        public DbSet<Message> MessageSet { get; set; }

        public DbSet<Lesson> LessonSet { get; set; }

        public DbSet<GroupTimetable> GroupTimetableSet { get; set; }

        // развязочные таблицы 

        public DbSet<LessonAuditory> LessonAuditorySet { get; set; }

        public DbSet<LessonTeacher> LessonTeacherSet { get; set; }

        public DbSet<DayLesson> DayLessonSet { get; set; }

        public DbSet<GroupTimetableDay> GroupTimetableDaySet { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Составные ключи

            modelBuilder.Entity<LessonAuditory>()
                  .HasKey(s => new { s.LessonId, s.AuditoryId });

            modelBuilder.Entity<LessonTeacher>()
                  .HasKey(s => new { s.LessonId, s.TeacherId });

            modelBuilder.Entity<DayLesson>()
              .HasKey(s => new { s.DayId, s.LessonId });

            modelBuilder.Entity<GroupTimetableDay>()
              .HasKey(s => new { s.GroupTimetableId, s.DayId });

        }

    }
}
