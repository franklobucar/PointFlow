using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PointFlow.Model.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Tasks related to acquiring new knowledge", "Learning" },
                    { 2, "Tasks related to physical health and exercise", "Fitness" },
                    { 3, "Professional and career-related tasks", "Work" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Study" },
                    { 2, "Work" },
                    { 3, "Health" },
                    { 4, "Personal" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CurrentBalance", "Email", "TotalPointsEarned", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 150, "ana@example.com", 320, "ana_k" },
                    { 2, new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, "marko@example.com", 200, "marko_p" },
                    { 3, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 260, "petra@example.com", 510, "petra_v" }
                });

            migrationBuilder.InsertData(
                table: "Rewards",
                columns: new[] { "Id", "AppUserId", "Description", "IsLocked", "Name", "PointsCost", "UnlockedAt" },
                values: new object[,]
                {
                    { 1, 1, "1 hour of guilt-free Netflix", false, "Netflix evening", 50, new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "Treat yourself to a new technical book", true, "Buy a new book", 120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, "2 hours of gaming without guilt", false, "Gaming session", 60, new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, "Short trip to the mountains", true, "Weekend trip", 300, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 3, "Full relaxation day at the spa", false, "Spa day", 200, new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 3, "Enroll in an advanced .NET course", false, "Online course", 150, new DateTime(2026, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "AppUserId", "CategoryId", "CreatedAt", "Description", "IsCompleted", "PointsReward", "Priority", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Go through chapters 1-5 of the C# guide", true, 50, 2, "Study C# fundamentals" },
                    { 2, 1, 2, new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morning run in the park", true, 30, 1, "Run 5km" },
                    { 3, 1, 1, new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "At least 30 pages per session", false, 40, 0, "Read Clean Code book" },
                    { 4, 2, 3, new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compile Q1 data and write summary", false, 60, 2, "Finish quarterly report" },
                    { 5, 2, 2, new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upper body workout", true, 25, 1, "Gym session" },
                    { 6, 3, 1, new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deep dive into object-oriented design principles", true, 70, 2, "Study SOLID principles" }
                });

            migrationBuilder.InsertData(
                table: "PointTaskTags",
                columns: new[] { "TagsId", "TasksId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 6 },
                    { 2, 4 },
                    { 3, 2 },
                    { 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "PomodoroSessions",
                columns: new[] { "Id", "DurationMinutes", "EndTime", "IsQuizPassed", "LearnedNotes", "PointTaskId", "StartTime" },
                values: new object[,]
                {
                    { 1, 25, new DateTime(2026, 3, 1, 9, 25, 0, 0, DateTimeKind.Unspecified), true, "Covered C# type system: value types vs reference types, boxing/unboxing.", 1, new DateTime(2026, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 25, new DateTime(2026, 3, 15, 10, 25, 0, 0, DateTimeKind.Unspecified), true, "Studied SOLID principles with examples in C#.", 6, new DateTime(2026, 3, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "ExpectedAnswer", "PomodoroSessionId", "Question", "UserAnswer" },
                values: new object[,]
                {
                    { 1, "A class is a reference type allocated on the heap; a struct is a value type allocated on the stack.", 1, "What is the difference between a class and a struct in C#?", "Classes are reference types, structs are value types stored on the stack." },
                    { 2, "Single responsibility, Open/closed, Liskov substitution, Interface segregation, Dependency inversion.", 2, "What does SOLID stand for?", "Single responsibility, Open/closed, Liskov substitution, Interface segregation, Dependency inversion." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PointTaskTags",
                keyColumns: new[] { "TagsId", "TasksId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PointTaskTags",
                keyColumns: new[] { "TagsId", "TasksId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "PointTaskTags",
                keyColumns: new[] { "TagsId", "TasksId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "PointTaskTags",
                keyColumns: new[] { "TagsId", "TasksId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "PointTaskTags",
                keyColumns: new[] { "TagsId", "TasksId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "PointTaskTags",
                keyColumns: new[] { "TagsId", "TasksId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PomodoroSessions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PomodoroSessions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
