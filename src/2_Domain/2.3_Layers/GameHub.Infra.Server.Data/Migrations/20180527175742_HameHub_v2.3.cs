using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GameHub.Infra.Server.Data.Migrations
{
    public partial class HameHub_v23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Games",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Games",
                type: "varchar(700)",
                maxLength: 700,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 700);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Friends",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Friends",
                type: "varchar(700)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Friends",
                type: "varchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Games",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Games",
                maxLength: 700,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(700)",
                oldMaxLength: 700);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Friends",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Friends",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(700)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Friends",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true);
        }
    }
}
