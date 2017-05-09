using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Conferency.Data.Migrations
{
    public partial class RemoveSpeakerAndConference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Talks_Conferences_ConferenceId",
                table: "Talks");

            migrationBuilder.DropTable(
                name: "ConferenceSpeakers");

            migrationBuilder.DropTable(
                name: "SpeakerTalks");

            migrationBuilder.DropTable(
                name: "Conferences");

            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.DropIndex(
                name: "IX_Talks_ConferenceId",
                table: "Talks");

            migrationBuilder.DropColumn(
                name: "ConferenceId",
                table: "Talks");

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagTalks",
                columns: table => new
                {
                    TalkId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagTalks", x => new { x.TalkId, x.TagId });
                    table.ForeignKey(
                        name: "FK_TagTalks_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagTalks_Talks_TalkId",
                        column: x => x.TalkId,
                        principalTable: "Talks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagTalks_TagId",
                table: "TagTalks",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagTalks");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.AddColumn<int>(
                name: "ConferenceId",
                table: "Talks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Hosted = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bio = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Github = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConferenceSpeakers",
                columns: table => new
                {
                    SpeakerId = table.Column<int>(nullable: false),
                    ConferenceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferenceSpeakers", x => new { x.SpeakerId, x.ConferenceId });
                    table.ForeignKey(
                        name: "FK_ConferenceSpeakers_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConferenceSpeakers_Speakers_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeakerTalks",
                columns: table => new
                {
                    SpeakerId = table.Column<int>(nullable: false),
                    TalkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakerTalks", x => new { x.SpeakerId, x.TalkId });
                    table.ForeignKey(
                        name: "FK_SpeakerTalks_Speakers_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpeakerTalks_Talks_TalkId",
                        column: x => x.TalkId,
                        principalTable: "Talks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Talks_ConferenceId",
                table: "Talks",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceSpeakers_ConferenceId",
                table: "ConferenceSpeakers",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakerTalks_TalkId",
                table: "SpeakerTalks",
                column: "TalkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Talks_Conferences_ConferenceId",
                table: "Talks",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
