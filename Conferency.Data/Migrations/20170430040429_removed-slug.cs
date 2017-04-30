using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Conferency.Data.Migrations
{
    public partial class removedslug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Talks");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Conferences");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Talks",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Speakers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Conferences",
                nullable: false,
                defaultValue: "");
        }
    }
}
