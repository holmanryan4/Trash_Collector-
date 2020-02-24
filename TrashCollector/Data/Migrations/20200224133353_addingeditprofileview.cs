using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class addingeditprofileview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f67f2580-b2e4-4f14-8587-574466f50b59", "6585fc45-ce98-4e9a-bacc-9cc87da41830", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d95be33-54ef-4bce-9889-f27977af2a77", "93cfb9ef-28e8-42a8-a652-ee6b57a4c8c5", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6174d1e0-d53d-44bf-adce-5cbdd478e268", "56629197-f513-4fe8-beca-9aa473e7a3a0", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d95be33-54ef-4bce-9889-f27977af2a77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6174d1e0-d53d-44bf-adce-5cbdd478e268");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f67f2580-b2e4-4f14-8587-574466f50b59");

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
    }
}
