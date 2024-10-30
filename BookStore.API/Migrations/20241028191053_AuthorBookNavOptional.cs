using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Migrations
{
    /// <inheritdoc />
    public partial class AuthorBookNavOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a080996-c520-4e3a-b4e3-98edc4dc6667",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1c24e58-45af-4021-a739-a12c6a1a4a4c", "AQAAAAIAAYagAAAAEIehHfUidE4MebHEPYwM2IV4XnM2js6dIrxUBNAFcjNstnl5a5a1Jv6B6rE2L2UP5Q==", "936f377f-827f-4f52-bdef-277825034a56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6763dde-1e30-4fe3-b1ff-9835a108a378",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5edd9029-e29e-4159-ae0b-2f3462b5c2a3", "AQAAAAIAAYagAAAAELNlhrpOgIt+xJFKkh312/n7Y0J40UY2cvXcLszoFWBnujLgkqa92HKOy/dcuQiszA==", "a7b0d65f-3d6a-4b58-8c4a-a8f8327865fb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a080996-c520-4e3a-b4e3-98edc4dc6667",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2829ba1-f8a0-4fe1-86f3-ef312d1dce4b", "AQAAAAIAAYagAAAAEFBRBqfNhMgl8uGlRge0mbRqE2iPadaMtr+TgKj/2hAa5ndDJ4fOGqtrDiNxRK3PHg==", "3a205d0f-3302-4659-ac08-fe84f4e1941d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6763dde-1e30-4fe3-b1ff-9835a108a378",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5008ef52-92c8-4f5d-816a-aa1cc8474ba4", "AQAAAAIAAYagAAAAEActRk7mgqK4auXSbOaMvV9ia3qfqxKg3nF710+eCvAfBY125+FbQItVzr7tm6b6wg==", "c5c5febe-3332-4bd2-ac55-ff9a3390428d" });
        }
    }
}
