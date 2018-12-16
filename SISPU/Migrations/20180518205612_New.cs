using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SISPU.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditorySet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuditoryAdress = table.Column<string>(nullable: true),
                    AuditoryName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditorySet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DaySet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Weekday = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaySet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacultySet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FacultyId = table.Column<string>(nullable: true),
                    FacultyName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultySet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupChatSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChatSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupTimetableSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTimetableSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateEnd = table.Column<string>(nullable: true),
                    DateStart = table.Column<string>(nullable: true),
                    Dates = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Parity = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    TimeEnd = table.Column<string>(nullable: true),
                    TimeStart = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TeacherName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FacultyId = table.Column<int>(nullable: true),
                    GroupId = table.Column<string>(nullable: true),
                    GroupName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupSet_FacultySet_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "FacultySet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupTimetableDaySet",
                columns: table => new
                {
                    GroupTimetableId = table.Column<int>(nullable: false),
                    DayId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTimetableDaySet", x => new { x.GroupTimetableId, x.DayId });
                    table.ForeignKey(
                        name: "FK_GroupTimetableDaySet_DaySet_DayId",
                        column: x => x.DayId,
                        principalTable: "DaySet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupTimetableDaySet_GroupTimetableSet_GroupTimetableId",
                        column: x => x.GroupTimetableId,
                        principalTable: "GroupTimetableSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayLessonSet",
                columns: table => new
                {
                    DayId = table.Column<int>(nullable: false),
                    LessonId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayLessonSet", x => new { x.DayId, x.LessonId });
                    table.ForeignKey(
                        name: "FK_DayLessonSet_DaySet_DayId",
                        column: x => x.DayId,
                        principalTable: "DaySet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayLessonSet_LessonSet_LessonId",
                        column: x => x.LessonId,
                        principalTable: "LessonSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonAuditorySet",
                columns: table => new
                {
                    LessonId = table.Column<int>(nullable: false),
                    AuditoryId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonAuditorySet", x => new { x.LessonId, x.AuditoryId });
                    table.ForeignKey(
                        name: "FK_LessonAuditorySet_AuditorySet_AuditoryId",
                        column: x => x.AuditoryId,
                        principalTable: "AuditorySet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonAuditorySet_LessonSet_LessonId",
                        column: x => x.LessonId,
                        principalTable: "LessonSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonTeacherSet",
                columns: table => new
                {
                    LessonId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTeacherSet", x => new { x.LessonId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_LessonTeacherSet_LessonSet_LessonId",
                        column: x => x.LessonId,
                        principalTable: "LessonSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonTeacherSet_TeacherSet_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "TeacherSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Surname = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSet_GroupSet_GroupId",
                        column: x => x.GroupId,
                        principalTable: "GroupSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MessageSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChatId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageSet_GroupChatSet_ChatId",
                        column: x => x.ChatId,
                        principalTable: "GroupChatSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageSet_UserSet_UserId",
                        column: x => x.UserId,
                        principalTable: "UserSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayLessonSet_LessonId",
                table: "DayLessonSet",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupSet_FacultyId",
                table: "GroupSet",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTimetableDaySet_DayId",
                table: "GroupTimetableDaySet",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonAuditorySet_AuditoryId",
                table: "LessonAuditorySet",
                column: "AuditoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonTeacherSet_TeacherId",
                table: "LessonTeacherSet",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageSet_ChatId",
                table: "MessageSet",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageSet_UserId",
                table: "MessageSet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSet_GroupId",
                table: "UserSet",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayLessonSet");

            migrationBuilder.DropTable(
                name: "GroupTimetableDaySet");

            migrationBuilder.DropTable(
                name: "LessonAuditorySet");

            migrationBuilder.DropTable(
                name: "LessonTeacherSet");

            migrationBuilder.DropTable(
                name: "MessageSet");

            migrationBuilder.DropTable(
                name: "DaySet");

            migrationBuilder.DropTable(
                name: "GroupTimetableSet");

            migrationBuilder.DropTable(
                name: "AuditorySet");

            migrationBuilder.DropTable(
                name: "LessonSet");

            migrationBuilder.DropTable(
                name: "TeacherSet");

            migrationBuilder.DropTable(
                name: "GroupChatSet");

            migrationBuilder.DropTable(
                name: "UserSet");

            migrationBuilder.DropTable(
                name: "GroupSet");

            migrationBuilder.DropTable(
                name: "FacultySet");
        }
    }
}
