using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Conferency.Data;

namespace Conferency.Data.Migrations
{
    [DbContext(typeof(ConferencyContext))]
    [Migration("20170508104055_RemoveSpeakerAndConference")]
    partial class RemoveSpeakerAndConference
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Conferency.Domain.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Conferency.Domain.Talk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Presented");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Talks");
                });

            modelBuilder.Entity("Conferency.Domain.TalkTag", b =>
                {
                    b.Property<int>("TalkId");

                    b.Property<int>("TagId");

                    b.HasKey("TalkId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("TagTalks");
                });

            modelBuilder.Entity("Conferency.Domain.TalkTag", b =>
                {
                    b.HasOne("Conferency.Domain.Tag", "Tag")
                        .WithMany("TalkTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Conferency.Domain.Talk", "Talk")
                        .WithMany("TalkTags")
                        .HasForeignKey("TalkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
