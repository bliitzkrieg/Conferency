using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using Conferency.Domain;

namespace Conferency.Data
{
    public class ConferencyContext: DbContext
    {

        public DbSet<Talk> Talks { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Conference> Conferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpeakerTalk>()
                .HasKey(s => new { s.SpeakerId, s.TalkId });

            modelBuilder.Entity<ConferenceSpeaker>()
                .HasKey(s => new { s.SpeakerId, s.ConferenceId });

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            this.timestamps();

            return base.SaveChanges();
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
            DateTime now = DateTime.Now;
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
