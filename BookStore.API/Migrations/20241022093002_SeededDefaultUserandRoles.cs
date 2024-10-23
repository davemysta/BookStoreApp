using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.API.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUserandRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "85dd46cd-31dd-47fb-94aa-1f15f80f35da", null, "Administrator", "ADMINISTRATOR" },
                    { "87ca7854-7ed6-4120-bbf1-2d7392fc17a2", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5a080996-c520-4e3a-b4e3-98edc4dc6667", 0, "f2829ba1-f8a0-4fe1-86f3-ef312d1dce4b", "user@bookstore.com", false, "Morty", "Smith", false, null, "USER@BOOKSTORE.COM", "JESSICA123", "AQAAAAIAAYagAAAAEFBRBqfNhMgl8uGlRge0mbRqE2iPadaMtr+TgKj/2hAa5ndDJ4fOGqtrDiNxRK3PHg==", null, false, "3a205d0f-3302-4659-ac08-fe84f4e1941d", false, "Jessica123" },
                    { "c6763dde-1e30-4fe3-b1ff-9835a108a378", 0, "5008ef52-92c8-4f5d-816a-aa1cc8474ba4", "admin@booksore.com", false, "Rick", "Sanchez", false, null, "ADMIN@BOOKSTORE.COM", "BOOGERAIDS", "AQAAAAIAAYagAAAAEActRk7mgqK4auXSbOaMvV9ia3qfqxKg3nF710+eCvAfBY125+FbQItVzr7tm6b6wg==", null, false, "c5c5febe-3332-4bd2-ac55-ff9a3390428d", false, "BoogerAids" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "87ca7854-7ed6-4120-bbf1-2d7392fc17a2", "5a080996-c520-4e3a-b4e3-98edc4dc6667" },
                    { "85dd46cd-31dd-47fb-94aa-1f15f80f35da", "c6763dde-1e30-4fe3-b1ff-9835a108a378" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "87ca7854-7ed6-4120-bbf1-2d7392fc17a2", "5a080996-c520-4e3a-b4e3-98edc4dc6667" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "85dd46cd-31dd-47fb-94aa-1f15f80f35da", "c6763dde-1e30-4fe3-b1ff-9835a108a378" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85dd46cd-31dd-47fb-94aa-1f15f80f35da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87ca7854-7ed6-4120-bbf1-2d7392fc17a2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a080996-c520-4e3a-b4e3-98edc4dc6667");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6763dde-1e30-4fe3-b1ff-9835a108a378");
        }
    }
}
