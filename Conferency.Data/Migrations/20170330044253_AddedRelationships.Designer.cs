using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Conferency.Data;

namespace Conferency.Data.Migrations
{
    [DbContext(typeof(ConferencyContext))]
    [Migration("20170330044253_AddedRelationships")]
    partial class AddedRelationships
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Conferency.Domain.Conference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("Hosted");

                    b.Property<string>("Location");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("Name");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.ToTable("Conferences");
                });

            modelBuilder.Entity("Conferency.Domain.ConferenceSpeaker", b =>
                {
                    b.Property<int>("SpeakerId");

                    b.Property<int>("ConferenceId");

                    b.HasKey("SpeakerId", "ConferenceId");

                    b.HasIndex("ConferenceId");

                    b.ToTable("ConferenceSpeaker");
                });

            modelBuilder.Entity("Conferency.Domain.Speaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bio");

                    b.Property<string>("Company");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("FullName");

                    b.Property<string>("Github");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("Photo");

                    b.Property<string>("Position");

                    b.Property<string>("Twitter");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("Conferency.Domain.SpeakerTalk", b =>
                {
                    b.Property<int>("SpeakerId");

                    b.Property<int>("TalkId");

                    b.HasKey("SpeakerId", "TalkId");

                    b.HasIndex("TalkId");

                    b.ToTable("SpeakerTalk");
                });

            modelBuilder.Entity("Conferency.Domain.Talk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConferenceId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Location");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Presented");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.ToTable("Talks");
                });

            modelBuilder.Entity("Conferency.Domain.ConferenceSpeaker", b =>
                {
                    b.HasOne("Conferency.Domain.Conference", "Conference")
                        .WithMany("ConferenceSpeakers")
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Conferency.Domain.Speaker", "Speaker")
                        .WithMany("ConferenceSpeakers")
                        .HasForeignKey("SpeakerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Conferency.Domain.SpeakerTalk", b =>
                {
                    b.HasOne("Conferency.Domain.Speaker", "Speaker")
                        .WithMany("SpeakerTalks")
                        .HasForeignKey("SpeakerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Conferency.Domain.Talk", "Talk")
                        .WithMany("SpeakerTalks")
                        .HasForeignKey("TalkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Conferency.Domain.Talk", b =>
                {
                    b.HasOne("Conferency.Domain.Conference", "Conference")
                        .WithMany("Talks")
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
