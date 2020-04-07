using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class googlemaps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17b75b32-37b2-405e-ada8-6c3d9c29178e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3abd806f-b50c-40d4-a43b-f74b49f482b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "936d6d3c-35fb-4fe9-8d4a-0c39d5d64f49");

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Address",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "Address",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2800fca-cd51-42c8-ad88-adc8e08adc70", "0b600acc-c5df-47ff-a414-efc9bcaf56fb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1f4e7b84-811e-41d8-99d2-d3e9feb33d8e", "090a2d22-1edf-47b4-859f-a80fbed3fe20", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a0c418f7-a609-4d33-8532-2ab92c39df1d", "235a1935-d152-4159-86eb-12fcf4911de0", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f4e7b84-811e-41d8-99d2-d3e9feb33d8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0c418f7-a609-4d33-8532-2ab92c39df1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2800fca-cd51-42c8-ad88-adc8e08adc70");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Address");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "17b75b32-37b2-405e-ada8-6c3d9c29178e", "289dc0e6-ea3b-427f-80e3-493f51049f4a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3abd806f-b50c-40d4-a43b-f74b49f482b8", "0fe08175-3be7-4f1e-95ff-48b6a162131c", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "936d6d3c-35fb-4fe9-8d4a-0c39d5d64f49", "49c48c8f-1e7b-4982-b138-c28ba88516da", "Employee", "EMPLOYEE" });
        }
    }
}
