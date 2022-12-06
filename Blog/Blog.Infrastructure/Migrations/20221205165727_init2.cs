using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Infrastructure.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 5, 17, 57, 27, 369, DateTimeKind.Local).AddTicks(2582), "iOS", null },
                    { 2, new DateTime(2022, 12, 5, 17, 57, 27, 369, DateTimeKind.Local).AddTicks(2595), "Android", null },
                    { 3, new DateTime(2022, 12, 5, 17, 57, 27, 369, DateTimeKind.Local).AddTicks(2598), "Trends", null },
                    { 4, new DateTime(2022, 12, 5, 17, 57, 27, 369, DateTimeKind.Local).AddTicks(2600), "innovation", null },
                    { 5, new DateTime(2022, 12, 5, 17, 57, 27, 369, DateTimeKind.Local).AddTicks(2602), "AR", null },
                    { 6, new DateTime(2022, 12, 5, 17, 57, 27, 369, DateTimeKind.Local).AddTicks(2605), "Gazzda", null }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "Id", "CreatedAt", "PostId", "TagId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 5, 17, 57, 27, 369, DateTimeKind.Local).AddTicks(1374), 1, 1, null },
                    { 2, new DateTime(2022, 12, 5, 17, 57, 27, 369, DateTimeKind.Local).AddTicks(1379), 1, 2, null },
                    { 3, new DateTime(2022, 12, 5, 17, 57, 27, 369, DateTimeKind.Local).AddTicks(1381), 1, 3, null },
                    { 4, new DateTime(2022, 12, 5, 17, 57, 27, 369, DateTimeKind.Local).AddTicks(1384), 2, 6, null },
                    { 5, new DateTime(2022, 12, 5, 17, 57, 27, 369, DateTimeKind.Local).AddTicks(1386), 2, 4, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5);

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
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6);

            
        }
    }
}
