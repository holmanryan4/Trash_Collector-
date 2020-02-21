using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class updatingmyaccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "877c83c7-60f9-4012-ac04-9c1b953a31dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d46e8e36-f4c6-4361-8b19-eb8e7db6f83c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7dcaeaa-fd23-40af-a5a8-23fdfc37af86");

            migrationBuilder.DropColumn(
                name: "Account",
                table: "Customer");

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

            migrationBuilder.CreateIndex(
                name: "IX_Customer_AccountId",
                table: "Customer",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Account_AccountId",
                table: "Customer",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Account_AccountId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_AccountId",
                table: "Customer");

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

            migrationBuilder.AddColumn<int>(
                name: "Account",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "877c83c7-60f9-4012-ac04-9c1b953a31dd", "108221ba-3a69-4566-8ad3-87e77468b7be", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7dcaeaa-fd23-40af-a5a8-23fdfc37af86", "ca8c7830-db01-4164-9d0e-a32c04edf753", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d46e8e36-f4c6-4361-8b19-eb8e7db6f83c", "28d94f12-0490-497e-b23d-d32344e09675", "Employee", "EMPLOYEE" });
        }
    }
}
