using Library.Core.Domain.Authors.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.LibraryDb.EntityTypeConfigurations.Authors;

public class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasColumnOrder(0);

        builder.Property(a => a.FirstName)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnOrder(1);

        builder.Property(a => a.LastName)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnOrder(2);

        builder.Property(a => a.Middlename)
            .HasMaxLength(50)
            .HasColumnOrder(3);

        builder.Property(a => a.Biography)
            .HasMaxLength(500)
            .HasColumnOrder(4);

        builder.Property(a => a.ImageUrl)
            .HasMaxLength(200)
            .HasColumnOrder(5);
    }
}
