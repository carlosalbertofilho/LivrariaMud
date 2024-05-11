using LivrariaMud.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LivrariaMud.Infrastructure.Context;

public class LivrariaMudContext
    ( DbContextOptions options ) : DbContext( options )
{
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating ( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );
        modelBuilder.ApplyConfigurationsFromAssembly( typeof( LivrariaMudContext ).Assembly );
    }
}
