using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class addingproptoacct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11a00c36-245b-4936-a271-dbbd301f3e37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d7cc6f9-bbff-4f12-8b70-e8a55e3eaaf9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82a33d0c-9ed0-47e5-baab-5d1a44ed3b86");

            migrationBuilder.AddColumn<bool>(
                name: "AccountStatus",
                table: "Account",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5db799cb-4ba3-4e49-9951-19f90a7cffaf", "856b344a-ce71-418f-89d6-89cb8fc08a8c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "995aea6b-4d01-4bba-94a6-8794817f8a6c", "3ba580fa-de9d-44b2-af82-d4dd672ba47e", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49446118-a5c3-4b51-bed6-0e4d3d984eb2", "6c7c368a-b79d-4d98-b031-d5f371ec0664", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49446118-a5c3-4b51-bed6-0e4d3d984eb2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5db799cb-4ba3-4e49-9951-19f90a7cffaf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "995aea6b-4d01-4bba-94a6-8794817f8a6c");

            migrationBuilder.DropColumn(
                name: "AccountStatus",
                table: "Account");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "82a33d0c-9ed0-47e5-baab-5d1a44ed3b86", "5bed64ae-b172-4363-b32b-3680917e1bff", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "11a00c36-245b-4936-a271-dbbd301f3e37", "756815a4-0f7a-4a4c-9d3d-a06a0337c185", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6d7cc6f9-bbff-4f12-8b70-e8a55e3eaaf9", "683bcb2e-6704-4508-a734-1079766180e0", "Employee", "EMPLOYEE" });
        }
    }
}
