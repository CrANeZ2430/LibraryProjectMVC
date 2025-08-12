using Library.Core.Domain.Books.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.LibraryDb.EntityTypeConfigurations.Books;

public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasColumnOrder(0);

        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnOrder(1);

        builder.Property(b => b.Description)
            .HasMaxLength(500)
            .HasColumnOrder(2);

        builder.Property(b => b.Isbn)
            .HasMaxLength(20)
            .HasColumnOrder(3);

        builder.Property(b => b.PublishedDate)
            .IsRequired()
            .HasColumnOrder(4);
    }
}
