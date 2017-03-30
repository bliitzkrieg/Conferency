using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Conferency.Data.Migrations
{
    public partial class AddedRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speakers_Conferences_ConferenceId",
                table: "Speakers");

            migrationBuilder.DropForeignKey(
                name: "FK_Talks_Conferences_ConferenceId",
                table: "Talks");

            migrationBuilder.DropForeignKey(
                name: "FK_Talks_Speakers_SpeakersId",
                table: "Talks");

            migrationBuilder.DropIndex(
                name: "IX_Talks_SpeakersId",
                table: "Talks");

            migrationBuilder.DropIndex(
                name: "IX_Speakers_ConferenceId",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "SpeakersId",
                table: "Talks");

            migrationBuilder.DropColumn(
                name: "ConferenceId",
                table: "Speakers");

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceId",
                table: "Talks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ConferenceSpeaker",
                columns: table => new
                {
                    SpeakerId = table.Column<int>(nullable: false),
                    ConferenceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferenceSpeaker", x => new { x.SpeakerId, x.ConferenceId });
                    table.ForeignKey(
                        name: "FK_ConferenceSpeaker_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConferenceSpeaker_Speakers_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeakerTalk",
                columns: table => new
                {
                    SpeakerId = table.Column<int>(nullable: false),
                    TalkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakerTalk", x => new { x.SpeakerId, x.TalkId });
                    table.ForeignKey(
                        name: "FK_SpeakerTalk_Speakers_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpeakerTalk_Talks_TalkId",
                        column: x => x.TalkId,
                        principalTable: "Talks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceSpeaker_ConferenceId",
                table: "ConferenceSpeaker",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakerTalk_TalkId",
                table: "SpeakerTalk",
                column: "TalkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Talks_Conferences_ConferenceId",
                table: "Talks",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Talks_Conferences_ConferenceId",
                table: "Talks");

            migrationBuilder.DropTable(
                name: "ConferenceSpeaker");

            migrationBuilder.DropTable(
                name: "SpeakerTalk");

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceId",
                table: "Talks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SpeakersId",
                table: "Talks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConferenceId",
                table: "Speakers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Talks_SpeakersId",
                table: "Talks",
                column: "SpeakersId");

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_ConferenceId",
                table: "Speakers",
                column: "ConferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Speakers_Conferences_ConferenceId",
                table: "Speakers",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Talks_Conferences_ConferenceId",
                table: "Talks",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Talks_Speakers_SpeakersId",
                table: "Talks",
                column: "SpeakersId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
