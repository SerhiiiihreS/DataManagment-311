using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataManagment_311.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Demo",
                table: "UserAccesses",
                columns: new[] { "Id", "Dk", "Login", "RoleId", "Salt", "UserId" },
                values: new object[,]
                {
                    { new Guid("16f5bbf5-226b-4796-abe2-87e6fbcb0c76"), "12345123", "user3", "guest", "12345", new Guid("9cab7a6a-e970-44ae-8e73-58005dce3a01") },
                    { new Guid("37d22e1d-4c73-4418-99b6-7a496d00780f"), "12345123", "user4-e", "editor", "12345", new Guid("ecf36ceb-c0d5-4107-9e02-b43f8967038e") },
                    { new Guid("711f2d8f-2494-4272-a667-36886035e2c8"), "12345123", "user1-m", "moderator", "12345", new Guid("d4e7f2a5-188c-48f5-9db6-6d8999ed5e42") },
                    { new Guid("89754503-2fe6-4d63-8420-3503d6d857d6"), "12345123", "user5-a", "admin", "12345", new Guid("449a3602-c38b-45d8-a33b-76a88085aba2") },
                    { new Guid("94e352b6-f348-42f6-a35a-8fcbef2d4b47"), "12345123", "user4", "guest", "12345", new Guid("ecf36ceb-c0d5-4107-9e02-b43f8967038e") },
                    { new Guid("af04f9b1-3f7f-4705-8233-9ef271cf39ef"), "12345123", "user5", "guest", "12345", new Guid("449a3602-c38b-45d8-a33b-76a88085aba2") },
                    { new Guid("c2ae1d8c-da5d-4ea6-9458-e859f15f002a"), "12345123", "user5-e", "editor", "12345", new Guid("449a3602-c38b-45d8-a33b-76a88085aba2") },
                    { new Guid("dae2716d-610d-415d-9bf3-dd8f58ad8d95"), "12345123", "user1", "guest", "12345", new Guid("d4e7f2a5-188c-48f5-9db6-6d8999ed5e42") },
                    { new Guid("e50ad259-367f-4cb9-8f0c-d9c9a462dfe5"), "12345123", "user2", "guest", "12345", new Guid("14b16781-27be-4fb4-804e-803c5a98e986") }
                });

            migrationBuilder.InsertData(
                schema: "Demo",
                table: "UserRoles",
                columns: new[] { "Id", "CanCreate", "CanDelete", "CanRead", "CanUpdate", "Description" },
                values: new object[,]
                {
                    { "admin", 1, 1, 1, 1, "Адміністратор БД" },
                    { "editor", 0, 0, 1, 1, "З правом редагування контенту" },
                    { "guest", 0, 0, 0, 0, "Самостійно зареєстрований користувач" },
                    { "moderator", 0, 1, 1, 0, "З правом блокування контенту" }
                });

            migrationBuilder.InsertData(
                schema: "Demo",
                table: "UsersData",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("14b16781-27be-4fb4-804e-803c5a98e986"), "user2@i.ua", "user2", "555-11-22" },
                    { new Guid("449a3602-c38b-45d8-a33b-76a88085aba2"), "user5@i.ua", "user5", "555-11-55" },
                    { new Guid("9cab7a6a-e970-44ae-8e73-58005dce3a01"), "user3@i.ua", "user3", "555-11-33" },
                    { new Guid("d4e7f2a5-188c-48f5-9db6-6d8999ed5e42"), "user1@i.ua", "user1", "555-11-11" },
                    { new Guid("ecf36ceb-c0d5-4107-9e02-b43f8967038e"), "user4@i.ua", "user4", "555-11-44" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("16f5bbf5-226b-4796-abe2-87e6fbcb0c76"));

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("37d22e1d-4c73-4418-99b6-7a496d00780f"));

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("711f2d8f-2494-4272-a667-36886035e2c8"));

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("89754503-2fe6-4d63-8420-3503d6d857d6"));

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("94e352b6-f348-42f6-a35a-8fcbef2d4b47"));

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("af04f9b1-3f7f-4705-8233-9ef271cf39ef"));

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("c2ae1d8c-da5d-4ea6-9458-e859f15f002a"));

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("dae2716d-610d-415d-9bf3-dd8f58ad8d95"));

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("e50ad259-367f-4cb9-8f0c-d9c9a462dfe5"));

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "editor");

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "guest");

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "moderator");

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UsersData",
                keyColumn: "Id",
                keyValue: new Guid("14b16781-27be-4fb4-804e-803c5a98e986"));

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UsersData",
                keyColumn: "Id",
                keyValue: new Guid("449a3602-c38b-45d8-a33b-76a88085aba2"));

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UsersData",
                keyColumn: "Id",
                keyValue: new Guid("9cab7a6a-e970-44ae-8e73-58005dce3a01"));

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UsersData",
                keyColumn: "Id",
                keyValue: new Guid("d4e7f2a5-188c-48f5-9db6-6d8999ed5e42"));

            migrationBuilder.DeleteData(
                schema: "Demo",
                table: "UsersData",
                keyColumn: "Id",
                keyValue: new Guid("ecf36ceb-c0d5-4107-9e02-b43f8967038e"));
        }
    }
}
