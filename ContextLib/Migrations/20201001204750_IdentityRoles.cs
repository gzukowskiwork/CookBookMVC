using Microsoft.EntityFrameworkCore.Migrations;

namespace ContextLib.Migrations
{
    public partial class IdentityRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b58e17a7-004c-4b00-b937-ce7dd21f4ccf", "ecc7f9f3-86d1-4c2d-bb9e-4c7f08cb1f71", "RegisteredUser", "REGISTEREDUSER" },
                    { "922bb005-5459-4ee3-93cf-28aea2625438", "58993b82-8007-4f06-aef9-67e4eb91b2ad", "Author", "AUTHOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "922bb005-5459-4ee3-93cf-28aea2625438");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b58e17a7-004c-4b00-b937-ce7dd21f4ccf");
        }
    }
}
