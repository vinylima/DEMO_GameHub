
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using GameHub.Domain.Core.Models;
using GameHub.Infra.Server.Data.Mapping;

namespace GameHub.Infra.Server.Data.Context
{
    public class GameHub_Context : DbContext
    {
        private IConfiguration configuration { get; set; }

        public DbSet<Friend> Friends { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Console> Consoles { get; set; }

        public GameHub_Context(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameMapping());
            modelBuilder.ApplyConfiguration(new FriendMapping());
            modelBuilder.ApplyConfiguration(new LoanMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                this.configuration.GetConnectionString("GameHub_Connection")
            );

            optionsBuilder.EnableSensitiveDataLogging(true);

            base.OnConfiguring(optionsBuilder);
        }
    }
}