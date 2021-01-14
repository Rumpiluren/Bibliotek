using Bibliotek.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotek.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<PublicationAuthor> BookAuthors { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Rent> Rents { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<PublicationAuthor>()
                .HasKey(sc => new { sc.PublicationId, sc.AuthorId });

            modelbuilder.Entity<PublicationAuthor>()
                .HasOne(sc => sc.Publication)
                .WithMany(s => s.PublicationAuthors)
                .HasForeignKey(sc => sc.PublicationId);

            modelbuilder.Entity<PublicationAuthor>()
                .HasOne(sc => sc.Author)
                .WithMany(s => s.PublicationAuthors)
                .HasForeignKey(sc => sc.AuthorId);
        }
    }
}
