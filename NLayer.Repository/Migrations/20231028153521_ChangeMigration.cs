using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 10, 28, 18, 35, 20, 946, DateTimeKind.Local).AddTicks(2147), new DateTime(2023, 10, 28, 18, 35, 20, 946, DateTimeKind.Local).AddTicks(2165) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 10, 28, 18, 35, 20, 946, DateTimeKind.Local).AddTicks(2168), new DateTime(2023, 10, 28, 18, 35, 20, 946, DateTimeKind.Local).AddTicks(2168) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 10, 28, 18, 35, 20, 946, DateTimeKind.Local).AddTicks(2405), new DateTime(2023, 10, 28, 18, 35, 20, 946, DateTimeKind.Local).AddTicks(2401) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 10, 28, 18, 35, 20, 946, DateTimeKind.Local).AddTicks(2407), new DateTime(2023, 10, 28, 18, 35, 20, 946, DateTimeKind.Local).AddTicks(2406) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 10, 28, 18, 35, 20, 946, DateTimeKind.Local).AddTicks(2409), new DateTime(2023, 10, 28, 18, 35, 20, 946, DateTimeKind.Local).AddTicks(2408) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 10, 28, 18, 29, 47, 589, DateTimeKind.Local).AddTicks(7856), new DateTime(2023, 10, 28, 18, 29, 47, 589, DateTimeKind.Local).AddTicks(7867) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 10, 28, 18, 29, 47, 589, DateTimeKind.Local).AddTicks(7873), new DateTime(2023, 10, 28, 18, 29, 47, 589, DateTimeKind.Local).AddTicks(7873) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 10, 28, 18, 29, 47, 589, DateTimeKind.Local).AddTicks(8056), new DateTime(2023, 10, 28, 18, 29, 47, 589, DateTimeKind.Local).AddTicks(8052) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 10, 28, 18, 29, 47, 589, DateTimeKind.Local).AddTicks(8059), new DateTime(2023, 10, 28, 18, 29, 47, 589, DateTimeKind.Local).AddTicks(8058) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 10, 28, 18, 29, 47, 589, DateTimeKind.Local).AddTicks(8061), new DateTime(2023, 10, 28, 18, 29, 47, 589, DateTimeKind.Local).AddTicks(8060) });
        }
    }
}
