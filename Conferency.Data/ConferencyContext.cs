﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using Conferency.Domain;
using System.Threading.Tasks;
using System.Threading;

namespace Conferency.Data
{
    public class ConferencyContext: DbContext
    {
        public DbSet<Talk> Talks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TalkTag> TagTalks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TalkTag>()
                .HasKey(s => new { s.TalkId, s.TagId });

            modelBuilder.Entity<TalkTag>()
                .HasOne(pt => pt.Talk)
                .WithMany(p => p.TalkTags)
                .HasForeignKey(pt => pt.TalkId);

            modelBuilder.Entity<TalkTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.TalkTags)
                .HasForeignKey(pt => pt.TagId);

            modelBuilder.Entity<Tag>().ToTable("Tag");

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            this.timestamps();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            this.timestamps();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void timestamps()
        {
            foreach (EntityEntry<IAuditable> entry in ChangeTracker.Entries<IAuditable>())
            {
                this.addTimestamps(entry);
            }
        }

        private void addTimestamps(EntityEntry<IAuditable> entry)
        {
            DateTime now = DateTime.UtcNow;
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreatedAt").CurrentValue = now;
                entry.Property("ModifiedAt").CurrentValue = now;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Property("ModifiedAt").CurrentValue = now;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=ConferencyData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        } 
    }
}
