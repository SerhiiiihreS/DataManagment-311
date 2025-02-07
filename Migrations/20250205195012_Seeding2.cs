using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataManagment_311.Migrations
{
    /// <inheritdoc />
    public partial class Seeding2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("c2ae1d8c-da5d-4ea6-9458-e859f15f002a"));

            migrationBuilder.InsertData(
                schema: "Demo",
                table: "UserAccesses",
                columns: new[] { "Id", "Dk", "Login", "RoleId", "Salt", "UserId" },
                values: new object[,]
                {
                    { new Guid("56c47e75-db11-46c5-8e65-8427b705f50a"), "12345123", "user8", "editor", "12345", new Guid("1b6628fc-4b91-4b3b-a388-89db7c07a153") },
                    { new Guid("75217169-694b-48ff-945b-7ba42d9d2d49"), "12345123", "user7", "editor", "12345", new Guid("a1aad69c-8bb7-4119-b7fd-fb5e512f9625") },
                    { new Guid("b98990e0-667e-4eb0-9f22-86f4948c112e"), "12345123", "user6", "editor", "12345", new Guid("20f46919-d7bf-477e-919a-4aaddd7e6852") }
                });

            migrationBuilder.UpdateData(
                schema: "Demo",
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "Description",
                value: "Database administrator");

            migrationBuilder.UpdateData(
                schema: "Demo",
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "editor",
                column: "Description",
                value: "With the right to edit content");

            migrationBuilder.UpdateData(
                schema: "Demo",
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "guest",
                column: "Description",
                value: "Self-registration of koristuvach");

            migrationBuilder.UpdateData(
                schema: "Demo",
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "moderator",
                column: "Description",
                value: "With the right to block content");

            migrationBuilder.InsertData(
                schema: "Demo",
                table: "UsersData",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("1b6628fc-4b91-4b3b-a388-89db7c07a153"), "user9@i.ua", "Nikolay", "123-11-55" },
                    { new Guid("20f46919-d7bf-477e-919a-4aaddd7e6852"), "user10@i.ua", "Valentine", "234-11-55" },
                    { new Guid("6a5aa914-d6c6-4a16-b9a1-87066a76b495"), "user6@i.ua", "Stephanie", "333-11-55" },
                    { new Guid("a1aad69c-8bb7-4119-b7fd-fb5e512f9625"), "user8@i.ua", "Afanasy", "222-11-55" },
                    { new Guid("e1e681e0-3dee-41df-b67d-b5db908fa1f6"), "user7@i.ua", "Antonina", "333-11-55" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("56c47e75-db11-46c5-8e65-8427b705f50a"));

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("75217169-694b-48ff-945b-7ba42d9d2d49"));

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("b98990e0-667e-4eb0-9f22-86f4948c112e"));

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UsersData",
                keyColumn: "Id",
                keyValue: new Guid("1b6628fc-4b91-4b3b-a388-89db7c07a153"));

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UsersData",
                keyColumn: "Id",
                keyValue: new Guid("20f46919-d7bf-477e-919a-4aaddd7e6852"));

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UsersData",
                keyColumn: "Id",
                keyValue: new Guid("6a5aa914-d6c6-4a16-b9a1-87066a76b495"));

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UsersData",
                keyColumn: "Id",
                keyValue: new Guid("a1aad69c-8bb7-4119-b7fd-fb5e512f9625"));

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UsersData",
                keyColumn: "Id",
                keyValue: new Guid("e1e681e0-3dee-41df-b67d-b5db908fa1f6"));

            migrationBuilder.InsertData(
                schema: "Demo",
                table: "UserAccesses",
                columns: new[] { "Id", "Dk", "Login", "RoleId", "Salt", "UserId" },
                values: new object[] { new Guid("c2ae1d8c-da5d-4ea6-9458-e859f15f002a"), "12345123", "user5-e", "editor", "12345", new Guid("449a3602-c38b-45d8-a33b-76a88085aba2") });

            migrationBuilder.UpdateData(
                schema: "Demo",
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "Description",
                value: "Адміністратор БД");

            migrationBuilder.UpdateData(
                schema: "Demo",
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "editor",
                column: "Description",
                value: "З правом редагування контенту");

            migrationBuilder.UpdateData(
                schema: "Demo",
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "guest",
                column: "Description",
                value: "Самостійно зареєстрований користувач");

            migrationBuilder.UpdateData(
                schema: "Demo",
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "moderator",
                column: "Description",
                value: "З правом блокування контенту");
        }
    }
}
