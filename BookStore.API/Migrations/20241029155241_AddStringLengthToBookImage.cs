using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Migrations
{
    /// <inheritdoc />
    public partial class AddStringLengthToBookImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a080996-c520-4e3a-b4e3-98edc4dc6667",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf6d802f-6f0f-40f9-8a93-764917c1f33f", "AQAAAAIAAYagAAAAEOrEDyzqWJTrjheP62GyVW9x7qq4eXq/82K4+8HEvgMgc1cuF2ugaKs7Navwi5mRFQ==", "502c6f24-c7aa-43ef-a421-d36ed71122f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6763dde-1e30-4fe3-b1ff-9835a108a378",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d40097f-8309-49c1-ac63-094554c00e4b", "AQAAAAIAAYagAAAAEHnDDoVx9kLGK7wQJ1slVXJayE4D1Wn4O0rhndlRXZ6N5/+r2Q1RLISJxLedLcRf0w==", "4f001d6e-223f-4102-a6dd-29ea5bb58e8b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a080996-c520-4e3a-b4e3-98edc4dc6667",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7649adfa-46a7-4c4d-9a0b-6c8537c1e2a0", "AQAAAAIAAYagAAAAEK7ONMVCx4hKVLpme6lSZQY73TT8MY3SJDQnL61FDaQB+CoS/jsUfyOz0fxSQ0wjgA==", "16b2b75c-fdb3-4f92-9884-dbe9b3624d42" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6763dde-1e30-4fe3-b1ff-9835a108a378",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69bc5839-bc02-416d-8099-ee69c1312f21", "AQAAAAIAAYagAAAAEFGbcFKMjSzHRtRsSGlQhN1yTg7ym7BRmBn+johkenH2QQ1a2Kq12Km+imGIHRfUNg==", "7d6377d7-77a2-4038-b6d8-67f870771d9e" });
        }
    }
}
