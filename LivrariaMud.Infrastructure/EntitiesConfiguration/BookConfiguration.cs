using LivrariaMud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrariaMud.Infrastructure.EntitiesConfiguration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure ( EntityTypeBuilder<Book> builder )
    {
        builder.ToTable( "Book" );

        builder
            .HasKey( book => book.Id );

        builder
            .Property( book => book.Id )
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .Property( book => book.Title )
            .IsRequired()
            .HasMaxLength( 150 );

        builder
            .Property( book => book.Author )
            .IsRequired()
            .HasMaxLength( 150 );


        builder
            .Property( book => book.Cover )
            .HasMaxLength( 300 );

        builder
            .Property( book => book.Synopsis )
            .HasMaxLength( 500 );

        builder
            .Property( book => book.PublishedAt )
            .IsRequired();

        builder
            .Property( book => book.PublishingCompany )
            .IsRequired()
            .HasConversion<int>();

        builder
            .Property( book => book.Category )
            .IsRequired()
            .HasConversion<int>();
    }
}