using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Migrations
{
    /// <inheritdoc />
    public partial class BookModelMaxLengthIncrease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a080996-c520-4e3a-b4e3-98edc4dc6667",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca84ebce-136f-4c0c-83b2-71b4bffc91a2", "AQAAAAIAAYagAAAAEMKcL0L5ywKbTCfEFLxwYU+0AywrJ62qojcEJ1OFdVT4mkMC4P5a3ZYd3oVMZd/X4g==", "64fd5db6-dea5-46df-8856-57b6469ad6e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6763dde-1e30-4fe3-b1ff-9835a108a378",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c640f57-bdce-4763-957f-07f07185b7b5", "AQAAAAIAAYagAAAAENi1XPCT14VJe0dqqDI8VMdNSF6lygjKN0Q+XuOc73AlOOrwYARhluWZg+YgFUBUZQ==", "fbc5b145-6025-499b-a83a-dedd94a202f1" });
        }
    }
}
