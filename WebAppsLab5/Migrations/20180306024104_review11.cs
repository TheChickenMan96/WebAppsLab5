using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebAppsLab5.Migrations
{
    public partial class review11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieIden",
                table: "Review");

            migrationBuilder.AlterColumn<string>(
                name: "Reviewer",
                table: "Review",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Review",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieID",
                table: "Review",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_MovieID",
                table: "Review",
                column: "MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Movie_MovieID",
                table: "Review",
                column: "MovieID",
                principalTable: "Movie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Movie_MovieID",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_MovieID",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "Review");

            migrationBuilder.AlterColumn<string>(
                name: "Reviewer",
                table: "Review",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Review",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "MovieIden",
                table: "Review",
                nullable: false,
                defaultValue: 0);
        }
    }
}
