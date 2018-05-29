
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameHub.Domain.Core.Models;

namespace GameHub.Infra.Server.Data.Mapping
{
    public class GameMapping : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Games");

            builder.HasKey(g => g.GameId);
            
            builder.Property(g => g.Title)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(g => g.ImagePath)
                .HasColumnType("varchar(700)")
                .HasMaxLength(700)
                .IsRequired();

            builder.Property(g => g.LastLoan)
                .IsRequired(false);
            
            builder.Ignore(g => g.CurrentLoan);
        }
    }
}