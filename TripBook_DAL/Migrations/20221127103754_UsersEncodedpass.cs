using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripBook.DAL.Migrations
{
    public partial class UsersEncodedpass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("57ef6a6e-4410-4345-b8e8-45ee6162929f"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Biography", "BirthDate", "Email", "EmailConfirmed", "EncodedPassword", "Gender", "HomeCountry", "Name", "NickName", "PhotoUrl", "Salt" },
                values: new object[] { new Guid("e0ab688a-df30-47aa-b5ca-8eefeb6da9fb"), "I'm Marco Polo, I love Asia!!", new DateTime(1254, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "marcopolo@gmail.com", false, new byte[] { 54, 113, 249, 93, 172, 155, 84, 75, 83, 35, 251, 217, 201, 17, 63, 12, 21, 245, 200, 75, 96, 27, 119, 206, 90, 65, 163, 207, 66, 226, 177, 179, 237, 143, 54, 166, 185, 180, 148, 156, 146, 3, 62, 201, 232, 85, 253, 175, 118, 217, 153, 253, 98, 175, 21, 231, 233, 69, 249, 189, 184, 245, 201, 43 }, 0, "Italy", "Marco Polo", "Milione", "", new Guid("1352a6d5-a1a6-468f-a4cd-53df56e2583a") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e0ab688a-df30-47aa-b5ca-8eefeb6da9fb"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Biography", "BirthDate", "Email", "EmailConfirmed", "EncodedPassword", "Gender", "HomeCountry", "Name", "NickName", "PhotoUrl", "Salt" },
                values: new object[] { new Guid("57ef6a6e-4410-4345-b8e8-45ee6162929f"), "I'm Marco Polo, I love Asia!!", new DateTime(1254, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "marcopolo@gmail.com", false, new byte[0], 0, "Italy", "Marco Polo", "Milione", "", new Guid("00000000-0000-0000-0000-000000000000") });
        }
    }
}
