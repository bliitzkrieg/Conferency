using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Conferency.Data;

namespace Conferency.Data.Migrations
{
    [DbContext(typeof(ConferencyContext))]
    [Migration("20170330040408_init")]
    partial class init
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

            modelBuilder.Entity("Conferency.Domain.Speaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bio");

                    b.Property<string>("Company");

                    b.Property<int?>("ConferenceId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("FullName");

                    b.Property<string>("Github");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("Photo");

                    b.Property<string>("Position");

                    b.Property<string>("Twitter");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("Conferency.Domain.Talk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ConferenceId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Location");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Presented");

                    b.Property<int?>("SpeakersId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.HasIndex("SpeakersId");

                    b.ToTable("Talks");
                });

            modelBuilder.Entity("Conferency.Domain.Speaker", b =>
                {
                    b.HasOne("Conferency.Domain.Conference")
                        .WithMany("Speakers")
                        .HasForeignKey("ConferenceId");
                });

            modelBuilder.Entity("Conferency.Domain.Talk", b =>
                {
                    b.HasOne("Conferency.Domain.Conference", "Conference")
                        .WithMany("Talks")
                        .HasForeignKey("ConferenceId");

                    b.HasOne("Conferency.Domain.Speaker", "Speakers")
                        .WithMany("Talks")
                        .HasForeignKey("SpeakersId");
                });
        }
    }
}
