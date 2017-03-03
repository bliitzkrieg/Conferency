using Microsoft.EntityFrameworkCore;
using Conferency.Domain;

namespace Conferency.Data
{
    public class ConferencyContext: DbContext
    {

        public DbSet<Talk> Talks { get; set; }
        public DbSet<Speaker> Speakers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        } 
    }
}
