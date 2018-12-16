﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SISPU.Models;
using System;

namespace SISPU.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SISPU.Models.Auditory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuditoryAdress");

                    b.Property<string>("AuditoryName");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.ToTable("AuditorySet");
                });

            modelBuilder.Entity("SISPU.Models.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("Weekday");

                    b.HasKey("Id");

                    b.ToTable("DaySet");
                });

            modelBuilder.Entity("SISPU.Models.DayLesson", b =>
                {
                    b.Property<int>("DayId");

                    b.Property<int>("LessonId");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("DayId", "LessonId");

                    b.HasIndex("LessonId");

                    b.ToTable("DayLessonSet");
                });

            modelBuilder.Entity("SISPU.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FacultyId");

                    b.Property<string>("FacultyName");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.ToTable("FacultySet");
                });

            modelBuilder.Entity("SISPU.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FacultyId");

                    b.Property<string>("GroupId");

                    b.Property<string>("GroupName");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("GroupSet");
                });

            modelBuilder.Entity("SISPU.Models.GroupChat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("GroupChatSet");
                });

            modelBuilder.Entity("SISPU.Models.GroupTimetable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GroupName");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.ToTable("GroupTimetableSet");
                });

            modelBuilder.Entity("SISPU.Models.GroupTimetableDay", b =>
                {
                    b.Property<int>("GroupTimetableId");

                    b.Property<int>("DayId");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("GroupTimetableId", "DayId");

                    b.HasIndex("DayId");

                    b.ToTable("GroupTimetableDaySet");
                });

            modelBuilder.Entity("SISPU.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DateEnd");

                    b.Property<string>("DateStart");

                    b.Property<int>("Dates");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("Parity");

                    b.Property<string>("Subject");

                    b.Property<string>("TimeEnd");

                    b.Property<string>("TimeStart");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("LessonSet");
                });

            modelBuilder.Entity("SISPU.Models.LessonAuditory", b =>
                {
                    b.Property<int>("LessonId");

                    b.Property<int>("AuditoryId");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("LessonId", "AuditoryId");

                    b.HasIndex("AuditoryId");

                    b.ToTable("LessonAuditorySet");
                });

            modelBuilder.Entity("SISPU.Models.LessonTeacher", b =>
                {
                    b.Property<int>("LessonId");

                    b.Property<int>("TeacherId");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("LessonId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("LessonTeacherSet");
                });

            modelBuilder.Entity("SISPU.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChatId");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Text");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserId");

                    b.ToTable("MessageSet");
                });

            modelBuilder.Entity("SISPU.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("TeacherName");

                    b.HasKey("Id");

                    b.ToTable("TeacherSet");
                });

            modelBuilder.Entity("SISPU.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GroupId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Login");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<bool>("Status");

                    b.Property<string>("Surname");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("UserSet");
                });

            modelBuilder.Entity("SISPU.Models.DayLesson", b =>
                {
                    b.HasOne("SISPU.Models.Day", "Day")
                        .WithMany("DL")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SISPU.Models.Lesson", "Lesson")
                        .WithMany("DL")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SISPU.Models.Group", b =>
                {
                    b.HasOne("SISPU.Models.Faculty")
                        .WithMany("Groups")
                        .HasForeignKey("FacultyId");
                });

            modelBuilder.Entity("SISPU.Models.GroupTimetableDay", b =>
                {
                    b.HasOne("SISPU.Models.Day", "Day")
                        .WithMany("GTD")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SISPU.Models.GroupTimetable", "GroupTimetable")
                        .WithMany("GTD")
                        .HasForeignKey("GroupTimetableId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SISPU.Models.LessonAuditory", b =>
                {
                    b.HasOne("SISPU.Models.Auditory", "Auditory")
                        .WithMany("LA")
                        .HasForeignKey("AuditoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SISPU.Models.Lesson", "Lesson")
                        .WithMany("LA")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SISPU.Models.LessonTeacher", b =>
                {
                    b.HasOne("SISPU.Models.Lesson", "Lesson")
                        .WithMany("LT")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SISPU.Models.Teacher", "Teacher")
                        .WithMany("LT")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SISPU.Models.Message", b =>
                {
                    b.HasOne("SISPU.Models.GroupChat", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatId");

                    b.HasOne("SISPU.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SISPU.Models.User", b =>
                {
                    b.HasOne("SISPU.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");
                });
#pragma warning restore 612, 618
        }
    }
}
