using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMaxLengthAuthorsDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
