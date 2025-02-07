using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataManagment_311.Migrations
{
    /// <inheritdoc />
    public partial class Seeding1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Demo",
                table: "UsersData",
                keyColumn: "Id",
                keyValue: new Guid("14b16781-27be-4fb4-804e-803c5a98e986"),
                column: "Name",
                value: "Sergey");

            migrationBuilder.UpdateData(
                schema: "Demo",
                table: "UsersData",
                keyColumn: "Id",
                keyValue: new Guid("449a3602-c38b-45d8-a33b-76a88085aba2"),
                column: "Name",
                value: "Stepan");

            migrationBuilder.UpdateData(
                schema: "Demo",
                table: "UsersData",
                keyColumn: "Id",
                keyValue: new Guid("9cab7a6a-e970-44ae-8e73-58005dce3a01"),
                column: "Name",
                value: "Ilona");

            migrationBuilder.UpdateData(
                schema: "Demo",
                table: "UsersData",
                keyColumn: "Id",
                keyValue: new Guid("d4e7f2a5-188c-48f5-9db6-6d8999ed5e42"),
                column: "Name",
                value: "Ivan");

            migrationBuilder.UpdateData(
                schema: "Demo",
                table: "UsersData",
                keyColumn: "Id",
                keyValue: new Guid("ecf36ceb-c0d5-4107-9e02-b43f8967038e"),
                column: "Name",
                value: "Marina");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Demo",
                table: "UsersData",
                keyColumn: "Id",
                keyValue: new Guid("14b16781-27be-4fb4-804e-803c5a98e986"),
                column: "Name",
                value: "user2");

            migrationBuilder.UpdateData(
                schema: "Demo",
                table: "UsersData",
                keyColumn: "Id",
                keyValue: new Guid("449a3602-c38b-45d8-a33b-76a88085aba2"),
                column: "Name",
                value: "user5");

            migrationBuilder.UpdateData(
                schema: "Demo",
                table: "UsersData",
                keyColumn: "Id",
                keyValue: new Guid("9cab7a6a-e970-44ae-8e73-58005dce3a01"),
                column: "Name",
                value: "user3");

            migrationBuilder.UpdateData(
                schema: "Demo",
                table: "UsersData",
                keyColumn: "Id",
                keyValue: new Guid("d4e7f2a5-188c-48f5-9db6-6d8999ed5e42"),
                column: "Name",
                value: "user1");

            migrationBuilder.UpdateData(
                schema: "Demo",
                table: "UsersData",
                keyColumn: "Id",
                keyValue: new Guid("ecf36ceb-c0d5-4107-9e02-b43f8967038e"),
                column: "Name",
                value: "user4");
        }
    }
}
