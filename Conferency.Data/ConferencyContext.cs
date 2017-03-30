using Microsoft.EntityFrameworkCore;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=ConferencyData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        } 
    }
}
