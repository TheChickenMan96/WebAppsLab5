using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebAppsLab5.Migrations
{
    public partial class review7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "Review",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "Review",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
