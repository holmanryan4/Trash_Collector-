using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class updatingnewrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea10a423-e367-4a5d-9ebc-a33e9fb51d82");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8501e6ed-96da-4f55-a7e3-ad8f01a5e3d5", "3b121cb4-f1b3-4310-aa1a-b7406961c323", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1a7e6ab6-811b-4c4c-9538-49865b99a622", "318a5a27-1f72-48e9-88c3-42847064a23e", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f302bd6-1848-4684-84bc-84a9ea728327", "6323e734-b368-4953-a8bf-f63d0416bda3", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a7e6ab6-811b-4c4c-9538-49865b99a622");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f302bd6-1848-4684-84bc-84a9ea728327");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8501e6ed-96da-4f55-a7e3-ad8f01a5e3d5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea10a423-e367-4a5d-9ebc-a33e9fb51d82", "e297aa4e-e26c-45eb-8ae2-d5d3b03e71fe", "Admin", "ADMIN" });
        }
    }
}
