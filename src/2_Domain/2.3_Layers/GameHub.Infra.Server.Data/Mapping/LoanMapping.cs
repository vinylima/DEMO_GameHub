
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameHub.Domain.Core.Models;

namespace GameHub.Infra.Server.Data.Mapping
{
    public class LoanMapping : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("Loans");

            builder.HasKey(l => l.LoanId);
            
            builder.HasOne(l => l.Game)
                .WithMany(g => g.Loans)
                .HasForeignKey(l => l.GameId)
                .HasConstraintName("Fk_Game_Loans");
            
            builder.HasOne(l => l.Friend)
                .WithMany(f => f.Loans)
                .HasForeignKey(l => l.FriendId)
                .HasConstraintName("FK_Friend_Loans");

            builder.Property(l => l.LoanDate)
                .IsRequired();
        }
    }
}