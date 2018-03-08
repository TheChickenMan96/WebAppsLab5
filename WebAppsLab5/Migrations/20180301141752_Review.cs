using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebAppsLab5.Migrations
{
    public partial class Review : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Movie_movieID",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_movieID",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "movieID",
                table: "Review",
                newName: "MovieID");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "Review",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Review",
                newName: "Reviewer");

            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "Review",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MovieTitle",
                table: "Review",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieTitle",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "Review",
                newName: "movieID");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Review",
                newName: "comment");

            migrationBuilder.RenameColumn(
                name: "Reviewer",
                table: "Review",
                newName: "name");

            migrationBuilder.AlterColumn<int>(
                name: "movieID",
                table: "Review",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Review_movieID",
                table: "Review",
                column: "movieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Movie_movieID",
                table: "Review",
                column: "movieID",
                principalTable: "Movie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
