using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GameHub.Infra.Server.Data.Migrations
{
    public partial class GameHub_v20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DevolutionPrevision",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "LoanDate",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Friends",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanId = table.Column<Guid>(nullable: false),
                    DevolutionPrevision = table.Column<DateTime>(nullable: false),
                    EfectiveDevolution = table.Column<DateTime>(nullable: false),
                    FriendId = table.Column<Guid>(nullable: false),
                    GameId = table.Column<Guid>(nullable: false),
                    LoanDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanId);
                    table.ForeignKey(
                        name: "FK_Friend_Loans",
                        column: x => x.FriendId,
                        principalTable: "Friends",
                        principalColumn: "FriendId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_Game_Loans",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_FriendId",
                table: "Loans",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_GameId",
                table: "Loans",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.AddColumn<DateTime>(
                name: "DevolutionPrevision",
                table: "Games",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LoanDate",
                table: "Games",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Friends",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }
    }
}
