using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Conferency.Data.Migrations
{
    public partial class AddedRelationDBsetAndRemovedLocationOnTalk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerTalk_Speakers_SpeakerId",
                table: "SpeakerTalk");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerTalk_Talks_TalkId",
                table: "SpeakerTalk");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpeakerTalk",
                table: "SpeakerTalk");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Talks");

            migrationBuilder.RenameTable(
                name: "SpeakerTalk",
                newName: "SpeakerTalks");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakerTalk_TalkId",
                table: "SpeakerTalks",
                newName: "IX_SpeakerTalks_TalkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpeakerTalks",
                table: "SpeakerTalks",
                columns: new[] { "SpeakerId", "TalkId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerTalks_Speakers_SpeakerId",
                table: "SpeakerTalks",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerTalks_Talks_TalkId",
                table: "SpeakerTalks",
                column: "TalkId",
                principalTable: "Talks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerTalks_Speakers_SpeakerId",
                table: "SpeakerTalks");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerTalks_Talks_TalkId",
                table: "SpeakerTalks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpeakerTalks",
                table: "SpeakerTalks");

            migrationBuilder.RenameTable(
                name: "SpeakerTalks",
                newName: "SpeakerTalk");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakerTalks_TalkId",
                table: "SpeakerTalk",
                newName: "IX_SpeakerTalk_TalkId");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Talks",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpeakerTalk",
                table: "SpeakerTalk",
                columns: new[] { "SpeakerId", "TalkId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerTalk_Speakers_SpeakerId",
                table: "SpeakerTalk",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerTalk_Talks_TalkId",
                table: "SpeakerTalk",
                column: "TalkId",
                principalTable: "Talks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
