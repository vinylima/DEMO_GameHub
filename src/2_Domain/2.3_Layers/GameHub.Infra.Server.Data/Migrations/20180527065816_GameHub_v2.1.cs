using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GameHub.Infra.Server.Data.Migrations
{
    public partial class GameHub_v21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLoan",
                table: "Games",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Games",
                maxLength: 700,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 700,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLoan",
                table: "Games",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Games",
                maxLength: 700,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 700);
        }
    }
}
