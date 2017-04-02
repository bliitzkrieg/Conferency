using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Conferency.Data.Migrations
{
    public partial class AddedContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceSpeaker_Conferences_ConferenceId",
                table: "ConferenceSpeaker");

            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceSpeaker_Speakers_SpeakerId",
                table: "ConferenceSpeaker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConferenceSpeaker",
                table: "ConferenceSpeaker");

            migrationBuilder.RenameTable(
                name: "ConferenceSpeaker",
                newName: "ConferenceSpeakers");

            migrationBuilder.RenameIndex(
                name: "IX_ConferenceSpeaker_ConferenceId",
                table: "ConferenceSpeakers",
                newName: "IX_ConferenceSpeakers_ConferenceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConferenceSpeakers",
                table: "ConferenceSpeakers",
                columns: new[] { "SpeakerId", "ConferenceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceSpeakers_Conferences_ConferenceId",
                table: "ConferenceSpeakers",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceSpeakers_Speakers_SpeakerId",
                table: "ConferenceSpeakers",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceSpeakers_Conferences_ConferenceId",
                table: "ConferenceSpeakers");

            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceSpeakers_Speakers_SpeakerId",
                table: "ConferenceSpeakers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConferenceSpeakers",
                table: "ConferenceSpeakers");

            migrationBuilder.RenameTable(
                name: "ConferenceSpeakers",
                newName: "ConferenceSpeaker");

            migrationBuilder.RenameIndex(
                name: "IX_ConferenceSpeakers_ConferenceId",
                table: "ConferenceSpeaker",
                newName: "IX_ConferenceSpeaker_ConferenceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConferenceSpeaker",
                table: "ConferenceSpeaker",
                columns: new[] { "SpeakerId", "ConferenceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceSpeaker_Conferences_ConferenceId",
                table: "ConferenceSpeaker",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceSpeaker_Speakers_SpeakerId",
                table: "ConferenceSpeaker",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
