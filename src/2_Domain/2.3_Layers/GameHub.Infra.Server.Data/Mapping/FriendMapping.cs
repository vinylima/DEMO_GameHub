
using Microsoft.EntityFrameworkCore;

using GameHub.Domain.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameHub.Infra.Server.Data.Mapping
{
    public class FriendMapping : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.ToTable("Friends");

            builder.HasKey(f => f.FriendId);
            
            builder.Property(f => f.Name)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(f => f.ImagePath)
                .HasColumnType("varchar(700)");

            builder.Property(f => f.Email)
                .HasColumnType("varchar(30)");
        }
    }
}