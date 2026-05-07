using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PointFlow.Model.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PointTaskTags",
                columns: new[] { "TagsId", "TasksId" },
                values: new object[,]
                {
                    { 2, 6 },
                    { 4, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: 2,
                column: "UnlockedAt",
                value: new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: 4,
                column: "UnlockedAt",
                value: new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PointTaskTags",
                keyColumns: new[] { "TagsId", "TasksId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "PointTaskTags",
                keyColumns: new[] { "TagsId", "TasksId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.UpdateData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: 2,
                column: "UnlockedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: 4,
                column: "UnlockedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
